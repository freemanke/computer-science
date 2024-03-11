using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class ObserverTest
{
    [Test]
    public void Behavior()
    {
        var studentJim = new Student { Name = "Jim" };
        var studentBob = new Student { Name = "Bob" };
        var teacher = new Teacher { Name = "Emily" };
        
        var publisher = new Publisher();
        publisher.AddSubscriber(studentJim);
        publisher.AddSubscriber(studentBob);
        publisher.AddSubscriber(teacher);
        publisher.Notify("2024年9月1日开学通知");
    }
}