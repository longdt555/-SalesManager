using Lib.Common.Enums;
using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
   public class TransactionDto : BaseDto
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerCartId { get; set; }
        public virtual CustomerCart CustomerCart { get; set; }
        public decimal TotalMoney { get; set; }
        public string ShippingFee { get; set; }
        public CustomerCartStatusEnum Status { get; set; } = 0;
        public PaymentMethodEnum PaymentMethod { get; set; } = 0;
        public IEnumerable<TransactionDetail> TransactionDetails { get; set; }
    }
}
