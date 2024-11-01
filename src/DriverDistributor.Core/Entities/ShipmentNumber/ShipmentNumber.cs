namespace DriverDistributor.Core.Entities.ShipmentNumber;

public class ShipmentNumber
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int ShipmentId { get; set; }

    # region Navigation Properties

    public Core.Entities.Shipment.Shipment Shipment { get; set; }

    # endregion
}