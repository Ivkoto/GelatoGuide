using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IEnumerable<AllArticlesViewModel> GetAllArticles(SearchArticlesViewModel searchModel)
        {
            var articlesQuery = this.data.Articles.AsQueryable();

            //filter query if any serach text have been imputed
            if (!string.IsNullOrWhiteSpace(searchModel.SearchTerm))
            {
                articlesQuery = articlesQuery.Where(a =>
                    a.ArticleText.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    a.Title.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    a.SubTitle.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    a.PostedByName.ToLower().Contains(searchModel.SearchTerm.ToLower()) ||
                    a.SourceName.ToLower().Contains(searchModel.SearchTerm.ToLower()));                
            }

            //filter query if author name have been selected
            if (!string.IsNullOrWhiteSpace(searchModel.PostedByName))
            {
                articlesQuery = articlesQuery.Where(a => 
                    a.PostedByName == searchModel.PostedByName);
            }

            //filter query if year have been selected
            if (!string.IsNullOrWhiteSpace(searchModel.PostedByYear))
            {
                articlesQuery = articlesQuery.Where(a => 
                    a.PostedByDate.Year.ToString() == searchModel.PostedByYear);
            }

            //filter query if month have been selected
            if (!string.IsNullOrWhiteSpace(searchModel.PostedByMonth))
            {
                articlesQuery = articlesQuery.Where(a => 
                    a.PostedByDate.Month == DateTime.ParseExact(searchModel.PostedByMonth, "MMMM", CultureInfo.CurrentCulture).Month);
            }

            var articles = articlesQuery
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

            return articles;
        }

        public IEnumerable<string> GetAllPostedByNames()
            => this.data.Articles
                .Select(a => a.PostedByName)
                .Distinct()
                .ToList();


        public IEnumerable<string> GetAllYears()
            =>
            this.data.Articles
                .Select(a => a.PostedByDate.Year.ToString())
                .Distinct()
                .ToList();


        public IEnumerable<string> GetAllMonths()
            => this.data.Articles
                .Select(a => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a.PostedByDate.Month))
                .Distinct()
                .ToList();
    }
}