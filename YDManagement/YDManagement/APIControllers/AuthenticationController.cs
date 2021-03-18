using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
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
using Lib.Service.Dtos.Auth;
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
        private readonly IBackendUserService _backendUserService;

        public AuthenticationController(IOptions<Jwt> jwt, IMapper mapper, ICustomerService customerService,
            IBackendUserService backendUserService)
        {
            _jwt = jwt.Value;
            _mapper = mapper;
            _customerService = customerService;
            _backendUserService = backendUserService;
        }

        #region Client

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
                YdConnectorSaver.Add(customerModel); // add logged user to static list connector
                CurrentContext.SetLoggedOnClientUser(customerModel); // Set logged user to static model
                var tokenStr = GenerateAccessToken(data, model.RememberMe);
                if (tokenStr != null)
                    HttpContext.Session.SetString("JWToken", tokenStr); //Save token in session object

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

        [HttpPost("ClientLogout")]
        public IActionResult ClientLogout()
        {
            Helpers.AppHelpers.RemoveCurrentCustomerData();
            HttpContext.Session.Clear();
            return NoContent();
        }

        #endregion

        #region Admin portal

        [AllowAnonymous]
        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin([FromBody] UserPortalDto model)
        {
            IActionResult response = Unauthorized();
            var result = new JResultHelper();
            try
            {
                var data = _backendUserService.Authenticate(model);
                if (data == null) return response;
                var backendUserModel = _mapper.Map<BackendUserModel>(data);
                YdConnectorSaver.Add(backendUserModel); // add logged user to static list connector
                CurrentContext.SetLoggedOnAdminUser(backendUserModel); // Set logged user to static model
                var tokenStr = GenerateAccessToken(data, model.RememberMe);
                if (tokenStr != null)
                    HttpContext.Session.SetString("JWToken", tokenStr); //Save token in session object

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

        #endregion

        #region private helper methods

        private string GenerateAccessToken(CustomerDto data, bool rememberMe = false)
        {
            var expiresVal = rememberMe
                ? new DateTimeOffset(DateTime.Now.AddMonths(3)).DateTime
                : new DateTimeOffset(DateTime.Now.AddMinutes(30))
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

        private string GenerateAccessToken(BackendUserDto data, bool rememberMe = false)
        {
            var expiresVal = rememberMe
                ? new DateTimeOffset(DateTime.Now.AddMonths(3)).DateTime
                : new DateTimeOffset(DateTime.Now.AddMinutes(30))
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

        private static IEnumerable<Claim> GetUserClaims(BackendUserDto data)
        {
            var claims = new[]
            {
                new Claim("USERID", data.Id.ToString()),
                new Claim("USERNAME", data.UserName)
            };
            return claims;
        }

        #endregion
    }
}
