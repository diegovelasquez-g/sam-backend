using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Discount
    {
        public Discount()
        {
            Products = new HashSet<Product>();
        }

        public int DiscountId { get; set; }
        public string DiscountName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Percentage { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
