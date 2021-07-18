using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Models.Local
{
    public class AmazonToExcel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Collection { get; set; }
        public string StockKeepingUnit { get; set; }
        public string Ribbon { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string? InfoName { get; set; }
        public string? InfoDescription { get; set; }

    }
}
