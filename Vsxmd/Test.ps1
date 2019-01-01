param (
    [switch]$Prepare,
    [switch]$Run
)

$path = (Resolve-Path "$($MyInvocation.MyCommand.Path)/..").Path
$md = "$path/Vsxmd.md"
$xml = "$path/Vsxmd.xml"

function Verify-Diff {
    param (
        [string]$file
    )

    $content1 = (Get-Content $file);
    $content2 = (Get-Content "$file.tmp")
    $diff = (Compare-Object $content1 $content2)
    $same = $diff.Count -eq 0

    echo "File $file Passed: $same"
    $diff

    if ($env:APPVEYOR -eq "True")
    {
        if ($same)
        {
            Add-AppveyorTest $file -Outcome Passed
        }
        else
        {
            Add-AppveyorTest $file -Outcome Failed
            exit -1
        }
    }
}

function Remove-TrailingSpaces {
    param (
        [string]$file
    )

    $content = Get-Content $file
    $content | Foreach { $_.TrimEnd() } | Set-Content $file
}


if ($Prepare)
{
    Remove-TrailingSpaces $md
    Remove-TrailingSpaces $xml

    Copy-Item $md "$md.tmp"
    Copy-Item $xml "$xml.tmp"
}

if ($Run)
{
    Verify-Diff $md
    Verify-Diff $xml
}
