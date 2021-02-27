using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;

namespace Lib.Service.IServices
{
    public interface ICustomerService : IReadOnlyService<CustomerDto>
    {
        CustomerDto Authenticate(UserPortalDto obj);
    }
}
