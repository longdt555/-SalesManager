using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class CategoryDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
