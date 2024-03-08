namespace DesignPatterns.Tests;

public class SingletonTest
{
    [Test]
    public void Create()
    {
        var config = Configuration.Instance;
        Assert.That(config, Is.Not.Null);
        config.Address = "127.0.0.1";
        Assert.That(config.Address, Is.EqualTo("127.0.0.1"));
    }
}