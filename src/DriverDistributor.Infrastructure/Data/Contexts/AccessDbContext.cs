using Microsoft.EntityFrameworkCore;

public class AccessDbContext : DbContextBase
{
    public AccessDbContext(DbContextOptions<AccessDbContext> options) 
        : base(options)
    {
    }

    public override Task InitializeDatabaseAsync()
    {
        return Task.CompletedTask; // Implement as needed for Access
    }

    
}