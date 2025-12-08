using System;
using System.Text.RegularExpressions;
using Phetolo.Math28.PuzzleGenerator.Constants;

namespace Phetolo.Math28.PuzzleGenerator.XUnitTest;

public class ExtensionTest
{
    [Fact]
    public void ReplaceOperatorsWithColon_ShouldReplaceAllOperators()
    {
        // Arrange
        string input = "5+3-2*4/1";
        string expectedOutput = "5:3:2:4:1";

        // Act
        string actualOutput = input.ReplaceOperatorsWithColon();

        // Assert
        Assert.Equal(expectedOutput, actualOutput);
    }

    [Theory]
    [InlineData("5x8/2+9-1")]
    [InlineData("5x8/2+11-3")]
    [InlineData("7*10/2-14+7")]
    public void Scramble_ShouldScrambleString(string puzzle)
    {
        string scrambled = puzzle.Scramble();

        // Assert
        Assert.NotEqual(puzzle, scrambled);
        Assert.Equal(puzzle.Length + 8, scrambled.Length);

         string[] arrayWithOutOperators = Regex.Split(puzzle, @"[+\-*/]");
        string[] operators = ["+", "-", "*", "/"];

        string[] completeArray = arrayWithOutOperators.Concat(operators).ToArray();
        foreach (var c in completeArray)
            Assert.Contains(c, scrambled);
    }
}
