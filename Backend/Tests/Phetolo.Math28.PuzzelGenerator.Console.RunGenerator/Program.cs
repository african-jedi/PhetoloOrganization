using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Constants;

var generator = new Generator();
while (true)
{
    try
    {
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

Console.ReadLine();