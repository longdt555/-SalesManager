using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly YdmApiDbContext _context;
        public RoleService(YdmApiDbContext context)
        {
            _context = context;
        }
        public Role Create(Role obj)
        {           
            _context.Roles.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data = _context.Roles.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (data == null) return;
            data.IsDeleted = true;

            _context.Roles.Update(data);
            _context.SaveChanges();
        }
        public void DeleteMany(List<int> ids)
        {
            var data = _context.Roles.Where(x => ids.Contains(x.Id) && x.IsDeleted == false);
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.Roles.UpdateRange(data);
            _context.SaveChanges();
        }
        public IEnumerable<Role> GetAll()
        {
            return _context.Roles.Where(x => x.IsDeleted == false);
        }

        public Role GetById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public IQueryable<Role> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(Role obj)
        {
            var exObj = _context.Roles.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);           
            exObj.Title = obj.Title;
            _context.Roles.Update(exObj);
            _context.SaveChanges();
        }

    }
}
