namespace DesignPatterns.Behavioral;

public interface ICity
{
    void AcceptVisitor(IVisitor visitor);
}

public interface IVisitor
{
    void VisitorBejing();
    void VisitorShanghai();
}


public class Visitor : IVisitor
{
    private readonly string name;

    protected Visitor(string name)
    {
        this.name = name;
    }

    public void VisitorBejing()
    {
        Console.WriteLine($"访问者 {name} 开始访问北京");
    }

    public void VisitorShanghai()
    {
        Console.WriteLine($"访问者 {name} 开始访问上海");
    }
}

public class DomesticVisitor : Visitor
{
    public DomesticVisitor(string name) : base(name)
    {
    }
}

public class ForeignVisitor : Visitor
{
    public ForeignVisitor(string name) : base(name)
    {
    }
}


public class BeijingCity : ICity
{
    public void AcceptVisitor(IVisitor visitor)
    {
        visitor.VisitorBejing();
    }
}

public class ShanghaiCity : ICity
{
    public void AcceptVisitor(IVisitor visitor)
    {
        visitor.VisitorShanghai();
    }
}