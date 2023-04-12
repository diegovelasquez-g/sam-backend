using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Address
    {
        public Address()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string Municipality { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
