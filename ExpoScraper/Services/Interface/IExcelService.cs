using ExpoScraper.Models.Local;
using System.Collections.Generic;

namespace ExpoScraper.Services.Interface
{
    public interface IExcelService
    {
        void WriteToExcelSheet(Excel product);
        List<string> GetCompletedImageNames();
        void CompleteImage(string imageName);
    }
}