using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly YDMApiDbContext _context;
        public CustomerService(YDMApiDbContext context)
        {
            _context = context;
        }
        public Customer Create(Customer obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion
            _context.Customers.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data= _context.Customers.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;
            _context.Customers.Update(data);
            _context.SaveChanges();
            
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
                Name = x.Name,                
                Address = x.Address               
            });
        }

        public CustomerDto GetById(int id)
        {
            return _context.Customers.Where(x => x.IsDeleted == false && x.Id == id ).Select(x => new CustomerDto()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).FirstOrDefault();
        }

        public int GetRecordCount()
        {
            return _context.Products.Where(x => x.IsDeleted == false).Count();
        }

        public IQueryable<CustomerDto> Query()
        {
            throw new System.NotImplementedException();
        }
        public CustomerDto Authenticate(UserPortalDto obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.UserName))
                throw new AppException(AppCodeStatus.ErrorCreateUserNameRequired);
            if (string.IsNullOrEmpty(obj.Password))
                throw new AppException(AppCodeStatus.ErrorCreatePasswordRequired);
            // username checking
            if (obj.UserName.Length < 2 || obj.UserName.Length > 50)
                throw new AppException(AppCodeStatus.ErrorTextLengthInvalid);
            if (AppHelpers.HasSpecialChar(obj.UserName))
                throw new AppException(AppCodeStatus.ErrorContainsSpecialCharacter);
            // password checking
            if (obj.Password.Length < 6 || obj.Password.Length > 30)
                throw new AppException(AppCodeStatus.ErrorTextLengthInvalid);
            if (!AppHelpers.PasswordValid(obj.Password))
                throw new AppException(AppCodeStatus.ErrorRegisterPasswordInvalid);
            #endregion

            return _context.Customers.Where(x => x.UserName.Trim().Replace(" ", "").ToLower().Equals(obj.UserName.ToLower()) && Security.EncryptKey(obj.Password).Equals(x.Password))
                .Select(x => new CustomerDto()
                {
                    Id = x.Id,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    IsDeleted = x.IsDeleted,
                    Name = x.Name,
                    Address = x.Address,
                    UserName = x.UserName
                }).SingleOrDefault();
        }
        public void Update(Customer obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            var exObj = _context.Customers.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            exObj.Address = obj.Address;           

            _context.Customers.Update(exObj);
            _context.SaveChanges();
        }

    }
}
