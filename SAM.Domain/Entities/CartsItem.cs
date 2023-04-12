using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class CartsItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotal { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
