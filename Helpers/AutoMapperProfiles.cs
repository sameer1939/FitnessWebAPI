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
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));

            CreateMap<SubCategory, SubCategoryListDTO>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        }
    }
}
