namespace DesignPatterns.Behavioral;

public interface IStrategy
{
    void Tranverse(List<string> collection);
}

public class OrderTranverseStrategy : IStrategy
{
    
    public void Tranverse(List<string> collection)
    {
        Console.WriteLine($"开始正向遍历序列：");
        foreach (var item in collection)
        {
           Console.WriteLine(item);
        }
    }
}

public class ReverseOrderTranverseStrategy : IStrategy
{
    public void Tranverse(List<string> collection)
    {
        var reverseCollection = new List<string>(collection);
        reverseCollection.Reverse();
        Console.WriteLine($"开始反向遍历序列：");
        foreach (var item in reverseCollection)
        {
            Console.WriteLine(item);
        }
    }
}