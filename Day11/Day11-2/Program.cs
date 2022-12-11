using System.Diagnostics;

Console.WriteLine("Day 11-1");


var monkeys = new List<Monkey>();
{
    //Test
    // monkeys.Add(new Monkey()
    // {
    //     Name = "Monkey 0",
    //     Items = new List<ulong> { 79, 98 },
    //     Operation = Operation.Multiply,
    //     OperationFactor = 19,
    //     TestFactor = 23
    // });
    // monkeys.Add(new Monkey()
    // {
    //     Name = "Monkey 1",
    //     Items = new List<ulong> { 54, 65, 75, 74 },
    //     Operation = Operation.Addition,
    //     OperationFactor = 6,
    //     TestFactor = 19
    // });
    // monkeys.Add(new Monkey()
    // {
    //     Name = "Monkey 2",
    //     Items = new List<ulong> { 79, 60, 97 },
    //     Operation = Operation.MultiplyOld,
    //     TestFactor = 13
    // });
    // monkeys.Add(new Monkey()
    // {
    //     Name = "Monkey 3",
    //     Items = new List<ulong> { 74 },
    //     Operation = Operation.Addition,
    //     OperationFactor = 3,
    //     TestFactor = 17
    // });
    // monkeys[0].TestTrueMonkey = monkeys[2];
    // monkeys[0].TestFalseMonkey = monkeys[3];
    // monkeys[1].TestTrueMonkey = monkeys[2];
    // monkeys[1].TestFalseMonkey = monkeys[0];
    // monkeys[2].TestTrueMonkey = monkeys[1];
    // monkeys[2].TestFalseMonkey = monkeys[3];
    // monkeys[3].TestTrueMonkey = monkeys[0];
    // monkeys[3].TestFalseMonkey = monkeys[1];
}
{
    //Real
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 0",
        Items = new List<ulong> { 73, 77 },
        Operation = Operation.Multiply,
        OperationFactor = 5,
        TestFactor = 11
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 1",
        Items = new List<ulong> { 57, 88, 80 },
        Operation = Operation.Addition,
        OperationFactor = 5,
        TestFactor = 19
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 2",
        Items = new List<ulong> { 61, 81, 84, 69, 77, 88 },
        Operation = Operation.Multiply,
        OperationFactor = 19,
        TestFactor = 5
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 3",
        Items = new List<ulong> { 78, 89, 71, 60, 81, 84, 87, 75 },
        Operation = Operation.Addition,
        OperationFactor = 7,
        TestFactor = 3
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 4",
        Items = new List<ulong> { 60, 76, 90, 63, 86, 87, 89 },
        Operation = Operation.Addition,
        OperationFactor = 2,
        TestFactor = 13
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 5",
        Items = new List<ulong> { 88 },
        Operation = Operation.Addition,
        OperationFactor = 1,
        TestFactor = 17
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 6",
        Items = new List<ulong> { 84, 98, 78, 85 },
        Operation = Operation.MultiplyOld,
        TestFactor = 7
    });
    monkeys.Add(new Monkey()
    {
        Name = "Monkey 7",
        Items = new List<ulong> { 98, 89, 78, 73, 71 },
        Operation = Operation.Addition,
        OperationFactor = 4,
        TestFactor = 2
    });
    monkeys[0].TestTrueMonkey = monkeys[6];
    monkeys[0].TestFalseMonkey = monkeys[5];
    monkeys[1].TestTrueMonkey = monkeys[6];
    monkeys[1].TestFalseMonkey = monkeys[0];
    monkeys[2].TestTrueMonkey = monkeys[3];
    monkeys[2].TestFalseMonkey = monkeys[1];
    monkeys[3].TestTrueMonkey = monkeys[1];
    monkeys[3].TestFalseMonkey = monkeys[0];
    monkeys[4].TestTrueMonkey = monkeys[2];
    monkeys[4].TestFalseMonkey = monkeys[7];
    monkeys[5].TestTrueMonkey = monkeys[4];
    monkeys[5].TestFalseMonkey = monkeys[7];
    monkeys[6].TestTrueMonkey = monkeys[5];
    monkeys[6].TestFalseMonkey = monkeys[4];
    monkeys[7].TestTrueMonkey = monkeys[3];
    monkeys[7].TestFalseMonkey = monkeys[2];
}

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
for (int round = 0; round < 10000; round++)
{
    foreach (var monkey in monkeys)
    {
        for (var i = 0; i < monkey.Items.Count;)
        {
            monkey.Inspections++;
            var item = monkey.Items[i];
            monkey.Items.RemoveAt(0);
            if (monkey.Operation == Operation.Addition)
            {
                item += monkey.OperationFactor;
            }
            else if (monkey.Operation == Operation.Multiply)
            {
                item *= monkey.OperationFactor;
            }
            else
            {
                item *= item;
            }

            //item /= 3;

            if (item % monkey.TestFactor == 0)
            {
                monkey.TestTrueMonkey.Items.Add(item);
            }
            else
            {
                monkey.TestFalseMonkey.Items.Add(item);
            }
        }
    }
}

stopWatch.Stop();

Console.WriteLine($"Result: - Elapsed {stopWatch.Elapsed} ");
Console.WriteLine(monkeys.OrderByDescending(m => m.Inspections).Select(m => m.Inspections).ToList()[0] *
                  monkeys.OrderByDescending(m => m.Inspections).Select(m => m.Inspections).ToList()[1]);


internal class Monkey
{
    internal ulong Inspections = 0;
    internal string Name;
    internal List<ulong> Items = new List<ulong>();
    internal Operation Operation;
    internal ulong OperationFactor;
    internal ulong TestFactor;
    internal Monkey TestTrueMonkey;
    internal Monkey TestFalseMonkey;
}

enum Operation
{
    Addition,
    Multiply,
    MultiplyOld
}