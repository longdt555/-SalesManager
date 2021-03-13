using System.Collections.Generic;
using System.Linq;
using Lib.Data.Entity;

namespace Lib.Common.Global
{
    public static class YdConnectorSaver
    {
        public static List<Customer> Customers { get; set; }

        static YdConnectorSaver()
        {
            Customers = new List<Customer>();
        }

        public static Customer Add(Customer customer)
        {
            Customers.Add(customer);
            return customer;
        }

        public static void Remove(int id)
        {
            var data = Customers.FirstOrDefault(x => x.Id == id);
            Customers.Remove(data);
        }

        public static Customer GetById(int id)
        {
            return Customers.FirstOrDefault(x => x.Id == id);
        }

        public static void RemoveAll()
        {
            Customers.Clear();
        }
    }
}
