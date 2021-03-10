using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Service.Dtos.UserPortal;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lib.Data.Entity;

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Jwt _jwt;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public AuthenticationController(IOptions<Jwt> jwt, IMapper mapper, ICustomerService customerService)
        {
            _jwt = jwt.Value;
            _mapper = mapper;
            _customerService = customerService;
        }
        #region SignIn
        /// <summary>
        ///  SignIn
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("ClientLogin")]
        public IActionResult ClientLogin([FromBody] UserPortalDto model)
        {
            IActionResult response = Unauthorized();
            try
            {
                var data = _customerService.Authenticate(model);
                if (data == null) return response;

                var tokenStr = GenerateAccessToken(data, model.RememberMe);
                if (tokenStr != null)
                    HttpContext.Session.SetString("JWToken", tokenStr);  //Save token in session object

                return Ok(new
                {
                    accessToken = tokenStr,
                    data
                });
            }
            catch (AppException ex)
            {
                switch (ex.Message)
                {
                    case AppCodeStatus.CreateUserNameRequired:
                    case AppCodeStatus.CreatePasswordRequired:
                        return Ok(new { StatusCode = StatusCodes.Status411LengthRequired, ex.Message });
                    case AppCodeStatus.TextLengthInvalid:
                    case AppCodeStatus.ContainsSpecialCharacter:
                    case AppCodeStatus.RegisterPasswordInvalid:
                        return Ok(new { StatusCode = StatusCodes.Status409Conflict, ex.Message });
                    default:
                        return response;
                }
            }

        }

        /// <summary>
        /// Sign out
        /// </summary>
        /// <returns></returns>
        [HttpPost("ClientLogout")]
        public IActionResult ClientLogout()
        {
            HttpContext.Session.Clear();
            return NoContent();
        }
        #endregion

        #region private helper methods 
        private string GenerateAccessToken(Customer data, bool rememberMe = false)
        {
            var expiresVal = rememberMe
                ? new DateTimeOffset(DateTime.Now.AddYears(1)).DateTime
                : new DateTimeOffset(DateTime.Now.AddMinutes(60))
                    .DateTime; // in this case: user selected remember me button
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: GetUserClaims(data),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: expiresVal,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static IEnumerable<Claim> GetUserClaims(Customer data)
        {
            var claims = new[]
           {
               new Claim("USERID", data.Id.ToString()),
               new Claim("USERNAME", data.UserName ?? string.Empty)
           };
            return claims;
        }
        #endregion
    }
}
