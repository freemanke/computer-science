using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class IteratorTest
{
    [Test]
    public void Behavior()
    {
        var collection = new WordsCollection();
        collection.AddItem("Chinese");
        collection.AddItem("Italy");
        collection.AddItem("USA");

        foreach (var c in collection)
        {
            Console.WriteLine(c);
        }
    }
}