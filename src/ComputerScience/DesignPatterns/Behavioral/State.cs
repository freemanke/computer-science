namespace DesignPatterns.Behavioral;

public interface IMusicPlayerState
{
    void Play();
    void Pause();
    void Next();
    void Previous();
}

public abstract class MusicPlayerState : IMusicPlayerState
{
    protected readonly MusicPlayer player;

    protected MusicPlayerState(MusicPlayer player)
    {
        this.player = player;
    }

    public abstract void Play();
    public abstract void Pause();
    public abstract void Next();
    public abstract void Previous();
}

public class PlayingState : MusicPlayerState
{
    public PlayingState(MusicPlayer player) : base(player)
    {
    }
    
    public override void Play()
    {
        Console.Write("已经是播放模式");
    }

    public override void Pause()
    {
       Console.WriteLine("暂停成功");
       player.SetState(new PausingState(player));
    }

    public override void Next()
    {
        Console.WriteLine("开始播放下一首");
    }

    public override void Previous()
    {
        Console.WriteLine("开始播放上一首");
    }
}

public class PausingState: MusicPlayerState
{
    public PausingState(MusicPlayer player) : base(player)
    {
    }

    public override void Play()
    {
        Console.WriteLine("开始播放");
        player.SetState(new PlayingState(player));
    }

    public override void Pause()
    {
        Console.WriteLine("已经是暂停模式");
    }

    public override void Next()
    {
        Console.WriteLine("开始播放下一首");
        player.SetState(new PlayingState(player));
    }

    public override void Previous()
    {
        Console.WriteLine("开始播放上一首");
        player.SetState(new PlayingState(player));
    }
}

public class MusicPlayer
{
    private IMusicPlayerState? _state;

    public void SetState(IMusicPlayerState state)
    {
        _state = state;
    }

    public void Play() => _state?.Play();
    public void Pause() => _state?.Pause();
    public void Next() => _state?.Next();
    public void Previous() => _state?.Previous();
}