namespace DesignPatterns.Behavioral;

public interface IMediator
{
    void Notify(object sender, string message);
}

public class ComponentBase
{
    protected IMediator? _mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }
}

public class FirstComponent : ComponentBase
{
    public void DoSomething()
    {
        _mediator?.Notify(this, "Draw a circle");
    }

    public void SayHello(object sender)
    {
        Console.WriteLine($"{sender.GetType().Name} required {nameof(FirstComponent)} Say Hello");
    }
}

public class SecondComponent : ComponentBase
{
    public void DoSometing()
    {
        _mediator?.Notify(this, "Say hello");
    }

    public void DrawACircle(object sender)
    {
        Console.WriteLine($"{sender.GetType().Name} required {nameof(SecondComponent)} Draw a circle");
    }
}

public class NotificationMediator : IMediator
{
    private readonly FirstComponent first;
    private readonly SecondComponent second;

    public NotificationMediator(FirstComponent first, SecondComponent second)
    {
        this.first = first;
        this.second = second;
    }

    public void Notify(object sender, string message)
    {
        switch (message)
        {
            case "Draw a circle":
                second.DrawACircle(sender);
                break;
            case "Say hello":
                first.SayHello(sender);
                break;
        }
    }
}