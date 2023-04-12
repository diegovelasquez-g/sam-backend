using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            ProductsProviders = new HashSet<ProductsProvider>();
        }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = null!;
        public string? Description { get; set; }
        public string Country { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ProductsProvider> ProductsProviders { get; set; }
    }
}
