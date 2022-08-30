using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.DTOs
{
    public class StoryDTO
    {
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool? Visible { get; set; }

    }
}
