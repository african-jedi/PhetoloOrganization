using System;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class GeneratorTest
{
    [Fact]
    public void Test_GeneratePuzzle_ShouldReturnValidResultDTO()
    {
        // Arrange
        var generator = new Phetolo.Math28.PuzzleGenerator.Generator();

        // Act
        var result = generator.GeneratePuzzle();

        // Assert
        Assert.NotNull(result);
        Assert.False(string.IsNullOrWhiteSpace(result.Scramble));
        Assert.False(string.IsNullOrWhiteSpace(result.RawPuzzle));
        Assert.False(string.IsNullOrWhiteSpace(result.Answer));
    }

    [Fact]
    public void Test_GeneratePuzzle_ShouldReturnValidResultDTO_Performance()
    {
        // Arrange
        var generator = new Phetolo.Math28.PuzzleGenerator.Generator();
        int countdownEvent = 0;
        while (countdownEvent < 1000)
        {
            // Act
            var result = generator.GeneratePuzzle();

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrWhiteSpace(result.Scramble));
            Assert.False(string.IsNullOrWhiteSpace(result.RawPuzzle));
            Assert.False(string.IsNullOrWhiteSpace(result.Answer));

            countdownEvent++;
        }
    }
}
