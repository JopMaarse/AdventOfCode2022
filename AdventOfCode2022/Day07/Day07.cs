namespace AdventOfCode2022.Day7;

internal class Day07
{
    public static async Task<string> Solve(Stream stream)
    {
        const int maxDirSize = 100000, totalCapacity = 70000000, updateSize = 30000000;
        using StreamReader streamReader = new(stream);
        Tree root = Tree.CreateRoot("/");
        Tree currentDirectory = null!;
        string? input;
        while ((input = await streamReader.ReadLineAsync()) is not null)
        {
            currentDirectory = input.Split(' ') switch
            {
                ["$", "cd", "/"] =>  root,
                ["$", "cd", ".."] => currentDirectory.Parent!,
                ["$", "cd", string dir] => currentDirectory is Directory node ? node.AddChildNode(dir) : throw new Exception(),
                ["$", "ls"] => currentDirectory,
                ["dir", string directory] => currentDirectory,
                [string size, string fileName] => currentDirectory is Directory node ? node.AddLeaf(fileName, int.Parse(size)) : throw new Exception(),
                _ => throw new Exception("invalid input")
            };
        }

        int part1 = root.Part1(maxDirSize);

        int free = totalCapacity - root.Size;
        int spaceNeeded = updateSize - free;
        return root.Part2(spaceNeeded, root.Size).ToString();
    }
}
