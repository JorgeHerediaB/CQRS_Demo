using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.CreateNewProduct
{
    public class CreateNewProductHandler(AppDbContext dbContext, IMapper mapper) : IRequestHandler<CreateNewProductCommand, Product?>
    {
        public async Task<Product> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            var response = await dbContext.Products.AddAsync(mapper.Map<Product>(request.ProductDto));
            await dbContext.SaveChangesAsync();
            return response!.Entity;
        }
    }
}
