using GelatoGuide.Services.Blog.Models;
using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Services.Blog
{
    public interface IBlogService
    {
        void CreateArticle(
            string title, string subTitle, string image, string articleText,
            string sourceName, string sourceUrl, string postedByName, string userId);

        AllArticlesServiceModel AllArticles(
            string searchTerm, string postedByName, string postedByYear, 
            string postedByMonth, int articlesPerPage, int currentPage);

        IEnumerable<ArticleServiceModel> AdminArticles();

        void Edit(string id, ArticleServiceModel model);

        void Delete(string id);

        IEnumerable<string> AllPostedByNames();

        IEnumerable<string> AllYears();

        IEnumerable<string> AllMonths();

        IEnumerable<ArticleServiceModel> AllByUserId(string id);

        Article ArticleById(string id);

        int TotalArticlesCount();

        IEnumerable<ArticleServiceModel> GetLastThreeArticles();

        bool IsArticleExist(string id);
    }
}
