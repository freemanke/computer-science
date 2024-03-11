namespace DesignPatterns.Behavioral;

public abstract class SalaryCaculator
{
    /// <summary>
    /// Template Method
    /// </summary>
    /// <returns></returns>
    public float Calculate()
    {
        var s1 = CalculateBaseSalary();
        var s2 = CalculateInsurance();
        var s3 = CalculateBonus();

        return s1 + s2 + s3;
    }

    protected abstract float CalculateBaseSalary();
    protected abstract float CalculateInsurance();
    protected virtual float CalculateBonus() => 0f;
}

public class FirtCompanyEmployee : SalaryCaculator
{
    protected override float CalculateBaseSalary() => 5000f;
    protected override float CalculateInsurance() => 2000f;
}

public class SecondCompanyEmployee : SalaryCaculator
{
    protected override float CalculateBaseSalary() => 6000f;
    protected override float CalculateInsurance() => 3000f;
    protected override float CalculateBonus() => 1000f;
}