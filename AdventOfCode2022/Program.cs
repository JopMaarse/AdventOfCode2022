using AdventOfCode2022.Day6;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day6)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day6.Solve(input));