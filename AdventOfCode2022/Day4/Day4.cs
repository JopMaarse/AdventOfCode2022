namespace AdventOfCode2022.Day4;

internal class Day4
{
    public static async Task<string> Solve(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        int total = 0;
        string? input;
        while ((input = await streamReader.ReadLineAsync()) is not null)
        {
            if (HasOverlap(input))
                total++;
        }
        return total.ToString();
    }

    private static bool HasOverlap(string input)
    {
        int[] sectionIds = input
            .Split(',')
            .SelectMany(s => s.Split('-'))
            .Select(int.Parse)
            .ToArray();
        
        return Part2(sectionIds);

        static bool Part1(int[] sectionIds)
        {
            return
                (sectionIds[0] <= sectionIds[2] && sectionIds[1] >= sectionIds[3]) ||
                (sectionIds[0] >= sectionIds[2] && sectionIds[1] <= sectionIds[3]);
        }
        
        static bool Part2(int[] sectionIds)
        {
            return Part1(sectionIds) ||
                (sectionIds[0] <= sectionIds[2] && sectionIds[1] >= sectionIds[2]) ||
                (sectionIds[0] <= sectionIds[3] && sectionIds[1] >= sectionIds[3]);
        }
    }
}
