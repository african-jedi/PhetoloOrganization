namespace Phetolo.Math28.Infrastructure.Repository;

public class PuzzleRepository : IPuzzleRepository
{
    private readonly IPuzzleGeneratorService _puzzleGeneratorService;
    private readonly Math28DBContext _dbContext;

    public PuzzleRepository(IPuzzleGeneratorService puzzleGeneratorService, Math28DBContext context)
    {
        _puzzleGeneratorService = puzzleGeneratorService;
        _dbContext = context;
    }

    public async Task<NumberPuzzle> GetPuzzleAsync(CancellationToken cancellationToken = default)
    {
        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        Puzzle entity = await CreatePuzzle(puzzle);
        

        if(entity.Id==0 || entity.RowGuid == Guid.Empty)
          throw new Exception("Database failed to save entity");

        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now, entity.RowGuid));
    }

    public async Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken = default)
    {
        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        Puzzle entity=await CreatePuzzle(puzzle, false);

        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now, entity.RowGuid));
    }

    #region Private Method
    
    private async Task<Puzzle> CreatePuzzle(PuzzleGeneratorDTO puzzle, bool IsToday=true)
    {
         Puzzle entity = new()
        {
            Answer = puzzle.Answer,
            ExpiryDate = DateTime.UtcNow.AddDays(1),
            Scramble = puzzle.Scramble,
            TodaysPuzzle = IsToday,
        };

        //check if puzzle already exists before adding
        _dbContext.Puzzles.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    #endregion
}
