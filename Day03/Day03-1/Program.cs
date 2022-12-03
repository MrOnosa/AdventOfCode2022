using System.Diagnostics;

Console.WriteLine("Day 3-1");
var sacks = new List<Rucksack>();
foreach (var line /*Store text into string records*/ in File.ReadLines(@"puzzle-input.txt"))
{
    sacks.Add(new Rucksack { Items = line });
    Console.WriteLine($"Input: {line}");
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

foreach (var sack in sacks)
{
    sack.c1 = sack.Items.Substring(0, sack.Items.Length / 2);
    sack.c2 = sack.Items.Substring(sack.Items.Length / 2);
    foreach (var c in sack.c1)
        if (sack.c2.Contains(c))
        {
            sack.shared = c;
            if (sack.shared >= 'a')
                sack.score = sack.shared - 'a' + 1;
            else
                sack.score = sack.shared - 'A' + 27;
            break;
        }

    Console.WriteLine($"{sack.score}");
}

stopWatch.Stop();

Console.WriteLine($"Result: {sacks.Sum(s => s.score)} - Elapsed {stopWatch.Elapsed} ");

internal class Rucksack
{
    public string Items { get; set; }
    public string c1 { get; set; }
    public string c2 { get; set; }
    public char shared { get; set; }
    public int score { get; set; }
}