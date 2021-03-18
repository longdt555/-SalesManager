using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
    public class CustomerProfileService : ICustomerProfileService
    {
        private readonly YdmApiDbContext _context;

        public CustomerProfileService(YdmApiDbContext context)
        {
            _context = context;
        }

        public CustomerProfile Create(CustomerProfile obj)
        {
            var data = _context.CustomerProfiles.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Update(CustomerProfile obj)
        {
            var exObj = _context.CustomerProfiles.FirstOrDefault(x => x.Id == obj.Id);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            exObj.FirstName = obj.FirstName;
            exObj.LastName = obj.LastName;
            exObj.Dob = obj.Dob;
            exObj.Address = obj.Address;
            exObj.Mobile = obj.Mobile;
            exObj.Avatar = obj.Avatar;
            exObj.IdentityCard = obj.IdentityCard;
            exObj.UpdatedDate = obj.UpdatedDate;
            exObj.UpdatedBy = obj.UpdatedBy;

            _context.Update(exObj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerProfileDto> GetAll()
        {
            return _context.CustomerProfiles.Where(x => x.IsDeleted == false).Select(x => new CustomerProfileDto()
            );
        }

        public CustomerProfileDto GetById(int id)
        {
            return _context.CustomerProfiles.Where(x => x.Id == id && x.IsDeleted == false).Select(
                x => new CustomerProfileDto()
            ).FirstOrDefault();
        }

        public IQueryable<CustomerProfileDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}
