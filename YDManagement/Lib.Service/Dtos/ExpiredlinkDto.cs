using System;
using System.Collections.Generic;
using System.Text;
using Lib.Common.Enums;
using Lib.Data.Entity;

namespace Lib.Service.Dtos
{
    public class ExpiredlinkDto : BaseDto
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public string SoftKey { get; set; }
        public string Value { get; set; }
        public ExpiredLinkEnum Type { get; set; }
        public int? State { get; set; } = 0;
    }
}
