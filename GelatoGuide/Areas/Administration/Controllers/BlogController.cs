using GelatoGuide.Services.Blog;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers
{
    public class BlogController : AdminController
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult All()
        {
            var articles = this.blogService.AdminArticles();

            return View(articles);
        }

        public IActionResult Update() => View();


        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (!this.blogService.IsArticleExist(id))
            {
                this.ModelState.AddModelError("", "Статията не съществува!");
                return View("All");
            }

            this.blogService.Delete(id);

            return RedirectToAction("All", "Blog");
        }
    }
}
