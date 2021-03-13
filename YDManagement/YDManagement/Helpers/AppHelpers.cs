using Lib.Common.Global;

namespace YDManagement.Helpers
{
    public static class AppHelpers
    {
        public static void RemoveCurrentUserData()
        {
            YdConnectorSaver.Remove(CurrentContext.GetLoggedOnClientUser().Id);
            CurrentContext.SetLoggedOnClientUser(null);
        }
    }
}
