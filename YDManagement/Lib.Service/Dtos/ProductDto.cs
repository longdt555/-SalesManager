using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quanity { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
