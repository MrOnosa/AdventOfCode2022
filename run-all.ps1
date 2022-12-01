echo "This wasn't as interesting as I thought it would be since part of the time captured is the dotnet run command itself which takes nearly a second. With no answers, this took 00:01:03.2730547."
$fullStopwatch =  [system.diagnostics.stopwatch]::StartNew()
for ($i = 1; $i -le 25; $i += 1)
{
    $stopwatchOne =  [system.diagnostics.stopwatch]::StartNew()
    cd ("Day{0:D2}\Day{0:D2}-1" -f $i)
    dotnet run | Out-Null
    $stopwatchOne.Stop()
    $r1 = $stopwatchOne.Elapsed.ToString('hh\:mm\:ss\.fffffff')
    echo "Day $i-1 - $r1"
    cd ("..\..\Day{0:D2}\Day{0:D2}-2" -f $i)
    $stopwatchTwo =  [system.diagnostics.stopwatch]::StartNew()
    dotnet run | Out-Null
    cd "..\..\"
    $stopwatchTwo.Stop()
    $r2 = $stopwatchTwo.Elapsed.ToString('hh\:mm\:ss\.fffffff')
    echo "Day $i-2 - $r2"
}
$fullStopwatch.Stop()
$r2 = $fullStopwatch.Elapsed.ToString('hh\:mm\:ss\.fffffff')
echo "All AoC time - $r2"