using System.Threading.Tasks;
using BlazingWaffles;
using Microsoft.AspNetCore.Blazor.Hosting;

public class Program
{
    public static Task Main()
    {
        var builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<App>("app");

        return builder.Build().RunAsync();
    }
}