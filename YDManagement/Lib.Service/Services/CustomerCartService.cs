using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Services.IServices;

namespace Lib.Service.Services
{
    public class CustomerCartService : ICustomerCartService
    {
        private readonly YdmApiDbContext _context;
        public CustomerCartService(YdmApiDbContext context)
        {
            _context = context;
        }
        public CustomerCart Create(CustomerCart obj)
        {
            _context.CustomerCarts.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data = _context.CustomerCarts.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;
            _context.CustomerCarts.Update(data);
            _context.SaveChanges();
        }
        public void DeleteMany(List<int> ids)
        {
            var data = _context.CustomerCarts.Where(x => ids.Contains(x.Id));
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.CustomerCarts.UpdateRange(data);
            _context.SaveChanges();
        }
        public void Update(CustomerCart obj, int? action = 0)
        {
            var exObj = _context.CustomerCarts.FirstOrDefault(x => x.Id == obj.Id);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);
            if (action == 1)
            {
                exObj.Quantity += obj.Quantity;
            }
            else
            {
                exObj.Quantity = obj.Quantity;
            }
            _context.CustomerCarts.Update(exObj);
            _context.SaveChanges();
        }
        public IQueryable<CustomerCartDto> Query()
        {
            throw new NotImplementedException();
        }
        public int GetRecordCount()
        {
            return _context.CustomerCarts.Count(x => x.IsDeleted == false);
        }
        public IEnumerable<CustomerCartDto> GetAll()
        {
            return _context.CustomerCarts.Where(x => x.IsDeleted == false).Select(x => new CustomerCartDto());
        }
        public CustomerCartDto GetById(int id)
        {
            return _context.CustomerCarts.Where(x => x.IsDeleted == false && x.Id == id).Select(x => new CustomerCartDto()).FirstOrDefault();

        }
    }
}
