namespace DesignPatterns;

public interface ICloneable<out T>
{
    T Clone();
    T DeepClone();
}

public class IDCard
{
    public string Number { get; set; } = "";
}

public class Person : ICloneable<Person>
{
    public int Age { get; set; }
    public string Name { get; set; } = "";
    public DateTime Birtyday { get; set; }
    public IDCard IdCard { get; set; } = new();

    public Person Clone()
    {
        return new Person
        {
            Age = Age,
            Name = Name,
            Birtyday = Birtyday,
            IdCard = IdCard
        };
    }

    public Person DeepClone()
    {
        return new Person
        {
            Age = Age,
            Name = Name,
            Birtyday = Birtyday,
            IdCard = new IDCard { Number = IdCard.Number }
        };
    }
}