using Lib.Data.Entity;
using Lib.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.IServices
{
    public interface ITransactionService : IReadOnlyService<TransactionDto>
    {
        Transaction Create(Transaction obj);
        void Update(Transaction obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
