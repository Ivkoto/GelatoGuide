using GelatoGuide.Areas.Administration.Views.Home.Models;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{

    public class HomeController : AdminController
    {
        private readonly IUserService userService;
        private readonly IPlaceService placeService;
        private readonly IBlogService blogService;

        public HomeController(IUserService userService, IPlaceService placeService, IBlogService blogService)
        {
            this.userService = userService;
            this.placeService = placeService;
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var totalUsers = this.userService.TotalUsersCount();
            var totalPlaces = this.placeService.TotalPlacesCount();
            var totalArticles = this.blogService.TotalArticlesCount();

            var statistic = new StatisticViewModel()
            {
                TotalPlaces = totalPlaces,
                TotalArticles = totalArticles,
                TotalUsers = totalUsers
            };

            return this.View(statistic);
        }
    }
}
