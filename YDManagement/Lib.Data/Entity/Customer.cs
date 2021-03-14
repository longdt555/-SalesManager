using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Lib.Common.Enums;

namespace Lib.Data.Entity
{
    [Table("customer")]
    public class Customer : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public CustomerStatusEnum Status { get; set; } = 0;
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<CustomerProfile> CustomerProfiles { get; set; }
        public virtual IEnumerable<CustomerCart> CustomerCarts { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}