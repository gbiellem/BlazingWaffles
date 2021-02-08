using System;
using System.Diagnostics;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class SeleniumFixture :
    IDisposable
{
    Process? process;
    ChromeDriver? driver;

    public SeleniumFixture()
    {
        StartBlazorApp();

        StartDriver();

        WaitForRender();
    }

    void StartBlazorApp()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory!;
        var binPath = baseDirectory.Replace("Tests", "BlazingWaffles");
        var projectDir = Path.GetFullPath(Path.Combine(binPath, "../../"));
        ProcessStartInfo startInfo = new("dotnet", "run")
        {
            WorkingDirectory = projectDir
        };
        process = Process.Start(startInfo);
    }

    void StartDriver()
    {
        ChromeOptions options = new();
        options.AddArgument("--no-sandbox");
        options.AddArgument("--headless");
        driver = new(options);
        driver.Manage().Window.Size = new(1024, 768);
        driver.Navigate().GoToUrl("https://localhost:5001");
    }

    void WaitForRender()
    {
        WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(30));
        wait.Until(drv => drv.FindElement(By.ClassName("main")));
    }

    public ChromeDriver Driver => driver!;

    public void Dispose()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }

        if (process != null)
        {
            process.Kill();
            process.Dispose();
        }
    }
}