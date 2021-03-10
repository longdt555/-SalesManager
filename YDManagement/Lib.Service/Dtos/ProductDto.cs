using System;
using Lib.Data.Entity;
using System.Collections.Generic;

namespace Lib.Service.Dtos
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
