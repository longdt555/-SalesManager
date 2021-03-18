namespace Lib.Service.Dtos
{
    public class SystemSettingsDto : BaseDto
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
