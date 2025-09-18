using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.CreateNewOrder
{
    public class CreateNewOrderHandler(AppDbContext dbContext) : IRequestHandler<CreateNewOrderCommand, Order?>
    {
        public async Task<Order?> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var matchedProducts = await dbContext.Products.Where(p => request.ProductIds.Contains(p.Id)).ToListAsync();
            if (!matchedProducts.Any())
            {
                Console.WriteLine("NO MATCHED PRODUCTS FOUND");
                return null;
            }

            var response = await dbContext.Orders.AddAsync(new Order
            {
                Id = Guid.NewGuid(),
                Products = matchedProducts,
            });
            await dbContext.SaveChangesAsync();
            return response.Entity;
        }
    }
}
