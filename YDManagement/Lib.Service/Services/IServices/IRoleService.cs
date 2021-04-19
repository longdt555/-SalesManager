using System.Collections.Generic;
using Lib.Data.Entity;

namespace Lib.Service.Services.IServices
{
   public interface IRoleService : IReadOnlyService<Role>
    {
        Role Create(Role obj);
        void Update(Role obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
    }
}
