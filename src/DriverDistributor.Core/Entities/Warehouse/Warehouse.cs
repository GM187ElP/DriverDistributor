namespace DriverDistributor.Core.Entities.Warehouse;

public class Warehouse
{
    public int Id { get; set; }
    public string WarehouseName { get; set; }

    #region Collection Properties

    public ICollection<Core.Entities.Shipment.Shipment> Shipments { get; set; }

    #endregion
}