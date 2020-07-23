using VerifyTests;

public static class ModuleInitializer
{
    public static void Initialize()
    {
        VerifierSettings.ScrubLinesContaining("id=\"waffle\"");
    }
}