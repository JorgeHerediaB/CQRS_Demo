using CQRS_Demo.Entities.Bases;

namespace CQRS_Demo.Entities.Concretes;

public class Order : BaseEntity
{
    public List<OrderListItem> Products { get; set; } = [];
    public string Currency { get; set; } = "bob";
    public decimal Total => Products.Sum(i => i.Product.Price * i.Quantity);
}