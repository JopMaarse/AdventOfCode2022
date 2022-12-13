using System;

namespace AdventOfCode2022.Day6;

internal class Day06
{
    //part 1: markerLength = 4
    private const int markerLength = 14;

    public static Task<string> Solve(Stream stream)
    {
        using StreamReader streamReader = new(stream);
        const int bufferLength = markerLength - 1;
        Span<int> buffer = stackalloc int[bufferLength];
        int character, i = 0, marker = 0;
        while ((character = streamReader.Read()) != -1)
        {
            int endIndex = i % bufferLength;
            int j = endIndex, fromEnd = 1;
            do
            {
                j--;
                if (j < 0)
                    j = bufferLength - 1;
                if (buffer[j] == character)
                    break;
                fromEnd++;                
            }
            while (j != endIndex);

            if (fromEnd == markerLength)
            { 
                marker++;
                if (marker == markerLength)
                    return Task.FromResult((i + 1).ToString());
            }
            else
                marker = Math.Min(marker + 1, fromEnd);

            buffer[endIndex] = character;
            i++;
        }

        throw new Exception("no marker found");
    }
}
