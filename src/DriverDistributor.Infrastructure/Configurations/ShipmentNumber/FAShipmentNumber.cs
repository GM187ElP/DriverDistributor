using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.ShipmentNumber;

public class FAShipmentNumber : IEntityTypeConfiguration<Core.Entities.ShipmentNumber.ShipmentNumber>
{
    public void Configure(EntityTypeBuilder<Core.Entities.ShipmentNumber.ShipmentNumber> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.Number).IsRequired();
        builder.Property(s => s.ShipmentId).IsRequired();
    }
}