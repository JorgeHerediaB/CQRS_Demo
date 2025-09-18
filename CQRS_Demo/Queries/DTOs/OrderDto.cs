namespace CQRS_Demo.Queries.DTOs;

public class OrderDto
{
    public Guid Id { get; set; }
    public List<ProductQueryDto> Products { get; set; } = [];
    public string Currency { get; set; } = "bob";
    public int TotalProducts => Products.Count;
    public int TotalQuantity => Products.Sum(p => p.Quantity);
}
