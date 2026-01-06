using System;
using FluentAssertions;
using Phetolo.Math28.Core.Entities;

namespace Phetolo.Math28.Core.XUnitTest;

public class PuzzleStatisticsTest
{
    [Fact]
    public void Test_PocoModel()
    {
        TimeOnly startTime = new TimeOnly(14, 30);
        PuzzleStatistics stats = new PuzzleStatistics
        {
            Puzzle = new Puzzle { Id = 100, RowGuid = Guid.NewGuid(), Answer = "42", Scramble = "8:5:*:/:2:+:9:-:1", ExpiryDate = DateTime.Now.AddDays(1), TodaysPuzzle = true },
            User = new User { Id = 1, RowGuid = Guid.NewGuid(), Email = "johndoe@test.com", IPAdress = "127.0.0.1", Name = "John", Surname = "Doe" },
            Completed = true,
            CompletedTime = startTime.AddMinutes(5),
            Attempts = 3
        };

        stats.Puzzle.Id.Should().Be(100);
        stats.User.Id.Should().Be(1);
        stats.Completed.Should().BeTrue();
        stats.CompletedTime.Should().Be(startTime.AddMinutes(5));
        stats.Attempts.Should().Be(3);
    }
}
