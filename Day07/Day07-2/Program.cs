using System.Diagnostics;

Console.WriteLine("Day 7-2");
var lines = new List<string>();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    //Console.WriteLine($"Input: {line}");
    lines.Add(line);
}
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

Directory parent = null;
Directory current = null;
for (var i = 0; i < lines.Count; i++)
{
    var line = lines[i];
    Console.WriteLine($"{line}");
    if (line == "$ cd /")
    {
        current = parent = new Directory() { name = "/" };
    } 
    else if (line.Split(' ')[1] == "ls")
    {
        //Add this list of items to the current directory
        i++;
        line = lines[i];
        while (!line.StartsWith("$") && lines.Count > i)
        {
            if (line.Split(' ')[0] == "dir")
            {
                //Dir spotted. If it's new, add it as a child
                if (!current.childrenDirectories.Any(d => d.name == line.Split(' ')[1]))
                {
                    current.childrenDirectories.Add(new Directory()
                    {
                        name = line.Split(' ')[1],
                        parentDirectory = current
                    });
                }
            }
            else
            {
                //File spotted. If it's new,a dd it as a child
                if (!current.childrenFiles.Any(d => d.name == line.Split(' ')[1]))
                {
                    current.childrenFiles.Add(new File(){name = line.Split(' ')[1], size = long.Parse(line.Split(' ')[0])});
                }
            }
            i++;
            if (lines.Count > i)
            {
                line = lines[i];
            }
        }

        i--;
    }
    else if (line.Split(' ')[1] == "cd")
    {
        if (line.Split(' ')[2] == "/")
        {
            current = parent;
        } else if (line.Split(' ')[2] == "..")
        {
            current = current.parentDirectory;
        }
        else
        {
            bool change = false;
            foreach (var dir in current.childrenDirectories)
            {
                if (dir.name == line.Split(' ')[2])
                {
                    change = true;
                    current = dir;
                    break;
                }
            }

            if (!change)
            {
                Console.WriteLine();
                Console.WriteLine($"Could not change to DIR {line.Split(' ')[2]} from {current.name}. Writting contents:");
                current.Print();
                Console.WriteLine("End of dir");
                Console.WriteLine();
            }
        }
    }
}

//parent.Print();

//Find sizes
parent.CalculateSizeRecursive();

long totalSpace = 70000000;
long targetUnusedSpace = 30000000;
long currentUnusedSpace = totalSpace - parent.size;
long amountToDelete = targetUnusedSpace - currentUnusedSpace;
Console.WriteLine($"Total Unused Space {currentUnusedSpace}");
Console.WriteLine($"Amount to delete {amountToDelete}");

var candidates = new List<Directory>();
parent.OverThreshold(amountToDelete, candidates);


//parent.Print();


stopWatch.Stop();

Console.WriteLine($"Result: {candidates.OrderBy(c => c.size).First().size} - Elapsed {stopWatch.Elapsed} ");

internal class File
{
    internal string name;
    internal long size;
    public override string ToString()
    {
        return $"{name} (file, size={size})";
    }
}

internal class Directory
{
    internal string name;
    internal Directory parentDirectory;
    internal List<Directory> childrenDirectories = new List<Directory>();
    internal List<File> childrenFiles = new List<File>();
    internal long size;

    public void Print(int tab = 0)
    {
        Console.WriteLine($"{new string(' ',tab)}- {name} (dir) {size}");
        foreach (var dir in childrenDirectories)
        {
            dir.Print(tab+1);
        }

        foreach (var file in childrenFiles)
        {
            Console.WriteLine($"{new string(' ',tab+1)}- {file}");
        }
    }

    public long CalculateSizeRecursive()
    {
        size = childrenFiles.Sum(f => f.size);
        foreach (var dir in childrenDirectories)
        {
            size += dir.CalculateSizeRecursive();
        }

        return size;
    }

    public void OverThreshold(long threshold, List<Directory> list)
    {
        if (size >= threshold)
        {
            list.Add(this);
        }

        foreach (var dir in childrenDirectories)
        {
            dir.OverThreshold(threshold, list);
        }
    }
}

