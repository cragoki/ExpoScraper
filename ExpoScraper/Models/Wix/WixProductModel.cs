using ExpoScraper.Enums;
using ExpoScraper.Models.Wix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Models
{
    public class WixProductModel
    {
        public string name { get; set; }
        public string imageUrl { get; set; }

        public string existingImage { get; set; }
        //Whether the product is visible to site visitors.
        public bool visible { get; set; }
        
        public ProductType productType { get; set; }
        
        public string description { get; set; }

        public string category { get; set; }
        public string ribbon { get; set; }
        public PriceData priceData { get; set; }

        //Stock keeping unit (if variant management is enabled, SKUs will be set per variant, and this field will be empty).
        public string sku { get; set; }
        public string customname { get; set; }
        public string customdesc { get; set; }
        public decimal weight { get; set; }

        public bool managevariants { get; set; }
    }
}
