using SQLite;

namespace CrazyPoleMobile.Data.Cookies
{
    public class CookieDataBase
    {
        SQLiteAsyncConnection Database;

        public CookieDataBase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
            await Database.CreateTableAsync<CookieItem>();
        }

        public async Task<List<CookieItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<CookieItem>().ToListAsync();
        }

        public async Task<CookieItem> GetItemByName(string name)
        {
            await Init();
            return await Database.Table<CookieItem>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(CookieItem item)
        {
            await Init();
            var currentItem = await GetItemByName(item.Name);
            if (currentItem != null)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(CookieItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
