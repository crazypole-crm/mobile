using SQLite;

namespace CrazyPoleMobile.Data.Notifications
{
    public class NotificationDataBase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
            await Database.CreateTableAsync<NotificationItem>();
        }
        public async Task<List<NotificationItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<NotificationItem>().ToListAsync();
        }

        public async Task<NotificationItem> GetItemById(int id)
        {
            await Init();
            return await Database.Table<NotificationItem>().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(NotificationItem item)
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
            return await Database.DeleteAsync<NotificationItem>(id);
        }
    }

}
