namespace CQRS_Demo.Queries.DTOs;

public class ViewOrderListItemDto
{
    public ProductQueryDto Product { get; set; }
    public int Quantity { get; set; }
}