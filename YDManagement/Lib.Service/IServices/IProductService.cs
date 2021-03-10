using System;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;

namespace Lib.Service.IServices
{
    public interface IProductService : IReadOnlyService<ProductDto>
    {
        Product Create(Product obj);
        void Update(Product obj);
        void Delete(Guid id);
        void DeleteMany(List<Guid> ids);
        int GetRecordCount();
        bool IsOutOfStock(Guid id, int? quantity = 0);
    }
}
