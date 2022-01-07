using System.Threading.Tasks;
using Microsoft.Playwright;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class PlaywrightTest :
    IClassFixture<PlaywrightFixture>
{
    IBrowser browser;

    public PlaywrightTest(PlaywrightFixture fixture)
    {
        browser = fixture.Browser;
    }

    [Fact]
    public async Task Page()
    {
        var page = await browser.NewPageAsync();
        var size = page.ViewportSize!;
        size.Height = 768;
        size.Width = 1024;
        await page.GotoAsync("https://localhost:5001");
        await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        await page.EvaluateAsync(@"
() =>
{
    let dom = document.querySelector('#waffle');
    dom.innerHTML = 'TheWaffle'
}");
        await Verifier.Verify(page)
            .ScrubLinesContaining(">Commit<");
    }
}