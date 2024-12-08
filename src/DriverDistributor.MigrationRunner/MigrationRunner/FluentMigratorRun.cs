using DriverDistributor.Infrastructure.Migrations;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace MigrationRunner;

public static class FluentMigratorRun
{
    public static ServiceProvider CreateServices(SqlConnectionStringBuilder connectionString)
    {
        return new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString.ToString())
                .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
    }

    public static void UpdateDatabase(SqlConnectionStringBuilder connectionString, long? version = null)
    {
        EnsureCreateDatabase(connectionString);

        var serviceProvider = CreateServices(connectionString);
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        Action run = version.HasValue
            ? () => runner.MigrateUp(version!.Value)
            : () => runner.MigrateUp();
        run.Invoke();
    }

    public static void RunAdo(SqlConnectionStringBuilder connectionString, DbType dbType)
    {
        if (dbType == DbType.Sql)
        {
            EnsureCreateDatabase(connectionString);
        }

        AdoMigration.CreateTable(connectionString.ToString(), dbType);
    }

    public static void EnsureCreateDatabase(SqlConnectionStringBuilder connectionString)
    {
        var databaseName = connectionString.InitialCatalog;
        var masterConnectionString = new SqlConnectionStringBuilder(connectionString.ToString())
        {
            InitialCatalog = "master"
        };

        using var connection = new SqlConnection(masterConnectionString.ToString());
        connection.Open();

        var checkDbExist = $@"
        IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}')
        BEGIN
            CREATE DATABASE [{databaseName}]
        END";

        using var command = new SqlCommand(checkDbExist, connection);
        command.ExecuteNonQuery();
    }
}