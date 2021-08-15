using GelatoGuide.Infrastructure;
using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace GelatoGuide.Controllers
{
    [Authorize]
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
                Articles = blogService.AllArticles(
                searchModel.SearchTerm,
                searchModel.PostedByName,
                searchModel.PostedByYear,
                searchModel.PostedByMonth),
                Names = blogService.AllPostedByNames(),
                Years = blogService.AllYears(),
                Months = blogService.AllMonths(),
                PostedByName = searchModel.PostedByName,
                PostedByYear = searchModel.PostedByYear,
                PostedByMonth = searchModel.PostedByMonth
            };

            return View(search);
        }

        public IActionResult CreateArticle()
        {
            if (this.User.IsAdmin() || this.User.IsPremium())
            {
                return View();
            }

            return RedirectToAction("CreatePremium", "User");
        }

        [HttpPost]
        public IActionResult CreateArticle(ArticleFormModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            blogService.CreateArticle(
                article.Title, article.SubTitle, article.Image, article.ArticleText,
                article.SourceName, article.SourceUrl, article.PostedByName, userId);

            return RedirectToAction("All", "Blog");
        }

        public IActionResult MyArticles()
        {
            if (this.User.IsAdmin() || this.User.IsPremium())
            {
                var userId = this.User.Id();

                var myArticles = this.blogService.AllByUserId(userId);

                return View(myArticles);
            }

            return RedirectToAction("CreatePremium", "User");

        }

        public IActionResult Edit(string id)
        {
            var article = this.blogService.ArticleById(id);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (article.UserId == userId || this.User.IsInRole("Admin"))
            {
                return View(new ArticleFormModel()
                {
                    Title = article.Title,
                    SubTitle = article.SubTitle,
                    Image = article.Image,
                    ArticleText = article.ArticleText,
                    PostedByName = article.PostedByName,
                    SourceName = article.SourceName,
                    SourceUrl = article.SourceUrl
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Edit(string id, ArticleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = new ArticleServiceModel()
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                Image = model.Image,
                ArticleText = model.ArticleText,
                PostedByName = model.PostedByName,
                SourceName = model.SourceName,
                SourceUrl = model.SourceUrl
            };

            this.blogService.Edit(id, serviceModel);

            if (this.User.IsAdmin())
            {
                return RedirectToAction("All", "Blog");
            }

            return RedirectToAction("MyArticles", "Blog");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var article = this.blogService.ArticleById(id);

            if (article == null)
            {
                this.ModelState.AddModelError("", "Статията не съществува!");
                return View("All");
            }

            this.blogService.Delete(article);

            //return View("All");

            return RedirectToAction("All", "Blog");
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
