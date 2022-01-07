﻿using System.Diagnostics;
using Microsoft.Playwright;

public class PlaywrightFixture :
    IAsyncLifetime
{
    Process? process;
    IPlaywright? playwright;
    IBrowser? browser;

    public IBrowser Browser { get => browser!; }

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
        if (browser is not null)
        {
            await browser.DisposeAsync();
        }

        playwright?.Dispose();

        if (process is not null)
        {
            process.Kill();
            process.Dispose();
        }
    }
}