namespace AdventOfCode2022.Day09;

internal enum Direction
{
    Up, Down, Left, Right
}

internal readonly struct Movement
{
    public int Distance { get; init; }
    public Direction Direction { get; init; }
}
