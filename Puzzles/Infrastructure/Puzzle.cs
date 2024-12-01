namespace Infrastructure;

public abstract class Puzzle(string inputFileName)
{
    protected string[] LoadInputFile()
    {
        return File.ReadLines($"Inputs/{inputFileName}").ToArray();
    }
    
    public abstract Output Solve();
}