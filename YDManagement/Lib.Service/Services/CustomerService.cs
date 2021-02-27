using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
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

        public IEnumerable<CustomerDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CustomerDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}
