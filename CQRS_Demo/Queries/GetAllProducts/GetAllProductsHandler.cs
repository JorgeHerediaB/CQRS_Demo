using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Queries.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Queries.GetAllProducts;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductQueryDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductQueryDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.ToListAsync(cancellationToken);
        return _mapper.Map<List<ProductQueryDto>>(products);
    }
}
