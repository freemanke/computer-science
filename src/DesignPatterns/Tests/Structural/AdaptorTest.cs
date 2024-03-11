using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class AdaptorTest
{
    [Test]
    public void Adaptor()
    { 
        IJsonProcess app = new JsonProcessor(new YmlProcessor());
        app.ProcessJson("");
    }
}