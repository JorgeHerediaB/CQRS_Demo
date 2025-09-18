using CQRS_Demo.Entities.Bases;

namespace CQRS_Demo.Entities.Concretes
{
    public class Product : BaseEntity
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
