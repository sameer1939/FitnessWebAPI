using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebAPI.Models
{
    public class Comment : BaseEntity
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
