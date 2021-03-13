using Lib.Data.Entity;

namespace Lib.Common.Global
{
    public static class CurrentContext
    {
        private static Customer LoggedOnClientUser { get; set; }

        public static void SetLoggedOnClientUser(Customer customer)
        {
            LoggedOnClientUser = customer;
        }

        public static Customer GetLoggedOnClientUser()
        {
            return LoggedOnClientUser;
        }


        private static Customer LoggedOnAdminUser { get; set; }

        public static void SetLoggedOnAdminUser(Customer customer)
        {
            LoggedOnAdminUser = customer;
        }

        public static Customer GetLoggedOnAdminUser()
        {
            return LoggedOnAdminUser;
        }
    }
}
