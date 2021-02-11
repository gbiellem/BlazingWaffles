using System.Net.Http;
using System.Threading.Tasks;
using BlazingWaffles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TextCopy;

        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.Services.InjectClipboard();
        builder.RootComponents.Add<App>("app");

        builder.Services.AddTransient(
            _ => new HttpClient
            {
                BaseAddress = new(builder.HostEnvironment.BaseAddress)
            });

        await builder.Build().RunAsync();