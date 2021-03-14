using System;
using System.ComponentModel.DataAnnotations.Schema;
using Lib.Common.Enums;

namespace Lib.Data.Entity
{
    [Table("expiredlink")]
    public class ExpiredLink : BaseImpact
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public string SoftKey { get; set; }
        public string Value { get; set; }
        public ExpiredLinkEnum Type { get; set; }
        public int? State { get; set; } = 0; // Link's available
    }
}
