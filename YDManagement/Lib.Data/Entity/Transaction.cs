using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Lib.Common.Enums;

namespace Lib.Data.Entity
{
    [Table("transaction")]
    public class Transaction : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerCartId { get; set; }
        public virtual CustomerCart CustomerCart { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalMoney { get; set; }
        public string ShippingFee { get; set; }
        public CustomerCartStatusEnum Status { get; set; } = 0;
        public PaymentMethodEnum PaymentMethod { get; set; } = 0;
        public IEnumerable<TransactionDetails> TransactionDetails { get; set; }
    }
}
