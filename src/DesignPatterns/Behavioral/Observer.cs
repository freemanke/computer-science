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

public interface IPublisher
{
    void AddSubscriber(ISubscriber subscriber);
    void DeleteSubscriber(ISubscriber subscriber);
    void Notify(string message);
}

public class Publisher: IPublisher
{
    private readonly List<ISubscriber> _subscribers = [];

    public void AddSubscriber(ISubscriber subscriber)
    {
        if (_subscribers.All(a => a != subscriber))
        {
            _subscribers.Add(subscriber);
            Console.WriteLine($"添加订阅者");
        }
    }

    public void DeleteSubscriber(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
        Console.WriteLine($"删除订阅者");
    }

    public void Notify(string message)
    {
        Console.WriteLine($"发布通知消息：{message}");
        _subscribers.ForEach(a=>a.Update(message));
    }
    
}