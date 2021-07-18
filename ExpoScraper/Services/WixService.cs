using ExpoScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpoScraper.Services.Interface;
using System.Net.Http;

namespace ExpoScraper.Services
{
    public class WixService : IWixService
    {
        static HttpClient client = new HttpClient();
        private readonly IConfigurationService _configurationService;


        public WixService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<bool> SendProductToWix(WixProductModel model)
        {
            bool result = false;
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://www.wixapis.com/stores/v1/products", model);

                if (response.IsSuccessStatusCode)
                {
                    result = true;
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
