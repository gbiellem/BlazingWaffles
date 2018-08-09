using Microsoft.AspNetCore.Blazor.Components;
using WaffleGenerator;

public class IndexModel : BlazorComponent
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

    public OutputType OutputType
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

    public void Generate()
    {
        if (outputType == OutputType.Text)
        {
            Waffle = WaffleEngine.Text(Paragraphs, IncludeHeading);
        }
        else
        {
            Waffle = WaffleEngine.Html(Paragraphs, IncludeHeading);
        }
    }
}