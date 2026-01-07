namespace Phetolo.Math28.Application.XUnitTest;

public class TestGetTodayPuzzleUseCase
{
    [Fact]
    public void Test_CanCreateInstance()
    {
        var mockRepository = Substitute.For<IPuzzleRepository>();
        var test = new CreatePuzzleCommandHandler(mockRepository, NullLogger<CreatePuzzleCommandHandler>.Instance);
        Assert.NotNull(test);
    }

     [Fact]
    public async Task Test_GetPuzzleShouldReturnPuzzle()
    {
        var mockRepository = Substitute.For<IPuzzleRepository>();
        string pValue = "2+2";
        mockRepository.GetPuzzleAsync(Arg.Any<CancellationToken>())
            .Returns(new NumberPuzzle { Id = Guid.NewGuid(), IsTodaysPuzzle = true, Value = pValue, Items=[new NumberPuzzleItem { Id = Guid.NewGuid(), Value = "5", Position=1 }] });

        var test = new CreatePuzzleCommandHandler(mockRepository, NullLogger<CreatePuzzleCommandHandler>.Instance);
        var result = await test.Handle(new CreatePuzzleCommand(true, null), CancellationToken.None);
        Assert.Equal(pValue, result.Value);
    }
}
