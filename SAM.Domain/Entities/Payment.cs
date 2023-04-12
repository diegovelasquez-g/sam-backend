using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int SaleId { get; set; }
        public decimal TotalPrice { get; set; }
        public int StatusId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethodId { get; set; }

        public virtual PaymentsMethod PaymentMethod { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
