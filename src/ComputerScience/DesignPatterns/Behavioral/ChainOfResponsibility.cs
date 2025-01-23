using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DesignPatterns.Behavioral;

public class Request
{
    public string Token { get; set; } = "";
    public string Header { get; set; } = "";
    public string Body { get; set; } = "";
}

public interface IHandler
{
    void Handle(Request request);
    void SetNextHandler(IHandler handler);
    List<string> Logs { get; }
}

public abstract class BaseHandler : IHandler
{
    protected IHandler? nextHandler;
    public List<string> Logs { get; } = [];
    
    public abstract void Handle(Request request);

    public void SetNextHandler(IHandler handler)
    {
        nextHandler = handler;
    }
}

public class AuthenticationHandler : BaseHandler
{

    public override void Handle(Request request)
    {
        Logs.Add($"{nameof(AuthenticationHandler)} 处理请求 {JsonSerializer.Serialize(request)}");
        nextHandler?.Handle(request);
    }
}

public class AuthorizationHandler : BaseHandler
{
    public override void Handle(Request request)
    {
        Logs.Add($"{nameof(AuthorizationHandler)} 处理请求 {JsonSerializer.Serialize(request)}");
        nextHandler?.Handle(request);
    }
}

public class ValidationHandler : BaseHandler
{
    public override void Handle(Request request)
    {
        Logs.Add($"{nameof(ValidationHandler)} 处理请求 {JsonSerializer.Serialize(request)}");
        nextHandler?.Handle(request);
    }
}