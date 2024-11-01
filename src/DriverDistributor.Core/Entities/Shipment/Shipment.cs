using DriverDistributor.Core.Entities.DriverOrDistributor;

namespace DriverDistributor.Core.Entities.Shipment;

public class Shipment
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public int DistributorId { get; set; }
    public int RouteId { get; set; }
    public int WarehouseId { get; set; }
    public DateOnly Date { get; set; }
    public int InvoiceCount { get; set; }
    public decimal InvoiceAmount { get; set; }
    public int ShipmentCount { get; set; }

    public string PersianDate => new PersianDate(Date).ToString();
    public string Weekday => new WeekdaysClass(Date.DayOfWeek).ToString();

    #region Navigation Properties

    public Driver Driver { get; set; }
    public Distributor Distributor { get; set; }
    public Route.Route Route { get; set; }
    public Warehouse.Warehouse Warehouse { get; set; }

    #endregion

    #region Collection Properties

    public ICollection<ShipmentNumber.ShipmentNumber> ShipmentNumbers { get; set; }

    #endregion
}