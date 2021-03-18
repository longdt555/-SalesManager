using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.DataContext;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly YdmApiDbContext _context;

        public TransactionService(YdmApiDbContext context)
        {
            _context = context;
        }

        public Transaction Create(Transaction obj)
        {
            _context.Transactions.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(int id)
        {
            var data = _context.Transactions.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            if (data == null) return;
            data.IsDeleted = true;
            _context.Transactions.Update(data);
            _context.SaveChanges();
        }

        public void DeleteMany(List<int> ids)
        {
            var data = _context.Transactions.Where(x => ids.Contains(x.Id) && x.IsDeleted == false);
            if (!data.Any()) return;
            foreach (var item in data)
                item.IsDeleted = true;
            _context.Transactions.UpdateRange(data);
            _context.SaveChanges();
        }

        public IEnumerable<TransactionDto> GetAll()
        {
            return _context.Transactions.Where(x => x.IsDeleted == false).Select(x => new TransactionDto()
            );
        }

        public TransactionDto GetById(int id)
        {
            return _context.Transactions.Where(x => x.Id == id && x.IsDeleted == false).Select(x => new TransactionDto()
            ).FirstOrDefault();
        }

        public int GetRecordCount()
        {
            return _context.Transactions.Count();
        }

        public IQueryable<TransactionDto> Query()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction obj)
        {
            var data = _context.Transactions.FirstOrDefault(x => x.Id == obj.Id && x.IsDeleted == false);
            if (data == null)
                throw new AppException(AppCodeStatus.ObjectNotFound);
            data.Status = obj.Status;
            _context.Transactions.Update(data);
            _context.SaveChanges();
        }
    }
}
