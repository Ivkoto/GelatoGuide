using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Shop.Models;

namespace GelatoGuide.Services.Shop
{
    public class ShopService : IShopService
    {

        private readonly GelatoGuideDbContext data;
        private readonly IMapper mapper;

        public ShopService(GelatoGuideDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public void CreateItem(ShopItemServiceModel model)
        {
            this.data.Add(new ShopItem()
            {
                Name = model.Name,
                Description = model.Description,
                MainImageUrl = model.MainImageUrl,
                Price = model.Price
            });

            this.data.SaveChanges();
        }

        //public IEnumerable<ShopItemServiceModel> GetAllItems()
        //    => this.data.ShopItems
        //        .Select(shi => new ShopItemServiceModel()
        //        {
        //            Id = shi.Id,
        //            Name = shi.Name,
        //            Description = shi.Description,
        //            MainImageUrl = shi.MainImageUrl,
        //            Price = shi.Price

        //        })
        //        .ToList();

        public IEnumerable<ShopItemServiceModel> GetAllItems()
            => this.data.ShopItems
                .ProjectTo<ShopItemServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

        public ShopItemServiceModel GetItemById(string id)
            => this.data.ShopItems
                .Where(shi => shi.Id == id)
                .ProjectTo<ShopItemServiceModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();

        public int TotalItemsCount()
            => this.data.ShopItems.Count();

        public void UpdateItem(ShopItemServiceModel model)
        {
            var currentItem = this.data.ShopItems.First(shi => shi.Id == model.Id);

            if (currentItem != null)
            {
                currentItem.Name = model.Name;
                currentItem.Description = model.Description;
                currentItem.MainImageUrl = model.MainImageUrl;
                currentItem.Price = model.Price;

                this.data.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var currentItem = this.data.ShopItems.First(shi => shi.Id == id);

            if (currentItem != null)
            {
                this.data.ShopItems.Remove(currentItem);
                this.data.SaveChanges();
            }
        }
    }
}
