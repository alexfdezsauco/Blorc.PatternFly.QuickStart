namespace Blorc.PatternFly.QuickStart
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Blorc.PatternFly.Services.Extensions;
    using Blorc.Services;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlorcCore();
            builder.Services.AddBlorcPatternFly();

            builder.Services.AddTransient(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().MapComponentServices(options => options.MapBlorcPatternFly()).RunAsync();
        }
    }
}