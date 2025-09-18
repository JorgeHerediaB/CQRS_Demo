using CQRS_Demo.Commands;
using CQRS_Demo.Commands.UpdateProduct;
using CQRS_Demo.Context;
using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IMediator mediator, AppDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<BaseResponse<Product?>> PostProductAsync(CreateNewProductCommand command)
        {
            var response = await mediator.Send(command);
            return new BaseResponse<Product?>(response);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<Product?>> PutProductAsync(Guid id, ProductDto productDto)
        {
            var response = await mediator.Send(new UpdateProductCommand
            {
                Id = id,
                ProductDto = productDto
            });
            return new BaseResponse<Product?>(response);
        }

        [HttpGet]
        public async Task<BaseResponse<IList<Product>>> GetAllProduct()
        {
            // TODO: Override with queries logic
            var products = context.Products.ToList();
            return new BaseResponse<IList<Product>>(products);
        }
    }
}
