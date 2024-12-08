using System.Data.OleDb;
using Microsoft.Data.SqlClient;

namespace DriverDistributor.Infrastructure.Migrations;

public class AdoMigration
{
    public static void CreateTable(string connectionString, DbType dbType)
    {
        var createTableScriptsSql = @"
            CREATE TABLE Drivers (
                Id INT PRIMARY KEY IDENTITY(1,1),
                FirstName NVARCHAR(25) NOT NULL,
                LastName NVARCHAR(25) NOT NULL,
                PersonnelId NVARCHAR(5) NOT NULL,
                CarType NVARCHAR(10) NOT NULL
            );
            CREATE TABLE Distributor (
                Id INT PRIMARY KEY IDENTITY(1,1),
                FirstName NVARCHAR(25) NOT NULL,
                LastName NVARCHAR(25) NOT NULL,
                PersonnelId NVARCHAR(5) NOT NULL
            );
            CREATE TABLE Routes (
                Id INT PRIMARY KEY IDENTITY(1,1),
                RouteName NVARCHAR(25) NOT NULL
            );
            CREATE TABLE WarehouseList (
                Id INT PRIMARY KEY IDENTITY(1,1),
                WarehouseName NVARCHAR(25) NOT NULL
            );
            CREATE TABLE ShipmentList (
                Id INT PRIMARY KEY IDENTITY(1,1),
                DriverId INT NOT NULL,
                DistributorId INT NOT NULL,
                RouteId INT NOT NULL,
                WarehouseId INT NOT NULL,
                Date DATE NOT NULL,
                InvoiceCount INT NOT NULL,
                InvoiceAmount INT NOT NULL,
                ShipmentCount INT NOT NULL,
                FOREIGN KEY (DriverId) REFERENCES Drivers(Id),
                FOREIGN KEY (DistributorId) REFERENCES Distributor(Id),
                FOREIGN KEY (RouteId) REFERENCES Routes(Id),
                FOREIGN KEY (WarehouseId) REFERENCES WarehouseList(Id)
            );
            CREATE TABLE ShipmentNumbers (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Number NVARCHAR(10) NOT NULL,
                ShipmentId INT NOT NULL,
                FOREIGN KEY (ShipmentId) REFERENCES ShipmentList(Id)
            );
        ";
        List<string> createTableScriptsAccess = new()
        {
            //-- Create Parent Tables
            @"
            CREATE TABLE Drivers (
            Id AUTOINCREMENT PRIMARY KEY,
            FirstName TEXT(25) NOT NULL,
            LastName TEXT(25) NOT NULL,
            PersonnelId TEXT(5) NOT NULL,
            CarType TEXT(10) NOT NULL
            );",

            @"
            CREATE TABLE Distributor (
            Id AUTOINCREMENT PRIMARY KEY,
            FirstName TEXT(25) NOT NULL,
            LastName TEXT(25) NOT NULL,
            PersonnelId TEXT(5) NOT NULL
            );            ",

            @"
            CREATE TABLE Routes (
            Id AUTOINCREMENT PRIMARY KEY,
            RouteName TEXT(25) NOT NULL
            );",

            @"            CREATE TABLE WarehouseList (
            Id AUTOINCREMENT PRIMARY KEY,
            WarehouseName TEXT(25) NOT NULL
            );",

            // Create Child Tables with Foreign Keys
            @"
            CREATE TABLE ShipmentList (
            Id AUTOINCREMENT PRIMARY KEY,
            DriverId LONG NOT NULL,
            DistributorId LONG NOT NULL,
            RouteId LONG NOT NULL,
            WarehouseId LONG NOT NULL,
            ShipmentDate DATETIME NOT NULL,
            InvoiceCount LONG NOT NULL,
            InvoiceAmount LONG NOT NULL,
            ShipmentCount LONG NOT NULL,
            FOREIGN KEY (DriverId) REFERENCES Drivers(Id),
            FOREIGN KEY (DistributorId) REFERENCES Distributor(Id),
            FOREIGN KEY (RouteId) REFERENCES Routes(Id),
            FOREIGN KEY (WarehouseId) REFERENCES WarehouseList(Id)
            );",

            @"
            CREATE TABLE ShipmentNumbers (
            Id AUTOINCREMENT PRIMARY KEY,
            Number TEXT(10) NOT NULL,
            ShipmentId LONG NOT NULL,
            FOREIGN KEY (ShipmentId) REFERENCES ShipmentList(Id)
            );"
        };

        switch (dbType)
        {
            case DbType.Sql:
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(createTableScriptsSql, connection);
                    command.ExecuteNonQuery();
                }

                break;

            case DbType.Access:
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    foreach (var s in createTableScriptsAccess)
                    {
                        OleDbCommand command = new OleDbCommand(s, connection);
                        command.ExecuteNonQuery();
                    }
                }

                break;

            default:
                throw new ArgumentException("Unsupported DbType");
        }
    }
}

public enum DbType
{
    Sql,
    Access
}