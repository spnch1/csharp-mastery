namespace FibonacciGenerator;

public static class Fibonacci
{
    public static IEnumerable<int> Generate(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException(
                $"{nameof(n)} cannot be smaller than 0.");
        }

        const int MaxValidNumber = 46;
        if (n > MaxValidNumber)
        {
            throw new ArgumentException(
                $"{nameof(n)} cannot be larger than {MaxValidNumber}, " +
                $"as it will cause numeric overflow.");
        }

        var result = new List<int>();

        var a = -1;
        var b = 1;
        for (var i = 0; i < n; i++)
        {
            var sum = a + b;
            result.Add(sum);
            a = b;
            b = sum;
        }

        return result;
    }
}