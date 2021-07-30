using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog;
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

        public IActionResult CreateArticle() => View();
        
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
