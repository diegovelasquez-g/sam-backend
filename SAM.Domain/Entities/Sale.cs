using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Sale
    {
        public Sale()
        {
            SalesItems = new HashSet<SalesItem>();
        }

        public int SaleId { get; set; }
        public string SaleCode { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Delivery? Delivery { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<SalesItem> SalesItems { get; set; }
    }
}
