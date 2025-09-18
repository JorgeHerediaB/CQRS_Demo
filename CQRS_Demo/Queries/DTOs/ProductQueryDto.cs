namespace CQRS_Demo.Queries.DTOs;

public class ProductQueryDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
}
