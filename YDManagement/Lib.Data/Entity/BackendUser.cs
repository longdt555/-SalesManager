using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("backenduser")]
    public class BackendUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}