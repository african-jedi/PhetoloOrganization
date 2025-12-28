using System;
using System.Threading.Tasks;
using Phetolo.Math28.PuzzleGenerator.Helper;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class SecondNumberTests
{
    private int _highestNumber = 14;

    private readonly NumberGeneratorHelper _helper;

    public SecondNumberTests() => _helper = new NumberGeneratorHelper();

    [Fact]
    public async Task SecondNumber_ShouldReturnException()
    {
        try
        {
            await _helper.SecondNumber((OperatorType)5, 2, highestNumber: _highestNumber);
        }
        catch (Exception ex)
        {
            Assert.Contains("Cannot find random number", ex.Message);
        }
    }
}
