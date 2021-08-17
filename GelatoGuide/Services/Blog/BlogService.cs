﻿using GelatoGuide.Data;
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
            string sourceName, string sourceUrl, string postedByName, string userId)
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
                PostedByDate = DateTime.Now,
                UserId = userId
            });

            this.data.SaveChanges();
        }

        public AllArticlesServiceModel AllArticles(
            string searchTerm, string postedByName, string postedByYear, 
            string postedByMonth, int articlesPerPage, int currentPage)
        {

            //validate data from the query
            var allPostedByName = this.AllPostedByNames();
            var allYears = this.AllYears();
            var allMonts = this.AllMonths();
            if (!allPostedByName.Contains(postedByName) && postedByName != null)
            {
                return null;
            }

            if (!allYears.Contains(postedByYear) && postedByYear != null)
            {
                return null;
            }

            if (!allMonts.Contains(postedByMonth) && postedByMonth != null)
            {
                return null;
            }

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

            //restrict receiving query with page value lower than 1
            if (currentPage < 1)
            {
                currentPage = 1;
            }

            //restrict viewing empty pages and non existing pages
            var totalArticles = articlesQuery.Count();
            var maxPageCount = (int)Math.Ceiling((double)totalArticles / articlesPerPage);
            if (currentPage > maxPageCount)
            {
                currentPage = maxPageCount;
            }

            List<ArticleServiceModel> articles;

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

        public void Edit(string id, ArticleServiceModel model)
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

        public void Delete(Article article)
        {
            this.data.Articles.Remove(article);
            this.data.SaveChanges();
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

        //ToDo - delete if everything works
        //public ArticleServiceModel ArticleById(string id)
        //    => this.data.Articles
        //        .Where(a => a.Id == id)
        //        .Select(a => new ArticleServiceModel()
        //        {
        //            Title = a.Title,
        //            SubTitle = a.SubTitle,
        //            Image = a.Image,
        //            ArticleText = a.ArticleText,
        //            SourceName = a.SourceName,
        //            SourceUrl = a.SourceUrl,
        //            PostedByName = a.PostedByName,
        //            UserId = a.UserId
        //        })
        //        .FirstOrDefault();

        public Article ArticleById(string id)
        {
            var articles = this.data.Articles.ToList();

            var curArt = articles.First(a => a.Id == id);

            return curArt;
        }

        public int TotalArticlesCount()
            => this.data.Articles.Count();
    }
}