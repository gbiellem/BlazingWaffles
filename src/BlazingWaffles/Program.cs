using BlazingWaffles;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TextCopy;

var builder = WebAssemblyHostBuilder.CreateDefault();
builder.Services.InjectClipboard();
builder.RootComponents.Add<App>("app");
await builder.Build().RunAsync();