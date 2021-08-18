using System.Collections.Generic;
using GelatoGuide.Services.Shop.Models;

namespace GelatoGuide.Services.Shop
{
    public interface IShopService
    {
        IEnumerable<ShopItemServiceModel> GetAllItems();

        ShopItemServiceModel GetItemById(string id);

        int TotalItemsCount();
    }
}
