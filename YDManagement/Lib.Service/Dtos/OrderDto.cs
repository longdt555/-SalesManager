using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class OrderDto : BaseDto
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}
