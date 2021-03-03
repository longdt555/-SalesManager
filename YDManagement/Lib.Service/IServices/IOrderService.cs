using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;

namespace Lib.Service.IServices
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
