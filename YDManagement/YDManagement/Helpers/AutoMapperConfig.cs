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
        }
    }
}
