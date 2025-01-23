using System.Drawing;

namespace DesignPatterns.Behavioral;

public interface ISnapshot
{
    string GetName();
    DateTime GetSnapshotDate();
}

public class Snapshot : ISnapshot
{
    public string Name { get; set; } = "";
    public DateTime SnapshotAt { get; set; }
    public string Text { get; set; } = "";
    public Color TextColor { get; set; }
    
    public string GetName()
    {
        return Name;
    }

    public DateTime GetSnapshotDate()
    {
        return SnapshotAt;
    }
}

public class Editor
{
    public string Text { get; set; } = "";
    public Color TextColor { get; set; }

    public Snapshot MakeSnapshot()
    {
        var name = Guid.NewGuid().ToString();
        Console.WriteLine($"Make snapshot {name} at {DateTime.Now}");
        return new Snapshot
        {
            Name = name,
            SnapshotAt = DateTime.Now,
            TextColor = TextColor,
            Text = Text
        };
    }

    public void Restore(Snapshot snapshot)
    {
        Console.WriteLine($"Restore snapshot (name: {snapshot.Name}, at: {snapshot.SnapshotAt}) at {DateTime.Now}");
        Text = snapshot.Text;
        TextColor = snapshot.TextColor;
    }
}

