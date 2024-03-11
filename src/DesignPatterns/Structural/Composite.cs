using System.Drawing;

namespace DesignPatterns.Structural;

public interface IShape
{
     Color Color { get; }
     void Draw();
     void Move();
}

public class Circle : IShape
{
     public Color Color { get; set; }=Color.Green;
     public void Draw() => Console.WriteLine("画一个圆圈");
     public void Move() => Console.WriteLine("移动一个圆圈");
}

public class Square : IShape
{
     public Color Color { get; set; } = Color.Red;
     public void Draw() => Console.WriteLine("画一个正方形");
     public void Move() => Console.WriteLine("移动一个正方形");
}

public class Diamond : IShape
{
     public Color Color { get; set; } = Color.Black;
     public void Draw() => Console.WriteLine("画一个菱形");
     public void Move() => Console.WriteLine("移动一个零星");
}

public class ImageEditor
{
     private readonly List<IShape> shapes = [];
     public void AddShape(IShape shape) => shapes.Add(shape);
     public void RemoveShape(IShape shape) => shapes.Remove(shape);

     public int GetShapeCount()
     {
          return shapes.Count;
     }

     public void Draw()
     {
          shapes.ForEach(a=>a.Draw());
     }
}