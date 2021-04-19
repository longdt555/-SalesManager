using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
{
    public interface ISystemSettingsService : IReadOnlyService<SystemSettingsDto>
    {
        SystemSettings Create(SystemSettings obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
