using System.Threading.Tasks;
using PlaywrightSharp;
using PlaywrightSharp.Chromium;
using VerifyXunit;
using Verify.AngleSharp;
using Xunit;

[UsesVerify]
public class PlaywrightTest :
    IClassFixture<PlaywrightFixture>
{
    IChromiumBrowser browser;

    public PlaywrightTest(PlaywrightFixture fixture)
    {
        browser = fixture.Browser;
    }

    [Fact]
    public async Task Page()
    {
        var page = await browser.NewPageAsync();
        page.ViewportSize.Height = 768;
        page.ViewportSize.Width = 1024;
        await page.GoToAsync("https://localhost:5001");
        await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
        await Verifier.Verify(page)
            .AutoVerify()
            .ScrubLinesContaining("Built from commit")
            .PrettyPrintHtml();
    }
}