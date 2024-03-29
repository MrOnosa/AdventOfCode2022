﻿for ($i = 1; $i -le 9; $i += 1)
{
    mkdir "Day0$i"
    New-Item "Day0$i\test-input.txt"
    New-Item "Day0$i\puzzle-input.txt"
    mkdir "Day0$i\Day0$i-1"
    mkdir "Day0$i\Day0$i-2"
    Set-Location "Day0$i\Day0$i-1"
    dotnet new console --framework net7.0
    dotnet new gitignore
    Remove-Item "Program.cs"
    Copy-Item "..\..\Template.cs" -Destination "Program.cs"
    Copy-Item "..\..\Template.csproj" -Destination "Day0$i-1.csproj" -Force
    ((Get-Content -path "Day0$i-1.csproj" -Raw) -replace "Day01_1","Day0$i`_1") | Set-Content -Path "Day0$i-1.csproj"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape("Hello World!"),"Day $i-1") | Set-Content -Path "Program.cs"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape(".\..\test-input.txt"),"test-input.txt") | Set-Content -Path "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day0$i-1") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day0$i-1") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\Day0$i\Day0$i-2"
    dotnet new console --framework net7.0
    dotnet new gitignore
    Remove-Item "Program.cs"
    Copy-Item "..\..\Template.cs" -Destination "Program.cs"    
    Copy-Item "..\..\Template.csproj" -Destination "Day0$i-2.csproj" -Force
    ((Get-Content -path "Day0$i-2.csproj" -Raw) -replace "Day01_1","Day0$i`_2") | Set-Content -Path "Day0$i-2.csproj"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape("Hello World!"),"Day $i-2") | Set-Content -Path "Program.cs"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape(".\..\test-input.txt"),"test-input.txt") | Set-Content -Path "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day0$i-2") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day0$i-2") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\"
}
for ($i = 10; $i -le 25; $i += 1)
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
    Copy-Item "..\..\Template.csproj" -Destination "Day$i-1.csproj" -Force
    ((Get-Content -path "Day$i-1.csproj" -Raw) -replace "Day01_1","Day$i`_1") | Set-Content -Path "Day$i-1.csproj"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape("Hello World!"),"Day $i-1") | Set-Content -Path "Program.cs"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape(".\..\test-input.txt"),"test-input.txt") | Set-Content -Path "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day$i-1") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day$i-1") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\Day$i\Day$i-2"
    dotnet new console --framework net7.0
    dotnet new gitignore
    Remove-Item "Program.cs"
    Copy-Item "..\..\Template.csproj" -Destination "Day$i-2.csproj" -Force
    ((Get-Content -path "Day$i-2.csproj" -Raw) -replace "Day01_1","Day$i`_2") | Set-Content -Path "Day$i-2.csproj"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape("Hello World!"),"Day $i-2") | Set-Content -Path "Program.cs"
    ((Get-Content -path "Program.cs" -Raw) -replace [regex]::escape(".\..\test-input.txt"),"test-input.txt") | Set-Content -Path "Program.cs"
    Copy-Item "..\..\Template.cs" -Destination "Program.cs"
    Copy-Item "..\..\.template-vscode" -Recurse -Destination ".vscode"
    ((Get-Content -path ".\.vscode\launch.json" -Raw) -replace "Day1-1","Day$i-2") | Set-Content -Path ".\.vscode\launch.json"
    ((Get-Content -path ".\.vscode\tasks.json" -Raw) -replace "Day1-1","Day$i-2") | Set-Content -Path ".\.vscode\tasks.json"
    dotnet build
    Set-Location "..\..\"
}