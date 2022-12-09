using System.Diagnostics;

Console.WriteLine("Day 9-1");
var instructions = new List<Instruction>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    //Console.WriteLine($"Input: {line}");
    instructions.Add(new Instruction()
    {
        dir = line[0],
        steps = int.Parse(line.Split(' ')[1])
    });
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

var hPos = new Position();
var tPos = new Position();
var visited = new HashSet<Position>();
visited.Add(tPos);

foreach (var instruction in instructions)
{
    for (int step = 0; step < instruction.steps; step++)
    {
        switch (instruction.dir)
        {
            case 'R':
                hPos.x++;
                break;
            case 'L':
                hPos.x--;
                break;
            case 'U':
                hPos.y++;
                break;
            case 'D':
                hPos.y--;
                break;
        }

        //Move tail
        if (hPos.x - tPos.x > 1)
        {
            tPos.x++;
            if (hPos.y != tPos.y)
            {
                tPos.y = hPos.y;
            }
        }
        else if (tPos.x - hPos.x > 1)
        {
            tPos.x--;
            if (hPos.y != tPos.y)
            {
                tPos.y = hPos.y;
            }
        }

        if (hPos.y - tPos.y > 1)
        {
            tPos.y++;
            if (hPos.x != tPos.x)
            {
                tPos.x = hPos.x;
            }
        }
        else if (tPos.y - hPos.y > 1)
        {
            tPos.y--;
            if (hPos.x != tPos.x)
            {
                tPos.x = hPos.x;
            }
        }

        visited.Add(tPos);
    }
}

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine(visited.Count);


internal struct Instruction
{
    internal char dir;
    internal int steps;
}

internal struct Position
{
    internal int x;
    internal int y;
}