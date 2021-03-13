using Lib.Common.Global;
using Lib.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace YDManagement.APIControllers
{
    public class BaseController : ControllerBase
    {
        public static Customer ClientCurrentUser = CurrentContext.GetLoggedOnClientUser();
        public static Customer AdminCurrentUser = CurrentContext.GetLoggedOnAdminUser();
    }
}
