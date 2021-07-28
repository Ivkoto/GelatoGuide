using System;
using System.Collections.Generic;
using System.Linq;
using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Models.Blog;

namespace GelatoGuide.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly GelatoGuideDbContext data;

        public BlogService(GelatoGuideDbContext data)
            => this.data = data;

        public void CreateArticle(CreateArticleFormModel article)
        {

            this.data.Add(new Article()
            {
                Title = article.Title,
                SubTitle = article.SubTitle,
                Image = article.Image,
                ArticleText = article.ArticleText,
                PostedByName = article.PostedByName,
                PostedByDate = DateTime.Now,
                SourceName = article.SourceName,
                SourceUrl = article.SourceUrl
            });

            this.data.SaveChanges();
        }

        public IEnumerable<AllArticlesViewModel> GetAllArticles()
            => 
            this.data
                .Articles
                .OrderByDescending(a => a.PostedByDate)
                .Select(a => new AllArticlesViewModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    SubTitle = a.SubTitle,
                    PostedByName = a.PostedByName,
                    PostedByDate = a.PostedByDate
                })
                .ToList();
    }
}