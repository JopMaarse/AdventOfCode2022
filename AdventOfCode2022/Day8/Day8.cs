namespace AdventOfCode2022.Day8;

internal class Day8
{
    public static async Task<string> Solve(Stream stream)
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

        int visibleTrees = 0;
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

                //look right
                bool visible = true;
                for (int k = i + 1; k < grid.GetLength(0); k++)
                {
                    if (grid[k, j] >= grid[i, j])
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees++;
                    continue;
                }

                //look left
                visible = true;
                for (int k = i - 1; k >= 0; k--)
                {
                    if (grid[k, j] >= grid[i, j])
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees++;
                    continue;
                }

                //look down
                visible = true;
                for (int k = j + 1; k < grid.GetLength(1); k++)
                {
                    if (grid[i, k] >= grid[i, j])
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees++;
                    continue;
                }

                //look up
                visible = true;
                for (int k = j - 1; k >= 0; k--)
                {
                    if (grid[i, k] >= grid[i, j])
                    {
                        visible = false;
                        break;
                    }
                }

                if (visible)
                {
                    visibleTrees++;
                }
            }
        }

        return visibleTrees.ToString();
    }
}

