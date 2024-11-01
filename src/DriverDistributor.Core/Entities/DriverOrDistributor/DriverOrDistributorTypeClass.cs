namespace DriverDistributor.Core.Entities.DriverOrDistributor;

public class DriverOrDistributorTypeClass
{
    private DriverOrDistributorTypeEnum TypeSelector { get; set; }
    private string Description { get; set; }

    public DriverOrDistributorTypeClass(DriverOrDistributorTypeEnum type)
    {
        TypeSelector = type;
        Description = GetTypeDescription();
    }

    private string GetTypeDescription()
    {
        return TypeSelector switch
        {
            DriverOrDistributorTypeEnum.Distributor => "موزع",
            DriverOrDistributorTypeEnum.Driver => "راننده"
        };
    }

    public override string ToString() => Description;
}