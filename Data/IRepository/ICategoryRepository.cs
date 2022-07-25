using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.IRepository
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        IEnumerable<Category> CategoryList();
        IEnumerable<Category> BindVisibleCategory();
        Category GetCategoryById(int id);
        void DeleteCategory(int id);
    }
}
