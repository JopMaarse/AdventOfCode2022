namespace AdventOfCode2022.Day3;

internal class Day03
{
    public static async Task<string>Solve(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        int total = 0;
        //string? rucksack;
        //while((rucksack = await streamReader.ReadLineAsync()) is not null)
        //{
        //    total += Part1(rucksack);
        //}
        string? rucksack1, rucksack2, rucksack3;
        while ((rucksack1 = await streamReader.ReadLineAsync()) is not null &&
               (rucksack2 = await streamReader.ReadLineAsync()) is not null &&
               (rucksack3 = await streamReader.ReadLineAsync()) is not null)
        {
            total += Part2(rucksack1, rucksack2, rucksack3);
        }
        return total.ToString();
    }

    private static int Part1(string rucksack)
    {
        ReadOnlySpan<char> one = rucksack.AsSpan(0, rucksack.Length / 2);
        ReadOnlySpan<char> two = rucksack.AsSpan(rucksack.Length / 2);
        for (int i = 0; i < one.Length; i++)
        {
            if (two.Contains(one[i]))
                return Priority(one[i]);
        }
        throw new Exception("invalid input");
    }

    private static int Part2(string rucksack1, string rucksack2, string rucksack3) =>
        Priority(rucksack1.Intersect(rucksack2).Intersect(rucksack3).Single());

    private static int Priority(char c)
    {
        int priority = c - 96;
        return priority < 0 ? c - 38 : priority;
    }
}
