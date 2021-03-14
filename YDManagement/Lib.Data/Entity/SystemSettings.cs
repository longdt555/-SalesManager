using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Data.Entity
{
    [Table("systemsettings")]
    public class SystemSettings : BaseImpact
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}