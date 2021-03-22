using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using PlaywrightSharp;
using PlaywrightSharp.Chromium;
using Xunit;

public class PlaywrightFixture :
    IAsyncLifetime
{
    Process? process;
    IPlaywright? playwright;
    IChromiumBrowser? browser;

    public IChromiumBrowser Browser { get => browser!; }

    public Task InitializeAsync()
    {
        StartBlazorApp();

        return StartDriver();
    }

    void StartBlazorApp()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory!;
        var binPath = baseDirectory.Replace("Tests", "BlazingWaffles");
        var projectDir = Path.GetFullPath(Path.Combine(binPath, "../../"));
        ProcessStartInfo startInfo = new("dotnet", "run --no-build --no-restore")
        {
            WorkingDirectory = projectDir
        };
        process = Process.Start(startInfo);
    }

    async Task StartDriver()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync();
    }

    public async Task DisposeAsync()
    {
        if (browser != null)
        {
            await browser.DisposeAsync();
        }

        playwright?.Dispose();

        if (process != null)
        {
            process.Kill();
            process.Dispose();
        }
    }
}