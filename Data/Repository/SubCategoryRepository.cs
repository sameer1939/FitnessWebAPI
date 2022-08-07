using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Data.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddSubCategory(SubCategory category)
        {
            _db.SubCategories.Add(category);
        }
        public void UpdateCategory(SubCategory category)
        {
            var cat = GetSubCategoryById(category.Id);
            cat.CategoryId = category.CategoryId;
            cat.SubCategoryName = category.SubCategoryName;
            cat.Visible = category.Visible;
            _db.SubCategories.Update(cat);
        }

        public IEnumerable<SubCategory> SubCategoryList()
        {
            return _db.SubCategories.Include(x=>x.Category).ToList();
        }
        public IEnumerable<SubCategory> BindVisibleSubCategory()
        {
            return _db.SubCategories.Where(x=>x.Visible==true);
        }

        public void DeleteSubCategory(int id)
        {
            var entity = _db.SubCategories.Find(id);
            _db.SubCategories.Remove(entity);
        }
        public SubCategory GetSubCategoryById(int id)
        {
            return _db.SubCategories.Find(id);
        }

        public void UpdateSubCategory(SubCategory category)
        {
            var cat = GetSubCategoryById(category.Id);
            cat.CategoryId = category.CategoryId;
            cat.SubCategoryName = category.SubCategoryName;
            cat.Visible = category.Visible;
            _db.SubCategories.Update(cat);
        }
        public async Task<List<SubCategory>> GetSubCategoryByCategoryId(int id)
        {
            return await _db.SubCategories.Where(x=>x.CategoryId==id && x.Visible==true).ToListAsync();
        }
    }
}
