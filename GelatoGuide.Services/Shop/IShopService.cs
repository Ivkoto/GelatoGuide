using GelatoGuide.Services.Shop.Models;
using System.Collections.Generic;

namespace GelatoGuide.Services.Shop;

public interface IShopService
{
    void CreateItem(ShopItemServiceModel model);

    IEnumerable<ShopItemServiceModel> GetAllItems();

    ShopItemServiceModel GetItemById(string id);

    int TotalItemsCount();

    void UpdateItem(ShopItemServiceModel model);

    void Delete(string id);
}