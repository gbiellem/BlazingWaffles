using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PropertyChanged;
using TextCopy;
using WaffleGenerator;

namespace BlazingWaffles
{
    [AddINotifyPropertyChangedInterface]
    public partial class IndexModel :
        ComponentBase
    {
        public IndexModel()
        {
            Sha = ShaLoader.Load();
            SetWaffle();
        }

        [Inject] public IClipboard Clipboard { get; set; }

        public string Waffle { get; set; }

        void SetWaffle()
        {
            if (OutputType == OutputType.Text)
            {
                Waffle = WaffleEngine.Text(Paragraphs, IncludeHeading);
                return;
            }

            Waffle = WaffleEngine.Html(Paragraphs, IncludeHeading, false);
        }

        public string Sha { get; set; }
        public int Paragraphs { get; set; } = 1;

        public void OnParagraphsChanged()
        {
            SetWaffle();
        }

        public bool IncludeHeading { get; set; }

        public void OnIncludeHeadingChanged()
        {
            SetWaffle();
        }

        public OutputType OutputType { get; set; }

        public void OnOutputTypeChanged()
        {
            SetWaffle();
        }

        public Task CopyTextToClipboard()
        {
            return Clipboard.SetTextAsync(Waffle);
        }
    }
}