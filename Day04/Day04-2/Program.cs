using System.Diagnostics;

Console.WriteLine("Day 4-2");
var overlap = 0;
var assignments = new List<Assignment>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    Console.WriteLine($"Input: {line}");
    var item = new Assignment();
    var elfs = line.Split(',');
    item.start1 = int.Parse(elfs[0].Split('-')[0]);
    item.end1 = int.Parse(elfs[0].Split('-')[1]);
    item.start2 = int.Parse(elfs[1].Split('-')[0]);
    item.end2 = int.Parse(elfs[1].Split('-')[1]);
    assignments.Add(item);
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
foreach (var a in assignments)
{
    if ((a.start1 <= a.start2 && a.end1 >= a.end2) ||
        (a.start2 <= a.start1 && a.end2 >= a.end1) ||
        (a.start1 >= a.start2 && a.start1 <= a.end2) ||
        (a.start2 >= a.start1 && a.start2 <= a.end1))
    {
        overlap++;
    }
}

stopWatch.Stop();

Console.WriteLine($"Result: {overlap} - Elapsed {stopWatch.Elapsed} ");

internal class Assignment
{
    public int end1;
    public int end2;
    public int start1;
    public int start2;
}