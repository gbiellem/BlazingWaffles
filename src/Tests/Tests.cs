using System.Threading.Tasks;
using BlazingWaffles.Pages;
using Verify;
using VerifyBunit;
using Xunit;
using Xunit.Abstractions;

public class Tests :
    VerifyBase
{
    [Fact]
    public Task Component()
    {
        var component = RenderComponent<Index>();
        component.Instance.Waffle = "The Waffle";
        var verifySettings = new VerifySettings();
        verifySettings.ModifySerialization(_ => { _.IgnoreMember("Sha"); });
        return Verify(component, verifySettings);
    }

    public Tests(ITestOutputHelper output) :
        base(output)
    {
    }
}