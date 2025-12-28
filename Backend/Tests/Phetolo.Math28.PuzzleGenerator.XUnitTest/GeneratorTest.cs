using System;
using System.Threading.Tasks;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class GeneratorTest
{
    private readonly Generator _generator;
    public GeneratorTest()
    {
        _generator = new Generator(new Helper.NumberGeneratorHelper());
    }
    [Fact]
    public async Task Test_GeneratePuzzle_ShouldReturnValidResultDTO()
    {

        // Act
        var result = await _generator.GeneratePuzzle();

        // Assert
        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result.Scramble));
        Assert.False(string.IsNullOrWhiteSpace(result.RawPuzzle));
        Assert.False(string.IsNullOrWhiteSpace(result.Answer));
    }

    [Fact]
    public async Task Test_GeneratePuzzle_ShouldReturnValidResultDTO_Performance()
    {

        int countdownEvent = 0;
        while (countdownEvent < 1000)
        {
            // Act
            var result = await _generator.GeneratePuzzle();

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrWhiteSpace(result.Scramble));
            Assert.False(string.IsNullOrWhiteSpace(result.RawPuzzle));
            Assert.False(string.IsNullOrWhiteSpace(result.Answer));

            countdownEvent++;
        }
    }
}
