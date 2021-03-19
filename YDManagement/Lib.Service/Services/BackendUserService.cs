using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
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
        //public BackendUserDto GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
        public BackendUser Create(BackendUser obj)
        {
            //#region validate
            //if (string.IsNullOrWhiteSpace(obj.UserName) || string.IsNullOrEmpty(obj.UserName))
            //    throw new AppException(AppCodeStatus.ErrorCreateUserNameRequired);
            //if (AppHelpers.HasSpecialChar(obj.UserName))
            //    throw new AppException(AppCodeStatus.ErrorRegisterUserNameInvalid);
            //if (CheckFieldExists(obj.UserName))
            //    throw new AppException(AppCodeStatus.ErrorCreateUserNameExist);
            //#endregion

            obj.UserName = obj.UserName.Trim().Replace(" ", "");
            obj.Password = Security.EncryptKey(obj.Password);

            _context.BackendUsers.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data = _context.BackendUsers.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (data == null) return;
            data.IsDeleted = true;

            _context.BackendUsers.Update(data);
            _context.SaveChanges();
        }
        public void DeleteMany(List<int> ids)
        {
            var data = _context.BackendUsers.Where(x => ids.Contains(x.Id) && x.IsDeleted == false);
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.BackendUsers.UpdateRange(data);
            _context.SaveChanges();
        }
        public BackendUserDto GetById(int id)
        {
            return _context.BackendUsers.Include(x => x.Role).Select(u => new BackendUserDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Password = u.Password,
                IsDeleted = u.IsDeleted,
                Role = u.Role == null ? null : new RoleDto()
                {
                    Id = u.Role.Id,
                    Name = u.Role.Name,
                    Title = u.Role.Title
                },
                RoleId = u.Role != null ? u.Role.Id : 0,
                CreatedDate = u.CreatedDate.Value.ToLocalTime(),
                UpdatedDate = u.UpdatedDate.Value.ToLocalTime(),
                CreatedBy = u.CreatedBy,
                UpdatedBy = u.UpdatedBy
            }).FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        }
        public void Update(BackendUser obj)
        {
            //#region validate
            //if (string.IsNullOrWhiteSpace(obj.UserName) || string.IsNullOrEmpty(obj.UserName))
            //    throw new AppException(AppCodeStatus.ErrorCreateUserNameRequired);
            //if (AppHelpers.HasSpecialChar(obj.UserName))
            //    throw new AppException(AppCodeStatus.ErrorRegisterUserNameInvalid);
            //if (CheckUserNameExist(obj))
            //    throw new AppException(AppCodeStatus.ErrorCreateUserNameExist);
            //#endregion
            var data = _context.BackendUsers.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (data == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            data.FirstName = obj.FirstName;
            data.UserName = obj.UserName;
            data.LastName = obj.LastName;
            data.RoleId = obj.RoleId;

            _context.BackendUsers.Update(data);
            _context.SaveChanges();
        }

        public IEnumerable<BackendUserDto> GetAll()
        {
            return _context.BackendUsers.Include(x => x.Role).Select(u => new BackendUserDto()
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Password = u.Password,
                IsDeleted = u.IsDeleted,
                Role = u.Role == null ? null : new RoleDto()
                {
                    Id = u.Role.Id,
                    Name = u.Role.Name,
                    Title = u.Role.Title
                },
                RoleId = u.Role != null ? u.Role.Id : 0,
                CreatedDate = u.CreatedDate.Value.ToLocalTime(),
                UpdatedDate = u.UpdatedDate.Value.ToLocalTime(),
                CreatedBy = u.CreatedBy,
                UpdatedBy = u.UpdatedBy
            }).Where(x => x.IsDeleted == false);
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
