// ReSharper disable JoinDeclarationAndInitializer

using System.Drawing;
using DesignPatterns.Creational;

namespace DesignPatterns.Tests.Creational;

public class AbstractFactoryTest
{
    [Test]
    public void Create()
    {
        IAbstractFactory factory;
        ISofa sofa;
        IChair chair;

        factory = new ChineseFactory();
        sofa = factory.CreateSofa();
        chair = factory.CreateChair();
        Assert.That(sofa.Color, Is.EqualTo(Color.Green));
        Assert.That(chair.Color, Is.EqualTo(Color.Green));

        factory = new AmericaFactory();
        sofa = factory.CreateSofa();
        chair = factory.CreateChair();
        Assert.That(sofa.Color, Is.EqualTo(Color.Red));
        Assert.That(chair.Color, Is.EqualTo(Color.Red));
    }
}