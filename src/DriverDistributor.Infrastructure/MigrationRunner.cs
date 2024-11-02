using DriverDistributor.Infrastructure.Migrations;

namespace DriverDistributor.Infrastructure;

using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class MigrationRunner
{
    public static void Run(string connectionString)
    {
        // Create a host builder to configure services
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Add FluentMigrator services
                services.AddFluentMigratorCore()
                    .ConfigureRunner(runner =>
                        runner.AddSqlServer() // Use the appropriate database provider
                            .WithGlobalConnectionString(connectionString)
                            .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole()); // Optional logging
            })
            .Build();

        // Execute the migrations
        using (var scope = host.Services.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp(); // Apply all pending migrations
        }
    }
}