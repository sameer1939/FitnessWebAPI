using AutoMapper;
using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Controllers
{
    
    public class SubCategoryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public IActionResult AddSubCategory(SubCategoryDTO subCategory)
        {
            var category = _mapper.Map<SubCategory>(subCategory);
            category.InsertedDate = DateTime.Now;
            category.InsertedBy = 1;
            _unitOfWork.SubCategoryRepository.AddSubCategory(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateSubCategory(SubCategoryDTO subCategory)
        {
            var category = _mapper.Map<SubCategory>(subCategory);
            _unitOfWork.SubCategoryRepository.UpdateSubCategory(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        [HttpGet("bindSubCategory")]
        public IActionResult SubCategoryList()
        {
            var result = _unitOfWork.SubCategoryRepository.SubCategoryList();
            var subCategoryList = _mapper.Map<IEnumerable<SubCategoryListDTO>>(result);
            return Ok(subCategoryList);
        }
        [HttpGet("bindVisibleSubCategory")]
        public IActionResult BindVisibleSubCategory()
        {
            var result = _unitOfWork.SubCategoryRepository.BindVisibleSubCategory();
            return Ok(result);
        }

        [HttpDelete("deletesubcategory/{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            _unitOfWork.SubCategoryRepository.DeleteSubCategory(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        [HttpGet("subCategoryById/{id}")]
        public IActionResult SubCategoryById(int id)
        {
            var result = _unitOfWork.SubCategoryRepository.GetSubCategoryById(id);
            return Ok(result);
        }
        [HttpGet("getbyCategoryId/{id}")]
        public async Task<IActionResult> GetSubCategoryByCategoryId(int id)
        {
            var result = await _unitOfWork.SubCategoryRepository.GetSubCategoryByCategoryId(id);
            return Ok(result);
        }
        [HttpGet("bindRandomVisibleSubCategory/{records}")]
        public IActionResult BindRandomVisibleSubCategory(int records)
        {
            var result = _unitOfWork.SubCategoryRepository.BindRandomVisibleSubCategory(records);
            return Ok(result);
        }
    }
}
