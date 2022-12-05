using System.Diagnostics;

Console.WriteLine("Day 5-1");
List<string> colLine = new List<string>();
List<Stack<char>> stacks = new List<Stack<char>>();
List<string> rowLine = new List<string>();
List<(int num, int start, int end)> instructions = new List<(int num, int start, int end)>();
int lineNumber = 0;
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    lineNumber++;
    if (lineNumber == 9 || lineNumber == 10)
    {
        //Ignore
    }
    else if (lineNumber < 9)
    {
        colLine.Add(line);
    }
    else
    {
        if (int.TryParse(line[6].ToString(), out var ones))
        {
            instructions.Add(new(
                int.Parse(line[5].ToString() + line[6]),
                int.Parse(line[13].ToString()),
                int.Parse(line[18].ToString())));
        }
        else
        {
            instructions.Add(new(
                int.Parse(line[5].ToString()),
                int.Parse(line[12].ToString()),
                int.Parse(line[17].ToString())));
        }

        Console.WriteLine($"instructions: {instructions[^1]}");
    }
}

for (int i = 0; i < 9; i++)
{
    stacks.Add(new Stack<char>());
}

colLine.Reverse();
foreach (var line in colLine)
{
    for (int i = 1, s = 0; i < line.Length; i += 4, s++)
    {
        if (line[i] != ' ')
        {
            stacks[s].Push(line[i]);
        }
    }
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

foreach (var instruction in instructions)
{
    var temp = new List<char>();
    for (int i = 0; i < instruction.num; i++)
    {
        temp.Add(stacks[instruction.start - 1].Pop());
    }

    temp.Reverse();
    foreach (var t in temp)
    {
        stacks[instruction.end - 1].Push(t);
    }
}

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine($"");
foreach (var stack in stacks)
{
    if (stack.Any())
        Console.Write(stack.Peek());
}