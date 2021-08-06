using System.Collections.Generic;
using GelatoGuide.Models.Blog;
using GelatoGuide.Services.Blog.Models;

namespace GelatoGuide.Services.Blog
{
    public interface IBlogService
    {
        void CreateArticle(
            string title, string subTitle, string image, string articleText,
            string sourceName, string sourceUrl, string postedByName);

        IEnumerable<AllArticlesServiceModel> GetAllArticles(string searchTerm, string postedByName, string postedByYear, string postedByMonth);

        IEnumerable<string> GetAllPostedByNames();

        IEnumerable<string> GetAllYears();

        IEnumerable<string> GetAllMonths();
    }
}
