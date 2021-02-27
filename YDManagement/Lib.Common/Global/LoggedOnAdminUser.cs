using System;
using Lib.Common.Helpers;

namespace Lib.Common.Global
{
    public static class LoggedOnAdminUser
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int LanguageId { get; set; } = 0;
        public static int RoleId { get; set; }
        public static string RoleName { get; set; }
        public static string RoleTitle { get; set; }
        public static string DisplayName { get; set; }
        public static DateTime? LastLoginTime { get; set; }
        public static string LastLoginTimeStr =>
            LastLoginTime.HasValue ?
                $"{LastLoginTime.Value.Day}/{LastLoginTime.Value.Month}/{LastLoginTime.Value.Year} {LastLoginTime.Value.Hour}:{LastLoginTime.Value.Minute}"
                : string.Empty;

        public static string Token => Security.EncryptKey(UserId.ToString());
    }
}
