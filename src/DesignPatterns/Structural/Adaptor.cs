namespace DesignPatterns.Structural;

/// <summary>
/// 老的不兼容对象
/// </summary>
public class YmlProcessor
{
    public void ProcessYml(string yml)
    {
        Console.WriteLine($"{nameof(YmlProcessor)} 处理 YML文档");
    }
}

public interface IJsonProcess
{
    void ProcessJson(string json);
}

/// <summary>
/// 新的对象封装老的对象
/// </summary>
public class JsonProcessor : IJsonProcess
{
    private readonly YmlProcessor _ymlProcessor;

    public JsonProcessor(YmlProcessor ymlProcessor)
    {
        _ymlProcessor = ymlProcessor;
    }
    
    public void ProcessJson(string json)
    {
        Console.WriteLine($"{nameof(JsonProcessor)} 处理 JSON 文档");
        var yml = JsonToYml(json);
        _ymlProcessor.ProcessYml(yml);
       
    }

    private static string JsonToYml(string json)
    {
        Console.WriteLine("将 JSON 格式文档转换成 YML 格式文档");
        return """
               name:
                 freeman
               """;
    }
}