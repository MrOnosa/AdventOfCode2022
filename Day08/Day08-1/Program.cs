using System.Diagnostics;

Console.WriteLine("Day 8-1");
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"test-input.txt"))
{
    Console.WriteLine($"Input: {line}");
}
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");




