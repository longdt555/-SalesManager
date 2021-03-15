using Lib.Common.Global;
using Lib.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace YDManagement.APIControllers
{
    public class BaseController : ControllerBase
    {
        public static CustomerModel ClientCurrentUser = CurrentContext.GetLoggedOnClientUser();
        public static BackendUserModel AdminCurrentUser = CurrentContext.GetLoggedOnAdminUser();
    }
}
