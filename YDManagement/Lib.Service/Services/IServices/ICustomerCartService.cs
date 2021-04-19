using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
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
