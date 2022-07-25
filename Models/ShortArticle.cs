using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Models
{
    public class ShortArticle : BaseEntity
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string HeadingName { get; set; }
        public string Article { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
