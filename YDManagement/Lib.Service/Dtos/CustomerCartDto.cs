using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class CustomerCartDto : BaseDto
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ShippingFee { get; set; }
        public int Quantity { get; set; } = 1;
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
