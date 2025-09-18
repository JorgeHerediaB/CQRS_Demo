using AutoMapper;
using CQRS_Demo.Context;
using CQRS_Demo.Entities.Concretes;
using MediatR;

namespace CQRS_Demo.Commands.CreateNewProduct;

public class CreateNewProductHandler : IRequestHandler<CreateNewProductCommand, Product?>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateNewProductHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Product?> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _dbContext.Products
            .AddAsync(_mapper.Map<Product>(request.ProductDto), cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return response!.Entity;
    }
}