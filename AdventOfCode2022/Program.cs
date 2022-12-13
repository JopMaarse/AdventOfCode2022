using AdventOfCode2022.Day9;
const string fileName = "input.txt";
await using Stream input = File.Open(@$"{nameof(Day09)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day09.Solve(input));