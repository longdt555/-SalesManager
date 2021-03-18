using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;

namespace Lib.Service.IServices
{
    public interface ICustomerProfileService : IReadOnlyService<CustomerProfileDto>
    {
        CustomerProfile Create(CustomerProfile obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
       
    }
}
