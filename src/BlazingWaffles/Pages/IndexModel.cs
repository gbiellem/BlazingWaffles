using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TextCopy;
using WaffleGenerator;

namespace BlazingWaffles
{
    public class IndexModel :
        ComponentBase,
        INotifyPropertyChanged
    {
        public IndexModel()
        {
            Sha = ShaLoader.Load();
            SetWaffle();
        }

        [Inject]
        public IClipboard Clipboard { get; set; } = null!;

        public string Waffle { get; set; } = null!;

        public void SetWaffle()
        {
            if (OutputType == OutputType.Text)
            {
                Waffle = WaffleEngine.Text(Paragraphs, IncludeHeading);
                return;
            }

            if (OutputType == OutputType.Markdown)
            {
                Waffle = WaffleEngine.Markdown(Paragraphs, IncludeHeading);
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new(propertyName));
        }
    }
}