namespace Lib.Service.Dtos.Auth
{
    public class UserPortalDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
