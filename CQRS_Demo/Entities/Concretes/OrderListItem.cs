using CQRS_Demo.Entities.Interfaces;

namespace CQRS_Demo.Entities.Concretes;

public class OrderListItem : IEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}