using System.ComponentModel;
using System.Reflection;
using Xunit.Sdk;

namespace Phetolo.Math28.PuzzelGenerator.XUnitTest;

public class NumberPuzzelTest
{
    [Fact]
    public void Test_CreateUsingTotal()
    {
        var puzzle = NumberPuzzle.CreateUsingTotal(10);
        Assert.NotNull(puzzle.Total);
        Assert.Null(puzzle.FirstNumber);
        Assert.Null(puzzle.SecondNumber);
        Assert.True(puzzle.Total == 10);
        Assert.False(puzzle.IsOperator);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(-1)]
    public void Test_SetInvalidFirstNumber_ThrowsValidationException(int invalidValue)
    {
        try
        {
            var puzzle = new NumberPuzzle
            {
                FirstNumber = invalidValue // Invalid value, should be between 0 and 10
            };

            Assert.Fail("Value is invalid");
        }
        catch (Exception ex)
        {
            Assert.Equal("FirstNumber must be between 0 and 10.", ex.Message);
            return;
        }
    }

    [Theory]
    [InlineData(11)]
    [InlineData(-1)]
    public void Test_SetInvalidSecondNumber_ThrowsValidationException(int invalidValue)
    {
        try
        {
            var puzzle = new NumberPuzzle
            {
                SecondNumber = invalidValue // Invalid value, should be between 0 and 10
            };

            Assert.Fail("Value is invalid");
        }
        catch (Exception ex)
        {
            Assert.Equal("SecondNumber must be between 0 and 10.", ex.Message);
            return;
        }
    }

    [Theory]
    [InlineData(11)]
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
            Assert.Equal("Total must be between 0 and 10.", ex.Message);
            return;
        }
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void Test_FirstNumberValidValues(int validValue)
    {
        var puzzle = new NumberPuzzle
        {
            FirstNumber = validValue,
            SecondNumber = validValue
        };
        Assert.Equal(validValue, puzzle.FirstNumber);
        Assert.Equal(validValue, puzzle.SecondNumber);
    }

    [Fact]
    public void Test_ToString_Total()
    {
        var puzzle = NumberPuzzle.CreateUsingTotal(9);

        Assert.True(puzzle.ToString() == $"{puzzle.Total}");
    }

    [Theory]
    [InlineData(OperatorType.plus)]
    [InlineData(OperatorType.minus)]
    [InlineData(OperatorType.multiply)]
    [InlineData(OperatorType.division)]

    public void Test_GetOperatorString_ValidOperator(OperatorType oType)
    {
        NumberPuzzle puzzle = new NumberPuzzle
        {
            IsOperator = true,
            operatorType = oType
        };
        MethodInfo? method = puzzle?.GetType()?.GetMethod("GetOperatorString", System.Reflection.BindingFlags.NonPublic
        | System.Reflection.BindingFlags.Instance);
        var result = method?.Invoke(puzzle, null);

        if (oType == OperatorType.plus)
            Assert.Equal("+", result?.ToString());
        if (oType == OperatorType.minus)
            Assert.Equal("-", result?.ToString());
        if (oType == OperatorType.multiply)
            Assert.Equal("*", result?.ToString());
        if (oType == OperatorType.division)
            Assert.Equal("/", result?.ToString());
    }

    [Fact]
    public void Test_GetOperatorString_InValidOperator()
    {
        NumberPuzzle puzzle = new NumberPuzzle
        {
            IsOperator = true,
            operatorType = (OperatorType)555
        };
        try
        {

            MethodInfo? method = puzzle?.GetType()?.GetMethod("GetOperatorString", System.Reflection.BindingFlags.NonPublic
            | System.Reflection.BindingFlags.Instance);
            var result = method?.Invoke(puzzle, null);
            Assert.Fail("Invalid operator");
        }
        catch (Exception ex)
        {
            Assert.Equal($"operatorType of value {puzzle.operatorType} is not valid.", ex.InnerException?.Message);
        }

    }
}
