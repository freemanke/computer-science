namespace DesignPatterns.Tests.Behavioral;

public class Receiver
{
    public string Article = "";

    public void Copy(string content) => Article += content;

    public void Delete(string content)
    {
        if (Article.EndsWith(content))
            Article = Article.Remove(Article.Length - content.Length);
    }
}

public interface ICommand
{
    void Execute();
}

public class DeleteCommand : ICommand
{
    private readonly Receiver receiver;
    public readonly string content;

    public DeleteCommand(Receiver receiver, string content)
    {
        this.receiver = receiver;
        this.content = content;
    }

    public void Execute() => receiver.Delete(content);
}

public class CopyCommnad : ICommand
{
    private readonly Receiver receiver;
    public readonly string content;

    public CopyCommnad(Receiver receiver, string content)
    {
        this.receiver = receiver;
        this.content = content;
    }

    public void Execute() => receiver.Copy(content);
}

public class Invoker
{
    private ICommand? onCopy;
    private ICommand? onDelete;

    public void SetOnCopy(ICommand command) => onCopy = command;
    public void SetOnDelete(ICommand command) => onDelete = command;
    public void Copy() => onCopy?.Execute();
    public void Delete() => onDelete?.Execute();
}