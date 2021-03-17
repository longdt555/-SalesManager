using AutoMapper;
using Lib.Common.Model;
using Lib.Data.Entity;
using Lib.Service.Dtos;

namespace YDManagement.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();

            CreateMap<BackendUserModel, BackendUser>();
            CreateMap<BackendUser, BackendUserModel>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<RoleDto, Role>();
            CreateMap<Role, RoleDto>();

            CreateMap<CustomerCartDto, CustomerCart>();
            CreateMap<CustomerCart, CustomerCartDto>();

            CreateMap<CustomerProfileDto, CustomerProfile>();
            CreateMap<CustomerProfile, CustomerProfileDto>();

            CreateMap<ExpiredlinkDto, ExpiredLink>();
            CreateMap<ExpiredLink, ExpiredlinkDto>();

            CreateMap<SystemSettingsDto, SystemSettings>();
            CreateMap<SystemSettings, SystemSettingsDto>();

            CreateMap<TransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>();

            CreateMap<TransactionDetailDto, TransactionDetail>();
            CreateMap<TransactionDetail, TransactionDetailDto>();

        }
    }
}
