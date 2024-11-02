[![Build status](https://ci.appveyor.com/api/projects/status/auc0ev6wgxs7dexo/branch/master?svg=true)](https://ci.appveyor.com/project/gbiellem/blazingwaffles/branch/master)


# BlazingWaffles

Blazor wrapper around the [Waffle Generator](https://github.com/SimonCropp/WaffleGenerator).

**See [Milestones](../../milestones?state=closed) for release notes.**

Site is live at http://wafflegen.azurewebsites.net


## Data Binding

Uses [Fody PropertyChanged](https://github.com/Fody/PropertyChanged) to implement INotifyPropertyChanged.


## Clipboard

Uses [TextCopy](https://github.com/CopyText/TextCopy) add content to the clipboard.


## Tests

Uses [bunit](https://bunit.egilhansen.com/) and [Verify](https://github.com/VerifyTests/Verify) to perform snapshot testing.

<!-- snippet: Tests -->
<a id='snippet-Tests'></a>
```cs
public class Tests
{
    [Fact]
    public Task Component()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IJSRuntime>(new MockJSRuntime());
        services.InjectMockClipboard();
        using var provider = services.BuildServiceProvider();
        var target = Render.Component<Index>(
            provider,
            template: new()
            {
                Waffle = "The Waffle",
                Sha = "TheSha"
            });
        return Verify(target);
    }
}
```
<sup><a href='/src/Tests/Tests.cs#L7-L29' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->
