using System.Threading.Tasks;

namespace iho.Services
{
    public interface IAuthStoreService
    {
        Task<bool> StoreToken(string key, string token);
        Task<string> ReceiveToken(string key);
    }
}