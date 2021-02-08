using System.Runtime.CompilerServices;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // remove some noise from the html snapshot
        VerifierSettings.ScrubEmptyLines();
        VerifierSettings.ScrubLinesWithReplace(s => s.Replace("<!--!-->", ""));

        VerifySelenium.Enable();
        VerifyPhash.RegisterComparer("png", .99f);
    }
}