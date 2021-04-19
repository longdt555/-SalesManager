using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly YdmApiDbContext _context;

        public SystemSettingsService(YdmApiDbContext context)
        {
            _context = context;
        }

        public SystemSettingsDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SystemSettingsDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SystemSettingsDto> Query()
        {
            throw new NotImplementedException();
        }

        public SystemSettings Create(SystemSettings obj)
        {
            #region validate

            #endregion

            _context.SystemSettingss.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Update(SystemSettings obj)
        {
            var exObj = _context.SystemSettingss.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);
            exObj.Value = obj.Value;
            exObj.Name = obj.Name;
            _context.SystemSettingss.Update(exObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.SystemSettingss.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (data == null) return;
            data.IsDeleted = true;
            _context.SystemSettingss.Update(data);
            _context.SaveChanges();
        }

        public void DeleteMany(List<int> ids)
        {
            var data = _context.SystemSettingss.Where(x => ids.Contains(x.Id) && x.IsDeleted == false);
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;
            _context.SystemSettingss.UpdateRange(data);
            _context.SaveChanges();
        }

        public int GetRecordCount()
        {
            return _context.SystemSettingss.Count();
        }
    }
}
