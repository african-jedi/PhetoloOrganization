using Phetolo.Math28.Core.Models;

namespace Phetolo.Math28.Core.Interfaces;

public interface IPuzzleRepository
{
     Task<NumberPuzzle> GetPuzzleAsync(CancellationToken cancellationToken);
    Task<NumberPuzzle> GetNewPuzzleAsync(int id, CancellationToken cancellationToken);
}