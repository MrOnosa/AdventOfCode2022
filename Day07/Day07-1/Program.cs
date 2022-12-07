using System.Diagnostics;
using System.Xml.Schema;

Console.WriteLine("Day 7-1");
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

//parent.Print();


stopWatch.Stop();

void Test()
{
    var parent = new Directory();
    parent.name = "/";
    var a = new Directory();
    a.name = "a";
    parent.childrenDirectories.Add(a);
    var e = new Directory();
    e.name = "e";
    a.childrenDirectories.Add(e);
    var i = new File();
    i.name = "i";
    i.size = 584;
    e.childrenFiles.Add(i);
    var f = new File();
    f.name = "f";
    f.size = 29116;
    a.childrenFiles.Add(f);
    var g = new File();
    g.name = "g";
    g.size = 2557;
    a.childrenFiles.Add(g);
    var h = new File();
    h.name = "h.lst";
    h.size = 62596;
    a.childrenFiles.Add(h);
    var b = new File();
    b.name = "b.txt";
    b.size = 14848514;
    parent.childrenFiles.Add(b);

    parent.Print();
}
Console.WriteLine($"Result: {parent.AccumulateSizeAtMost100000Recursive()} - Elapsed {stopWatch.Elapsed} ");

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
    public long AccumulateSizeAtMost100000Recursive()
    {
        long temp = 0;
        if (size <=100000)
        {
            temp += size;
        }
        foreach (var dir in childrenDirectories)
        {
            temp += dir.AccumulateSizeAtMost100000Recursive();
        }
        return temp;
    }
}

