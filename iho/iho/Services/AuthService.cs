using iho.Constants;
using iho.Models.Requests;
using iho.Models.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iho.Services
{
    public interface IAuthService
    {
        Task<bool> Authenticate(AuthRequest requestModel);
    }

    public class AuthService : IAuthService 
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthStoreService _authStore;
        private readonly ILogger<AuthService> _logger;

        public AuthService(HttpClient httpClient, IAuthStoreService authStore, ILogger<AuthService> logger)
        {
            _httpClient = httpClient;
            _authStore = authStore;
            _logger = logger;
        }

        public async Task<bool> Authenticate(AuthRequest requestModel)
        {
            try
            {
                var request = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
                //request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer your_access_token");
                var response = await _httpClient.PostAsync(HttpRequestConstants.AuthentitcateEndpoint, request);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var authResponse = JsonConvert.DeserializeObject<AuthResponse>(responseBody);
                    // Handle successful response
                    await _authStore.StoreToken(StorageConstants.accessTokenKey, authResponse.AccessToken);
                    await _authStore.StoreToken(StorageConstants.refreshTokenKey, authResponse.RefreshToken);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle error response
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
