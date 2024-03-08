using System.Drawing;

namespace DesignPatterns;

public interface IProductBuilder
{
    Product Build();
    IProductBuilder AddTitle(string title);
    IProductBuilder AddColor(Color color);
    IProductBuilder AddSize(Size size);
}

public class Product
{
    public string Title { get; set; } = "";
    public Color Color { get; set; }
    public Size Size { get; set; }
}

public class ProductBuilder : IProductBuilder
{
    private readonly Product product = new();

    public Product Build()
    {
        return product;
    }

    public IProductBuilder AddTitle(string title)
    {
        product.Title = title;
        return this;
    }

    public IProductBuilder AddColor(Color color)
    {
        product.Color = color;
        return this;
    }

    public IProductBuilder AddSize(Size size)
    {
        product.Size = size;
        return this;
    }
}