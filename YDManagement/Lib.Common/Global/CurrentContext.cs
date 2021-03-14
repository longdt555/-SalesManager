using Lib.Common.Model;

namespace Lib.Common.Global
{
    public static class CurrentContext
    {
        private static CustomerModel LoggedOnClientUser { get; set; }

        public static void SetLoggedOnClientUser(CustomerModel customer)
        {
            LoggedOnClientUser = customer;
        }

        public static CustomerModel GetLoggedOnClientUser()
        {
            return LoggedOnClientUser;
        }


        private static CustomerModel LoggedOnAdminUser { get; set; }

        public static void SetLoggedOnAdminUser(CustomerModel customer)
        {
            LoggedOnAdminUser = customer;
        }

        public static CustomerModel GetLoggedOnAdminUser()
        {
            return LoggedOnAdminUser;
        }
    }
}
