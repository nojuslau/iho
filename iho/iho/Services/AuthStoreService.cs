using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace iho.Services
{
    public class AuthStoreService : IAuthStoreService
    {
        private readonly ILogger<AuthStoreService> _logger;

        public AuthStoreService(ILogger<AuthStoreService> logger)
        {
            _logger= logger;
        }

        public async Task<string> ReceiveToken(string key)
        {
            try
            {
                // Retrieve the access token
                var accessToken = await SecureStorage.GetAsync(key);
                _logger.LogInformation("succeful received token from storage");
                return accessToken;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(string.Empty).ConfigureAwait(false);
            }
            
        }

        public async Task<bool> StoreToken(string key, string token)
        {
            try
            {
                // Store the access token
                await SecureStorage.SetAsync(key, token);
                _logger.LogInformation("succeful stored token");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
