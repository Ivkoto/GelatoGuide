using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Blog;
using GelatoGuide.Areas.Administration.Models.Places;
using GelatoGuide.Data.Models;
using GelatoGuide.Models.Blog;
using GelatoGuide.Models.Places;
using GelatoGuide.Services.Blog.Models;
using GelatoGuide.Services.Places.Models;
using GelatoGuide.Services.Shop.Models;

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

            this.CreateMap<ArticleServiceModel, ArticleDetailsViewModel>();

            this.CreateMap<ArticleFormModel, ArticleServiceModel>();

            this.CreateMap<CreatePlaceFormModel, PlaceServiceModel>().ReverseMap();

            this.CreateMap<PlaceServiceModel, Place>().ReverseMap();

            this.CreateMap<Place, CreatePlaceFormModel>();

            this.CreateMap<PlaceServiceModel, PlaceDetailsVewModel>();

            this.CreateMap<ShopItem, ShopItemServiceModel>();

        }
    }
}
