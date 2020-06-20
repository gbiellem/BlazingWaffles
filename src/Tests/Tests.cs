using System.Threading.Tasks;
using BlazingWaffles.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using TextCopy;
using VerifyTests.Blazor;
using VerifyXunit;
using Xunit;

#region Tests

[UsesVerify]
public class Tests
{
    [Fact]
    public Task Component()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IJSRuntime>(new MockJSRuntime());
        services.InjectMockClipboard();
        var provider = services.BuildServiceProvider();
        var target = Render.Component<Index>(provider,
            beforeRender: component =>
            {
                component.Waffle = "The Waffle";
                component.Sha = "TheSha";
            });
        return Verifier.Verify(target);
    }
}

#endregion