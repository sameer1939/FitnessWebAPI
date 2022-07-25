using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
        }
        public void UpdateCategory(Category category)
        {
            var cat = GetCategoryById(category.Id);
            cat.Name = category.Name;
            cat.Visible = category.Visible;
            _db.Categories.Update(cat);
        }

        public IEnumerable<Category> CategoryList()
        {
            return _db.Categories.ToList();
        }
        public IEnumerable<Category> BindVisibleCategory()
        {
            return _db.Categories.Where(x=>x.Visible==true);
        }

        public void DeleteCategory(int id)
        {
            var entity = _db.Categories.Find(id);
            _db.Categories.Remove(entity);
        }

        public Category GetCategoryById(int id)
        {
            return _db.Categories.Find(id);
        }
    }
}
