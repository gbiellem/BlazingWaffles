using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;
using WaffleGenerator;

public partial class IndexModel : BlazorComponent
{
    int paragraphs;

    bool includeHeading;

    OutputType outputType;

    public string Waffle;

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

    public OutputType Type
    {
        get => outputType;
        set
        {
            outputType = value;
            Generate();
        }
    }

    protected override void OnInit()
    {
        Paragraphs = 1;
    }

    public Task Generate()
    {
        if (outputType == OutputType.Text)
        {
            Waffle = WaffleEngine.Text(Paragraphs, IncludeHeading);
        }
        else
        {
            Waffle = WaffleEngine.Html(Paragraphs, IncludeHeading);
        }

        return Task.CompletedTask;
    }
}