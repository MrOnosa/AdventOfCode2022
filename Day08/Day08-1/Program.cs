using System.Diagnostics;

Console.WriteLine("Day 8-1");
var lines = new List<string>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    //Console.WriteLine($"Input: {line}");
    lines.Add(line);
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

int cols = lines[0].Length + 2;
int rows = lines.Count + 2;

var grid = new int[rows, cols];

for (var r = 0; r < rows; r++)
{
    for (int c = 0; c < cols; c++)
    {
        if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
        {
            grid[r, c] = -1;
        }
        else
        {
            var line = lines[r - 1];
            grid[r, c] = int.Parse(line[c - 1].ToString());
        }
    }
}

int visible = 0;

for (var r = 1; r < rows - 1; r++)
{
    for (int c = 1; c < cols - 1; c++)
    {
        var hidden = true;

        //left
        var left = new List<int>();
        for (int x = 0; x < c && hidden; x++)
        {
            left.Add(grid[r, x]);
        }

        if (left.All(t => t < grid[r, c]))
        {
            visible++;
            continue;
        }

        //right
        var right = new List<int>();
        for (int x = c + 1; x < cols && hidden; x++)
        {
            right.Add(grid[r, x]);
        }

        if (right.All(t => t < grid[r, c]))
        {
            visible++;
            continue;
        }

        //up
        var up = new List<int>();
        for (int y = 0; y < r && hidden; y++)
        {
            up.Add(grid[y, c]);
        }
        
        if (up.All(t => t < grid[r, c]))
        {
            visible++;
            continue;
        }

        //down
        var down = new List<int>();
        for (int y = r + 1; y < rows && hidden; y++)
        {
            down.Add(grid[y, c]);
        }
        
        if (down.All(t => t < grid[r, c]))
        {
            visible++;
            continue;
        }
    }
}

stopWatch.Stop();

Console.WriteLine($"Result:  - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine(visible);