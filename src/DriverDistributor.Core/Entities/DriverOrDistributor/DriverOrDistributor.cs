namespace DriverDistributor.Core.Entities.DriverOrDistributor;

public abstract class DriverOrDistributor
{
    public int Id { get; set; }
    public int PersonnelId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    #region Collection Properties

    public ICollection<Shipment.Shipment> Shipments { get; set; }

    #endregion
}

public class Driver : DriverOrDistributor
{
    public CarTypeClass CarType { get; set; }
}

public class Distributor : DriverOrDistributor
{
}