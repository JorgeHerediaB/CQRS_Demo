using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.UpdateOrder
{
    public class UpdateOrderHandler(AppDbContext context) : IRequestHandler<UpdateOrderCommand, Order?>
    {
        public async Task<Order?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id);
            if (order == null)
            {
                Console.WriteLine("NO ORDER FOUND");
                return null;
            }

            var matchedProducts = await context.Products.Where(p => request.ProductsIds.Contains(p.Id)).ToListAsync();
            if (!matchedProducts.Any())
            {
                return null;
            }

            order.Products = matchedProducts;

            var response = context.Orders.Update(order);
            await context.SaveChangesAsync();
            return response.Entity;
        }
    }
}
