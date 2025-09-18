using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using CQRS_Demo.Queries.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Commands.UpdateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, OrderDto?>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateOrderHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        if (order == null)
        {
            return null;
        }

        var productDict = request.Products
            .ToDictionary(p => p.ProductId, p => p.Quantity);
        var matchedProducts = await _context.Products.Where(p => productDict.Keys.Contains(p.Id))
            .ToListAsync(cancellationToken);
        if (!matchedProducts.Any())
        {
            return null;
        }

        order.Products.Clear();
        order.Products = matchedProducts.Select(p => 
            new OrderListItem
            {
                ProductId = p.Id, 
                Product = p,
                Quantity = productDict.GetValueOrDefault(p.Id, 0)
            }).ToList();

        var response = _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OrderDto?>(response.Entity);
    }
}