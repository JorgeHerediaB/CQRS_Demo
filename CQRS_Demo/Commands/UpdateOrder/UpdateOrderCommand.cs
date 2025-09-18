using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using System.Collections.Generic;

namespace CQRS_Demo.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Order?>
    {
        public Guid Id { get; set; }
        public IReadOnlyList<Guid> ProductsIds { get; set; } = [];
    }
}
