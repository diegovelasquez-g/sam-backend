using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Status
    {
        public Status()
        {
            Deliveries = new HashSet<Delivery>();
            Payments = new HashSet<Payment>();
            Products = new HashSet<Product>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusType { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
