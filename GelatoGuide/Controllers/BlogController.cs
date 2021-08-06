using GelatoGuide.Data.Enumerations;
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
                Articles = blogService.GetAllArticles(
                    searchModel.SearchTerm, 
                    searchModel.PostedByName, 
                    searchModel.PostedByYear, 
                    searchModel.PostedByMonth),
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
            if (User.IsInRole(nameof(RolesEnum.Admin)) || User.IsInRole(nameof(RolesEnum.Premium)))
            {
                return View();
            }

            return RedirectToAction(nameof(UserController.CreatePremium), "User");
        }

        [HttpPost]
        public IActionResult CreateArticle(CreateArticleFormModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            blogService.CreateArticle(
                article.Title, article.SubTitle, article.Image, article.ArticleText, 
                article.SourceName, article.SourceUrl, article.PostedByName);

            return RedirectToAction("All", "Blog");
        }
    }
}
