using SQLite;

namespace CrazyPoleMobile.Data.Favourites
{
    public class FavouritesDataBase
    {
        SQLiteAsyncConnection Database;

        public FavouritesDataBase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
            await Database.CreateTableAsync<FavouritesItem>();
        }
        public async Task<List<FavouritesItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<FavouritesItem>().ToListAsync();
        }

        public async Task<FavouritesItem> GetItemById(int id)
        {
            await Init();
            return await Database.Table<FavouritesItem>().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(FavouritesItem item)
        {
            await Init();
            var currentItem = await GetItemById(item.Id);
            if (currentItem != null)
                await Database.UpdateAsync(item);
            else
                await Database.InsertAsync(item);
            return item.Id;
        }

        public async Task<int> DeleteItemByIdAsync(int id)
        {
            await Init();
            return await Database.DeleteAsync<FavouritesItem>(id);
        }

        public async Task<int> DeleteAll()
        {
            await Init();
            return await Database.DeleteAllAsync<FavouritesItem>();
        }

    }
}
