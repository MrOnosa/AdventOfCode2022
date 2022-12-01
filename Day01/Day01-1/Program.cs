using System.Diagnostics;

Console.WriteLine("Hello World!");
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
List<int> calorieAggregation = new List<int>();
int elfIndex = 0;
foreach (string line /*Store text into string records*/ in System.IO.File.ReadLines(@".\..\puzzle-input.txt"))
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

int mostIndex=0;
for (int i = 1; i < calorieAggregation.Count; i++)
{
    int currentWinner = calorieAggregation[mostIndex];
    int calories = calorieAggregation[i];
    if(calories > currentWinner){
        mostIndex = i;
    }
}

stopWatch.Stop();

Console.WriteLine($"Result: Elf #{mostIndex+1} had the most calories with {calorieAggregation[mostIndex]} - Elapsed {stopWatch.Elapsed} ");
