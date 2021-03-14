using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Service.Dtos;
using Lib.Service.Dtos.UserPortal;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (string.IsNullOrEmpty(obj.Email))
                throw new AppException(AppCodeStatus.EmailRequired);
            if (string.IsNullOrEmpty(obj.Password))
                throw new AppException(AppCodeStatus.PasswordRequired);
            // email checking
            if (!obj.Email.IsValidEmail())
                throw new AppException(AppCodeStatus.EmailInvalid);
            // password checking
            if (obj.Password.Length < 6 || obj.Password.Length > 30)
                throw new AppException(AppCodeStatus.TextLengthInvalid);
            if (!AppHelpers.PasswordValid(obj.Password))
                throw new AppException(AppCodeStatus.RegisterPasswordInvalid);
            #endregion

            var data = _context.Customers
                .Where(x => x.Email.Trim().Replace(" ", "").ToLower().Equals(obj.Email.ToLower()) &&
                            Security.EncryptKey(obj.Password).Equals(x.Password)).Select(x => new CustomerDto()
                            {
                                Email = x.Email,
                                Name = x.Name
                            }).SingleOrDefault();

            return data;
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
