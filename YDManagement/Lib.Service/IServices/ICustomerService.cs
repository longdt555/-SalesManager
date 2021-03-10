using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;

namespace Lib.Service.IServices
{
    public interface ICustomerService : IReadOnlyService<CustomerDto>
    {
        Customer Authenticate(UserPortalDto obj);
    }
}
