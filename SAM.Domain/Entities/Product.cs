using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartsItems = new HashSet<CartsItem>();
            ProductsCategories = new HashSet<ProductsCategory>();
            ProductsProviders = new HashSet<ProductsProvider>();
            SalesItems = new HashSet<SalesItem>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public string ProductCode { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int DiscountId { get; set; }
        public string? ProductImage { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Discount Discount { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Inventory? Inventory { get; set; }
        public virtual ICollection<CartsItem> CartsItems { get; set; }
        public virtual ICollection<ProductsCategory> ProductsCategories { get; set; }
        public virtual ICollection<ProductsProvider> ProductsProviders { get; set; }
        public virtual ICollection<SalesItem> SalesItems { get; set; }
    }
}
