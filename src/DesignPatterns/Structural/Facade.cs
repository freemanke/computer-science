namespace DesignPatterns.Structural;

public interface IVideoConvert
{
    void ConvertVideo(string fileName, string formatter);
}

public class VideoConverter : IVideoConvert
{
    public void ConvertVideo(string fileName, string formatter)
    {
        var vm = new VideoFormat(formatter);
       Console.WriteLine($"视频 {fileName} 已通过格式 {formatter} 转换器转换成功");
    }
}

public class VideoFormat
{
    private string name;
    
    public VideoFormat(string name)
    {
        this.name = name;
    }
}