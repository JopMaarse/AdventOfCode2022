using AdventOfCode2022.Day7;
const string fileName = "input.txt";
using Stream input = System.IO.File.Open(@$"{nameof(AdventOfCode2022.Day7.Day7)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day7.Solve(input));