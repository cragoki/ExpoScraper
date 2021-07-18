using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Models
{
    public class ConfirmProductModel
    {
        public List<AmazonProductModel> amazonProductModel { get; set; }
        public string OriginalImage { get; set; }

        public string customURL { get; set; }

    }
}
