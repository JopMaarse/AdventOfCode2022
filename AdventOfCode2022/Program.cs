using AdventOfCode2022.Day8;
const string fileName = "input.txt";
await using Stream input = File.Open(@$"{nameof(Day8)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day8.Solve(input));