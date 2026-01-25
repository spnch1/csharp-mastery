using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests;

[TestFixture]
public class FibonacciTests
{
    [TestCase(-1)]
    [TestCase(-5)]
    [TestCase(-2_000_000_000)]
    public void Generate_ShallThrowException_IfNIsSmallerThanZero(int n) =>
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));

    [TestCase(47)]
    [TestCase(200)]
    [TestCase(2_000_000_000)]
    public void Generate_ShallThrowException_IfNIsLargerThan_46(int n) =>
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(47));

    [Test]
    public void Generate_ShallProduceSequenceWith_0_ForNEqualTo_1()
    {
        int[] expected = [0];
        var result = Fibonacci.Generate(1);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWith_0_1_ForNEqualTo_2()
    {
        int[] expected = [0, 1];
        var result = Fibonacci.Generate(2);
        Assert.AreEqual(expected, result);
    }

    [TestCase(3, new[] { 0, 1, 1 })]
    [TestCase(5, new[] { 0, 1, 1, 2, 3 })]
    [TestCase(10, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
    public void Generate_ShallProduceValidFibonacciSequence(int n, int[] expected)
    {
        var result = Fibonacci.Generate(n);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Generate_ShallProduceSequenceWithLastNumber_1134903170_ForNEqualTo_46()
    {
        const int FibonacciNumber46 = 1134903170;
        var result = Fibonacci.Generate(46);
        Assert.AreEqual(FibonacciNumber46, result.Last());
    }

    [Test]
    public void Generate_ShallProduceEmptySequence_ForNEqualTo_0()
    {
        var result = Fibonacci.Generate(0);
        Assert.IsEmpty(result);
    }
}