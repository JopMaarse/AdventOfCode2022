using AdventOfCode2022.Day2;
const string fileName = "input.txt";
using Stream input = File.Open(@$"{nameof(Day2)}\{fileName}", FileMode.Open);
Console.WriteLine(await Day2.Solve(input));