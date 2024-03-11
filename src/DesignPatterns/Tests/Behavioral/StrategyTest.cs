using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class StrategyTest
{
    [Test]
    public void Behavior()
    {
        var collection = new List<string> { "1", "2", "3" };
        IStrategy orderTranverse = new OrderTranverseStrategy();

        orderTranverse.Tranverse(collection);
        IStrategy reverseOrderTransverse = new ReverseOrderTranverseStrategy();
        reverseOrderTransverse.Tranverse(collection);
    }
}