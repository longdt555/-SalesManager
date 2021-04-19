using Lib.Data.DataContext;
using Lib.Service.Services.IServices;

namespace Lib.Service.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YdmApiDbContext _db;

        public UnitOfWork(YdmApiDbContext db)
        {
            _db = db;
            ProductService = new ProductService(_db);
            CategoryService = new CategoryService(_db);
            OrderService = new OrderService(_db);
            CustomerService = new CustomerService(_db);
            BackendUserService = new BackendUserService(_db);
            RoleService = new RoleService(_db);
            RoleService = new RoleService(_db);
            CustomerCartService = new CustomerCartService(_db);
            CustomerProfileService = new CustomerProfileService(_db);
            TransactionService = new TransactionService(_db);
            TransactionDetailService = new TransactionDetailService(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IProductService ProductService { get; private set; }
        public ICategoryService CategoryService { get; private set; }
        public IOrderService OrderService { get; private set; }
        public ICustomerService CustomerService { get; private set; }
        public IBackendUserService BackendUserService { get; private set; }
        public IRoleService RoleService { get; private set; }
        public ICustomerCartService CustomerCartService { get; private set; }
        public ICustomerProfileService CustomerProfileService { get; private set; }
        public ITransactionService TransactionService { get; private set; }
        public ITransactionDetailService TransactionDetailService { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
