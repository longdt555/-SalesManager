using Lib.Data.Entity;
using System.Collections.Generic;

namespace Lib.Service.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public decimal Price { get; set; } = 0;
        public string Description { get; set; }
        public int Quantity { get; set; } = 0;
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
