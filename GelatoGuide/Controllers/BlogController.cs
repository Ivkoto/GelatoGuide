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

        public IActionResult All()
        {
            var articles = blogService.GetAllArticles();

            return View(articles);
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
