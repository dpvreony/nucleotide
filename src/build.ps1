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

msbuild Dhgms.Nucleotide.sln /p:Configuration=Release /p:Platform="Any CPU"
copy Dhgms.Nucleotide\Dhgms.Nucleotide.nuspec "$currentExecutingPath\build\Dhgms.Nucleotide.nuspec"
copy "Dhgms.Nucleotide\bin\Release\*.*" "$targetDir"
copy "..\license" "$targetDir"

$version = [System.Reflection.AssemblyName]::GetAssemblyName("$currentExecutingPath\Dhgms.Nucleotide\bin\Release\Dhgms.Nucleotide.dll").Version.ToString()

.nuget\nuget.exe pack "$currentExecutingPath\build\Dhgms.Nucleotide.nuspec" -basepath $nugetBaseDir -outputdirectory $nugetBaseDir -version $version -NoPackageAnalysis
popd
