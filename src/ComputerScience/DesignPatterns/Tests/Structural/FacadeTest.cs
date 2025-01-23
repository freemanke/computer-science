using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class FacadeTest
{
    [Test]
    public void Facade()
    {
        IVideoConvert videoConverter = new VideoConverter();
        videoConverter.ConvertVideo("introduction.mp4", "mp4");
        videoConverter.ConvertVideo("introduction.wmv", "wmv");
    }
}