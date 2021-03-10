using Lib.Data.Entity;

namespace Lib.Common.Global
{
    public static class CurrentContext
    {
        public static Customer LoggedOnClientUser { get; set; }
        public static Customer LoggedOnAdminUser { get; set; }
    }
}
