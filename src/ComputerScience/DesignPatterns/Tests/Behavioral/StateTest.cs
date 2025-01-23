using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class StateTest
{
    [Test]
    public void Behavior()
    {
        var player = new MusicPlayer();
        player.SetState(new PausingState(player));
       
        player.Play();    
        player.Previous();
        player.Next();
        
        player.Pause();
        player.Previous();
        player.Next();
    }
}