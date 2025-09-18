using CQRS_Demo.Entities.Concretes;
using MediatR;

namespace CQRS_Demo.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<Order?>
{
    public Guid Id { get; set; }
    public IReadOnlyList<Guid> ProductsIds { get; set; } = [];
}