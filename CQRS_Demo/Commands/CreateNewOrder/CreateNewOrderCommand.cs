using CQRS_Demo.Entities.Concretes;
using MediatR;

namespace CQRS_Demo.Commands.CreateNewOrder
{
    public class CreateNewOrderCommand : IRequest<Order?>
    {
        public IReadOnlyList<Guid> ProductIds { get; set; } = [];
    }
}
