﻿using System.Security.Claims;
using AutoMapper;
using GelatoGuide.Infrastructure;
using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GelatoGuide.Data.Constants.DataConstants;

namespace GelatoGuide.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IMapper mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this.blogService = blogService;
            this.mapper = mapper;
        }

        public IActionResult All([FromQuery] AllArticlesServiceModel searchModel)
        {
            var search = this.blogService.AllArticles(
                searchModel.SearchTerm, searchModel.PostedByName,
                searchModel.PostedByYear, searchModel.PostedByMonth,
                Blog.ArticlesPerPage, searchModel.CurrentPage);

            return View(search);
        }

        public IActionResult Details(string id)
        {
            var article = this.blogService.ArticleById(id);
            var articles = this.blogService.GetLastThreeArticles();

            var articleModel = this.mapper.Map<ArticleDetailsViewModel>(article);
            articleModel.Articles = articles;

            return View(articleModel);
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

            var articleModel = this.mapper.Map<ArticleServiceModel>(article);
            articleModel.UserId = userId;

            blogService.CreateArticle(articleModel);

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

            this.blogService.Update(id, serviceModel);

            if (this.User.IsAdmin())
            {
                return RedirectToAction("All", "Blog");
            }

            return RedirectToAction("MyArticles", "Blog");
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

        //private void Errors(IdentityResult result)
        //{
        //    foreach (IdentityError error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //}
    }
}
