using System;
using FluentAssertions;
using Phetolo.Math28.Core.Entities;
using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.Core.XUnitTest;

public class PuzzleTest
{
   [Fact]
   public void Test_PocoModel()
   {
        DateTime createdDate = DateTime.Now;
        Puzzle puzzle = new Puzzle
        {
            Id = 1,
            RowGuid =Guid.NewGuid(),
            Scramble = "8:5:*:/:2:+:9:-:1",
            Answer = "42",
            CreatedDate = createdDate,
            ExpiryDate = createdDate.AddDays(1),
            TodaysPuzzle = true,
        };

        puzzle.Id.Should().Be(1);
        puzzle.Scramble.Should().Be("8:5:*:/:2:+:9:-:1");
        puzzle.Answer.Should().Be("42");
        puzzle.CreatedDate.Should().Be(createdDate);
        puzzle.ExpiryDate.Should().Be(createdDate.AddDays(1));
   }
}
