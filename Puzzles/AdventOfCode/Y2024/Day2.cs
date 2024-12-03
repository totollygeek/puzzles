using Infrastructure;

namespace AdventOfCode.Y2024;

public class Day2() : Puzzle("day2.txt")
{
    private record Input(List<int[]> Reports);
    
    private Input ProcessInput()
    {
        var input = LoadInputFile();

        var result = new Input([]);

        foreach (var line in input)
        {
            var split = 
                line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            
            result.Reports.Add(split);
        }

        return result;
    }

    private static string SolvePartOne(Input input)
    {
        var safeReports = input.Reports.Where(IsReportSafe).ToArray();

        return  safeReports.Length.ToString();
    }

    private static bool IsReportSafe(int[] report)
    {
        var clone = new List<int>(report);
        
        clone.Sort();

        if (clone.SequenceEqual(report)) return HasCorrectDifferences(clone);

        clone.Reverse();
        
        return clone.SequenceEqual(report) && HasCorrectDifferences(clone);
    }

    private static bool HasCorrectDifferences(List<int> report)
    {
        for (var i = 0; i < report.Count - 1; i++)
        {
            var diff = Math.Abs(report[i] - report[i + 1]);
            
            if (diff is < 1 or > 3) return false;
        }

        return true;
    }
    
    private static bool IsDamperReport(int[] report)
    {
        if (IsReportSafe(report)) return true;

        return report.Select((_, i) => i == 0
                ? report[1..]
                : report[..i].Concat(report[(i + 1)..]).ToArray())
            .Any(IsReportSafe);
    }
    
    private static string SolvePartTwo(Input input)
    {
        var safeReports = input.Reports.Where(IsDamperReport).ToArray();

        return  safeReports.Length.ToString();
    }

    public override Output Solve()
    {
        var input = ProcessInput();

        var partOne = SolvePartOne(input);
        var partTwo = SolvePartTwo(input);

        return new Output(partOne, partTwo);
    }
}