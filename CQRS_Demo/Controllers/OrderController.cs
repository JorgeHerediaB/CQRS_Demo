using CQRS_Demo.Commands.CreateNewOrder;
using CQRS_Demo.Commands.UpdateOrder;
using CQRS_Demo.Dtos;
using CQRS_Demo.Queries.DTOs;
using CQRS_Demo.Queries.GetAllOrders;
using CQRS_Demo.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<BaseResponse<OrderDto?>> PostOrderAsync(CreateNewOrderCommand command)
    {
        var response = await mediator.Send(command);
        return new BaseResponse<OrderDto?>(response);
    }

    [HttpPut("{id}")]
    public async Task<BaseResponse<OrderDto?>> PutOrderAsync(Guid id, IReadOnlyList<OrderListItemDto> products)
    {
        var response = await mediator.Send(new UpdateOrderCommand
        {
            Id = id,
            Products = products
        });
        return new BaseResponse<OrderDto?>(response);
    }

    [HttpGet]
    public async Task<BaseResponse<List<OrderListDto>>> GetAllOrdersAsync()
    {
        var response = await mediator.Send(new GetAllOrdersQuery());
        return new BaseResponse<List<OrderListDto>>(response);
    }

    [HttpGet("{id}")]
    public async Task<BaseResponse<OrderDto?>> GetOrderByIdAsync(Guid id)
    {
        var response = await mediator.Send(new GetOrderByIdQuery { Id = id });
        return new BaseResponse<OrderDto?>(response);
    }
}