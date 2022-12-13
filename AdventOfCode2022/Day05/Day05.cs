namespace AdventOfCode2022.Day5;

internal class Day05
{
    private readonly record struct Operation(int number, int from, int to);

    public static async Task<string> Solve(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        
        List<LinkedList<char>> stacks = new();
        List<Operation> operations = new();

        string? input;
        while ((input = await streamReader.ReadLineAsync()) is not null)
        {
            if (input.StartsWith('['))
            {
                ParseStacks(input);
            }
            if (input.StartsWith("move"))
            {
                ParseOperation(input);
            }
        }

        foreach (Operation operation in operations)
        {
            Part2(operation);
        }

        return new(stacks.Select(list => list.First!.Value).ToArray());

        void ParseStacks(string input)
        {
            int startIndex = 0;
            while (input.Length > startIndex)
            {
                if (stacks.Count <= startIndex / 4)
                {
                    stacks.Add(new LinkedList<char>());
                }
                if (input[startIndex + 1] != ' ')
                {
                    stacks[startIndex / 4].AddLast(input[startIndex + 1]);
                }
                startIndex += 4;
            }
        }

        void ParseOperation(string input)
        {
            string[] split = input.Split(' ');
            operations.Add(new Operation(int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5])));
        }

        void Part1(Operation operation)
        {
            for (int i = 0; i < operation.number; i++)
            {
                char box = stacks[operation.from - 1].First!.Value;
                stacks[operation.from - 1].RemoveFirst();
                stacks[operation.to - 1].AddFirst(box);
            }
        }
        
        void Part2(Operation operation)
        {
            foreach (char box in stacks[operation.from - 1].Take(operation.number).Reverse())
            {
                stacks[operation.to - 1].AddFirst(box);
            }
            for (int i = 0; i < operation.number; i++)
            {
                stacks[operation.from - 1].RemoveFirst();
            }
        }
    }
}
