using System;
using System.Linq;
using System.Security.Claims;
using Lib.Common.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlcDigiLinkApi.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                LoggedOnAdminUser.UserId = int.TryParse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value, out var uId) ? uId : 0;
                LoggedOnAdminUser.UserName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("USER_NAME"))?.Value;
                LoggedOnAdminUser.DisplayName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value;
                LoggedOnAdminUser.RoleId = int.TryParse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("ROLE_ID"))?.Value, out var rId) ? rId : 0;
                LoggedOnAdminUser.RoleName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            }

        }
    }
}