using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.ViewModels
{
    public class ArticleVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Heading { get; set; }
        public string ShortArticle { get; set; }
        public string ArticleInEnglish { get; set; }
        public string ArticleInHindi { get; set; }
        public string Image { get; set; }
        public bool Visible { get; set; }
    }
}
