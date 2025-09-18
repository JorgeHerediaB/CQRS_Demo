using CQRS_Demo.Entities.Interfaces;

namespace CQRS_Demo.Entities.Bases
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
