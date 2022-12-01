using AdventOfCode2022.Day1;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day1)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day1.Solve(input));