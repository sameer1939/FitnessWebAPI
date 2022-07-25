using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Models
{
    public class SubCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool? Visible { get; set; }
        public Category Category { get; set; }
    }
}
