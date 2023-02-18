using iho.Services;
using Microsoft.Extensions.DependencyInjection;

namespace iho
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the HttpClient service
            services.AddHttpClientService();
        }
    }
}
