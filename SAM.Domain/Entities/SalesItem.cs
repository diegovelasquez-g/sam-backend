using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class SalesItem
    {
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ItemQuantity { get; set; }
        public int DiscountId { get; set; }
        public decimal ItemTotal { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
    }
}
