using System.Collections.Generic;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.Services.IServices
{
    public interface ITransactionService : IReadOnlyService<TransactionDto>
    {
        Transaction Create(Transaction obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
