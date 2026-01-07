using Microsoft.EntityFrameworkCore;

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
        var existingPuzzle = await GetPuzzle(true, null);
        if (existingPuzzle != null)
            return await Task.FromResult(NumberPuzzle.MapToModel(existingPuzzle.Scramble, true, DateTime.Now, existingPuzzle.RowGuid));

        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        Puzzle entity = await CreatePuzzle(puzzle);


        if (entity.Id == 0 || entity.RowGuid == Guid.Empty)
            throw new Exception("Database failed to save entity");

        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now, entity.RowGuid));
    }

    public async Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken = default)
    {
        var existingPuzzle = await GetPuzzle(false, id);
        if (existingPuzzle != null)
            return await Task.FromResult(NumberPuzzle.MapToModel(existingPuzzle.Scramble, true, DateTime.Now, existingPuzzle.RowGuid));

        var puzzle = await _puzzleGeneratorService.GetPuzzleAsync();
        Puzzle entity = await CreatePuzzle(puzzle, false, id);

        return await Task.FromResult(NumberPuzzle.MapToModel(puzzle.Scramble, true, DateTime.Now, entity.RowGuid));
    }

    #region Private Method

    private async Task<Puzzle> CreatePuzzle(PuzzleGeneratorDTO puzzle, bool IsToday = true, int? stage = null)
    {
        Puzzle entity = new()
        {
            Answer = puzzle.Answer,
            ExpiryDate = DateTime.UtcNow.Date.AddDays(1),
            Scramble = puzzle.Scramble,
            TodaysPuzzle = IsToday,
            Stage = stage
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
    
    private async Task<Puzzle?> GetPuzzle(bool isToday, int? stage)
    {
        DateTime expiryDate = DateTime.UtcNow.Date.AddDays(1);
        var existingPuzzle = await _dbContext.Puzzles
            .FirstOrDefaultAsync(p => p.ExpiryDate == expiryDate && p.TodaysPuzzle == isToday && p.Stage == stage);

        return existingPuzzle;
    }
    #endregion
}
