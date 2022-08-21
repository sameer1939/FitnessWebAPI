using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Models
{
    public class Article : BaseEntity
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string HeadingName { get; set; }
        public string ShortArticle { get; set; }
        public string ArticleInEnglish { get; set; }
        public string ArticleInHindi { get; set; }
        public string Image { get; set; }
        public bool Visible { get; set; }
        public int Views { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
