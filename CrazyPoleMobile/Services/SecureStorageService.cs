
namespace CrazyPoleMobile.Services;

public class SecureStorageService : ISecureStorageService
{
    public SecureStorageService() { }

    public async Task<string> Get(string key)
    {
        return await SecureStorage.Default.GetAsync(key);
    }
    public void RemoveData()
    {
        SecureStorage.Default.RemoveAll();
    }
    public async Task Save(string key, string value)
    {
        await SecureStorage.Default.SetAsync(key, value);
    }

    public bool Remove(string key)
    {
        return SecureStorage.Default.Remove(key);
    }
}

