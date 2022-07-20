using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Controllers
{
    
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost("add")]
        public IActionResult AddCategory(Category category)
        {
            if (category.Visible == null)
                category.Visible = false;
            category.InsertedDate = DateTime.Now;
            category.InsertedBy = 1;
            _categoryRepository.AddCategory(category);
            return Ok();
        }
        [HttpGet("bindcategory")]
        public IActionResult CategoryList()
        {
            var result = _categoryRepository.CategoryList();
            return Ok(result);
        }

        [HttpDelete("deletecategory/{id}")]
        public IActionResult CategoryList(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok();
        }
    }
}
