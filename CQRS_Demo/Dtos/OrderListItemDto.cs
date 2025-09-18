namespace CQRS_Demo.Dtos;

public class OrderListItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}