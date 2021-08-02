﻿using System.Collections.Generic;
using GelatoGuide.Models.Blog;

namespace GelatoGuide.Services.Blog
{
    public interface IBlogService
    {
        void CreateArticle(CreateArticleFormModel article);

        IEnumerable<AllArticlesViewModel> GetAllArticles(SearchArticlesViewModel searchModel);

        IEnumerable<string> GetAllPostedByNames();

        IEnumerable<string> GetAllYears();

        IEnumerable<string> GetAllMonths();
    }
}