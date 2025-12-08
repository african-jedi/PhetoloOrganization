using System.ComponentModel;
using System.Reflection;
using Phetolo.Math28.PuzzleGenerator.Model;
using Xunit.Sdk;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class NumberPuzzleTest
{
    [Fact]
    public void Test_CreateUsingTotal()
    {
        var puzzle = NumberPuzzle.CreateUsingTotal(10);
        Assert.NotNull(puzzle.Total);
        Assert.True(puzzle.Total == 10);
        Assert.False(puzzle.IsOperator);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Test_RandomOperator(int opt)
    {
        NumberPuzzle number = NumberPuzzle.CreateRandomOperator(opt);
        Assert.Equal((OperatorType)opt, number.operatorType);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(-1)]
    public void Test_SetInvalidTotal_ThrowsValidationException(int invalidValue)
    {
        try
        {
            var puzzle = new NumberPuzzle
            {
                Total = invalidValue // Invalid value, should be between 0 and 10
            };

            Assert.Fail("Value is invalid");
        }
        catch (Exception ex)
        {
            Assert.Equal("Total must be between 0 and 14.", ex.Message);
            return;
        }
    }
}
