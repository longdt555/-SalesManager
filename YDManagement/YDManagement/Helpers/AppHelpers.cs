using Lib.Common.Global;

namespace YDManagement.Helpers
{
    public static class AppHelpers
    {
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
