namespace Lib.Service.Dtos
{
   public class BackendUserDto:BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleDto Role { get; set; }
    }
}
