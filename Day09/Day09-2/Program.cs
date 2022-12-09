using System.Diagnostics;

Console.WriteLine("Day 9-2");
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

//Planck length rope
var rope = new List<Position>();
for (int i = 0; i < 10; i++)
{
    rope.Add(new Position());
}

var visited = new HashSet<Position>();
visited.Add(rope[9]);

foreach (var instruction in instructions)
{
    for (int step = 0; step < instruction.steps; step++)
    {
        switch (instruction.dir)
        {
            case 'R':
                rope[0].x++;
                break;
            case 'L':
                rope[0].x--;
                break;
            case 'U':
                rope[0].y++;
                break;
            case 'D':
                rope[0].y--;
                break;
        }

        //Visualizer
        /*if(instruction.dir == 'U' && instruction.steps == 8)
        {
            Console.WriteLine($"== {instruction.dir} Rope H - {step} of {instruction.steps:00} ==");
            for (int y = 15; y > -6; y--)
            {
                string line = $"{y:+00;-00} ";
                for (int x = -11; x < 15; x++)
                {
                    char o = '.';
                    if (x == 0 && y == 0)
                    {
                        o = 's';
                    }
                    for (int r = 9; r > 0; r--)
                    {
                        if (rope[r].x == x && rope[r].y == y)
                        {
                            o = r.ToString()[0];
                        }
                    }
                    if (rope[0].x == x && rope[0].y == y)
                    {
                        o = 'H';
                    }

                    line = line + o;
                }
                Console.WriteLine(line);
            }
        }*/

        //Move tail
        for (int i = 0; i < rope.Count - 1; i++)
        {
            if (rope[i].x - rope[i + 1].x > 1)
            {
                rope[i + 1].x++;
                if (rope[i].y - rope[i + 1].y > 0)
                {
                    rope[i + 1].y++;
                }
                else if (rope[i + 1].y - rope[i].y > 0)
                {
                    rope[i + 1].y--;
                }
            }
            else if (rope[i + 1].x - rope[i].x > 1)
            {
                rope[i + 1].x--;
                if (rope[i].y - rope[i + 1].y > 0)
                {
                    rope[i + 1].y++;
                }
                else if (rope[i + 1].y - rope[i].y > 0)
                {
                    rope[i + 1].y--;
                }
            }
            else if (rope[i].y - rope[i + 1].y > 1)
            {
                rope[i + 1].y++;
                if (rope[i].x - rope[i + 1].x > 0)
                {
                    rope[i + 1].x++;
                }
                else if (rope[i + 1].x - rope[i].x > 0)
                {
                    rope[i + 1].x--;
                }
            }
            else if (rope[i + 1].y - rope[i].y > 1)
            {
                rope[i + 1].y--;
                if (rope[i].x - rope[i + 1].x > 0)
                {
                    rope[i + 1].x++;
                }
                else if (rope[i + 1].x - rope[i].x > 0)
                {
                    rope[i + 1].x--;
                }
            }

            //Visualizer
            /*if(instruction.dir == 'U' && instruction.steps == 8)
            {
                Console.WriteLine($"== {instruction.dir} Rope {i} - {step} of {instruction.steps:00} ==");
                for (int y = 15; y > -6; y--)
                {
                    string line = $"{y:+00;-00} ";
                    for (int x = -11; x < 15; x++)
                    {
                        char o = '.';
                        if (x == 0 && y == 0)
                        {
                            o = 's';
                        }
                        for (int r = 9; r > 0; r--)
                        {
                            if (rope[r].x == x && rope[r].y == y)
                            {
                                o = r.ToString()[0];
                            }
                        }
                        if (rope[0].x == x && rope[0].y == y)
                        {
                            o = 'H';
                        }

                        line = line + o;
                    }
                    Console.WriteLine(line);
                }
            }*/
        }

        visited.Add(rope[9]);
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

internal class Position
{
    internal int x;
    internal int y;

    protected bool Equals(Position other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Position)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public static bool operator ==(Position? left, Position? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Position? left, Position? right)
    {
        return !Equals(left, right);
    }
}