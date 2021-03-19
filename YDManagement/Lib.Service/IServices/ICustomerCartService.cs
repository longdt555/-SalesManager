using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;

namespace Lib.Service.IServices
{
    public interface ICustomerCartService : IReadOnlyService<CustomerCartDto>
    {
        CustomerCart Create(CustomerCart obj);
        void Update(CustomerCart obj, int? action = 0);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();      
    }
}
