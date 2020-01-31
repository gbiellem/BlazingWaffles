using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using PropertyChanged;
using WaffleGenerator;

namespace BlazingWaffles
{
    [AddINotifyPropertyChangedInterface]
    public partial class IndexModel :
        ComponentBase
    {
        public IndexModel()
        {
            var informationalVersion = GetType().Assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>().Single().InformationalVersion;
            Sha = informationalVersion.Substring(informationalVersion.IndexOf('+') + 1);
        }

        public string Waffle
        {
            get
            {
                if (OutputType == OutputType.Text)
                {
                    return WaffleEngine.Text(Paragraphs, IncludeHeading);
                }

                return WaffleEngine.Html(Paragraphs, IncludeHeading, false);
            }
        }

        public string Sha { get; }
        public int Paragraphs { get; set; } = 1;
        public bool IncludeHeading { get; set; }
        public OutputType OutputType { get; set; }
    }
}