using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class VisitorTest
{
    [Test]
    public void Behavior()
    {
        ICity beijing = new BeijingCity();
        ICity shanghai = new ShanghaiCity();
        IVisitor domesticVisitor = new DomesticVisitor("国内游客张三");
        IVisitor foreignVisitor = new ForeignVisitor("国外游客安妮");
        
        beijing.AcceptVisitor(domesticVisitor);
        beijing.AcceptVisitor(foreignVisitor);
        shanghai.AcceptVisitor(domesticVisitor);
    }
}