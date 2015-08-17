param (
    [switch]$Prepare,
    [switch]$Run
)

$path = (Resolve-Path "$($MyInvocation.MyCommand.Path)\..").Path
$md = "$path\Vsxmd.md"
$xml = "$path\Vsxmd.xml"

function Test {
    param (
        [string]$file
    )

    $content1 = (cat $file);
    $content2 = (cat "$file.tmp")
    $diff = (diff $content1 $content2)
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
        }
    }
}

if ($Prepare)
{
    copy $md "$md.tmp"
    copy $xml "$xml.tmp"
}

if ($Run)
{
    Test $md
    Test $xml
}
