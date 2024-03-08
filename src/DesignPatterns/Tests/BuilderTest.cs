using System.Drawing;

namespace DesignPatterns.Tests;

public class ProductBuilderTest
{
    [Test]
    public void Create()
    {
        var builder = new ProductBuilder();
        var product = builder.AddTitle("工具书").AddColor(Color.Red).AddSize(new Size(100, 100))
            .Build();

        Assert.That(product, Is.Not.Null);
        Assert.That(product.Title, Is.EqualTo("工具书"));
        Assert.That(product.Color, Is.EqualTo(Color.Red));
        Assert.That(product.Size, Is.EqualTo(new Size(100, 100)));
    }
}