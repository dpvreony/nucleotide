$fullPathIncFileName = $MyInvocation.MyCommand.Definition
$currentScriptName = $MyInvocation.MyCommand.Name
$currentExecutingPath = $fullPathIncFileName.Replace($currentScriptName, "")
pushd $currentExecutingPath

$nugetBaseDir = "$currentExecutingPath\build"
$targetDir = "$nugetBaseDir\tools"
if(!(Test-Path -Path $targetDir ))
{
    New-Item -ItemType directory -Path $targetDir
}

msbuild Dhgms.Nucleotide.csproj /p:OutputPath=$targetDir
copy Dhgms.Nucleotide.nuspec "$currentExecutingPath\build\Dhgms.Nucleotide.nuspec"
.nuget\nuget.exe pack "$currentExecutingPath\build\Dhgms.Nucleotide.nuspec" -basepath $nugetBaseDir -outputdirectory $nugetBaseDir -version 1.0.0 -NoPackageAnalysis
popd
