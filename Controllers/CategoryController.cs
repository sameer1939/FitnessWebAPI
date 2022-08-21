using AutoMapper;
using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FitnessWebAPI.Controllers
{

    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _environment;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment environment, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult AddCategory([FromForm] CategoryDTO dtos)
        {
            Category category = new Category();
            if (dtos.CategoryImage == null)
            {
                return BadRequest("File cannot be null or empty");
            }
            var folder = Path.Combine("images", "CategoryImages");
            var pathToSave = Path.Combine(this._environment.WebRootPath, folder);
            //var filename = ContentDispositionHeaderValue.Parse(dtos.CategoryImage.ContentDisposition).FileName.Trim('"');
            var filename = Guid.NewGuid() + Path.GetExtension(dtos.CategoryImage.FileName);
            var fullPath = Path.Combine(pathToSave, filename);
            var dbPath = Path.Combine(folder, filename);
            using (var steam = new FileStream(fullPath, FileMode.Create))
            {
                dtos.CategoryImage.CopyTo(steam);
            }
            category.InsertedDate = DateTime.Now;
            category.InsertedBy = 1;
            category.Quotes = dtos.Quotes;
            category.Name = dtos.Name;
            category.CategoryImage = dbPath;
            _unitOfWork.CategoryRepository.AddCategory(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateCategory([FromForm]CategoryDTO categoryDTO)
        {

            var cat = _unitOfWork.CategoryRepository.GetCategoryById(categoryDTO.Id);
            if (categoryDTO.CategoryImage != null)
            {
                var folder = Path.Combine("images", "CategoryImages");
                var pathToSave = Path.Combine(this._environment.WebRootPath, folder);
                //var filename = ContentDispositionHeaderValue.Parse(categoryDTO.CategoryImage.ContentDisposition).FileName.Trim('"');
                var filename = Guid.NewGuid() + Path.GetExtension(categoryDTO.CategoryImage.FileName);
                var fullPath = Path.Combine(pathToSave, filename);
                var dbPath = Path.Combine(folder, filename);
                using (var steam = new FileStream(fullPath, FileMode.Create))
                {
                    categoryDTO.CategoryImage.CopyTo(steam);
                }
                if (cat.CategoryImage != null)
                {
                    var existingFile = Path.Combine(this._environment.WebRootPath, cat.CategoryImage);
                    if (System.IO.File.Exists(existingFile))
                    {
                        System.IO.File.Delete(existingFile);
                    }
                } 
                cat.CategoryImage = dbPath;
            }
            cat.Name = categoryDTO.Name;
            cat.Visible = categoryDTO.Visible;
            cat.Quotes = categoryDTO.Quotes;
            
            _unitOfWork.CategoryRepository.UpdateCategory(cat);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("bindcategory")]
        public IActionResult CategoryList()
        {
            var result = _unitOfWork.CategoryRepository.CategoryList();
            return Ok(result);
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet("categoryById/{id}")]
        public IActionResult CategoryById(int id)
        {
            var result = _unitOfWork.CategoryRepository.GetCategoryById(id);
            return Ok(result);
        }
    }
}
