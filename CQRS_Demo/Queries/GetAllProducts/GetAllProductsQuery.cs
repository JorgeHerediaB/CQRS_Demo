using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductQueryDto>>
{
}
