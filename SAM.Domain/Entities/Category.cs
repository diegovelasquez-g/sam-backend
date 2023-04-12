namespace SAM.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductsCategories = new HashSet<ProductsCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
    }
}
