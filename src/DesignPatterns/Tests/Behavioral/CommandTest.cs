using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class CommandTest
{
    [Test]
    public void Behavior()
    {
        var receiver = new Receiver();
        var copyCommand = new CopyCommnad(receiver, "2012");
        var deleteCommand = new DeleteCommand(receiver, "2012");

        var invoker = new Invoker();
        invoker.SetOnCopy(copyCommand);
        invoker.SetOnDelete(deleteCommand);
        invoker.Copy();
        Assert.That(receiver.Article, Is.EqualTo("2012"));
        invoker.Delete();
        Assert.That(receiver.Article, Is.EqualTo(""));
    }
    
}