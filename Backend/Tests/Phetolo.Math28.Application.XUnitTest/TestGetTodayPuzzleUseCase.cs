namespace Phetolo.Math28.Application.XUnitTest;

public class TestGetTodayPuzzleUseCase
{
    [Fact]
    public void Test_CanCreateInstance()
    {
        var mockRepository = Substitute.For<IPuzzleRepository>();
        var test = new GetTodayPuzzleUseCase(mockRepository, NullLogger<GetTodayPuzzleUseCase>.Instance);
        Assert.NotNull(test);
    }

     [Fact]
    public async Task Test_GetPuzzleShouldReturnPuzzle()
    {
        var mockRepository = Substitute.For<IPuzzleRepository>();
        string pValue = "2+2";
        mockRepository.GetPuzzleAsync(Arg.Any<CancellationToken>())
            .Returns(new NumberPuzzle { Id = Guid.NewGuid(), IsTodaysPuzzle = true, Value = pValue, Items=[new NumberPuzzleItem { Id = Guid.NewGuid(), Value = "5", Position=1 }] });

        var test = new GetTodayPuzzleUseCase(mockRepository, NullLogger<GetTodayPuzzleUseCase>.Instance);
        var result = await test.GetPuzzle(CancellationToken.None);
        Assert.Equal(pValue, result.Value);
    }
}
