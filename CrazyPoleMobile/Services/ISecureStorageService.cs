
namespace CrazyPoleMobile.Services;

public interface ISecureStorageService
{
    public Task Save(string key, string value);
    public Task<string> Get(string key);
    public void RemoveData();
    public bool Remove(string key);
}

