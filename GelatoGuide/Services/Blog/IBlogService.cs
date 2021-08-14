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

        IEnumerable<ArticleServiceModel> GetAllArticles(string searchTerm, string postedByName, string postedByYear, string postedByMonth);

        void Edit(string id, ArticleServiceModel model);

        void Delete(Article article);

        IEnumerable<string> GetAllPostedByNames();

        IEnumerable<string> GetAllYears();

        IEnumerable<string> GetAllMonths();

        IEnumerable<ArticleServiceModel> GetAllByUserId(string id);

        Article GetArticleById(string id);
    }
}
