using System;
using System.Net.Http;
using iho.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace iho.Services
{
    public static class HttpClientService
    {
        public static void AddHttpClientService(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>(sp =>
            {
                var httpClientHandler = new HttpClientHandler();
                // Add any customizations to httpClientHandler, such as setting SSL/TLS certificate validation

                return new HttpClient(httpClientHandler)
                {
                    BaseAddress = new Uri(HttpRequestConstants.BaseApiAddress)
                };
            });
        }
    }
}