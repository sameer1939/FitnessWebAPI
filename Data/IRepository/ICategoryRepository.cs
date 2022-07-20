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
        IEnumerable<Category> CategoryList();
        void DeleteCategory(int id);
    }
}
