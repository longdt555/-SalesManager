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
using Lib.Common.Global;
using Lib.Common.Model;
using Lib.Service.Dtos;
using YDManagement.Helpers;

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
            var result = new JResultHelper();
            try
            {
                var data = _customerService.Authenticate(model);
                if (data == null) return response;
                var customerModel = _mapper.Map<CustomerModel>(data);
                YdConnectorSaver.Add(customerModel);
                CurrentContext.SetLoggedOnClientUser(customerModel);
                var tokenStr = GenerateAccessToken(data, model.RememberMe);
                if (tokenStr != null)
                    HttpContext.Session.SetString("JWToken", tokenStr);  //Save token in session object

                result.SetKey(tokenStr);
                result.SetData(data);
                result.SetStatusSuccess();
                return Ok(result);
            }
            catch (AppException ex)
            {
                result.SetMessage(ex.Message);
                result.SetStatusFailed();
                switch (ex.Message)
                {
                    case AppCodeStatus.CreateUserNameRequired:
                    case AppCodeStatus.CreatePasswordRequired:
                    case AppCodeStatus.TextLengthInvalid:
                    case AppCodeStatus.ContainsSpecialCharacter:
                    case AppCodeStatus.RegisterPasswordInvalid:
                        return Ok(result);
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
            Helpers.AppHelpers.RemoveCurrentUserData();
            HttpContext.Session.Clear();
            return NoContent();
        }
        #endregion

        #region private helper methods 
        private string GenerateAccessToken(CustomerDto data, bool rememberMe = false)
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
        private static IEnumerable<Claim> GetUserClaims(CustomerDto data)
        {
            var claims = new[]
           {
               new Claim("USERID", data.Id.ToString()),
               new Claim("EMAIL", data.Email)
           };
            return claims;
        }
        #endregion
    }
}
