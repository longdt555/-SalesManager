using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("role")]
    public class Role : BaseImpact
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<BackendUser> BackendUsers { get; set; }
    }
}