// ReSharper disable JoinDeclarationAndInitializer
using System.Text.Json;
using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class ChainOfResponsibilityTest
{
    [Test]
    public void Behavior()
    {
        var authenticationHandler = new AuthenticationHandler();
        var authorizationHandler = new AuthorizationHandler();
        var validationHander = new ValidationHandler();
        authenticationHandler.SetNextHandler(authorizationHandler);
        authorizationHandler.SetNextHandler(validationHander);
        
        var request = new Request { Token = "token", Header = "header", Body = "body" };
        authenticationHandler.Handle(request);
        string log;
        
        log = $"{nameof(AuthenticationHandler)} 处理请求 {JsonSerializer.Serialize(request)}";
        Assert.That(authenticationHandler.Logs, Does.Contain(log));
        
        log = $"{nameof(AuthorizationHandler)} 处理请求 {JsonSerializer.Serialize(request)}";
        Assert.That(authorizationHandler.Logs, Does.Contain(log));
       
        log = $"{nameof(ValidationHandler)} 处理请求 {JsonSerializer.Serialize(request)}";
        Assert.That(validationHander.Logs, Does.Contain(log));
    }
}