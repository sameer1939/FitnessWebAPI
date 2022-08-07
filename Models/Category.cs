namespace FitnessWebAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool? Visible { get; set; }
        public int DisplayOrder { get; set; }
    }
}
