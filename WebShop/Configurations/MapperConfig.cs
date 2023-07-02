using AutoMapper;
using WebShop.Data;
using WebShop.Models.Articles;
using WebShop.Models.ColorInfo;
using WebShop.Models.Users;
using WebShop.Models.VariantInfo;

namespace WebShop.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Article, CreateArticleDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, UpdateArticleDto>().ReverseMap();

            CreateMap<ColorInfo, CreateColorInfoDto>().ReverseMap();
            CreateMap<ColorInfo, ColorInfoDto>().ReverseMap();
            CreateMap<ColorInfo, UpdateColorInfoDto>().ReverseMap();

            CreateMap<VariantInfo, CreateVariantInfoDto>().ReverseMap();
            CreateMap<VariantInfo, VariantInfoDto>().ReverseMap();

            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
        }
    }
}
