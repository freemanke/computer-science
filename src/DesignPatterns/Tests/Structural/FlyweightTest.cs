using System.Drawing;
using DesignPatterns.Behavioral;
using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class FlyweightTest
{
    [Test]
    public void Flyweight()
    {
        var treeTypeFactory = new TreeTypeFatory();
        var type1 = treeTypeFactory.Create("松树", Color.DarkGreen, "木纹");
        var type2 = treeTypeFactory.Create("铁树", Color.DarkBlue, "贴木纹");
        var type3 = treeTypeFactory.Create("棕榈树", Color.Red, "花岗岩");
        var forest = new Forest();

        forest.PlantTree(new Tree { Position = new Point(1, 1), TreeType = type1 });
        forest.PlantTree(new Tree { Position = new Point(2, 2), TreeType = type1 });
        forest.PlantTree(new Tree { Position = new Point(3, 3), TreeType = type2 });
        forest.PlantTree(new Tree { Position = new Point(4, 4), TreeType = type2 });
        forest.PlantTree(new Tree { Position = new Point(5, 5), TreeType = type3 });

        forest.Draw();
        Assert.That(treeTypeFactory.treeTypes, Has.Count.EqualTo(3));
        Assert.That(forest.Trees[0].TreeType, Is.EqualTo(forest.Trees[1].TreeType));
    }
}