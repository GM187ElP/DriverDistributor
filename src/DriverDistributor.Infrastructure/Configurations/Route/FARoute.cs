using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.Route;

public class FARoute : IEntityTypeConfiguration<Core.Entities.Route.Route>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Route.Route> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(r => r.RouteName).IsRequired().HasMaxLength(25);

        builder.HasMany<Core.Entities.Shipment.Shipment>(r => r.Shipments).WithOne(s => s.Route).HasForeignKey(s => s.RouteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}