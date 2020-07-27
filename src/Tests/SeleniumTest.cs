using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class SeleniumTest :
    IClassFixture<SeleniumFixture>
{
    RemoteWebDriver driver;

    public SeleniumTest(SeleniumFixture fixture)
    {
        driver = fixture.Driver;
    }

    [Fact]
    public async Task Page()
    {
        var element = driver.FindElement(By.Id("waffle"));
        ((IJavaScriptExecutor) driver).ExecuteScript(
            "var ele=arguments[0]; ele.innerHTML = 'my new content';", element);
        var settings = new VerifySettings();
        settings.ScrubLinesContaining("Built from commit");
        await Verifier.Verify(driver, settings);
    }
}