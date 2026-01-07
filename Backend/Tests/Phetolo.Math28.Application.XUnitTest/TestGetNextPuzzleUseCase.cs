namespace Phetolo.Math28.Application.XUnitTest;

public class TestGetNextPuzzleUseCase
{
    [Fact]
    public void Test_CanCreateInstance()
    {
        var mockRepository = Substitute.For<IPuzzleRepository>();
        var test = new CreatePuzzleCommandHandler(mockRepository, NullLogger<CreatePuzzleCommandHandler>.Instance);
        Assert.NotNull(test);
    }

    [Fact]
    public async Task Test_GetPuzzleShouldReturnNewPuzzle()
    {
        int stage = 2;
        var mockRepository = Substitute.For<IPuzzleRepository>();
        mockRepository.GetNewPuzzleAsync(stage, Arg.Any<CancellationToken>())
     .Returns(new NumberPuzzle { Id = Guid.NewGuid(), Stage = stage, IsTodaysPuzzle = false, Value = "2+2", Items = [new NumberPuzzleItem { Id = Guid.NewGuid(), Value = "5", Position = 1 }] });
        var test = new CreatePuzzleCommandHandler(mockRepository, NullLogger<CreatePuzzleCommandHandler>.Instance);
        var result = await test.Handle(new CreatePuzzleCommand(false, stage), CancellationToken.None);

        Assert.Equal(stage, result.Stage);
    }
}
