using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Heading { get; set; }
        public string ShortArticle { get; set; }
        public string ArticleInEnglish { get; set; }
        public string ArticleInHindi { get; set; }
        public IFormFile Image { get; set; }
        public bool Visible { get; set; }
    }
}
