
public abstract class FeePlan
{
    public string Name { get; }

    protected FeePlan(string name)
    {
        Name = name;
    }
}

public interface IValue
{
    int GetValue();
}

public class LateFee : FeePlan, IValue
{
    public int Days { get; }
    public int Rate { get; }

    public LateFee(string name, int x, int y) : base(name)
    {
        Days = x;
        Rate = y;
    }

    public int GetValue()
    {
        return Math.Max(0, Days - 1) * Rate;
    }
}

public class Calculator
{
    public int Total(IValue[] items)
    {
        int total = 0;

        foreach (IValue item in items)
            total += item.GetValue();

        return total;
    }
}

public class ConstantValue : IValue
{
    public int GetValue()
    {
        return 7;
    }
}
