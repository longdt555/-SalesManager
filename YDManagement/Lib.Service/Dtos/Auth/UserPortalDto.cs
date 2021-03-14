namespace Lib.Service.Dtos.UserPortal
{
    public class UserPortalDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
