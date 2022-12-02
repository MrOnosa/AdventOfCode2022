using System.Diagnostics;

Console.WriteLine("Hello World!");
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
List<int> calorieAggregation = new List<int>();
int elfIndex = 0;
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@"puzzle-input.txt"))
{
    Console.WriteLine($"Input: {line}");
    if(string.IsNullOrWhiteSpace(line)){
    Console.WriteLine($"Elf #{elfIndex+1} had  {calorieAggregation[elfIndex]} calories.");
        elfIndex++;
    }
    else if(calorieAggregation.Count == elfIndex){
        calorieAggregation.Add(int.Parse(line));
    } else {
        calorieAggregation[elfIndex]+=int.Parse(line);
    }
}
calorieAggregation = calorieAggregation.OrderByDescending(c => c).ToList();

stopWatch.Stop();

Console.WriteLine($"Result: {calorieAggregation.Take(3).Sum()} - Elapsed {stopWatch.Elapsed} ");
