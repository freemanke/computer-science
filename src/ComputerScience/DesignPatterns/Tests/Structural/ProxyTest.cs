using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class ProxyTest
{
    [Test]
    public void Proxy()
    {
        var proxy = new OrderServiceProxy(new OrderService());
        proxy.AddItem("帽子");
        proxy.AddItem("鞋子");
        proxy.AddItem("围巾");

        Assert.That(proxy.GetItems().Count, Is.EqualTo(2));
    }
}