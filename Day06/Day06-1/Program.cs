using System.Diagnostics;

Console.WriteLine("Day 6-1");
int i = 0;

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    char a = ' ';
    char b = ' ';
    char c = ' ';
    char d = ' ';
    //Console.WriteLine($"Input: {line}");
    foreach (var l in line)
    {
        i++;
        a = b;
        b = c;
        c = d;
        d = l;
        if (i > 4 && a != b && a != c && a != d && b != c && b != d && c != d)
        {
            Console.WriteLine($"Result: {i} - {a}{b}{c}{d} ");
            break;
        }
    }
}

stopWatch.Stop();

Console.WriteLine($"Elapsed {stopWatch.Elapsed} ");