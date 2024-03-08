// ReSharper disable JoinDeclarationAndInitializer

using DesignPatterns.Creational;

namespace DesignPatterns.Tests.Creational;

public class FactoryMethodTest
{
    [Test]
    public void Create()
    {
        IBookFactory factory;
        IBook book;

        factory = new EpubBookFactory();
        book = factory.Create();
        Assert.That(book.Title, Is.EqualTo("EPUB"));
        Assert.That(book.Content, Is.EqualTo("Hello EPUB!"));

        factory = new PdfBookFactory();
        book = factory.Create();
        Assert.That(book.Title, Is.EqualTo("PDF"));
        Assert.That(book.Content, Is.EqualTo("Hello PDF!"));
    }
}