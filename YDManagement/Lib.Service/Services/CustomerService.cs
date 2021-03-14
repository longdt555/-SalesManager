using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Common.Global;
using Lib.Data.Entity;

namespace Lib.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly YdmApiDbContext _context;
        public CustomerService(YdmApiDbContext context)
        {
            _context = context;
        }
        public Customer Authenticate(UserPortalDto obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.UserName))
                throw new AppException(AppCodeStatus.CreateUserNameRequired);
            if (string.IsNullOrEmpty(obj.Password))
                throw new AppException(AppCodeStatus.CreatePasswordRequired);
            // username checking
            if (obj.UserName.Length < 2 || obj.UserName.Length > 50)
                throw new AppException(AppCodeStatus.TextLengthInvalid);
            if (AppHelpers.HasSpecialChar(obj.UserName))
                throw new AppException(AppCodeStatus.ContainsSpecialCharacter);
            // password checking
            if (obj.Password.Length < 6 || obj.Password.Length > 30)
                throw new AppException(AppCodeStatus.TextLengthInvalid);
            if (!AppHelpers.PasswordValid(obj.Password))
                throw new AppException(AppCodeStatus.RegisterPasswordInvalid);
            #endregion

            var data = _context.Customers
                .SingleOrDefault(x => x.UserName.Trim().Replace(" ", "").ToLower().Equals(obj.UserName.ToLower()) && Security.EncryptKey(obj.Password).Equals(x.Password));

            return YdConnectorSaver.Add(data);
        }
        public Customer Create(Customer obj)
        {
            _context.Customers.Add(obj);
            _context.SaveChanges();
            return obj;
        }       
        public void Delete(int id)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;

            _context.Customers.Update(data);
            _context.SaveChanges();
        }
        public void Delete(CustomerDto data)
        {
            throw new System.NotImplementedException();
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
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Address = x.Address,

            });
        }
        public CustomerDto GetById(int id)
        {
            return _context.Customers.Where(x => x.IsDeleted == false && x.Id == id).Select(x => new CustomerDto()
            {
                Id = x.Id,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Address = x.Address,
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
            if (obj == null)
            {
                throw new AppException(AppCodeStatus.ObjectNotFound);
            }
            exObj.Address = obj.Address;
            _context.Customers.Update(exObj);
            _context.SaveChanges();
        }
        public IQueryable<CustomerDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}
