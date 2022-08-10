namespace FitnessWebAPI.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool? Visible { get; set; }
        public int DisplayOrder { get; set; }
        public string CategoryImage { get; set; }
        public string Quotes { get; set; }
    }
}
