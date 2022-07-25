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
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("add")]
        public IActionResult AddCategory(Category category)
        {
            category.InsertedDate = DateTime.Now;
            category.InsertedBy = 1;
            _unitOfWork.CategoryRepository.AddCategory(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.UpdateCategory(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("bindcategory")]
        public IActionResult CategoryList()
        {
            var result = _unitOfWork.CategoryRepository.CategoryList();
            return Ok(result);
        }
        [HttpGet("bindVisibleCategory")]
        public IActionResult BindVisibleCategory()
        {
            var result = _unitOfWork.CategoryRepository.BindVisibleCategory();
            return Ok(result);
        }

        [HttpDelete("deletecategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.DeleteCategory(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        [HttpGet("categoryById/{id}")]
        public IActionResult CategoryById(int id)
        {
            var result = _unitOfWork.CategoryRepository.GetCategoryById(id);
            return Ok(result);
        }
    }
}
