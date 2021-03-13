using Lib.Data.Entity;

namespace Lib.Service.Dtos
{
    public class OrderDto : BaseDto
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public decimal Amount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
    }
}
