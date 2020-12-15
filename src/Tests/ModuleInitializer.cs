using System.Runtime.CompilerServices;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        // remove some noise from the html snapshot
        VerifierSettings.ScrubLinesContaining("<!--!-->");
        VerifierSettings.ScrubLinesContaining("id=\"waffle\"");
        VerifySelenium.Enable();
        VerifyPhash.RegisterComparer("png", .99f);
    }
}