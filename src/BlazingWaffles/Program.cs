using System.Threading.Tasks;
using BlazingWaffles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TextCopy;

class Program
{
    static async Task Main()
    {
        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.Services.InjectClipboard();
        builder.RootComponents.Add<App>("app");
        await builder.Build().RunAsync();
    }
}