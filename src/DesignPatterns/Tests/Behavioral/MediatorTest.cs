using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class MediatorTest
{
    [Test]
    public void Behavior()
    {
        var first = new FirstComponent();
        var second = new SecondComponent();
        var mediator = new NotificationMediator(first, second);
        first.SetMediator(mediator);
        second.SetMediator(mediator);

        first.DoSomething();
        second.DoSometing();
    }
}