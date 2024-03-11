using DesignPatterns.Structural;

namespace DesignPatterns.Tests.Structural;

public class CompositeTest
{
    [Test]
    public void Composit()
    {
        var diamond = new Diamond();
        var editor = new ImageEditor();
        editor.AddShape(new Circle());
        editor.AddShape(new Circle());
        editor.AddShape(new Square());
        editor.AddShape(new Diamond());
        editor.AddShape(diamond);

        Assert.That(editor.GetShapeCount(), Is.EqualTo(5));
        editor.Draw();
        editor.RemoveShape(diamond);
        Assert.That(editor.GetShapeCount(), Is.EqualTo(4));
        editor.Draw();
    }
}