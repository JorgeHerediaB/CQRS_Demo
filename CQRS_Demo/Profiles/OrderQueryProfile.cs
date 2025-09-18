using AutoMapper;
using CQRS_Demo.Entities.Concretes;
using CQRS_Demo.Queries.DTOs;

namespace CQRS_Demo.Profiles;

public class OrderQueryProfile : Profile
{
    public OrderQueryProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<Order, OrderListDto>()
            .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Products.Count))
            .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.Products.Sum(p => p.Quantity)));

        CreateMap<Product, ProductQueryDto>();
    }
}
