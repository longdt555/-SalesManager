using Lib.Service.Dtos;
using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos.Auth;

namespace Lib.Service.IServices
{
    public interface ICustomerService : IReadOnlyService<CustomerDto>
    {
        Customer Create(Customer obj);
        void Update(Customer obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
        void Delete(CustomerDto data);
        CustomerDto Authenticate(UserPortalDto obj);
    }
}
