using AutoMapper;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using FitnessWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<Article, ArticleDTO>().ReverseMap();

            CreateMap<Article, ArticleVM>()
                .ForMember(x => x.Heading, opt => opt.MapFrom(src => src.HeadingName))
                .ForMember(x => x.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.SubCategoryName))
                .ForMember(x => x.TotalViews, opt => opt.MapFrom(src => NumberFormatter(src.Views)))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));

            CreateMap<SubCategory, SubCategoryListDTO>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        }

        public static string NumberFormatter(long num)
        {
            long i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
            num = num / i * i;

            if (num >= 1000000000)
                return (num / 1000000000D).ToString("0.##") + "B";
            if (num >= 1000000)
                return (num / 1000000D).ToString("0.##") + "M";
            if (num >= 1000)
                return (num / 1000D).ToString("0.##") + "K";

            return num.ToString("#,0");
        }
    }
}
