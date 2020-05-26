using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
            Sha = ShaLoader.Load();
        }

        [Inject] public IJSRuntime JSRuntime { get; set; }
        public string Waffle { get; set; }

        public bool IsWaffleEmpty => Waffle == null;

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

        public async Task CopyTextToClipboard()
        {
            await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Waffle);
        }
    }
}