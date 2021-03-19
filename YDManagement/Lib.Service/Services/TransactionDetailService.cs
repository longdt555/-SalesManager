using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
   public class TransactionDetailService : ITransactionDetailService
    {
        private readonly YdmApiDbContext _context;

        public TransactionDetailService(YdmApiDbContext context)
        {
            _context = context;
        }

        public TransactionDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TransactionDto> Query()
        {
            throw new NotImplementedException();
        }

        public TransactionDetail Create(TransactionDetail obj)
        {
            #region validate

            #endregion

            _context.TransactionDetails.Add(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}
