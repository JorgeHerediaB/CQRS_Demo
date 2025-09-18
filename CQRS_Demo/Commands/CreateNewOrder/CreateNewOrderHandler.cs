using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using CQRS_Demo.Queries.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.CreateNewOrder;

public class CreateNewOrderHandler : IRequestHandler<CreateNewOrderCommand, OrderDto?>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateNewOrderHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<OrderDto?> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var productDict = request.Products.ToDictionary(p => p.ProductId, p => p.Quantity);

        var matchedProducts = await _dbContext.Products
            .Where(p => productDict.Keys.Contains(p.Id))
            .ToListAsync(cancellationToken);

        if (!matchedProducts.Any())
        {
            return null;
        }

        var orderItems = matchedProducts.Select(product => 
            new OrderListItem
            {
                ProductId = product.Id, 
                Product = product,
                Quantity = productDict.GetValueOrDefault(product.Id, 0)
            }
        ).ToList();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            Products = orderItems
        };

        var response = await _dbContext.Orders.AddAsync(order, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<OrderDto>(response.Entity);

    }
}