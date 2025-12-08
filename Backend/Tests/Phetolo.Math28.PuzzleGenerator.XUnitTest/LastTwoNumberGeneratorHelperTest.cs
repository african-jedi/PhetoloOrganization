using Phetolo.Math28.PuzzleGenerator.Helper;
namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class LastTwoNumberGeneratorHelperTests
{
    private int _total = 28;
    private int _highestNumber = 14;

    [Theory]
    [InlineData(15)]
    [InlineData(80)]
    public void DividePlusNumbers_ShouldEqual28(int total)
    {
        var result = NumberGeneratorHelper.DividePlusNumbers(total, out int sum);
        Assert.Equal(_total, sum);
    }

    [Theory]
    [InlineData(90)]
    public void DividePlusNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = NumberGeneratorHelper.DividePlusNumbers(total, out int sum);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("DividePlusNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(15)]
    [InlineData(35)]
    public void MinusPlusNumbers_ShouldEqual28(int total)
    {
        var result = NumberGeneratorHelper.MinusPlusNumbers(total, highestNumber: _highestNumber, out int sum);
        Assert.Equal(_total, sum);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(80)]
    public void MinusPlusNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = NumberGeneratorHelper.MinusPlusNumbers(total, highestNumber: _highestNumber, out int sum);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MinusPlusNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(40)]
    [InlineData(35)]
    public void MinusDivideNumbers_ShouldEqual28(int total)
    {
        var result = NumberGeneratorHelper.MinusDivideNumbers(total, highestNumber: _highestNumber, out int sum);
        Assert.Equal(_total, sum);
    }

    [Theory]
    [InlineData(47)]
    [InlineData(23)]
    public void MinusDivideNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = NumberGeneratorHelper.MinusDivideNumbers(total, highestNumber: _highestNumber, out int sum);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MinusDivideNumbers", ex.Message);
        }
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(14)]
    [InlineData(28)]
    public void MultiplyDivideNumbers_ShouldEqual28(int total)
    {
        var result = NumberGeneratorHelper.MultiplyDivideNumbers(total, out int sum);
        Assert.Equal(_total, sum);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(29)]
    public void MultiplyDivideNumbers_ShouldThrowError(int total)
    {
        try
        {
            var result = NumberGeneratorHelper.MultiplyDivideNumbers(total, out int sum);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("MultiplyDivideNumbers", ex.Message);
        }
    }

    [Fact]
    public void LastTwoNumbers_ShouldArgumentException()
    {
        try
        {
            var result = NumberGeneratorHelper.LastTwoNumbers([1, 2, 3], 10, highestNumber: _highestNumber, out int sum);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.Contains("Only 2 operators must be left", ex.Message);
        }
    }

}