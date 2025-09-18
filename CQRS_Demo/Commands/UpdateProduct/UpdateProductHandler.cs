using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.UpdateProduct;

public class UpdateProductHandler(AppDbContext dbContext) : IRequestHandler<UpdateProductCommand, Product?>
{
    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
            
        var product = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
        {
            return null;
        }

        product.Name = request.ProductDto.Name;
        product.Quantity = request.ProductDto.Quantity;

        var response = dbContext.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);
        return response.Entity;
    }
}