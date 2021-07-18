using ExpoScraper.Services.Interface;
using ExpoScraper.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _config;

        public ConfigurationService(IConfiguration config)
        {
            _config = config;
        }

        public AmazonSettings GetAmazonSettings()
        {
            var result = new AmazonSettings();

            try 
            {
                result = new AmazonSettings()
                {
                    BaseUrl = _config.GetValue<string>("AmazonSettings:BaseUrl"),
                    SearchUrl = _config.GetValue<string>("AmazonSettings:SearchUrl")
                };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public WixSettings GetWixSettings()
        {
            var result = new WixSettings();

            try
            {
                result = new WixSettings()
                {
                    BaseUrl = _config.GetValue<string>("WixSettings:BaseUrl"),
                    AuthenticationToken = _config.GetValue<string>("WixSettings:AuthenticationToken")
                };
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
