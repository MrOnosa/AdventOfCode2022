using System.Diagnostics;

Console.WriteLine("Day 10-2");
var lines = new List<string>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    Console.WriteLine($"Input: {line}");
    lines.Add(line);
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

var X = 1;
int cycle = 0;
string hl = string.Empty;
foreach (var line in lines)
{
    if (line == "noop")
    {
        //during
        cycle++;
        hl += energize(X, cycle);
        hl = display(hl);
        //after
    }
    else
    {
        //first
        cycle++;
        hl += energize(X, cycle);
        hl = display(hl);
        //second
        cycle++;
        hl += energize(X, cycle);
        hl = display(hl);
        X += int.Parse(line.Split(' ')[1]);
    }

    if (cycle > 240) break;
}

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");

string display(string line)
{
    if (cycle % 40 == 0)
    {
        Console.WriteLine(line);
        return string.Empty;
    }

    return line;
}

string energize(int X, int cycle)
{
    if (X == cycle % 40 || X + 1 == cycle % 40 || X + 2 == cycle % 40)
    {
        return "#";
    }

    return ".";
}