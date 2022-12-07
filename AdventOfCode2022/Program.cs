using AdventOfCode2022.Day5;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day5)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day5.Solve(input));