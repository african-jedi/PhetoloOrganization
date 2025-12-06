using System;
using Phetolo.Math28.PuzzleGenerator.Model;

namespace Phetolo.Math28.PuzzelGenerator.XUnitTest;

public class ResultDTOTest
{
    [Fact]
    public void Test_ObjectInitialization()
    {
        var result = new ResultDTO
        {
            Answer = "test",
            Scramble = "test",
            RawPuzzle = "test"
        };
        Assert.True(true);
    }
}
