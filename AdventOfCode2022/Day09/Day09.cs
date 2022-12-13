using AdventOfCode2022.Day09;

namespace AdventOfCode2022.Day9;

internal class Day09
{
    public static async Task<string> Solve(Stream stream)
    {
        HashSet<(int X, int Y)> tailLocations = new();
        (int X, int Y)[] knotLocations = new (int X, int Y)[10];

        using StreamReader streamReader = new(stream);
        string? input;
        while ((input = await streamReader.ReadLineAsync()) is not null)
        {
            Movement movement = ParseLine(input);
            PerformMovement(movement);
        }

        return tailLocations.Count.ToString();

        void PerformMovement(Movement movement)
        {
            for (int i = 0; i < movement.Distance; i++)
            {
                knotLocations[0] = movement.Direction switch
                {
                    Direction.Up => (knotLocations[0].X, knotLocations[0].Y + 1),
                    Direction.Down => (knotLocations[0].X, knotLocations[0].Y - 1),
                    Direction.Left => (knotLocations[0].X - 1, knotLocations[0].Y),
                    Direction.Right => (knotLocations[0].X + 1, knotLocations[0].Y),
                };

                for (int k = 1; k < knotLocations.Length; k++)
                {
                    int up = knotLocations[k - 1].Y - knotLocations[k].Y;
                    int right = knotLocations[k - 1].X - knotLocations[k].X;
                    int absUp = Math.Abs(up);
                    int absRight = Math.Abs(right);
                    if ((absUp > 0 && absRight > 1) || (absUp > 1 && absRight > 0))
                    {
                        knotLocations[k].Y += up / absUp;
                        knotLocations[k].X += right / absRight;
                    }
                    else if (absUp > 1)
                    {
                        knotLocations[k].Y += up / absUp;
                    }
                    else if (absRight > 1)
                    {
                        knotLocations[k].X += right / absRight;
                    }
                }

                tailLocations.Add(knotLocations[^1]);
            }
        }
    }

    private static Movement ParseLine(string input) => new()
    {
        Direction = input[0] switch
        {
            'U' => Direction.Up,
            'D' => Direction.Down,
            'L' => Direction.Left,
            'R' => Direction.Right,
            _ => throw new Exception(),
        },
        Distance = int.Parse(input[2..])
    };    
}
