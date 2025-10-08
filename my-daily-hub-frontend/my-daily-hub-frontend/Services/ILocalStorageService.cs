namespace my_daily_hub_frontend.Services;

public interface ILocalStorageService {
    public Task SetItemAsync(string key, string value);
    public Task<string?> GetItemAsync(string key);
    public Task RemoveItemAsync(string key);
}
