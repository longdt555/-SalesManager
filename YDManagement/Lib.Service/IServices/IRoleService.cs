using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.IServices
{
   public interface IRoleService : IReadOnlyService<Role>
    {
        Role Create(Role obj);
        void Update(Role obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
    }
}
