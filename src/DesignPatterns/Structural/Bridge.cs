namespace DesignPatterns.Structural;

public interface IVideo
{
    void Open();
    void Play();
}

public class MP4Video : IVideo
{
    public void Open() => Console.WriteLine("打开 MP4 格式视频");
    public void Play() => Console.WriteLine("播放 MP4 格式视频");
}

public class WMVVideo : IVideo
{
    public void Open() => Console.WriteLine("打开 WMV 格式视频");
    public void Play() => Console.WriteLine("播放 WMV 格式视频");
}

public class AVIVideo : IVideo
{
    public void Open() => Console.WriteLine("打开 AVI 格式视频");
    public void Play() => Console.WriteLine("播放 AVI 格式视频");
}

/// <summary>
/// 将平台和视频编码格式作为两个独立的抽象层次进行扩展
/// </summary>
public abstract class Platform
{
    private readonly IVideo video;
    protected Platform(IVideo vidio)
    {
        video = vidio;
    }

    public void Play()
    {
        Console.WriteLine($"在 {GetType().Name} 平台上操作:");
        video.Open();
        video.Play();
    }
}

public class WindowsPlatform : Platform
{
    public WindowsPlatform(IVideo vidio) : base(vidio)
    {
    }
}

public class LinuxPlatform : Platform
{
    public LinuxPlatform(IVideo vidio) : base(vidio)
    {
    }
}

public class MacosPlatform : Platform
{
    public MacosPlatform(IVideo vidio) : base(vidio)
    {
    }
}