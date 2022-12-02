namespace AdventOfCode2022.Day2;

internal class Day2
{
    public static async Task<string> Solve(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        int score = 0;
        string? input;
        while((input = await streamReader.ReadLineAsync()) is not null)
        {
            score += ScorePart2(input);
        }
        return score.ToString();
    }

    private static int ScorePart1(string round) => round switch
    {
        "A X" => 4,
        "A Y" => 8,
        "A Z" => 3,
        "B X" => 1,
        "B Y" => 5,
        "B Z" => 9,
        "C X" => 7,
        "C Y" => 2,
        "C Z" => 6
    };
    
    private static int ScorePart2(string round) => round switch
    {
        "A X" => 3,
        "A Y" => 4,
        "A Z" => 8,
        "B X" => 1,
        "B Y" => 5,
        "B Z" => 9,
        "C X" => 2,
        "C Y" => 6,
        "C Z" => 7
    };
}
