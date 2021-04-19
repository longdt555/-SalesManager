using System;

namespace Lib.Service.Services.IServices
{
    public interface IUnitOfWork : IDisposable
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        ICustomerService CustomerService { get; }
        IBackendUserService BackendUserService { get; }
        IRoleService RoleService { get; }
        ICustomerCartService CustomerCartService { get; }
        ICustomerProfileService CustomerProfileService { get; }
        ITransactionService TransactionService { get; }
        ITransactionDetailService TransactionDetailService { get; }


        #region log

        #endregion

        /// <summary>
        /// Commit to DB
        /// </summary>
        void Save();
    }
}
