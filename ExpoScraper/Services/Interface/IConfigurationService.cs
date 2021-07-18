using ExpoScraper.Settings;

namespace ExpoScraper.Services.Interface
{
    public interface IConfigurationService
    {
        AmazonSettings GetAmazonSettings();
        WixSettings GetWixSettings();
    }
}