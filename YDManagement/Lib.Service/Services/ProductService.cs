using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly YDMApiDbContext _context;
        public ProductService(YDMApiDbContext context)
        {
            _context = context;
        }
        public Product Create(Product obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            _context.Products.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (data == null) return;
            data.IsDeleted = true;

            _context.Products.Update(data);
            _context.SaveChanges();
        }

        public void DeleteMany(List<int> ids)
        {
            var data = _context.Products.Where(x => ids.Contains(x.Id));
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;

            _context.Products.UpdateRange(data);
            _context.SaveChanges();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Where(x => x.IsDeleted == false).Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public ProductDto GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetRecordCount()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductDto> Query()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product obj)
        {
            #region validate
            if (string.IsNullOrEmpty(obj.Name))
                throw new AppException(AppCodeStatus.ErrorCreateNameRequired);
            #endregion

            var exObj = _context.Products.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (exObj == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);

            exObj.Price = obj.Price;
            exObj.Quanity = obj.Quanity;
            exObj.Description = obj.Description;
            exObj.CategoryId = obj.CategoryId;

            _context.Products.Update(exObj);
            _context.SaveChanges();
        }
    }
}
