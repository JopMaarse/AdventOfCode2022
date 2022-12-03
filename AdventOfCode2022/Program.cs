using AdventOfCode2022.Day3;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day3)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day3.Solve(input));