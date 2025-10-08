using Microsoft.JSInterop;

namespace my_daily_hub_frontend.Services;

public class LocalStorageService(IJSRuntime _js) : ILocalStorageService {

    public async Task SetItemAsync(string key, string value)
        => await _js.InvokeVoidAsync("localStorageInterop.set", key, value);

    public async Task<string?> GetItemAsync(string key)
        => await _js.InvokeAsync<string?>("localStorageInterop.get", key);

    public async Task RemoveItemAsync(string key)
        => await _js.InvokeVoidAsync("localStorageInterop.remove", key);
}
