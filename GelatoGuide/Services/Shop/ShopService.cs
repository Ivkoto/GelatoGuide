using System.Collections.Generic;
using System.Linq;
using GelatoGuide.Data;
using GelatoGuide.Services.Shop.Models;

namespace GelatoGuide.Services.Shop
{
    public class ShopService : IShopService
    {

        private readonly GelatoGuideDbContext data;

        public ShopService(GelatoGuideDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ShopItemServiceModel> GetAllItems()
            => this.data.ShopItems
                .Select(shi => new ShopItemServiceModel()
                {
                    Id = shi.Id,
                    Name = shi.Name,
                    Description = shi.Description,
                    MainImageUrl = shi.MainImageUrl,
                    Price = shi.Price

                })
                .ToList();

        public ShopItemServiceModel GetItemById(string id)
            => this.data.ShopItems
                .Where(shi => shi.Id == id)
                .Select(shi => new ShopItemServiceModel()
                {
                    Id = shi.Id,
                    Name = shi.Name,
                    Description = shi.Description,
                    MainImageUrl = shi.MainImageUrl,
                    Price = shi.Price
                })
                .FirstOrDefault();

        public int TotalItemsCount()
            => this.data.ShopItems.Count();
    }
}
