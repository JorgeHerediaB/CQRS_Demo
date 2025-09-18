using AutoMapper;
using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;

namespace CQRS_Demo.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<ProductDto, Product>();
        }
    }
}
