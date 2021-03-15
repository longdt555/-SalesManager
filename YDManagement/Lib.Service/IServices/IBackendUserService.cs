using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Dtos.Auth;
using System.Collections.Generic;

namespace Lib.Service.IServices
{
    public interface IBackendUserService : IReadOnlyService<BackendUserDto>
    {
        BackendUserDto Authenticate(UserPortalDto obj);
        BackendUser Create(BackendUser obj);
        void Update(BackendUser obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
    }
}