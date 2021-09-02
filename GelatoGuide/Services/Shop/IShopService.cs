using System.Collections.Generic;
using GelatoGuide.Services.Shop.Models;

namespace GelatoGuide.Services.Shop
{
    public interface IShopService
    {
        void CreateItem(ShopItemServiceModel model);

        IEnumerable<ShopItemServiceModel> GetAllItems();

        ShopItemServiceModel GetItemById(string id);

        int TotalItemsCount();

        void UpdateItem(ShopItemServiceModel model);

        void Delete(string id);
    }
}
