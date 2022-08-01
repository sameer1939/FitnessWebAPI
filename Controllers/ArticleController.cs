using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FitnessWebAPI.Controllers
{
    
    public class ArticleController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("add")]
        public IActionResult AddArticle([FromForm]ArticleDTO articleDTO)
        {
            Article article = new Article();
            if (articleDTO.Image == null)
            {
                return BadRequest("File cannot be null or empty");
            }
            //var fileName = articleDTO.Image.FileName;
            var folder = Path.Combine("Resources", "ArticleImages");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);
            var filename = ContentDispositionHeaderValue.Parse(articleDTO.Image.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, filename);
            var dbPath = Path.Combine(folder, filename);
            using (var steam = new FileStream(fullPath,FileMode.Create))
            {
                articleDTO.Image.CopyTo(steam);
            }
            article.InsertedDate = DateTime.Now;
            article.InsertedBy = 1;
            article.CategoryId = articleDTO.CategoryId;
            article.SubCategoryId = articleDTO.SubCategoryId;
            article.HeadingName = articleDTO.Heading;
            article.ShortArticle = articleDTO.ShortArticle;
            article.Image = dbPath;
            article.ArticleInEnglish = articleDTO.ArticleInEnglish;
            article.ArticleInHindi = articleDTO.ArticleInHindi;
            article.Visible = articleDTO.Visible;
            _unitOfWork.ArticleRepository.AddArticle(article);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateArticle(Article category)
        {
            _unitOfWork.ArticleRepository.UpdateArticle(category);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("bindarticle")]
        public IActionResult ArticleList()
        {
            var result = _unitOfWork.ArticleRepository.ArticleList();
            return Ok(result);
        }
        [HttpGet("bindVisibleArticle")]
        public IActionResult BindVisibleArticle()
        {
            var result = _unitOfWork.ArticleRepository.BindVisibleArticle();
            return Ok(result);
        }

        [HttpDelete("deletearticle/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            _unitOfWork.ArticleRepository.DeleteArticle(id);
            _unitOfWork.SaveChanges();
            return Ok();
        }
        [HttpGet("articleById/{id}")]
        public IActionResult ArticleById(int id)
        {
            var result = _unitOfWork.ArticleRepository.GetArticleById(id);
            return Ok(result);
        }
    }
}
