using Lib.Common.Global;
using Lib.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace YDManagement.Helpers
{
    public class AppHelpers
    {
        public static Jwt GetConfiguration()
        {
            var appName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return new Jwt
            {
                SecretKey = appName.GetSection("Jwt")["SecretKey"],
                Audience = appName.GetSection("Jwt")["Audience"],
                Issuer = appName.GetSection("Jwt")["Issuer"]
            };
        }
        public static bool ValidToken(string token) // validate jwt token
        {
            if (string.IsNullOrEmpty(token)) return false;
            var jwtConfiguration = GetConfiguration();
            if (jwtConfiguration == null) return false;

            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            try
            {
                if (token.Length <= 7) return false;
                var claimsPrincipal = handler.ValidateToken(token.Substring(7), validations, out _);
                return SetLoggedOnClientUser(claimsPrincipal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private static bool SetLoggedOnClientUser(ClaimsPrincipal claimsPrincipal) // get user's information by jwt token
        {
            if (claimsPrincipal == null)
            {
                LoggedOnClientUser.UserId = 0;
                LoggedOnClientUser.UserName = string.Empty;
                LoggedOnClientUser.Email = string.Empty;
                return false;
            }
            else
            {
                LoggedOnClientUser.UserId = int.TryParse(claimsPrincipal.Claims.First(x => x.Type.Equals("USERID"))?.Value, out var uId) ? uId : 0;
                LoggedOnClientUser.UserName = claimsPrincipal.Claims.First(x => x.Type.Equals("USERID"))?.Value;
                return true;
            }
        }
    }
}
