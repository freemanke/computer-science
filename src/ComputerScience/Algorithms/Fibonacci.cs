using System.Diagnostics;

namespace DesignPatterns.Algorithms;

public class Fibonacci
{
    /// <summary>
    /// 通过递归计算
    /// </summary>
    public ulong CountFibonacciByRecursion(ulong n)
    {
        if (n <= 1) return n;
        return CountFibonacciByRecursion(n - 1) + CountFibonacciByRecursion(n - 2);
    }

    /// <summary>
    /// 通过动态规划计算
    /// </summary>
    public ulong CountFibonacciByDP(ulong n)
    {
        if (n <= 1) return n;

        var dp = new ulong[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (ulong i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    /// <summary>
    /// 通过优化后的动态规划计算
    /// </summary>
    public ulong CountFibonacciByDPOptimised(ulong n)
    {
        if (n <= 1) return n;

        ulong previous2 = 0;
        ulong previous1 = 1;
        for (ulong i = 2; i <= n; i++)
        {
            var current = previous1 + previous2;
            previous2 = previous1;
            previous1 = current;
        }

        return previous1;
    }
}

public class FibonacciTest
{
    [Test]
    public void CountFibonacciByRecursion()
    {
        var fibonacci = new Fibonacci();
        var counter = new Counter(a => fibonacci.CountFibonacciByRecursion(a));
        Computer(counter, 30);
    }

    [Test]
    public void CountFibonacciByDP()
    {
        var fibonacci = new Fibonacci();
        var counter = new Counter(a => fibonacci.CountFibonacciByDP(a));
        Computer(counter, 10000000);
    }

    [Test]
    public void CountFibonacciByDPOptimized()
    {
        var fibonacci = new Fibonacci();
        var counter = new Counter(a => fibonacci.CountFibonacciByDPOptimised(a));
        Computer(counter, 10000000);
    }
    
    public delegate ulong Counter(ulong n);

    private void Computer(Counter counter, ulong number)
    {
        Assert.That(counter(0), Is.EqualTo(0));
        Assert.That(counter(1), Is.EqualTo(1));
        Assert.That(counter(2), Is.EqualTo(1));
        Assert.That(counter(3), Is.EqualTo(2));
        Assert.That(counter(4), Is.EqualTo(3));
        Assert.That(counter(5), Is.EqualTo(5));
        Assert.That(counter(6), Is.EqualTo(8));

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = counter(number);
        stopwatch.Stop();

        Console.WriteLine($"计算结果： {number} ==> {result:N0}");
        Console.WriteLine($"计算耗时：{stopwatch.ElapsedMilliseconds} ms");
    }
}