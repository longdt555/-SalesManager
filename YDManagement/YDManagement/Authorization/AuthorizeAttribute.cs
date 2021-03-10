using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YDManagement.Authorization
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
                //LoggedOnUser.UserId = int.TryParse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value, out var uId) ? uId : 0;
                //LoggedOnUser.UserName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("USER_NAME"))?.Value;
                //LoggedOnUser.DisplayName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value;
                //LoggedOnUser.RoleId = int.TryParse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("ROLE_ID"))?.Value, out var rId) ? rId : 0;
                //LoggedOnUser.RoleName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            }

        }
    }
}