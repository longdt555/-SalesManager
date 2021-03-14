using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;
using System.Collections.Generic;
using Lib.Data.Entity;

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
