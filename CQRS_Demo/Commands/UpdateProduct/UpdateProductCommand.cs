using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using MediatR;

namespace CQRS_Demo.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Product?>
    {
        public Guid Id { get; set; }
        public ProductDto ProductDto { get; set; }
    }
}
