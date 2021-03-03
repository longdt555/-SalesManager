using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly YDMApiDbContext _context;
        public OrderService(YDMApiDbContext context)
        {
            _context = context;
        }
        public Order Create(Order obj)
        {
            #region validate
            if (String.IsNullOrEmpty(obj.CustomerId.ToString()))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion
            _context.Orders.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data=_context.Orders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;
            _context.Orders.Update(data);
            _context.SaveChanges();
        }
        public void DeleteMany(List<int> ids)
        {
            var data = _context.Orders.Where(x => ids.Contains(x.Id));
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.Orders.UpdateRange(data);
            _context.SaveChanges();
        }
        public IEnumerable<OrderDto> GetAll()
        {
            return _context.Orders.Include(x => x.Product).Where(x => x.IsDeleted == false).Select(x => new OrderDto()
            {
                Id = x.Id,
                Amount=x.Amount,

            }
            );
        }
        public OrderDto GetById(int id)
        {
            return _context.Orders.Include(x => x.Product).Where(x => x.IsDeleted == false).Select(x => new OrderDto()
            {
                Id = x.Id,
                Amount = x.Amount,
            }).FirstOrDefault();

        }
        public int GetRecordCount()
        {
            return _context.Orders.Where(x => x.IsDeleted == false).Count();
        }

        public IQueryable<OrderDto> Query()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.CustomerId.ToString()))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            var exObj = _context.Orders.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            
            exObj.CustomerId = obj.CustomerId;
            exObj.ProductId = obj.ProductId;
            exObj.Amount = obj.Amount;

            _context.Orders.Update(exObj);
            _context.SaveChanges();
        }

    }
}
