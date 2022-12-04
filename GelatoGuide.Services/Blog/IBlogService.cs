using System.Collections.Generic;
using GelatoGuide.Services.Blog.Models;

namespace GelatoGuide.Services.Blog;

public interface IBlogService
{
    AllArticlesServiceModel AllArticles(
        string searchTerm, string postedByName, string postedByYear,
        string postedByMonth, int articlesPerPage, int currentPage);

    IEnumerable<ArticleServiceModel> AllArticlesAdmin();

    IEnumerable<ArticleServiceModel> AllByUserId(string id);

    ArticleServiceModel ArticleById(string id);

    IEnumerable<ArticleServiceModel> GetLastThreeArticles();

    void CreateArticle(ArticleServiceModel model);

    void Update(string id, ArticleServiceModel model);

    void Delete(string id);

    IEnumerable<string> AllPostedByNames();

    IEnumerable<string> AllYears();

    IEnumerable<string> AllMonths();

    int TotalArticlesCount();

    bool IsArticleExist(string id);
}