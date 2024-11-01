using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DriverDistributor.Infrastructure.Configurations.Warehouse;

public class FAWarehouse : IEntityTypeConfiguration<Core.Entities.Warehouse.Warehouse>
{
    public void Configure(EntityTypeBuilder<Core.Entities.Warehouse.Warehouse> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).ValueGeneratedOnAdd();
        builder.Property(w => w.WarehouseName).IsRequired();
    }
}