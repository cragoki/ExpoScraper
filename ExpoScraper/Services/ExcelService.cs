using ExpoScraper.Models.Local;
using ExpoScraper.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpoScraper.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExcelService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void WriteToExcelSheet(Excel product)
        {
            try
            {
                string rootFolder = _hostingEnvironment.WebRootPath;
                string fileName = @"ExpoProducts.xlsx";

                FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

                //create a new Excel package from the file
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    //create an instance of the the first sheet in the loaded file
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    var row = worksheet.Dimension.End.Row + 1;
                    //add some data
                    worksheet.Cells[row, 1].Value = product.handleId;
                    worksheet.Cells[row, 2].Value = product.fieldType;
                    worksheet.Cells[row, 3].Value = RemoveSpecialCharacters(product.name) ?? "";
                    worksheet.Cells[row, 4].Value = product.description;
                    worksheet.Cells[row, 5].Value = product.productImageUrl;
                    worksheet.Cells[row, 6].Value = product.collection;
                    worksheet.Cells[row, 7].Value = product.sku;
                    worksheet.Cells[row, 8].Value = product.ribbon;
                    worksheet.Cells[row, 9].Value = product.price;
                    worksheet.Cells[row, 10].Value = product.surcharge;
                    worksheet.Cells[row, 11].Value = product.visible;
                    worksheet.Cells[row, 12].Value = product.discountMode;
                    worksheet.Cells[row, 13].Value = product.discountValue;
                    worksheet.Cells[row, 12].Value = product.inventory;
                    worksheet.Cells[row, 15].Value = product.weight;
                    worksheet.Cells[row, 16].Value = product.productOptionName1;
                    worksheet.Cells[row, 17].Value = product.productOptionType1;
                    worksheet.Cells[row, 18].Value = product.productOptionDescription1;
                    worksheet.Cells[row, 19].Value = product.productOptionName2;
                    worksheet.Cells[row, 20].Value = product.productOptionType2;
                    worksheet.Cells[row, 21].Value = product.productOptionDescription2;
                    worksheet.Cells[row, 22].Value = product.productOptionName3;
                    worksheet.Cells[row, 23].Value = product.productOptionType3;
                    worksheet.Cells[row, 24].Value = product.productOptionDescription3;
                    worksheet.Cells[row, 25].Value = product.productOptionName4;
                    worksheet.Cells[row, 26].Value = product.productOptionType4;
                    worksheet.Cells[row, 27].Value = product.productOptionDescription4;
                    worksheet.Cells[row, 28].Value = product.productOptionName5;
                    worksheet.Cells[row, 29].Value = product.productOptionType5;
                    worksheet.Cells[row, 30].Value = product.productOptionDescription5;
                    worksheet.Cells[row, 31].Value = product.productOptionName6;
                    worksheet.Cells[row, 32].Value = product.productOptionType6;
                    worksheet.Cells[row, 33].Value = product.productOptionDescription6;
                    worksheet.Cells[row, 34].Value = product.additionalInfoTitle1;
                    worksheet.Cells[row, 35].Value = product.additionalInfoDescription1;
                    worksheet.Cells[row, 36].Value = product.additionalInfoTitle2;
                    worksheet.Cells[row, 37].Value = product.additionalInfoDescription2;
                    worksheet.Cells[row, 38].Value = product.additionalInfoTitle3;
                    worksheet.Cells[row, 39].Value = product.additionalInfoDescription3;
                    worksheet.Cells[row, 40].Value = product.additionalInfoTitle4;
                    worksheet.Cells[row, 41].Value = product.additionalInfoDescription4;
                    worksheet.Cells[row, 42].Value = product.additionalInfoTitle5;
                    worksheet.Cells[row, 43].Value = product.additionalInfoDescription5;
                    worksheet.Cells[row, 44].Value = product.additionalInfoTitle6;
                    worksheet.Cells[row, 45].Value = product.additionalInfoDescription6;
                    worksheet.Cells[row, 46].Value = product.customTextField1;
                    worksheet.Cells[row, 47].Value = product.customTextCharLimit1;
                    worksheet.Cells[row, 48].Value = product.customTextMandatory1;

                    //save the changes
                    excelPackage.Save();
                }
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetCompletedImageNames() 
        {
            var result = new List<string>();

            try
            {
                int row = 0;
                string rootFolder = _hostingEnvironment.WebRootPath;
                string fileName = @"Completed.xlsx";

                FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

                //create a new Excel package from the file
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    if (worksheet.Dimension != null)
                    {
                        row = worksheet.Dimension.End.Row;
                    }

                    if (row == 0)
                    {
                        return result;
                    }

                    for (int i = 1; i <= row; i++)
                    {
                        var newRow = worksheet.Cells[i, 1];

                        if (newRow.Value != null)
                        {
                            result.Add(newRow.Value.ToString());
                        }
                    }
                }

            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }

            return result;
        }

        public void CompleteImage(string imageName) 
        {
            try
            {
                string rootFolder = _hostingEnvironment.WebRootPath;
                string fileName = @"Completed.xlsx";
                FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

                //create a new Excel package from the file
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    int row = 1;

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    if (worksheet.Dimension != null)
                    {
                        row = worksheet.Dimension.End.Row + 1;
                    }

                    worksheet.Cells[row, 1].Value = imageName;
                    excelPackage.Save();

                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }

        private string RemoveSpecialCharacters(string str)
        {
            string result = "";

            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in str)
                {
                    if (c == ' ')
                    {
                        sb.Append(c);
                    }
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                    {
                        sb.Append(c);
                    }
                }

                result = sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }



    }
    
}

