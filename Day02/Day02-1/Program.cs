using System.Diagnostics;

Console.WriteLine("Day 2-1");
var stopWatch = new Stopwatch();
stopWatch.Start();
var rounds = new List<Round>();
foreach (var line /*Store text into string records*/ in File.ReadLines(@"puzzle-input.txt"))
{
    Console.WriteLine($"Input: {line}");
    rounds.Add(new Round
    {
        ElfMove = line[0],
        YourMove = line[2]
    });
}

var sum = 0;
foreach (var round in rounds) sum += round.Outcome();

stopWatch.Stop();

Console.WriteLine($"Result: {sum} - Elapsed {stopWatch.Elapsed} ");

internal struct Round
{
    public const int Loss = 0;
    public const int Tie = 3;
    public const int Win = 6;
    public const int Rock = 1;
    public const int Paper = 2;
    public const int Scissors = 3;

    public char ElfMove;
    public char YourMove;

    public int Outcome()
    {
        if (ElfMove == 'A') //Rock
        {
            if (YourMove == 'X') return Tie + Rock;
            if (YourMove == 'Y') return Win + Paper;
            if (YourMove == 'Z') return Loss + Scissors;
        }

        if (ElfMove == 'B') //Paper
        {
            if (YourMove == 'X') return Loss + Rock;
            if (YourMove == 'Y') return Tie + Paper;
            if (YourMove == 'Z') return Win + Scissors;
        }

        if (ElfMove == 'C') //Scissors
        {
            if (YourMove == 'X') return Win + Rock;
            if (YourMove == 'Y') return Loss + Paper;
            if (YourMove == 'Z') return Tie + Scissors;
        }

        throw new Exception(ToString());
    }
}