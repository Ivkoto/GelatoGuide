using GelatoGuide.Services.Blog.Models;
using System.Collections.Generic;
using GelatoGuide.Data.Models;

namespace GelatoGuide.Services.Blog
{
    public interface IBlogService
    {
        void CreateArticle(ArticleServiceModel model);

        AllArticlesServiceModel AllArticles(
            string searchTerm, string postedByName, string postedByYear, 
            string postedByMonth, int articlesPerPage, int currentPage);

        IEnumerable<ArticleServiceModel> AllArticlesAdmin();

        void Update(string id, ArticleServiceModel model);

        void Delete(string id);

        IEnumerable<string> AllPostedByNames();

        IEnumerable<string> AllYears();

        IEnumerable<string> AllMonths();

        IEnumerable<ArticleServiceModel> AllByUserId(string id);

        ArticleServiceModel ArticleById(string id);

        int TotalArticlesCount();

        IEnumerable<ArticleServiceModel> GetLastThreeArticles();

        bool IsArticleExist(string id);
    }
}
