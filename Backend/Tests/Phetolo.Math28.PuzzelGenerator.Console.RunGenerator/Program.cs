using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Constants;

var generator = new Generator();

int count=0;
while (count < 100)
{
    try
    {
        count++;
        var output = generator.GeneratePuzzle();

        Console.WriteLine($"RawPuzzle: {output.RawPuzzle}");
        Console.WriteLine($"Scrambled puzzle: {output.Scramble}");
        Console.WriteLine($"Answer: {output.Answer}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}