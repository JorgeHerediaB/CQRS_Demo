using CQRS_Demo.Commands.CreateNewProduct;
using CQRS_Demo.Commands.UpdateProduct;
using CQRS_Demo.Dtos;
using CQRS_Demo.Entities.Concretes;
using CQRS_Demo.Queries.DTOs;
using CQRS_Demo.Queries.GetAllProducts;
using CQRS_Demo.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IMediator mediator) : ControllerBase
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
        public async Task<BaseResponse<List<ProductQueryDto>>> GetAllProductAsync()
        {
            var response = await mediator.Send(new GetAllProductsQuery());
            return new BaseResponse<List<ProductQueryDto>>(response);
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<ProductQueryDto?>> GetProductByIdAsync(Guid id)
        {
            var response = await mediator.Send(new GetProductByIdQuery { Id = id });
            return new BaseResponse<ProductQueryDto?>(response);
        }
    }
}
