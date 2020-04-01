using System.Linq;
using System.Reflection;

static class ShaLoader
{
    public static string Load()
    {
        var version = typeof(ShaLoader).Assembly
            .GetCustomAttributes<AssemblyInformationalVersionAttribute>()
            .Single()
            .InformationalVersion;
        return version.Substring(version.IndexOf('+') + 1);
    }
}