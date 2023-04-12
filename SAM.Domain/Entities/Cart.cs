using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartsItems = new HashSet<CartsItem>();
        }

        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CartsItem> CartsItems { get; set; }
    }
}
