using AutoMapper;
using FitnessWebAPI.Data.IRepository;
using FitnessWebAPI.DTOs;
using FitnessWebAPI.Models;
using FitnessWebAPI.ViewModels;
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
    
    public class ArticleController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _environment;
        public ArticleController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
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
            var folder = Path.Combine("images", "ArticleImages");
            var pathToSave = Path.Combine(this._environment.WebRootPath, folder);
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
        public IActionResult UpdateArticle([FromForm] ArticleDTO articleDTO)
        {
            var art = _unitOfWork.ArticleRepository.GetArticleById(articleDTO.Id);
            if (articleDTO.Image != null)
            {
                var folder = Path.Combine("images", "ArticleImages");
                var pathToSave = Path.Combine(this._environment.WebRootPath, folder);
                var filename = ContentDispositionHeaderValue.Parse(articleDTO.Image.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, filename);
                var dbPath = Path.Combine(folder, filename);
                using (var steam = new FileStream(fullPath, FileMode.Create))
                {
                    articleDTO.Image.CopyTo(steam);
                }
                var existingFile = Path.Combine(this._environment.WebRootPath, art.Image);
                if (System.IO.File.Exists(existingFile))
                {
                    System.IO.File.Delete(existingFile);
                }
                art.Image = dbPath;
            }
            //var fileName = articleDTO.Image.FileName;
            
            art.CategoryId = articleDTO.CategoryId;
            art.SubCategoryId = articleDTO.SubCategoryId;
            art.HeadingName = articleDTO.Heading;
            art.ShortArticle = articleDTO.ShortArticle;
            art.ArticleInEnglish = articleDTO.ArticleInEnglish;
            art.ArticleInHindi = articleDTO.ArticleInHindi;
            art.Visible = articleDTO.Visible;
            _unitOfWork.ArticleRepository.UpdateArticle(art);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpGet("bindarticle")]
        public IActionResult ArticleList()
        {
            var result = _unitOfWork.ArticleRepository.ArticleList();
            var resultVM = _mapper.Map<IEnumerable<ArticleVM>>(result);
            return Ok(resultVM);
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
            var article = _unitOfWork.ArticleRepository.GetArticleById(id);
            // remove file from folder
            var pathToSave = Path.Combine(this._environment.WebRootPath, article.Image);
            if (System.IO.File.Exists(pathToSave))
            {
                System.IO.File.Delete(pathToSave);
            }
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

        [HttpGet("bindVisibleArticleFrontend/{catId}")]
        public IActionResult BindVisibleArticleFrontend(int catId)
        {
            var result = _unitOfWork.ArticleRepository.BindVisibleArticleFrontend(catId);
            return Ok(result);
        }
    }
}
