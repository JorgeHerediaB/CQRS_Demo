using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using MediatR;

namespace CQRS_Demo.Commands.CreateNewProduct;

public class CreateNewProductCommand : IRequest<Product?>
{
    public ProductDto ProductDto { get; set; }
}