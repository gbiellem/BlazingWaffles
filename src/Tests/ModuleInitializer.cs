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
        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));
        HtmlPrettyPrint.All();
        VerifierSettings.ScrubLinesWithReplace(s =>
        {
            var indexOf = s.IndexOf("sha256-");
            if (indexOf == -1)
            {
                return s;
            }

            return s.Substring(0, indexOf) + s.Substring(indexOf + 51);
        });
        VerifyPlaywright.Enable();
        VerifyImageMagick.Initialize();
        VerifyImageMagick.RegisterComparers(.01, ErrorMetric.Fuzz);
    }
}