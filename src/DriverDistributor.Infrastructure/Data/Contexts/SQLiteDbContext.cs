using Microsoft.EntityFrameworkCore;

public class SQLiteDbContext : DbContextBase
{
    public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) 
        : base(options)
    {
    }

    public override Task InitializeDatabaseAsync()
    {
        return Database.EnsureCreatedAsync();
    }
}