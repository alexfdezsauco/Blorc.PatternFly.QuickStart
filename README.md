# Getting started with Blorc.PatternFly

The source code of the [Getting started with Blorc.PatternFly](https://medium.com/patternfly/getting-started-with-blorc-patternfly-tutorial-cc71fed4bef6) tutorial published in the [PatternFly Medium Publication](https://medium.com/patternfly).

![](design/image.png)

# Summary of steps 

1) Create a new Blazor app with Blazor WebAssembly experience
2) Update `wwwroot/index.html` file.

        <!DOCTYPE html>
        <html>
            <head>
                <meta charset="utf-8" />
                <meta name="viewport" content="width=device-width" />
                <title>Blorc.PatternFly.QuickStart</title>
                <base href="/" />
                <script src="_content/Blorc.Core/injector.js"></script>
                <link href="css/site.css" rel="stylesheet" />
            </head>
            <body>
                <app>Loading...</app>
                <script src="_framework/blazor.webassembly.js"></script>
            </body>
        </html>

3) Update `Program.cs` file.

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
                    
                    builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

                    await builder.Build().MapComponentServices(options => options.MapBlorcPatternFly()).RunAsync();
                }
            }
        }

4) Update `App.razor` file.

        @using Blorc.PatternFly.Services.Extensions
        @using Blorc.Services

        @inherits Blorc.Components.BlorcApplicationBase

        @if (Initialized)
        {
            <Router AppAssembly="@typeof(Program).Assembly">
                <Found Context="routeData">
                    <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
                </Found>
                <NotFound>
                    <LayoutView Layout="@typeof(MainLayout)">
                        <p>Sorry, there's nothing at this address.</p>
                    </LayoutView>
                </NotFound>
            </Router>
        }

        @code
        {
            protected override async Task OnConfiguringDocumentAsync(IDocumentService documentService)
            {
                await documentService.InjectBlorcPatternFly();
            }
        }

5) Update Shared\MainLayout.razor file.

        @using Blorc.PatternFly.Layouts
        @using Blorc.PatternFly.Components.Page
        @using Blorc.PatternFly.Components.Button

        @inherits Blorc.Components.BlorcLayoutComponentBase

        <Page>
            <LogoContent>
                Blorc.PatternFly.QuickStart
            </LogoContent>
            <ToolbarContent>
                <Button Component="a" Variant="ButtonVariant.Primary" Href="http://blazor.net">
                    About
                </Button>
            </ToolbarContent>
            <SidebarContent>
                <NavMenu />
            </SidebarContent>
            <MainContent>
                @Body
            </MainContent>
        </Page>
        
6) Start using PatternFly components. For instance in the `Shared\NavMenu.razor`.

        @using Blorc.PatternFly.Components.Navigation
        @using Blorc.PatternFly.Components.Icon
        @using Blorc.PatternFly.Layouts.Split

        <Navigation>
            <Items>
                <NavigationItem Link="/">
                    <Split IsGutter="true">
                        <SplitItem><HomeIcon /></SplitItem>
                        <SplitItem>Home</SplitItem>
                    </Split>
                </NavigationItem>
                <NavigationItem Link="/counter">
                    <Split IsGutter="true">
                        <SplitItem><PlusIcon /></SplitItem>
                        <SplitItem>Counter</SplitItem>
                    </Split>
                </NavigationItem>
                <NavigationItem Link="/fetchdata">
                    <Split IsGutter="true">
                        <SplitItem><ListIcon /></SplitItem>
                        <SplitItem>Fetch data</SplitItem>
                    </Split>
                </NavigationItem>
            </Items>
        </Navigation>
