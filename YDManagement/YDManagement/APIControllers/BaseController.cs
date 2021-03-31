using Lib.Common.Global;
using Lib.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace YDManagement.APIControllers
{
    public class BaseController : ControllerBase
    {
        public CustomerModel ClientCurrentUser = CurrentContext.GetLoggedOnClientUser();
        public BackendUserModel AdminCurrentUser = CurrentContext.GetLoggedOnAdminUser();

        public static void RemoveCurrentCustomerData()
        {
            YdConnectorSaver.RemoveCustomer(CurrentContext.GetLoggedOnClientUser().Id);
            CurrentContext.SetLoggedOnClientUser(null);
        }

        public static void RemoveCurrentBackendUserData()
        {
            YdConnectorSaver.RemoveBackendUser(CurrentContext.GetLoggedOnAdminUser().Id);
            CurrentContext.SetLoggedOnAdminUser(null);
        }
    }
}