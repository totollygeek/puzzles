// See https://aka.ms/new-console-template for more information

using AdventOfCode.Y2024;
using Infrastructure;
using Spectre.Console;

Puzzle[] puzzles = [
    new Day1()
];

var table = new Table();
table.AddColumn("Day");
table.AddColumn("Part One");
table.AddColumn("Part Two");

for (var i = 0; i < puzzles.Length; i++)
{
    var day = (i + 1).ToString();
    var result = puzzles[i].Solve();
    
    table.AddRow(day, result.PartOne, result.PartTwo);
}

AnsiConsole.Write(table);