using System.Runtime.CompilerServices;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifySelenium.Enable();
        VerifyPhash.RegisterComparer("png", .99f);
    }
}