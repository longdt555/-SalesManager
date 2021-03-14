using System.Collections.Generic;
using System.Linq;
using Lib.Common.Model;

namespace Lib.Common.Global
{
    public static class YdConnectorSaver
    {
        public static List<CustomerModel> Customers { get; set; }

        static YdConnectorSaver()
        {
            Customers = new List<CustomerModel>();
        }

        public static CustomerModel Add(CustomerModel customer)
        {
            Customers.Add(customer);
            return customer;
        }

        public static void Remove(int id)
        {
            var data = Customers.FirstOrDefault(x => x.Id == id);
            Customers.Remove(data);
        }

        public static CustomerModel GetById(int id)
        {
            return Customers.FirstOrDefault(x => x.Id == id);
        }

        public static void RemoveAll()
        {
            Customers.Clear();
        }
    }
}
