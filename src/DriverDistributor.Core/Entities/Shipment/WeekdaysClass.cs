namespace DriverDistributor.Core.Entities.Shipment;

public class WeekdaysClass
{
    private DayOfWeek Weekday { get; set; }
    private string Day { get; set; }

    public WeekdaysClass(DayOfWeek date)
    {
        Weekday = date;
        GetDay();
    }

    private void GetDay()
    {
        Day = Weekday switch
        {
            DayOfWeek.Saturday => "شنبه",
            DayOfWeek.Sunday => "یک شنبه",
            DayOfWeek.Monday => "دوشنبه",
            DayOfWeek.Tuesday => "سه شنبه",
            DayOfWeek.Wednesday => "چهارشنبه",
            DayOfWeek.Thursday => "پنج شنبه",
            DayOfWeek.Friday => "جمعه",
        };
    }

    public override string ToString() => Day;
}