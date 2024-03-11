using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class AdaptorTest
{
    [Test]
    public void Adaptor()
    { 
        IYmlProcess app = new JsonProcessor(new YmlProcessor());
        app.ProcessYml("");
    }
}