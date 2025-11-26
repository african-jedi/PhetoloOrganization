using Phetolo.Math28.PuzzleGenerator;

var generator = new Generator();
int count = 0;
// while (count < 100)
// {
    var output = generator.GeneratePuzzle();

    Console.WriteLine($"RawPuzzle: {output.RawPuzzle}");
    Console.WriteLine($"Puzzle: {output.Puzzle}");
    Console.WriteLine($"Answer: {output.Answer}");
    count++;
//}

Console.ReadLine();