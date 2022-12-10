using System.Diagnostics;

Console.WriteLine("Day 10-1");
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
var bits = new List<int>();
foreach (var line in lines)
{
    if (line == "noop")
    {
        //during
        cycle++;
        storeSignalStrength(cycle, bits, X);
        //after
    }
    else
    {
        //first
        cycle++;
        storeSignalStrength(cycle, bits, X);
        //second
        cycle++;
        storeSignalStrength(cycle, bits, X);
        X += int.Parse(line.Split(' ')[1]);
    }

    if (cycle > 220) break;
}

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine(bits.Sum());

void storeSignalStrength(int cycle, List<int> ints, int X)
{
    if ((cycle - 20) % 40 == 0)
    {
        ints.Add(cycle * X);
        Console.WriteLine($"During cycle {cycle}, X is {X}, so signal strength is {ints[^1]}.");
    }
}