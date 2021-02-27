using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("order")]
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = 1;
        public int Quantity { get; set; } = 1;
    }
}
