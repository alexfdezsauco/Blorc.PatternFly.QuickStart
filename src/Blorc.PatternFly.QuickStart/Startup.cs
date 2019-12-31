using Blorc.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blorc.PatternFly.QuickStart
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlorcCore();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
