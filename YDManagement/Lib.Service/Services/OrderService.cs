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
            _context.Orders.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var data = _context.Orders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
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
            return _context.Orders.Include(x => x.Product).Include(x => x.Customer).Where(x => x.IsDeleted == false && x.Product.IsDeleted == false && x.Customer.IsDeleted == false).Select(x => new OrderDto()
            {
                Id = x.Id,
                Customer = x.Customer != null ? new Customer()
                {
                    UserName = x.Customer.UserName,
                    Name = x.Customer.Name,
                    Address = x.Customer.Address
                } : null,
                Product = x.Product != null ? new ProductDto()
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Description = x.Product.Description,
                } : null,
                Amount = x.Amount,
                Quantity = x.Quantity,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            });
        }

        public OrderDto GetById(int id)
        {
            return _context.Orders.Include(x => x.Product).Include(x => x.Customer).Where(x => x.Id == id && x.IsDeleted == false && x.Product.IsDeleted == false && x.Customer.IsDeleted == false).Select(x => new OrderDto()
            {
                Id = x.Id,
                Customer = x.Customer != null ? new Customer()
                {
                    UserName = x.Customer.UserName,
                    Name = x.Customer.Name,
                    Address = x.Customer.Address
                } : null,
                Product = x.Product != null ? new ProductDto()
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Description = x.Product.Description,
                } : null,
                Amount = x.Amount,
                Quantity = x.Quantity,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted
            }).FirstOrDefault();
        }

        public int GetRecordCount()
        {
            return _context.Orders.Where(x => x.IsDeleted == false).Count();
        }

        public IQueryable<OrderDto> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            var exObj = _context.Orders.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            exObj.Amount = obj.Amount;
            exObj.Quantity = obj.Quantity;

            _context.Orders.Update(exObj);
            _context.SaveChanges();
        }
    }
}
