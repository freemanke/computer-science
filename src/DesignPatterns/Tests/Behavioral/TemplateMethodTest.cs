using DesignPatterns.Behavioral;

namespace DesignPatterns.Tests.Behavioral;

public class TemplateMethodTest
{
    [Test]
    public void Behavior()
    {
        var firstEmployee = new FirtCompanyEmployee();
        var firstSalary = firstEmployee.Calculate();
        Assert.That(firstSalary, Is.EqualTo(7000f));

        var secondEmployee = new SecondCompanyEmployee();
        var secondSalary = secondEmployee.Calculate();
        Assert.That(secondSalary, Is.EqualTo(10000f));
    }
}