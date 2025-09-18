using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Queries.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Queries.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderListDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllOrdersHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderListDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _context.Orders
            .Include(o => o.Products)
            .ThenInclude(p => p.Product)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<OrderListDto>>(orders);
    }
}
