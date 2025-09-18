using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<OrderDto?>
{
    public Guid Id { get; set; }
    public IReadOnlyList<OrderListItemDto> Products { get; set; } = [];
}