using System.Security.Claims;
using GelatoGuide.Areas.Administration.Models.Blog;
using GelatoGuide.Infrastructure;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Blog.Models;
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
            var articles = this.blogService.AllArticlesAdmin();

            return View(articles);
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(CreateArticleFormModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var articleModel = new ArticleServiceModel()
            {
                Title = article.Title,
                SubTitle = article.SubTitle,
                Image = article.Image,
                ArticleText = article.ArticleText,
                PostedByName = article.PostedByName,
                SourceName = article.SourceName,
                SourceUrl = article.SourceUrl,
                UserId = userId
            };

            blogService.CreateArticle(articleModel);

            return RedirectToAction("All", "Blog");
        }

        public IActionResult Update(string id)
        {
            var article = this.blogService.ArticleById(id);
            
            return View(new CreateArticleFormModel()
            {
                Title = article.Title,
                SubTitle = article.SubTitle,
                ArticleText = article.ArticleText,
                SourceName = article.SourceName,
                PostedByName = article.PostedByName,
                SourceUrl = article.SourceUrl,
                Image = article.Image
            });
        }

        [HttpPost]
        public IActionResult Update(string id, CreateArticleFormModel model)
        {
            //Todo add image section to the view and the form model

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = new ArticleServiceModel()
            {
                Id = id,
                Title = model.Title,
                SubTitle = model.SubTitle,
                ArticleText = model.ArticleText,
                Image = model.Image,
                PostedByName = model.PostedByName,
                SourceName = model.SourceName,
                SourceUrl = model.SourceUrl
            };

            this.blogService.Update(id, serviceModel);

            return RedirectToAction("All", "Blog");
        }


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
