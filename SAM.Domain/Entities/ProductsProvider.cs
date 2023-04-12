using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class ProductsProvider
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
    }
}
