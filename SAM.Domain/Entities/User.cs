using System;
using System.Collections.Generic;

namespace SAM.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            Sales = new HashSet<Sale>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string? FullName { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Token { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
