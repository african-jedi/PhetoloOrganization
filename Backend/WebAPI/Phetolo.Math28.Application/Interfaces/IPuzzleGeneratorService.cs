namespace Phetolo.Math28.Application.Interface;

public interface IPuzzleGeneratorService
{
    public Task<PuzzleGeneratorDTO> GetPuzzleAsync();
}
