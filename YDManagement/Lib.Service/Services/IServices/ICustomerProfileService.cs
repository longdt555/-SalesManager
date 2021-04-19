using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
{
    public interface ICustomerProfileService : IReadOnlyService<CustomerProfileDto>
    {
        CustomerProfile Create(CustomerProfile obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
       
    }
}
