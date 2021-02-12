using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using TextCopy;
using VerifyTests.Blazor;
using VerifyXunit;
using Xunit;
using Index = BlazingWaffles.Pages.Index;

#region Tests

[UsesVerify]
public class Tests
{
    [Fact]
    public Task Component()
    {
        ServiceCollection services = new();
        services.AddSingleton<IJSRuntime>(new MockJSRuntime());
        services.InjectMockClipboard();
        using var provider = services.BuildServiceProvider();
        var target = Render.Component<Index>(
            provider,
            beforeRender: component =>
            {
                component.Waffle = "The Waffle";
                component.Sha = "TheSha";
            });
        return Verifier.Verify(target);
    }
}

#endregion