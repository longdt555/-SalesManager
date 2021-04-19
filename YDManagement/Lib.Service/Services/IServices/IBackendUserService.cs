using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Dtos.Auth;

namespace Lib.Service.Services.IServices
{
    public interface IBackendUserService : IRepository<BackendUser>
    {
        BackendUserDto Authenticate(UserPortalDto obj);
        BackendUser Create(BackendUser obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
    }
}