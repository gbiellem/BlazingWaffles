using Microsoft.AspNetCore.Blazor.Hosting;

namespace BlazingWaffles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder() =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
