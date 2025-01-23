using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class DecoratorTest
{
    [Test]
    public void Decorator()
    {
        IEmailService emailService = new LogDecorator(new AliEmailService());
        emailService.Send("Hello World!");
    }
}