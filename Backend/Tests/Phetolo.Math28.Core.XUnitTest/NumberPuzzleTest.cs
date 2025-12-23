using FluentAssertions;
using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.Core.XUnitTest;

public class NumberPuzzleTest
{
    [Fact]
    public void MapToModel_ShouldPass()
    {
        var result = NumberPuzzle.MapToModel("8:5:*:/:2:+:9:-:1", true, DateTime.Now);
        result.Items.Should().HaveCount(9);
        result.Items[0].Value.Should().Be("8");
        result.Items[1].Value.Should().Be("5");
        result.Items[2].IsNumber.Should().BeFalse();
        result.Items[3].IsNumber.Should().BeFalse();
        result.Items[4].Value.Should().Be("2");
        result.Items[5].IsNumber.Should().BeFalse();
        result.Items[6].Value.Should().Be("9");
        result.Items[7].IsNumber.Should().BeFalse();
        result.Items[8].Value.Should().Be("1");
    }

    [Theory]
    [InlineData("8:5:*:/:2:+:9:-:1")]
    [InlineData("10:4:*:/:2:+:9:-:1")]
    public void MapToModel_ShouldHaveCountOfNine(string puzzleValue)
    {
        var result = NumberPuzzle.MapToModel(puzzleValue, true, DateTime.Now);
        result.Items.Should().HaveCount(9);
    }
}
