using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly YDMApiDbContext _context;
        public CategoryService(YDMApiDbContext context)
        {
            _context = context;
        }
        public Category Create(Category obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            _context.Categories.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var data = _context.Categories.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;

            _context.Categories.Update(data);
            _context.SaveChanges();
        }

        public void Delete(CategoryDto data)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMany(List<int> ids)
        {
            var data = _context.Categories.Where(x => ids.Contains(x.Id));
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.Categories.UpdateRange(data);
            _context.SaveChanges();
        }
        public IEnumerable<CategoryDto> GetAll()
        {
            return _context.Categories.Where(x => x.IsDeleted == false ).Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,              
                Description = x.Description,                
            });
        }

        public CategoryDto GetById(int id)
        {
            return _context.Categories.Where(x => x.IsDeleted == false && x.Id == id ).Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,                           
            }).FirstOrDefault();
        }
        public int GetRecordCount()
        {
            return _context.Categories.Where(x => x.IsDeleted == false).Count();
        }

        public IQueryable<CategoryDto> Query()
        {
            throw new System.NotImplementedException();
        }
        public void Update(Category obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            var exObj = _context.Categories.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            
            exObj.Description = obj.Description;
            

            _context.Categories.Update(exObj);
            _context.SaveChanges();
        }

    }
}
