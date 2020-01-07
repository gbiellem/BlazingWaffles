using Microsoft.AspNetCore.Components;
using WaffleGenerator;

namespace BlazingWaffles
{
    public partial class IndexModel :
        ComponentBase
    {
        int paragraphs = 1;

        bool includeHeading;

        OutputType outputType;

        public string Waffle = WaffleEngine.Text(1, false);

        public int Paragraphs
        {
            get => paragraphs;
            set
            {
                paragraphs = value;
                Generate();
            }
        }

        public bool IncludeHeading
        {
            get => includeHeading;
            set
            {
                includeHeading = value;
                Generate();
            }
        }

        public OutputType OutputType
        {
            get => outputType;
            set
            {
                outputType = value;
                Generate();
            }
        }

        public void Generate()
        {
            if (outputType == OutputType.Text)
            {
                Waffle = WaffleEngine.Text(Paragraphs, IncludeHeading);
            }
            else
            {
                Waffle = WaffleEngine.Html(Paragraphs, IncludeHeading, false);
            }
        }
    }
}