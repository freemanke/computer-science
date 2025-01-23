using DesignPatterns.Creational;

namespace DesignPatterns.Tests.Creational;

public class PrototyeTest
{
    [Test]
    public void Create()
    {
        var person = new Person
        {
            Name = "Freeman Ke",
            Age = 20,
            Birtyday = new DateTime(2000, 12, 12),
            IdCard = new IDCard { Number = "20001212" }
        };

        // Shallow clone
        var secondPerson = person.Clone();
        Assert.That(secondPerson.Name, Is.EqualTo("Freeman Ke"));
        Assert.That(secondPerson.Age, Is.EqualTo(20));
        Assert.That(secondPerson.Birtyday, Is.EqualTo(new DateTime(2000, 12, 12)));
        Assert.That(secondPerson.IdCard, Is.EqualTo(person.IdCard));

        // Deep clone
        var thirdPerson = person.DeepClone();
        Assert.That(thirdPerson.Name, Is.EqualTo("Freeman Ke"));
        Assert.That(thirdPerson.Age, Is.EqualTo(20));
        Assert.That(thirdPerson.Birtyday, Is.EqualTo(new DateTime(2000, 12, 12)));
        Assert.That(thirdPerson.IdCard, Is.Not.EqualTo(person.IdCard));
        Assert.That(thirdPerson.IdCard.Number, Is.EqualTo(person.IdCard.Number));
    }
}