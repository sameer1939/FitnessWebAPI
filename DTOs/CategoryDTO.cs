using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Visible { get; set; }
        public int DisplayOrder { get; set; }
        public IFormFile CategoryImage { get; set; }
        public string Quotes { get; set; }
    }
}
