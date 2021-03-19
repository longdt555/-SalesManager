using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace Lib.Service.IServices
{
    public interface ITransactionDetailService : IReadOnlyService<TransactionDto>
    {
        TransactionDetail Create(TransactionDetail obj);
       
    }
}
