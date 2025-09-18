using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDto?>
{
    public Guid Id { get; set; }
}
