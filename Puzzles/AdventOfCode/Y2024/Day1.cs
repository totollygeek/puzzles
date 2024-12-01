using Infrastructure;

namespace AdventOfCode.Y2024;

public record Input(List<int> Left, List<int> Right);

public class Day1() : Puzzle("day1.txt")
{
    private Input ProcessInput()
    {
        var input = LoadInputFile();

        var result = new Input([], []);

        foreach (var line in input)
        {
            var split = line.Split(' ').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            if (split.Length != 2)
            {
                throw new Exception("Invalid input: "+ line);
            }
            
            result.Left.Add(int.Parse(split[0]));
            result.Right.Add(int.Parse(split[1]));
        }

        return result;
    }

    private string SolvePartOne(Input input)
    {
        input.Left.Sort();
        input.Right.Sort();
        
        var result = 
            input.Left.Select((left, i) => Math.Abs(left - input.Right[i])).Sum();

        return result.ToString();
    }
    
    private string SolvePartTwo(Input input)
    {
        var result =
            input.Left.Select(left =>
            {
                var similar = input.Right.Count(right => right == left);
                
                return left * similar;
            }).Sum();

        return result.ToString();
    }

    public override Output Solve()
    {
        var input = ProcessInput();
        
        if (input.Left.Count != input.Right.Count)
        {
            throw new Exception($"Invalid input. Left and right count mismatch: {input.Left.Count} != {input.Right.Count}");
        }

        var partOne = SolvePartOne(input);
        var partTwo = SolvePartTwo(input);

        return new Output(partOne, partTwo);
    }
}