using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Models
{
    public class Story : BaseEntity
    {
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public bool? Visible { get; set; }
    }
}
