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
            _db.SaveChanges();
        }

        public IEnumerable<Category> CategoryList()
        {
            return _db.Categories.ToList();
        }

        public void DeleteCategory(int id)
        {
            var entity = _db.Categories.Find(id);
            _db.Categories.Remove(entity);
            _db.SaveChanges();
        }
    }
}
