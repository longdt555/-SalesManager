using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
{
    public interface ICategoryService : IReadOnlyService<CategoryDto>
    {
        Category Create(Category obj);
        void Update(Category obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
        void Delete(CategoryDto data);
    }
}
