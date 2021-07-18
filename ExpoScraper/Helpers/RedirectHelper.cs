using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExpoScraper.Helpers
{
    public class RedirectHelper
    {
        public static async Task<string> GetFinalRedirect(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                    return url;

                //We want to follow the url to reach the final endpoint
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseUri = response.RequestMessage.RequestUri.ToString();

                return responseUri;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
