namespace DriverDistributor.Core.Entities.Route;

public class Route
{
    public int Id { get; set; }
    public string RouteName { get; set; }

    #region Collection Properties

    public ICollection<Shipment.Shipment> Shipments { get; set; }

    #endregion
}