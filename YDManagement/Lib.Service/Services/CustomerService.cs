using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Data.Entity;
using Lib.Service.Dtos.Auth;

namespace Lib.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly YdmApiDbContext _context;
        public CustomerService(YdmApiDbContext context)
        {
            _context = context;
        }
        public CustomerDto Authenticate(UserPortalDto obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Email)) throw new AppException(AppCodeStatus.EmailRequired);
            if (string.IsNullOrEmpty(obj.Password)) throw new AppException(AppCodeStatus.PasswordRequired);
            // email checking
            if (!obj.Email.IsValidEmail()) throw new AppException(AppCodeStatus.EmailInvalid);
            // password checking
            if (obj.Password.Length < 6 || obj.Password.Length > 30) throw new AppException(AppCodeStatus.TextLengthInvalid);
            if (!AppHelpers.PasswordValid(obj.Password)) throw new AppException(AppCodeStatus.RegisterPasswordInvalid);
            #endregion

            var data = _context.Customers
                .Where(x => x.Email.Trim().Replace(" ", "").ToLower().Equals(obj.Email.ToLower()) &&
                            Security.EncryptKey(obj.Password).Equals(x.Password) && x.IsDeleted == false).Select(x => new CustomerDto()
                            {
                                Id = x.Id,
                                Email = x.Email,
                                Name = x.Name
                            }).SingleOrDefault();

            return data;
        }
        public Customer Create(Customer obj)
        {
            _context.Customers.Add(obj);
            _context.SaveChanges();
            return obj;
        }


        public void Delete(int id)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (data == null) return;
            data.IsDeleted = true;

            _context.Customers.Update(data);
            _context.SaveChanges();
        }
        public void Delete(CustomerDto data)
        {
            throw new NotImplementedException();
        }
        public void DeleteMany(List<int> ids)
        {
            var data = _context.Customers.Where(x => ids.Contains(x.Id));
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;
            _context.Customers.UpdateRange(data);
            _context.SaveChanges();
        }
        public IEnumerable<CustomerDto> GetAll()
        {
            return _context.Customers.Where(x => x.IsDeleted == false).Select(x => new CustomerDto()
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                Name = x.Name,

            });
        }
        public CustomerDto GetById(int id)
        {
            return _context.Customers.Where(x => x.IsDeleted == false && x.Id == id).Select(x => new CustomerDto()
            {
                Id = x.Id,
                Email = x.Email,
                Password = x.Password,
                Name = x.Name
            }).FirstOrDefault();

        }
        public int GetRecordCount()
        {
            return _context.Customers.Count(x => x.IsDeleted == false);
        }
        public void Update(Customer obj)
        {
            #region validate
            //if (string.IsNullOrEmpty(obj.Name))
            //    throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion
            var exObj = _context.Customers.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
            {
                throw new AppException(AppCodeStatus.ObjectNotFound);
            }
            exObj.Name = obj.Name;
            _context.Customers.Update(exObj);
            _context.SaveChanges();
        }
        public IQueryable<CustomerDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}
