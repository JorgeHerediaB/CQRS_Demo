namespace CQRS_Demo.Queries.DTOs;

public class OrderListDto
{
    public Guid Id { get; set; }
    public string Currency { get; set; } = "bob";
    public int ProductsCount { get; set; }
    public int TotalQuantity { get; set; }
}
