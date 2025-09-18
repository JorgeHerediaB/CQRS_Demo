using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.CreateNewOrder;

public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand, Order?>
{
    private readonly AppDbContext _dbContext;

    public CreateNewOrderHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order?> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var matchedProducts = await _dbContext.Products.Where(p => request.ProductIds
            .Contains(p.Id)).ToListAsync(cancellationToken);
        if (!matchedProducts.Any())
        {
            return null;
        }

        var response = await _dbContext.Orders.AddAsync(new Order
        {
            Id = Guid.NewGuid(),
            Products = matchedProducts,
        }, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return response.Entity;
    }
}