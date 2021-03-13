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
