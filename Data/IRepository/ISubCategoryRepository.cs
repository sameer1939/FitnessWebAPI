﻿using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface ISubCategoryRepository
    {
        void AddSubCategory(SubCategory category);
        void UpdateSubCategory(SubCategory category);
        IEnumerable<SubCategory> SubCategoryList();
        IEnumerable<SubCategory> BindVisibleSubCategory();
        SubCategory GetSubCategoryById(int id);
        Task<List<SubCategoryDTO>> GetSubCategoryByCategoryId(int id);
        void DeleteSubCategory(int id);
        IEnumerable<SubCategoryDTO> BindRandomVisibleSubCategory(int records);
    }
}
