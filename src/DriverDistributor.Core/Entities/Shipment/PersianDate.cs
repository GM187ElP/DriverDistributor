namespace DriverDistributor.Core.Entities.Shipment;

public class PersianDate
{
    private string _date { get; set; }

    public PersianDate(DateOnly date)
    {
        _date = GetPersianDate(date);
    }

    private static Dictionary<int, int> _yearLength = new()
    {
        { 1403, 366 }, { 1404, 365 }, { 1405, 365 }, { 1406, 365 }, { 1407, 365 }, { 1408, 366 }, { 1409, 365 }
    };

    private static Dictionary<int, DateOnly> _yearStartDate = new()
    {
        { 1403, new DateOnly(2024, 03, 20) }, { 1404, new DateOnly(2025, 03, 21) }, { 1405, new DateOnly(2026, 03, 21) },
        { 1406, new DateOnly(2027, 03, 21) }, { 1407, new DateOnly(2028, 03, 20) }, { 1408, new DateOnly(2029, 03, 20) },
        { 1409, new DateOnly(2030, 03, 21) }
    };

    private static Dictionary<string, string> _monthName = new()
    {
        { "01", "فروردین" }, { "02", "اردیبهشت" }, { "03", "خرداد" }, { "04", "تیر" }, { "05", "مرداد" }, { "06", "شهریور" }, { "07", "مهر" },
        { "08", "آبان" }, { "09", "آذر" },
        { "10", "دی" }, { "11", "بهمن" }, { "12", "اسفند" }
    };

    private static Dictionary<int, string> _monthNum = new()
    {
        { 1, "01" }, { 2, "02" }, { 3, "03" }, { 4, "04" }, { 5, "05" }, { 6, "06" }, { 7, "07" }, { 8, "08" }, { 9, "09" },
        { 10, "10" }, { 11, "11" }, { 12, "12" }
    };


    private static Dictionary<int, int> _monthLength = new()
    {
        { 1, 31 }, { 2, 62 }, { 3, 93 }, { 4, 124 }, { 5, 155 }, { 6, 186 }, { 7, 216 }, { 8, 246 }, { 9, 276 }, { 10, 306 }, { 11, 336 }
    };

    private string GetPersianDate(DateOnly date)
    {
        var yearInfo = _yearStartDate.First(d => d.Value <= date);
        int persianYear = yearInfo.Key;
        int dayOfYearInPersianCalendar = (date.DayNumber - yearInfo.Value.DayNumber) + 1;
        int persianMonth = _monthLength.First(m => m.Value < dayOfYearInPersianCalendar).Key;
        int persianDay = dayOfYearInPersianCalendar - _monthLength[persianMonth - 1];

        return $"{persianYear}/{persianMonth:D2}/{persianDay:D2}";
    }

    public override string ToString() => _date;
}