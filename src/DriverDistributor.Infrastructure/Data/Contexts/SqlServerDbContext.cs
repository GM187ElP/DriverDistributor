using Microsoft.EntityFrameworkCore;

public class SqlServerDbContext : DbContextBase
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) 
        : base(options)
    {
    }

    public override Task InitializeDatabaseAsync()
    {
        return Database.EnsureCreatedAsync();
    }
    // Additional configurations can go here
}