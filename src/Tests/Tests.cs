using System.Threading;
using System.Threading.Tasks;
using BlazingWaffles.Pages;
using Bunit.Mocking.JSInterop;
using TextCopy;
using VerifyBunit;
using Xunit;
using Xunit.Abstractions;

public class Tests :
    VerifyBase
{
    [Fact]
    public Task Component()
    {
        Services.AddMockJsRuntime();
        Services.InjectMockClipboard();
        var component = RenderComponent<Index>();
        var instance = component.Instance;
        instance.Waffle = "The Waffle";
        instance.Sha = "TheSha";
        component.Render();
        return Verify(component);
    }

    public Tests(ITestOutputHelper output) :
        base(output)
    {
    }
}