using AutoMapper;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YDManagement.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
            CreateMap<CustomerDto,Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
