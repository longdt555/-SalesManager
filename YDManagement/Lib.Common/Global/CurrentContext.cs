using Lib.Common.Model;

namespace Lib.Common.Global
{
    public static class CurrentContext
    {
        private static CustomerModel LoggedOnClientUser { get; set; }
        private static BackendUserModel LoggedOnAdminUser { get; set; }

        public static void SetLoggedOnClientUser(CustomerModel customer)
        {
            LoggedOnClientUser = customer;
        }

        public static CustomerModel GetLoggedOnClientUser()
        {
            return LoggedOnClientUser;
        }


        public static void SetLoggedOnAdminUser(BackendUserModel model)
        {
            LoggedOnAdminUser = model;
        }

        public static BackendUserModel GetLoggedOnAdminUser()
        {
            return LoggedOnAdminUser;
        }
    }
}
