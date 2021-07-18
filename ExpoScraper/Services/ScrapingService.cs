using ExpoScraper.Enums;
using ExpoScraper.Models;
using ExpoScraper.Models.Wix;
using ExpoScraper.Services.Interface;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpoScraper.Services
{
    public class ScrapingService : IScrapingService
    {
        private List<AmazonProductModel> _amazonProductDictionary;
        private readonly IConfigurationService _configurationService;

        public ScrapingService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
            _amazonProductDictionary = new List<AmazonProductModel>();
        }

        public List<AmazonProductModel> ParseAmazonProductList(string html)
        {
            try
            {
                var amazonSettings = _configurationService.GetAmazonSettings();

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                //Get all links on search result page
                var filterResults = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 's-result-item')]");

                foreach (HtmlNode amazonResult in filterResults)
                {
                    var productDiv = amazonResult.SelectSingleNode("//a[contains(@class, 'a-link-normal s-no-outline')]");

                    //InnerHTML.alt
                    var productName = amazonResult.SelectSingleNode("//span[contains(@class, 'a-size-base-plus a-color-base a-text-normal')]").InnerText;
                    var productsrc = amazonResult.SelectSingleNode("//img[contains(@class, 's-image')]").GetAttributeValue("src", "Undefined").ToString();
                    var url = productDiv.GetAttributeValue("href", "Undefined").ToString();

                    //BaseURl + OuterHTML.href
                    url = amazonSettings.BaseUrl + url;
                    //Add to result list if it doesnt exist
                    if (!_amazonProductDictionary.Any(x => x.ProductName == productName))
                    {
                        var item = new AmazonProductModel()
                        {
                            ProductName = productName,
                            Url = url,
                            ImageSrc = productsrc
                        };

                        _amazonProductDictionary.Add(item);
                    }
                    url = "";
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return _amazonProductDictionary;
        }

        public WixProductModel ParseWixProduct(string html)
        {
            var result = new WixProductModel();

            try
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                if (htmlDoc != null)
                {
                    result = new WixProductModel()
                    {
                        name = GetProductName(htmlDoc),
                        imageUrl = GetImageUrl(htmlDoc),
                        description = GetProductDescription(htmlDoc),
                        weight = new decimal(),
                        priceData = GetProductPrice(htmlDoc),
                        managevariants = false,
                        productType = ProductType.physical,
                        sku = "",
                        visible = true
                    };
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


        private string GetProductName(HtmlDocument htmlDoc) 
        {
            var result = "";

            try
            {
                var titleSection = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'titleSection')]");

                var productName = titleSection.SelectSingleNode("//span[contains(@id, 'productTitle')]");

                result = Regex.Replace(productName.InnerText, @"\s+", " ").Trim();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return result;

        }
        private string GetImageUrl(HtmlDocument htmlDoc)
        {
            var result = "";

            try
            {
                var imageContainer = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'altImage')]//ul//li[contains(@class, 'a-spacing-small item')]//img/@src");

                var url = imageContainer.GetAttributeValue("src", "Undefined").ToString();

                //We need to do the following to get a larger version of the base image
                result = url.Replace("US40", "SX569");
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        private string GetProductDescription(HtmlDocument htmlDoc)
        {
            var result = "";

            try
            {
                var descriptionSection = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'feature-bullets')]");

                var descriptionBullets = descriptionSection.SelectSingleNode("//ul[contains(@class, 'a-unordered-list a-vertical a-spacing-mini')]");

                //Potentially could replace the /n/n's with HTML syntax if this works with the Wix API, for example <li></li> instead
                if (descriptionBullets == null)
                {
                    return result;
                }

                result = Regex.Replace(descriptionBullets.InnerText, @"\s+", " ").Trim();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        private PriceData GetProductPrice(HtmlDocument htmlDoc)
        {
            var result = new PriceData();

            try
            {
                decimal priceToDecimal = 0;

                var priceSection = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@id, 'unifiedPrice_feature_div')]");

                var price = priceSection.SelectSingleNode("//span[contains(@id, 'priceblock_ourprice')]");

                if (price == null)
                {
                    price = priceSection.SelectSingleNode("//span[contains(@id, 'priceblock_pospromoprice')]");
                }

                //Remove Euro Character, replace comma with decimal and any spaces
                if (price != null)
                {
                    var priceDecimal = price.InnerText.Replace("€", "");

                    priceDecimal = priceDecimal.Replace(",", ".");
                    priceDecimal = priceDecimal.Replace(" ", "");

                    if (decimal.TryParse(priceDecimal, out priceToDecimal))
                    {
                        result = new PriceData()
                        {
                            price = priceToDecimal
                        };
                    }
                }
                else
                {
                    result = new PriceData()
                    {
                        price = priceToDecimal
                    };
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
