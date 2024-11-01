using DriverDistributor.Core.Entities.DriverOrDistributor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.DriverOrDistributor;

public class FADriver : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.Property(d => d.PersonnelId).IsRequired().HasMaxLength(10);
        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);
        builder.Property(d => d.CarType).HasMaxLength(25);

        builder.HasMany(d => d.Shipments).WithOne(s => s.Driver).HasForeignKey(s => s.DriverId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
    }
}