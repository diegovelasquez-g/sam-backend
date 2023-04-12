using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int InitialStock { get; set; }
        public int CurrentStock { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? WithdrawalDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
