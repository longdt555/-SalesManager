using Lib.Data.Entity;
using Lib.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.IServices
{
    public interface ITransactionDetailService : IReadOnlyService<TransactionDto>
    {
        TransactionDetail Create(TransactionDetail obj);
       
    }
}
