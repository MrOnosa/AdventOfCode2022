using System.Diagnostics;

Console.WriteLine("Day 8-2");
var lines = new List<string>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    //Console.WriteLine($"Input: {line}");
    lines.Add(line);
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

int cols = lines[0].Length;
int rows = lines.Count;

var grid = new int[rows, cols];

for (var r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        var line = lines[r];
        grid[r, c] = int.Parse(line[c].ToString());
    }
}

int visible = 0;
int highestScore = 0;

for (var r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        int ls = 0;
        int rs = 0;
        int us = 0;
        int ds = 0;
        //left
        var left = new Stack<int>();
        for (int x = 0; x < c; x++)
        {
            left.Push(grid[r, x]);
        }

        while (left.Count > 0)
        {
            ls++;
            if (left.Pop() < grid[r, c])
            {
            }
            else
            {
                break;
            }
        }

        //right
        var right = new List<int>();
        for (int x = c + 1; x < cols; x++)
        {
            right.Add(grid[r, x]);
        }

        foreach (var t in right)
        {
            rs++;
            if (t < grid[r, c])
            {
            }
            else
            {
                break;
            }
        }

        //up
        var up = new Stack<int>();
        for (int y = 0; y < r; y++)
        {
            up.Push(grid[y, c]);
        }

        while (up.Count > 0)
        {
            us++;
            if (up.Pop() < grid[r, c])
            {
            }
            else
            {
                break;
            }
        }

        //down
        var down = new List<int>();
        for (int y = r + 1; y < rows; y++)
        {
            down.Add(grid[y, c]);
        }

        foreach (var t in down)
        {
            ds++;
            if (t < grid[r, c])
            {
            }
            else
            {
                break;
            }
        }

        int score = ls * rs * us * ds;
        if (score > highestScore)
        {
            highestScore = score;
            Console.WriteLine($"New high score found at {r},{c} of {highestScore} ");
        }
    }
}

stopWatch.Stop();

Console.WriteLine($"Result:  - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine(highestScore);