using CrazyPoleMobile.Data.Favourites;
using CrazyPoleMobile.Helpers;
using CrazyPoleMobile.MVVM.Models;

namespace CrazyPoleMobile.Services
{
    public class FavouritesService
    {
        private readonly FavouritesDataBase _dataBase;
        public FavouritesService()
        {
            _dataBase = ServiceHelper.GetService<FavouritesDataBase>();
        }

        public async void AddFavorites(FavouriteData data)
        {
            var item = new FavouritesItem() 
            {
                Direction = data.Direction,
                Hall = data.Hall,
                Trainer = data.Trainer
            };

            item.Id = await _dataBase.SaveItemAsync(item);
        }

        public async void DeleteFavorite(FavouriteData item)
        {
            await _dataBase.DeleteItemByIdAsync(item.Id);
        }

        public async void DeleteAllFavorittes()
        {
            await _dataBase.DeleteAll();
        }

        public async Task<List<FavouriteData>> LoadFavorites()
        {
            var items = await _dataBase.GetItemsAsync();
            var result = new List<FavouriteData>();
            await Task.Run(() =>
            {
                foreach (var item in items)
                {
                    result.Add(new()
                    {
                        Id = item.Id,
                        Direction = item.Direction,
                        Hall = item.Hall,
                        Trainer = item.Trainer
                    });
                }
            });
            return result;
        }
    }
}
