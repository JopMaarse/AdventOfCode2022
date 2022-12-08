using System.IO;

namespace AdventOfCode2022.Day8;

internal class Day8
{
    public static async Task<string> Solve(Stream stream)
    {
        int[,] grid = await ParseInput(stream);
        int visibleTrees = 0;
        int bestScenicScore = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                //edge
                if (i == 0 || j == 0 || i == grid.GetLength(0) - 1 || j == grid.GetLength(1) - 1)
                {
                    visibleTrees++;                    
                    continue;
                }

                int scenicScore = 1;

                bool visibleRight = true;
                int k;
                for (k = i + 1; k < grid.GetLength(0); k++)
                {
                    if (grid[k, j] >= grid[i, j])
                    {
                        visibleRight = false;
                        break;
                    }
                }
                scenicScore *= k == grid.GetLength(0) ? k - 1 - i : k - i;

                bool visibleLeft = true;
                for (k = i - 1; k >= 0; k--)
                {
                    if (grid[k, j] >= grid[i, j])
                    {
                        visibleLeft = false;
                        break;
                    }
                }
                scenicScore *= k == -1 ? i : i - k;

                bool visibleDown = true;
                for (k = j + 1; k < grid.GetLength(1); k++)
                {
                    if (grid[i, k] >= grid[i, j])
                    {
                        visibleDown = false;
                        break;
                    }
                }
                scenicScore *= k == grid.GetLength(1) ? k - 1 - j : k - j;

                bool visibleUp = true;
                for (k = j - 1; k >= 0; k--)
                {
                    if (grid[i, k] >= grid[i, j])
                    {
                        visibleUp = false;
                        break;
                    }
                }
                scenicScore *= k == -1 ? j : j - k;

                if (visibleRight || visibleLeft || visibleDown || visibleUp)
                {
                    visibleTrees++;
                }

                if (scenicScore > bestScenicScore)
                    bestScenicScore = scenicScore;
            }
        }

        return $"{visibleTrees}{Environment.NewLine}{bestScenicScore}";
    }

    private static async Task<int[,]> ParseInput(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        string[] lines = (await streamReader.ReadToEndAsync()).Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int[,] grid = new int[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                grid[i, j] = lines[i][j] - '0';
            }
        }

        return grid;
    }
}

