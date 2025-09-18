using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Queries.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Demo.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductQueryDto?>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductQueryDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return null;
        }

        return _mapper.Map<ProductQueryDto>(product);
    }
}
