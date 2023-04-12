using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int? AddressId { get; set; }
        public int StatusId { get; set; }
        public DateTime? DueDate { get; set; }
        public string TrackingNumber { get; set; } = null!;
        public int SaleId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual DeliveriesMethod DeliveryMethod { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
