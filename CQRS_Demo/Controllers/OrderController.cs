using CQRS_Demo.Commands;
using CQRS_Demo.Commands.CreateNewOrder;
using CQRS_Demo.Commands.UpdateOrder;
using CQRS_Demo.Commands.UpdateProduct;
using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<BaseResponse<Order?>> PostOrderAsync(CreateNewOrderCommand command)
        {
            var response = await mediator.Send(command);
            return new BaseResponse<Order?>(response);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<Order?>> PutOrderAsync(Guid id, IReadOnlyList<Guid> productIds)
        {
            var response = await mediator.Send(new UpdateOrderCommand
            {
                Id = id,
                ProductsIds = productIds
            });
            return new BaseResponse<Order?>(response);
        }
    }
}
