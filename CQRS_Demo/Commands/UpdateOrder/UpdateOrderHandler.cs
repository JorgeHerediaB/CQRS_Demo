using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.UpdateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Order?>
{
    private readonly AppDbContext _context;

    public UpdateOrderHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        if (order == null)
        {
            return null;
        }

        var matchedProducts = await _context.Products.Where(p => request.ProductsIds.Contains(p.Id)).ToListAsync();
        if (!matchedProducts.Any())
        {
            return null;
        }

        order.Products = matchedProducts;

        var response = _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return response.Entity;
    }
}