namespace AdventOfCode2022.Day1;

internal class Day01
{
    public static async Task<string> Solve(Stream stream)
    {
        using StreamReader streamReader= new(stream);
        string input = await streamReader.ReadToEndAsync();
        IEnumerable<int> calories = 
            input
                .Split("\n\n")
                .Select(elf => elf
                    .Split("\n")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Select(int.Parse)
                    .Sum());

        string part1 =
            calories
                .Max()
                .ToString();
                
        return calories
            .OrderDescending()
            .Take(3)
            .Sum()
            .ToString();            
    }
}
