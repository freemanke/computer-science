namespace DesignPatterns.Behavioral;

public interface ISubscriber
{
    void Update(string message);
}

public class Student : ISubscriber
{
    public string Name { get; set; } = "";
    
    public void Update(string message)
    {
        Console.WriteLine($"学生 {Name} 收到订阅通知：{message}");
    }
}

public class Teacher : ISubscriber
{
    public string Name { get; set; } = "";
    
    public void Update(string message)
    {
        Console.WriteLine($"老师 {Name} 收到订阅通知：{message}");
    }
}

public class Publisher
{
    private readonly List<ISubscriber> _subscribers = [];

    public void AddSubscriber(ISubscriber subscriber)
    {
        if (_subscribers.All(a=> a!= subscriber)) _subscribers.Add(subscriber);
    }

    public void Notify(string message)
    {
        _subscribers.ForEach(a=>a.Update(message));
    }
    
}