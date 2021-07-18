using ExpoScraper.Helpers;
using ExpoScraper.Models;
using ExpoScraper.Models.Local;
using ExpoScraper.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ExpoScraper.Controllers
{
    public class HomeController : Controller
    {
        private List<AmazonProductModel> _amazonProductDictionary;
        private readonly IConfigurationService _configurationService;
        private readonly IScrapingService _scrapingService;
        private readonly IExcelService _excelService;
        private static string _imageName;
        private static string _imagePath;

        public static string _imageFolder = @"C:\Users\Craig\Desktop\Craig\CSharp\ExpoScraper\ExpoScraper\wwwroot\img\";

        public HomeController(ILogger<HomeController> logger, IConfigurationService configurationService, IScrapingService scrapingService, IExcelService excelService)
        {
            _configurationService = configurationService;
            _scrapingService = scrapingService;
            _excelService = excelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var completedImages = _excelService.GetCompletedImageNames();
            var model = new List<ImageNameModel>();
            var imageNames = new List<ImageNameModel>();

            var jpgFiles = GetFileNamesByExtension("*.png");
            var pngFiles = GetFileNamesByExtension("*.jpg");

            if (jpgFiles != null) 
            {
                imageNames.AddRange(jpgFiles);
            }

            if (pngFiles != null) 
            {
                imageNames.AddRange(pngFiles);
            }

            if (completedImages != null || completedImages.Count > 0)
            {
                foreach (var image in imageNames)
                {
                    var match = completedImages.FirstOrDefault(stringToCheck => stringToCheck.Contains(image.ImageName));

                    if (match == null)
                    {
                        var add = new ImageNameModel()
                        {
                            ImageName = image.ImageName,
                            ImagePath = image.ImagePath
                        };

                        model.Add(add);
                    }
                }
            }
            else 
            {
                model.AddRange(imageNames);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmProduct(string searchTerm, string imagePath)
        {
            var response = "";

            _imageName = searchTerm;
            _imagePath = imagePath;

            var amazonSettings = _configurationService.GetAmazonSettings();

            if (string.IsNullOrEmpty(amazonSettings.SearchUrl)) 
            {
                 response = await CallUrl(amazonSettings.SearchUrl + searchTerm);

                //Get the results to display to user, which product is most accurate? Then the next step
                _amazonProductDictionary = _scrapingService.ParseAmazonProductList(response);
            }

            var model = new ConfirmProductModel()
            {
                amazonProductModel = _amazonProductDictionary,
                OriginalImage = _imagePath
            };

            return View(model);
        }

        public async Task<IActionResult> CreateWixProduct(string urlToSearch) 
        {
            var model = new WixProductModel();

            if (!string.IsNullOrEmpty(urlToSearch)) 
            {
            
                var decodedUrl = HttpUtility.UrlDecode(urlToSearch);

                decodedUrl = FormatAmazonString(decodedUrl, "es", "url=");

                try
                {
                    decodedUrl = decodedUrl.Remove(decodedUrl.IndexOf("url="), 4);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                //Get the amazon page content via url
                var html = await CallUrl(decodedUrl);

                //Build model to send to wix
                model = _scrapingService.ParseWixProduct(html);
            }

            model.existingImage = _imagePath;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> GenerateExcel(WixProductModel productModel)
        {
            //TODO update productid to the highest existing product id ++
            var build = new AmazonToExcel()
            {
                ProductId = "1",
                Name = productModel.name,
                Description = productModel.description,
                ImageUrl = productModel.imageUrl,
                Collection = productModel.category,
                StockKeepingUnit = productModel.sku,
                Ribbon = productModel.ribbon,
                Price = productModel.priceData.price,
                Weight = productModel.weight,
                InfoName = productModel.customname,
                InfoDescription = productModel.customdesc
            };

            var model = ExcelBuilder.BuildExcelInput(build);

            _excelService.WriteToExcelSheet(model);
            _excelService.CompleteImage(_imageName);

            return RedirectToAction("Index");
        }

        private string FormatAmazonString(string original, string firstTag, string secondTag)
        {
            string pattern = firstTag + "(.*?)" + secondTag;
            Regex regex = new Regex(pattern, RegexOptions.RightToLeft);

            foreach (Match match in regex.Matches(original))
            {
                original = original.Replace(match.Groups[1].Value, string.Empty);
            }

            return original;
        }

        private List<ImageNameModel> GetFileNamesByExtension(string extension) 
        {
            var result = new List<ImageNameModel>();

            DirectoryInfo d = new DirectoryInfo(_imageFolder);

            FileInfo[] files = d.GetFiles(extension, SearchOption.AllDirectories); //Getting Text files

            foreach (FileInfo file in files)
            {
                var dir = file.DirectoryName + "\\" + file.Name;
                var dirPrefix = dir.Substring(dir.LastIndexOf("\\img")).Replace("\\", "/");
                var fileToAdd = new ImageNameModel()
                {
                    ImageName = file.Name.Substring(0, file.Name.Length - 4),
                    ImagePath = dirPrefix
                };

                //Check if file is already there
                if (!result.Any(x => x.ImageName == fileToAdd.ImageName)) 
                {
                    result.Add(fileToAdd);
                }
            }

            return result;
        }

        private async Task<string> CallUrl(string fullUrl)
        {
            try
            {
                //Get the HTML from a specific page
                var handler = new HttpClientHandler()
                {
                    AllowAutoRedirect = false
                };

                HttpClient client = new HttpClient(handler);

                //If you get HTTPS handshake errors, it’s likely because you are not using the right cryptographic library.
                ////The below statement forces the connection to use the TLS 1.3 library so that an HTTPS handshake can be established.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = await client.GetStringAsync(fullUrl);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
