using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult All([FromQuery] SearchArticlesViewModel searchModel)
        {
            var search = new SearchArticlesViewModel()
            {
                Articles = blogService.GetAllArticles(searchModel),
                Names = blogService.GetAllPostedByNames(),
                Years = blogService.GetAllYears(),
                Months = blogService.GetAllMonths(),
                PostedByName = searchModel.PostedByName,
                PostedByYear = searchModel.PostedByYear,
                PostedByMonth = searchModel.PostedByMonth
            };
            
            return View(search);
        }

        
        [Authorize]
        public IActionResult CreateArticle()
        {
            if (!User.IsInRole("Premium") || !User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(UserController.CreatePremium), "User");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(CreateArticleFormModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            blogService.CreateArticle(article);

            return RedirectToAction("All", "Blog");
        }
    }
}
