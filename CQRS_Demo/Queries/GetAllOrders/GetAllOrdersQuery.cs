using CQRS_Demo.Queries.DTOs;
using MediatR;

namespace CQRS_Demo.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<List<OrderListDto>>
{
}
