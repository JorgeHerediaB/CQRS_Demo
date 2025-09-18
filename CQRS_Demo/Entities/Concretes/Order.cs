using CQRS_Demo.Entities.Bases;

namespace CQRS_Demo.Entities.Concretes
{
    public class Order : BaseEntity
    {
        public List<Product> Products { get; set; } = [];
        public string Currency { get; set; } = "bob";
    }
}
