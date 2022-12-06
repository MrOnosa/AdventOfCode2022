using System.Diagnostics;

Console.WriteLine("Day 6-1");
int i = 0;

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    var stm = new char[14];
    //Console.WriteLine($"Input: {line}");
    foreach (var l in line)
    {
        i++;
        for (int j = 0; j < stm.Length - 1; j++)
        {
            stm[j] = stm[j + 1];
        }

        stm[^1] = l;
        if (i > 14)
        {
            bool unique = true;
            for (int j = 0; j < stm.Length - 1 && unique; j++)
            {
                for (int k = j + 1; k < stm.Length && unique; k++)
                {
                    if (stm[j] == stm[k])
                    {
                        unique = false;
                        break;
                    }
                }
            }

            if (unique)
            {
                Console.WriteLine($"Result: {i} ");
                break;
            }
        }
    }
}

stopWatch.Stop();

Console.WriteLine($"Elapsed {stopWatch.Elapsed} ");