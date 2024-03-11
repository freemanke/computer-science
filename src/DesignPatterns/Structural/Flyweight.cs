using System.Drawing;
using System.Globalization;

namespace DesignPatterns.Structural;

public class Forest
{
    public readonly List<Tree> Trees = [];

    public void PlantTree(Tree tree)
    {
        Trees.Add(tree);
    }

    public void Draw()
    {
        Trees.ForEach(a=>a.Draw());
    }
}

public class TreeType
{
    public string Name { get; set; } = "松树";
    public Color Color { get; set; } = Color.DarkGreen;
    public string Texture { get; set; } = "木纹";

    public override string ToString()
    {
        return $"树名：{Name}，颜色：{Color}，材质：{Texture}";
    }
}

public class TreeTypeFatory
{
    public readonly Dictionary<string, TreeType> treeTypes = new();

    public TreeType Create(string name, Color color, string texture)
    {
        var key = $"{name}:{color}{texture}";
        if (!treeTypes.TryGetValue(key, out var v))
        {
            treeTypes.Add(key, new TreeType { Name = name, Color = color, Texture = texture });
        }
        
        return treeTypes[key];
    }
}

public class Tree
{

    public Point Position { get; set; }
    public TreeType TreeType { get; set; } = new();

    public void Draw()
    {
        Console.WriteLine($"位置：{Position}，树型：{TreeType}");
    }
}