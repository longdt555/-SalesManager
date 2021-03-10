using System;
using Lib.Data.Entity;

namespace Lib.Service.Dtos
{
    public class OrderDto : BaseDto
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
    }
}
