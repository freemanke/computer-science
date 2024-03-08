using System.Text.Json;

namespace DesignPatterns;

public interface IBook
{
    public string Title { get; }
    public string Content { get; }
}

public class EpubBook : IBook
{
    public EpubBook(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; set; }
    public string Content { get; set; }
}

public class PdfBook : IBook
{
    public PdfBook(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; set; }
    public string Content { get; set; }
}

public interface IBookFactory
{
    IBook Create();
}

public abstract class BookFactory : IBookFactory
{
    public abstract IBook Create();

    public void PrintBookInfo()
    {
        var book = Create();
        Console.WriteLine(JsonSerializer.Serialize(book));
    }
}

public class EpubBookFactory : BookFactory
{
    public override IBook Create()
    {
        return new EpubBook("EPUB", "Hello EPUB!");
    }
}

public class PdfBookFactory : BookFactory
{
    public override IBook Create()
    {
        return new EpubBook("PDF", "Hello PDF!");
    }
}