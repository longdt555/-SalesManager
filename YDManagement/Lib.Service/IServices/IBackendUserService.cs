using Lib.Service.Dtos;
using Lib.Service.Dtos.Auth;

namespace Lib.Service.IServices
{
    public interface IBackendUserService : IReadOnlyService<BackendUserDto>
    {
        BackendUserDto Authenticate(UserPortalDto obj);
    }
}