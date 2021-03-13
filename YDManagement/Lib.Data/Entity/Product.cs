using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("product")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; } = 0;
        public string Description { get; set; }
        public int Quantity { get; set; } = 0;
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}