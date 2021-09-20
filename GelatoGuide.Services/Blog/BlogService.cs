using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Blog.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GelatoGuide.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly GelatoGuideDbContext data;

        public BlogService(GelatoGuideDbContext data)
            => this.data = data;


        public void CreateArticle(ArticleServiceModel model)
        {

            this.data.Add(new Article()
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                Image = model.Image,
                ArticleText = model.ArticleText,
                PostedByName = model.PostedByName,
                SourceName = model.SourceName,
                SourceUrl = model.SourceUrl,
                PostedByDate = DateTime.Now,
                UserId = model.UserId
            });

            this.data.SaveChanges();
        }

        public AllArticlesServiceModel AllArticles(
            string searchTerm, string postedByName, string postedByYear, 
            string postedByMonth, int articlesPerPage, int currentPage)
        {
            var articlesQuery = this.data.Articles.AsQueryable();

            if (!articlesQuery.Any())
            {
                return null;
            }
            
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
                    a.PostedByName.ToLower() == postedByName.ToLower());
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
                Enum.TryParse(postedByMonth, out MonthsEnum searchedMonth);

                var filteredMonth = searchedMonth.GetHashCode();

                articlesQuery = articlesQuery.Where(a =>
                    a.PostedByDate.Month == filteredMonth);
            }

            //restrict receiving query with page value lower than 1
            if (currentPage < 1)
            {
                currentPage = 1;
            }

            //restrict viewing empty pages and non existing pages
            var totalArticles = articlesQuery.Any()? articlesQuery.Count() : 0;
            var maxPageCount = (int)Math.Ceiling((double)totalArticles / articlesPerPage);
            if (currentPage > maxPageCount)
            {
                currentPage = maxPageCount;
            }

            List<ArticleServiceModel> articles;

            //if no results after search
            if (!articlesQuery.Any())
            {
                articles = new List<ArticleServiceModel>();
            }
            else
            {
                articles = articlesQuery
                    .OrderByDescending(a => a.PostedByDate)
                    .Skip((currentPage - 1) * articlesPerPage)
                    .Take(articlesPerPage)
                    .Select(a => new ArticleServiceModel()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        SubTitle = a.SubTitle,
                        PostedByName = a.PostedByName,
                        PostedByDate = a.PostedByDate
                    })
                    .ToList();
            }

            var result = new AllArticlesServiceModel()
            {
                CurrentPage = currentPage,
                TotalArticles = totalArticles,
                SearchTerm = searchTerm,
                PostedByName = postedByName,
                PostedByYear = postedByYear,
                PostedByMonth = postedByMonth,
                Articles = articles,
                Months = this.AllMonths(),
                Years = this.AllYears(),
                PostedByNames = this.AllPostedByNames()
            };

            return result;
        }

        public IEnumerable<ArticleServiceModel> AllArticlesAdmin()
            => this.data.Articles
                .Select(a => new ArticleServiceModel()
                {
                    Id = a.Id,
                    ArticleText = a.ArticleText,
                    Image = a.Image,
                    PostedByDate = a.PostedByDate,
                    PostedByName = a.PostedByName,
                    SourceName = a.SourceName,
                    SourceUrl = a.SourceUrl,
                    SubTitle = a.SubTitle,
                    Title = a.Title,
                    UserId = a.UserId
                })
                .ToList();

        public void Update(string id, ArticleServiceModel model)
        {
            var curArticle = this.data.Articles.Find(id);
            
            curArticle.Title = model.Title;
            curArticle.SubTitle = model.SubTitle;
            curArticle.Image = model.Image;
            curArticle.ArticleText = model.ArticleText;
            curArticle.PostedByName = model.PostedByName;
            curArticle.SourceName = model.SourceName;
            curArticle.SourceUrl = model.SourceUrl;

            this.data.SaveChanges();
        }

        public void Delete(string id)
        {
            var article = this.data.Articles.FirstOrDefault(a => a.Id == id);

            if (article != null)
            {
                this.data.Articles.Remove(article);
                this.data.SaveChanges();
            }
        }

        public IEnumerable<string> AllPostedByNames()
            => this.data.Articles
                .Select(a => a.PostedByName)
                .Distinct()
                .ToList();


        public IEnumerable<string> AllYears()
            =>
            this.data.Articles
                .Select(a => a.PostedByDate.Year.ToString())
                .Distinct()
                .ToList();


        public IEnumerable<string> AllMonths()
            => this.data.Articles
                .Select(a => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(a.PostedByDate.Month))
                .Distinct()
                .ToList();

        public IEnumerable<ArticleServiceModel> AllByUserId(string id)
            => this.data.Articles
                .Where(a => a.UserId == id)
                .Select(a => new ArticleServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    SubTitle = a.SubTitle,
                    PostedByName = a.PostedByName,
                    PostedByDate = a.PostedByDate
                })
                .ToList();

        public ArticleServiceModel ArticleById(string id)
        {
            var article = this.data.Articles
                .Where(a => a.Id == id)
                .Select(a => new ArticleServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    SubTitle = a.SubTitle,
                    ArticleText = a.ArticleText,
                    SourceName = a.SourceName,
                    SourceUrl = a.SourceUrl,
                    PostedByName = a.PostedByName,
                    PostedByDate = a.PostedByDate,
                    Image = a.Image,
                    UserId = a.UserId
                })
                .FirstOrDefault();
                

            //var articles = this.data.Articles.ToList();

            //var curArt = articles.First(a => a.Id == id);

            //return curArt;

            return article;
        }

        public int TotalArticlesCount()
            => this.data.Articles.Count();

        public IEnumerable<ArticleServiceModel> GetLastThreeArticles()
            => this.data.Articles
                .OrderByDescending(a => a.PostedByDate)
                .Take(3)
                .Select(a => new ArticleServiceModel()
                {
                    Id = a.Id,
                    Title = a.Title,
                    SubTitle = a.SubTitle,
                    Image = a.Image,
                    ArticleText = a.ArticleText,
                    SourceName = a.SourceName,
                    SourceUrl = a.SourceUrl,
                    PostedByName = a.PostedByName,
                    PostedByDate = a.PostedByDate
                })
                .ToList();

        public bool IsArticleExist(string id)
            => this.data.Articles.Any(a => a.Id == id);
    }
}