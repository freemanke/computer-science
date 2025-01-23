namespace DesignPatterns.Structural;

public interface IEmailService
{
    void Send(string message);
}

public class AliEmailService : IEmailService
{
    public void Send(string message)
    {
        Console.WriteLine($"通过阿里云邮件服务器发送邮件 {message}");
        Thread.Sleep(1000);
    }
}

public abstract class BaseDecorator: IEmailService
{
    private readonly IEmailService emailService;

    protected BaseDecorator(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    public virtual void Send(string message)
    {
        emailService.Send(message);
    }
}

public class LogDecorator : BaseDecorator
{
    public LogDecorator(IEmailService emailService) : base(emailService)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{DateTime.Now} 开始调用发送服务...");
        base.Send(message);
        Console.WriteLine($"{DateTime.Now} 调用发送服务完成");
    }
}