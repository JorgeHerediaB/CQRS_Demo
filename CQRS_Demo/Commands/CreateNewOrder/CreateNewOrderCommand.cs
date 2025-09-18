using CQRS_Demo.Dtos;
using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Commands.CreateNewOrder;

public class CreateNewOrderCommand : IRequest<OrderDto?>
{
    public IReadOnlyList<OrderListItemDto> Products { get; set; } = [];
}