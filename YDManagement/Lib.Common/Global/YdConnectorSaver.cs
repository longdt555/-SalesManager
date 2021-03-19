using System.Collections.Generic;
using System.Linq;
using Lib.Common.Model;

namespace Lib.Common.Global
{
    public static class YdConnectorSaver
    {
        public static List<CustomerModel> Customers { get; set; }
        public static List<BackendUserModel> BackendUsers { get; set; }

        static YdConnectorSaver()
        {
            Customers = new List<CustomerModel>();
            BackendUsers = new List<BackendUserModel>();
        }


        #region Customer

        public static CustomerModel Add(CustomerModel model)
        {
            Customers.Add(model);
            return model;
        }

        public static void RemoveCustomer(int id)
        {
            var data = Customers.FirstOrDefault(x => x.Id == id);
            Customers.Remove(data);
        }

        public static CustomerModel GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(x => x.Id == id);
        }

        #endregion

        #region Backend user

        public static BackendUserModel Add(BackendUserModel model)
        {
            BackendUsers.Add(model);
            return model;
        }

        public static void RemoveBackendUser(int id)
        {
            var data = BackendUsers.FirstOrDefault(x => x.Id == id);
            BackendUsers.Remove(data);
        }

        public static BackendUserModel GetBackendUserById(int id)
        {
            return BackendUsers.FirstOrDefault(x => x.Id == id);
        }

        #endregion
    }
}
