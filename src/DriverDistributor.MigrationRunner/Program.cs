using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using MigrationRunner;
using DbType = DriverDistributor.Infrastructure.Migrations.DbType;

// Define connection strings
SqlConnectionStringBuilder connectionString1 = new()
{
    DataSource = ".",
    InitialCatalog = "DriverDistributor",
    TrustServerCertificate = true,
    MultipleActiveResultSets = true,
    IntegratedSecurity = true
};

SqlConnectionStringBuilder connectionString3 = new()
{
    DataSource = ".",
    InitialCatalog = "DriverDistributor2",
    TrustServerCertificate = true,
    MultipleActiveResultSets = true,
    IntegratedSecurity = true
};

OleDbConnectionStringBuilder connectionString2 = new()
{
    DataSource = @"C:\Users\a.rahmanian\RiderProjects\DriverDistributor\src\DriverDistributor.accdb",
    Provider = "Microsoft.ACE.OLEDB.12.0",
    PersistSecurityInfo = false
};

#region Migrators

// 1. FluentMigrator Direct Migration
//FluentMigratorRun.UpdateDatabase(connectionString1);

// 2. FluentMigrator with Version Control
/*
Console.WriteLine("Running specific version migration...");
var version = 202411021018;
FluentMigratorRun.UpdateDatabase(connectionString1, version);
*/

// 3. ADO-style Migration

// Using ADO with SQL
//FluentMigratorRun.RunAdo(connectionString3, DbType.Sql);

// Using ADO with Access (if needed)
FluentMigratorRun.RunAdo(connectionString2, DbType.Access);

#endregion