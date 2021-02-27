using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Data.Entity
{
    [Table("customer")]
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
