using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Blog.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GelatoGuide.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly GelatoGuideDbContext data;

        public BlogService(GelatoGuideDbContext data)
            => this.data = data;


        public void CreateArticle(
            string title, string subTitle, string image, string articleText,
            string sourceName, string sourceUrl, string postedByName)
        {

            this.data.Add(new Article()
            {
                Title = title,
                SubTitle = subTitle,
                Image = image,
                ArticleText = articleText,
                PostedByName = postedByName,
                SourceName = sourceName,
                SourceUrl = sourceUrl,
                PostedByDate = DateTime.Now
            });

            this.data.SaveChanges();
        }

        public IEnumerable<AllArticlesServiceModel> GetAllArticles(
            string searchTerm, string postedByName,
            string postedByYear, string postedByMonth)
        {
            var articlesQuery = this.data.Articles.AsQueryable();

            //filter query if any search text have been imputed
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                articlesQuery = articlesQuery.Where(a =>
                    a.ArticleText.ToLower().Contains(searchTerm.ToLower()) ||
                    a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    a.SubTitle.ToLower().Contains(searchTerm.ToLower()) ||
                    a.PostedByName.ToLower().Contains(searchTerm.ToLower()) ||
                    a.SourceName.ToLower().Contains(searchTerm.ToLower()));
            }

            //filter query if author name have been selected
            if (!string.IsNullOrWhiteSpace(postedByName))
            {
                articlesQuery = articlesQuery.Where(a =>
                    a.PostedByName == postedByName);
            }

            //filter query if year have been selected
            if (!string.IsNullOrWhiteSpace(postedByYear))
            {
                articlesQuery = articlesQuery.Where(a =>
                    a.PostedByDate.Year.ToString() == postedByYear);
            }

            //filter query if month have been selected
            if (!string.IsNullOrWhiteSpace(postedByMonth))
            {
                articlesQuery = articlesQuery.Where(a =>
                    a.PostedByDate.Month == DateTime.ParseExact(postedByMonth, "MMMM", CultureInfo.CurrentCulture).Month);
            }

            var articles = articlesQuery
                .OrderByDescending(a => a.PostedByDate)
                .Select(a => new AllArticlesServiceModel()
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