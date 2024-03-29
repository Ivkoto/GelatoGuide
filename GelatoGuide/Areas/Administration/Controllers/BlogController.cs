﻿using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Blog;
using GelatoGuide.Infrastructure;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers;

public class BlogController : AdminController
{
    private readonly IBlogService blogService;
    private readonly IMapper mapper;

    public BlogController(IBlogService blogService, IMapper mapper)
    {
        this.blogService = blogService;
        this.mapper = mapper;
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

        var userId = this.User.Id();

        var articleModel = this.mapper.Map<ArticleServiceModel>(article);
        articleModel.UserId = userId;

        blogService.CreateArticle(articleModel);

        return RedirectToAction("All", "Blog");
    }

    public IActionResult Update(string id)
    {
        var article = this.blogService.ArticleById(id);

        var createModel = this.mapper.Map<CreateArticleFormModel>(article);

        return View(createModel);
    }

    [HttpPost]
    public IActionResult Update(string id, CreateArticleFormModel createModel)
    {
        if (!ModelState.IsValid)
        {
            return View(createModel);
        }

        var serviceModel = this.mapper.Map<ArticleServiceModel>(createModel);
        serviceModel.Id = id;

        this.blogService.Update(id, serviceModel);

        return RedirectToAction("All", "Blog");
    }


    [HttpPost]
    public IActionResult Delete(string id)
    {
        var isArticleExist = this.blogService.IsArticleExist(id);

        if (!isArticleExist)
        {
            this.ModelState.AddModelError("", "Article do not exist!");
            var articles = this.blogService.AllArticlesAdmin();
            return View("All", articles);
        }

        this.blogService.Delete(id);

        return RedirectToAction("All", "Blog");
    }

    public IActionResult Details(string id)
    {
        var article = this.blogService.ArticleById(id);

        var articleDetails = this.mapper.Map<ArticleServiceModel>(article);

        return View(articleDetails);
    }
}