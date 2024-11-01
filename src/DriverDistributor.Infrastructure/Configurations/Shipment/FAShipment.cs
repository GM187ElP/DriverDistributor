using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.Shipment;

public class FAShipment : IEntityTypeConfiguration<Core.Entities.Shipment.Shipment>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Shipment.Shipment> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.DriverId).IsRequired();
        builder.Property(s => s.DistributorId).IsRequired();
        builder.Property(s => s.RouteId).IsRequired();
        builder.Property(s => s.WarehouseId).IsRequired();
        builder.Property(s => s.Date).IsRequired();
        builder.Property(s => s.PersianDate).IsRequired();
        builder.Property(s => s.InvoiceCount).IsRequired();
        builder.Property(s => s.InvoiceAmount).IsRequired();
        builder.Ignore(s => s.ShipmentCount);
        builder.Ignore(s => s.Weekday);

        builder.HasMany<Core.Entities.ShipmentNumber.ShipmentNumber>(s => s.ShipmentNumbers).WithOne(s => s.Shipment)
            .HasForeignKey(s => s.ShipmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}