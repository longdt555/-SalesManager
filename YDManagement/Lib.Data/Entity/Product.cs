using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("product")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}