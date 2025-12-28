using Phetolo.Math28.PuzzleGenerator;
using Phetolo.Math28.PuzzleGenerator.Helper;

var generator = new Generator(new NumberGeneratorHelper());

int count=0;
while (count < 100)
{
    try
    {
        count++;
        var output = await generator.GeneratePuzzle();

        Console.WriteLine($"RawPuzzle: {output.RawPuzzle}");
        Console.WriteLine($"Scrambled puzzle: {output.Scramble}");
        Console.WriteLine($"Answer: {output.Answer}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}