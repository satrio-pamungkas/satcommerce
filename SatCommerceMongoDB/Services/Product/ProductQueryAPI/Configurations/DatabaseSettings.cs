namespace ProductQueryAPI.Configurations;

public class DatabaseSettings
{
    public String ConnectionString { get; set; } = null!;
    public String DatabaseName { get; set; } = null!;
    public String CollectionName { get; set; } = null!;
}