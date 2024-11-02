using FluentMigrator;

namespace DriverDistributor.Infrastructure.Migrations;

[Migration(202411021018)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("Drivers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("PersonnelId").AsString().NotNullable()
            .WithColumn("CarType").AsString().NotNullable();
        Create.Table("Distributors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("PersonnelId").AsString().NotNullable();
        Create.Table("Routes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("RouteName").AsString().NotNullable();
        Create.Table("WarehouseList")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("WarehouseName").AsString().NotNullable();
        Create.Table("ShipmentList")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DriverId").AsInt32().NotNullable().ForeignKey("FK_ShipmentList_Drivers", "Drivers", "Id")
            .WithColumn("DistributorId").AsInt32().NotNullable().ForeignKey("FK_ShipmentList_Distributors", "Distributors", "Id")
            .WithColumn("RouteId").AsInt32().NotNullable().ForeignKey("FK_ShipmentList_Routes", "Routes", "Id")
            .WithColumn("WarehouseId").AsInt32().NotNullable().ForeignKey("FK_ShipmentList_WarehouseList", "WarehouseList", "Id")
            .WithColumn("Date").AsDateTime2().NotNullable()
            .WithColumn("InvoiceCount").AsInt32().NotNullable()
            .WithColumn("InvoiceAmount").AsInt32().NotNullable()
            .WithColumn("ShipmentCount").AsInt32().NotNullable();
        Create.Table("ShipmentNumbers")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Number").AsString().NotNullable()
            .WithColumn("ShipmentId").AsInt32().NotNullable().ForeignKey("FK_ShipmentNumbers_ShipmentList", "ShipmentList", "Id");
    }

    public override void Down()
    {
        Delete.Table("ShipmentNumbers");
        Delete.Table("ShipmentList");
        Delete.Table("WarehouseList");
        Delete.Table("Routes");
        Delete.Table("Distributors");
        Delete.Table("Drivers");
    }
}