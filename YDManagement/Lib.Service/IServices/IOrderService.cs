using System;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;

namespace Lib.Service.IServices
{
    public interface IOrderService:IReadOnlyService<OrderDto>
    {
        Order Create(Order obj);
        void Update(Order obj);
        void Delete(Guid id);
        void DeleteMany(List<Guid> ids);
        int GetRecordCount();
    }
}
