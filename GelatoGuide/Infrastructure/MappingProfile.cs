using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Blog;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data.Models;
using GelatoGuide.Services.Blog.Models;
using GelatoGuide.Services.Places.Models;

namespace GelatoGuide.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CreateArticleFormModel, ArticleServiceModel>().ReverseMap();

            this.CreateMap<Article, ArticleServiceModel>()
                .ForMember(asm => asm.UserName, cfg => cfg.MapFrom(a => $"{a.User.FullName} ({a.User.UserName})"))
                .ReverseMap();

            this.CreateMap<CreatePlaceFormModel, PlaceServiceModel>();

            this.CreateMap<PlaceServiceModel, Place>().ReverseMap();

            this.CreateMap<Place, CreatePlaceFormModel>();
        }
    }
}
