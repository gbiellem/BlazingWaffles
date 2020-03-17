using System.Threading.Tasks;
using BlazingWaffles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static Task Main()
    {
        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<App>("app");
        builder.Services.AddBaseAddressHttpClient();
        return builder.Build().RunAsync();
    }
}