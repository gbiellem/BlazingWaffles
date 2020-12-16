using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class MockJSRuntime :
    IJSRuntime
{
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        return default;
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellation, object?[]? args)
    {
        return default;
    }
}