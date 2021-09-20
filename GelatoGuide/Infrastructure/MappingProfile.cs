using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Blog;
using GelatoGuide.Services.Blog.Models;

namespace GelatoGuide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CreateArticleFormModel, ArticleServiceModel>();
        }
    }
}
