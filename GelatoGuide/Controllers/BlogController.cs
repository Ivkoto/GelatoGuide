﻿using GelatoGuide.Data.Enumerations;
using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GelatoGuide.Services.Blog.Models;

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

        [Authorize]
        public IActionResult MyArticles()
        {
            if (User.IsInRole(nameof(RolesEnum.Admin)) || User.IsInRole(nameof(RolesEnum.Premium)))
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var myArticles = this.blogService.GetAllByUserId(userId);

                return View(myArticles);
            }

            return RedirectToAction("CreatePremium", "User");
            
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var article = this.blogService.GetArticleById(id);
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
        [Authorize]
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

            return RedirectToAction("All", "Blog");
        }
    }
}
