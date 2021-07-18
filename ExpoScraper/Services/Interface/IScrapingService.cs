using ExpoScraper.Models;
using System.Collections.Generic;

namespace ExpoScraper.Services.Interface
{
    public interface IScrapingService
    {
        List<AmazonProductModel> ParseAmazonProductList(string html);

        WixProductModel ParseWixProduct(string html);
    }
}