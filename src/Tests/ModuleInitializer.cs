using System.Runtime.CompilerServices;
using ImageMagick;
using Verify.AngleSharp;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // remove some noise from the html snapshot
        #region scrubbing
        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));
        HtmlPrettyPrint.All();
        VerifierSettings.ScrubLinesContaining("<script src=\"_framework/dotnet.");
        #endregion
        VerifyPlaywright.Enable();
        VerifyImageMagick.Initialize();
        VerifyImageMagick.RegisterComparers(.01, ErrorMetric.Fuzz);
    }
}