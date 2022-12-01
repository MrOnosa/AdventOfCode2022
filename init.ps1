for ($i = 1; $i -le 25; $i += 1)
{
    mkdir "Day$i"
    New-Item "Day$i\test-input.txt"
    New-Item "Day$i\puzzle-input.txt"
    mkdir "Day$i\Day$i-1"
    mkdir "Day$i\Day$i-2"
    Set-Location "Day$i\Day$i-1"
    dotnet new console --framework net7.0
    dotnet new gitignore
    Remove-Item "Program.cs"
    Copy-Item "..\..\Template.cs" -Destination "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day$i-1") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day$i-1") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\Day$i\Day$i-2"
    dotnet new console --framework net7.0
    dotnet new gitignore
    Remove-Item "Program.cs"
    Copy-Item "..\..\Template.cs" -Destination "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day$i-2") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day$i-2") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\"
}