namespace DesignPatterns.Structural;

public interface IYmlProcess
{
    void ProcessYml(string yml);
}

/// <summary>
/// 老的不兼容对象
/// </summary>
public class YmlProcessor: IYmlProcess
{
    public void ProcessYml(string yml)
    {
        Console.WriteLine("xml");
    }
}

public interface IJsonProcess
{
    void ProcessJson(string json);
}

/// <summary>
/// 新的对象封装老的对象
/// </summary>
public class JsonProcessor : IJsonProcess, IYmlProcess
{
    private IYmlProcess _ymlProcessor;

    public JsonProcessor(IYmlProcess ymlProcessor)
    {
        _ymlProcessor = ymlProcessor;
    }

    public void ProcessYml(string yml)
    {
        var json = YmlToJson(yml);
        ProcessJson(json);
    }

    public void ProcessJson(string json)
    {
        Console.WriteLine(json);
    }

    private string YmlToJson(string yml)
    {
        Console.WriteLine("将 YML 格式转换成 JSON 格式");
        return "{\"name\": \"freeman\"}";
    }
}