using System.Diagnostics;

Console.WriteLine("Day 3-2");
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
            break;
        }
}

var sum = 0;
var cont = false;
for (var i = 0; i < sacks.Count; i += 3)
{
    cont = false;
    var sack1 = sacks[i];
    var sack2 = sacks[i + 1];
    var sack3 = sacks[i + 2];
    foreach (var c1 in sack1.Items)
        if (sack2.Items.Contains(c1) && !cont)
            foreach (var c2 in sack2.Items)
                if (c1 == c2 && sack3.Items.Contains(c2) && !cont)
                {
                    if (c2 >= 'a')
                        sum += c2 - 'a' + 1;
                    else
                        sum += c2 - 'A' + 27;

                    cont = true;
                    break;
                }
}

stopWatch.Stop();

Console.WriteLine($"Result: {sum} - Elapsed {stopWatch.Elapsed} ");

internal class Rucksack
{
    public string Items { get; set; }
    public string c1 { get; set; }
    public string c2 { get; set; }
    public char shared { get; set; }
    public int score { get; set; }
}