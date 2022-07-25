using AutoMapper;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
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

            CreateMap<SubCategory, SubCategoryListDTO>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        }
    }
}
