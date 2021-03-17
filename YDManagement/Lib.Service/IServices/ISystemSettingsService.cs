using Lib.Data.Entity;
using Lib.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.IServices
{
    public interface ISystemSettingsService : IReadOnlyService<SystemSettingsDto>
    {
        SystemSettings Create(SystemSettings obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
