using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class PaymentsMethod
    {
        public PaymentsMethod()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentMethodId { get; set; }
        public string Method { get; set; } = null!;
        public bool IsActive { get; set; }
        public int StatusId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
