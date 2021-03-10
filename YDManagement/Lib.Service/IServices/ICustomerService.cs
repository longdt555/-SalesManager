using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.IServices
{
    public interface ICustomerService : IReadOnlyService<CustomerDto>
    {
        CustomerDto Authenticate(UserPortalDto obj);
        Customer Create(Customer obj);
        void Update(Customer obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
