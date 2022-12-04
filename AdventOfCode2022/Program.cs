using AdventOfCode2022.Day4;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day4)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day4.Solve(input));