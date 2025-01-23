using System.Drawing;
using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class MementoTest
{
    [Test]
    public void Behavior()
    {
        var editor = new Editor();
       
        editor.Text = "First line";
        editor.TextColor = Color.Black;
        var firstSnapshot = editor.MakeSnapshot();

        editor.Text += "\nSecond line";
        editor.TextColor = Color.Brown;
        var secondSnapshot = editor.MakeSnapshot();
        
        Assert.That(editor.Text, Is.EqualTo("First line\nSecond line"));
        Assert.That(editor.TextColor, Is.EqualTo(Color.Brown));
        
        editor.Restore(firstSnapshot);
        Assert.That(editor.Text, Is.EqualTo("First line"));
        Assert.That(editor.TextColor, Is.EqualTo(Color.Black));
    }
}