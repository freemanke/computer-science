using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class BridgeTest
{
    [Test]
    public void Bridge()
    {
        var windowsPlatform = new WindowsPlatform(new MP4Video());
        windowsPlatform.Play();

        var linuxPlatform = new LinuxPlatform(new WMVVideo());
        linuxPlatform.Play();

        var macosPlatform = new MacosPlatform(new AVIVideo());
        macosPlatform.Play();
    }
}