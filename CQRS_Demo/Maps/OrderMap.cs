using CQRS_Demo.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS_Demo.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Currency);
            builder.Property(x => x.Products);
            builder.HasMany(x => x.Products).WithMany();
        }
    }
}
