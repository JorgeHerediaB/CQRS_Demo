using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductQueryDto?>
{
    public Guid Id { get; set; }
}
