using System.Text.Json;

namespace DesignPatterns.Creational;

public class Configuration
{
    private static readonly Lazy<Configuration> config = new(() =>
        new Configuration(), LazyThreadSafetyMode.ExecutionAndPublication);

    private Configuration()
    {
    }

    public static Configuration Instance => config.Value;

    public string Address { get; set; } = "";
    public string Name { get; set; } = "";
    public string ToJson => JsonSerializer.Serialize(this);
}