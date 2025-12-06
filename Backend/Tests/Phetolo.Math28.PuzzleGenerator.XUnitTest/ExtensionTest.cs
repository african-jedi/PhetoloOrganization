using System;
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
}
