using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Service.Dtos;
using Lib.Service.Dtos.Auth;
using Lib.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace Lib.Service.Services
{
    public class BackendUserService : IBackendUserService
    {
        private readonly YdmApiDbContext _context;
        public BackendUserService(YdmApiDbContext context)
        {
            _context = context;
        }
        public BackendUserDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BackendUserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BackendUserDto> Query()
        {
            throw new NotImplementedException();
        }

        public BackendUserDto Authenticate(UserPortalDto obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.UserName)) throw new AppException(AppCodeStatus.UserNameRequired);
            if (string.IsNullOrEmpty(obj.Password)) throw new AppException(AppCodeStatus.PasswordRequired);
            // password checking
            if (AppHelpers.HasSpecialChar(obj.UserName)) throw new AppException(AppCodeStatus.RegisterUserNameInvalid);
            if (obj.Password.Length < 6 || obj.Password.Length > 30) throw new AppException(AppCodeStatus.TextLengthInvalid);
            if (!AppHelpers.PasswordValid(obj.Password)) throw new AppException(AppCodeStatus.RegisterPasswordInvalid);
            #endregion

            var data = _context.BackendUsers.Include(x => x.Role)
                .Where(x => x.UserName.Trim().Replace(" ", "").ToLower().Equals(obj.Email.ToLower()) &&
                            Security.EncryptKey(obj.Password).Equals(x.Password) && x.IsDeleted == false).Select(x => new BackendUserDto()
                            {
                                Id = x.Id,
                                UserName = x.UserName,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                Role = x.Role != null ? new RoleDto()
                                {
                                    Id = x.Role.Id,
                                    Name = x.Role.Name,
                                    Title = x.Role.Title
                                } : null
                            }).SingleOrDefault();

            return data;
        }
    }
}
