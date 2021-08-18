using GelatoGuide.Areas.Administration.Views.Home.Models;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Shop;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{

    public class HomeController : AdminController
    {
        private readonly IUserService userService;
        private readonly IPlaceService placeService;
        private readonly IBlogService blogService;
        private readonly IShopService shopService;

        public HomeController(
            IUserService userService, 
            IPlaceService placeService, 
            IBlogService blogService, 
            IShopService shopService)
        {
            this.userService = userService;
            this.placeService = placeService;
            this.blogService = blogService;
            this.shopService = shopService;
        }

        public IActionResult Index()
        {
            var totalUsers = this.userService.TotalUsersCount();
            var totalPlaces = this.placeService.TotalPlacesCount();
            var totalArticles = this.blogService.TotalArticlesCount();
            var totalShopItems = this.shopService.TotalItemsCount();

            var statistic = new StatisticViewModel()
            {
                TotalPlaces = totalPlaces,
                TotalArticles = totalArticles,
                TotalUsers = totalUsers,
                TotalItemsInTheShop = totalShopItems
            };

            return this.View(statistic);
        }
    }
}
