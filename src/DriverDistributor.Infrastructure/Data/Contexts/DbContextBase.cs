using DriverDistributor.Core.Entities.Shipment;
using DriverDistributor.Core.Entities.ShipmentNumber;
using Microsoft.EntityFrameworkCore;

public abstract class DbContextBase : DbContext
{
    protected DbContextBase(DbContextOptions options) : base(options)
    {
    }

    public abstract Task InitializeDatabaseAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        // Additional common configurations can go here

        base.OnModelCreating(modelBuilder);
    }

    // Define your DbSets here
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentNumber> ShipmentNumbers { get; set; }
}