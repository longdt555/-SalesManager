using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
{
    public interface IOrderService : IReadOnlyService<OrderDto>
    {
        Order Create(Order obj);
        void Update(Order obj);
        void Delete(int obj);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
