[![Build status](https://ci.appveyor.com/api/projects/status/auc0ev6wgxs7dexo/branch/master?svg=true)](https://ci.appveyor.com/project/gbiellem/blazingwaffles/branch/master)


# BlazingWaffles

Blazor wrapper around the [Waffle Generator](https://github.com/SimonCropp/WaffleGenerator)

Site is live at http://wafflegen.azurewebsites.net


## Data Binding

Uses [Fody PropertyChanged](https://github.com/Fody/PropertyChanged) to implement INotifyPropertyChanged.


## Clipboard

Uses [TextCopy](https://github.com/CopyText/TextCopy) add content to the clipboard.


## Tests

Uses [bunit](https://bunit.egilhansen.com/) and [Verify](https://github.com/VerifyTests/Verify) to perform snapshot testing.

snippet: Tests