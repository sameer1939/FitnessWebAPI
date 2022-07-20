using System;

namespace FitnessWebAPI.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public int InsertedBy { get; set; }
    }
}
