using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazingWaffles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TextCopy;

public class Program
{
    public static Task Main()
    {
        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.Services.InjectClipboard();
        builder.RootComponents.Add<App>("app");

        builder.Services.AddTransient(
            provider => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

        return builder.Build().RunAsync();
    }
}