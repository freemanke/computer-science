using System.Drawing;

namespace DesignPatterns;

public interface ISofa
{
    public Color Color { get; set; }
    public int Legs { get; set; }
}

public interface IChair
{
    public Color Color { get; set; }
    public int Legs { get; set; }
}

public class ChineseSofa : ISofa
{
    public Color Color { get; set; } = Color.Green;
    public int Legs { get; set; } = 4;
}

public class ChineseChair : IChair
{
    public Color Color { get; set; } = Color.Green;
    public int Legs { get; set; } = 4;
}

public class AmericaSofa : ISofa
{
    public Color Color { get; set; } = Color.Red;
    public int Legs { get; set; } = 4;
}

public class AmericaChair : IChair
{
    public Color Color { get; set; } = Color.Red;
    public int Legs { get; set; } = 4;
}

public interface IAbstractFactory
{
    ISofa CreateSofa();
    IChair CreateChair();
}

public class ChineseFactory : IAbstractFactory
{
    public ISofa CreateSofa()
    {
        return new ChineseSofa();
    }

    public IChair CreateChair()
    {
        return new ChineseChair();
    }
}

public class AmericaFactory : IAbstractFactory
{
    public ISofa CreateSofa()
    {
        return new AmericaSofa();
    }

    public IChair CreateChair()
    {
        return new AmericaChair();
    }
}