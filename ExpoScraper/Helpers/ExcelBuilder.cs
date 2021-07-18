using ExpoScraper.Models.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Helpers
{
    public class ExcelBuilder
    {

        public static Excel BuildExcelInput(AmazonToExcel model) 
        {
            return new Excel()
            {
                handleId = model.ProductId,
                fieldType = "Product",
                name = model.Name,
                description = model.Description,
                productImageUrl = model.ImageUrl,
                collection = model.Collection,
                sku = model.StockKeepingUnit,
                ribbon = model.Ribbon,
                price = model.Price,
                surcharge = 0,
                visible = true,
                discountMode = "Amount",
                discountValue = 0,
                inventory = 0,
                weight = model.Weight,
                productOptionName1 = "",
                productOptionType1 = "",
                productOptionDescription1 = "",
                productOptionName2 = "",
                productOptionType2 = "",
                productOptionDescription2 = "",
                productOptionName3 = "",
                productOptionType3 = "",
                productOptionDescription3 = "",
                productOptionName4 = "",
                productOptionType4 = "",
                productOptionDescription4 = "",
                productOptionName5 = "",
                productOptionType5 = "",
                productOptionDescription5 = "",
                productOptionName6 = "",
                productOptionType6 = "",
                productOptionDescription6 = "",
                additionalInfoTitle1 = model.InfoName,
                additionalInfoDescription1 = model.InfoDescription,
                additionalInfoTitle2 = "",
                additionalInfoDescription2 = "",
                additionalInfoTitle3 = "",
                additionalInfoDescription3 = "",
                additionalInfoTitle4 = "",
                additionalInfoDescription4 = "",
                additionalInfoTitle5 = "",
                additionalInfoDescription5 = "",
                additionalInfoTitle6 = "",
                additionalInfoDescription6 = "",
                customTextField1 = "C",
                customTextCharLimit1 = 2,
                customTextMandatory1 = false
            };
        }
    }
}
