using DriverDistributor.Core.Entities.DriverOrDistributor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.DriverOrDistributor;

public class FADistributor : IEntityTypeConfiguration<Distributor>
{
    public void Configure(EntityTypeBuilder<Distributor> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.Property(d => d.PersonnelId).IsRequired().HasMaxLength(10);
        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);

        builder.HasMany(d => d.Shipments).WithOne(s => s.Distributor).HasForeignKey(s => s.DistributorId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
    }
}