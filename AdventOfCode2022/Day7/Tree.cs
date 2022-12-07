namespace AdventOfCode2022.Day7;

public abstract class Tree : IEquatable<Tree>
{
    public string Name { get; }
    public Tree? Parent { get; }
    public abstract int Size { get; }

    protected Tree(string name, Tree? parent = null)
    {
        Name = name;
        Parent = parent;        
    }

    public static Tree CreateRoot(string name) => new Directory(name);
    public bool Equals(Tree? other) => other is not null && other.Parent == Parent && other.Name == Name;

    public int Part1(int max)
    {
        int size = 0;
        if (this is Directory dir)
        {
            if (Size <= max)
                size += Size;

            size += dir.Children
                .Where(c => c is Directory)
                .Sum(c => c.Part1(max));
        }

        return size;
    }

    public int Part2(int target, int currentBest)
    {
        if (this is Directory dir)
        {
            if (Size >= target)
            {
                currentBest = dir.Children.Min(c => c.Part2(target, Size < currentBest ? Size : currentBest));
            }
        }
        return currentBest;
    }
}

public class Directory : Tree
{
    private int? _size;
    public override int Size => _size ??= Children.Sum(c => c.Size);
    public HashSet<Tree> Children { get; }

    public Directory(string name, Tree? parent = null) : base(name, parent)
    {
        Children = new();
    }

    public Tree AddLeaf(string name, int value)
    {
        Children.Add(new File(name, this, value));
        return this;
    }

    public Tree AddChildNode(string name)
    {
        Tree node = new Directory(name, this);
        Children.Add(node);
        Children.TryGetValue(node, out node!);
        return node;
    }
}

public class File : Tree
{
    public override int Size { get; }
    public File(string name, Tree? parent, int size) : base(name, parent)
    {
        Size = size;
    }
}
