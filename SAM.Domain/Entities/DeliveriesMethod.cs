using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class DeliveriesMethod
    {
        public DeliveriesMethod()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int DeliveryMethodId { get; set; }
        public string Method { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
