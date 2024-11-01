namespace DriverDistributor.Core.Entities.DriverOrDistributor;

public class CarTypeClass
{
    public string Description { get; private set; }
    private CarTypeEnum _type { get; set; }

    public CarTypeClass(CarTypeEnum type)
    {
        _type = type;
        Description = GetTypeDescription();
    }

    private string GetTypeDescription()
    {
        return _type switch
        {
            CarTypeEnum.Isuzu => "ایسوزو",
            CarTypeEnum.Nissan => "نیسان"
        };
    }

    public override string ToString() => Description;
}