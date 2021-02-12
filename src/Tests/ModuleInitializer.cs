using System.Runtime.CompilerServices;
using ImageMagick;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // remove some noise from the html snapshot
        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));

        VerifyPlaywright.Enable();
        VerifyImageMagick.Initialize();
        VerifyImageMagick.RegisterComparers(.01, ErrorMetric.Fuzz);
    }
}