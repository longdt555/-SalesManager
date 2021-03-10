using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class CustomerDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
