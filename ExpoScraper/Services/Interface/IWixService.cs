using ExpoScraper.Models;
using System.Threading.Tasks;

namespace ExpoScraper.Services.Interface
{
    public interface IWixService
    {
        Task<bool> SendProductToWix(WixProductModel model);
    }
}