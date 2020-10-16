$ErrorActionPreference = 'Stop'

$solutionName = 'Dhgms.Nucleotide'
$solutionPath = 'src\\' + $solutionName + '.sln'
$testProject = 'src\\' + $solutionName + '.UnitTests\\' + $solutionName + '.UnitTests.csproj'

function CreateDirectoryIfItDoesNotExist([String] $DirectoryToCreate)
{
	if (-not (Test-Path -LiteralPath $DirectoryToCreate))
	{
		try
		{
			New-Item -Path $DirectoryToCreate -ItemType Directory -ErrorAction Stop | Out-Null #-Force
		}
		catch
		{
			Write-Error -Message "Unable to create directory '$DirectoryToCreate'. Error was: $_" -ErrorAction Stop
		}
	}
}

$tools = (
	('dotnet', ('tool', 'install', '--global', 'dotMorten.OmdGenerator')),
	('dotnet', ('tool', 'install', '--global', 'ConfigValidate')),
	('dotnet', ('tool', 'install', '--global', 'dotnet-outdated')),
	('dotnet', ('tool', 'install', '--global', 'snitch')),
	('dotnet', ('tool', 'install', '--global', 'dotnet-sonarscanner'))
	#{ restore $solutionPath /bl:artifacts\\binlog\\restore.binlog }
)

Foreach ($i in $tools)
{
	& $i[0] $i[1]
}

CreateDirectoryIfItDoesNotExist('.\artifacts\nupkg');
CreateDirectoryIfItDoesNotExist('.\artifacts\outdated');
CreateDirectoryIfItDoesNotExist('.\artifacts\snitch');
CreateDirectoryIfItDoesNotExist('.\artifacts\omd');
CreateDirectoryIfItDoesNotExist('.\artifacts\docfx');
Remove-Item 'artifacts\docfx\*.*' -Recurse

$actions = (
	('dotnet', ('restore', $solutionPath, '/bl:artifacts\\binlog\\restore.binlog')),
	('dotnet', ('build', $solutionPath, '--configuration', 'Release', '--no-restore', '/bl:artifacts\\binlog\\build.binlog')),
	('dotnet', ('test', $testProject, '--configuration', 'Release', '--no-build', '--nologo', '--collect:"XPlat Code Coverage"', '--', 'DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover', '/bl:artifacts\\binlog\\test.binlog'))
)

Foreach ($i in $actions)
{
	& $i[0] $i[1]
	if(!$?)
	{
		return 1;
	}
}

#$runSonar = $false;
#
#if ($runSonar)
#{
#	dotnet sonarscanner begin /k:"project-key"
#}


#if ($runSonar)
#{
#	dotnet sonarscanner end
#}

if ($Env:GITHUB_REF -and $Env:GITHUB_REF.StartsWith("refs/heads/dependabot"))
{
	#drop out if dependabot, no point doing package ref checks, or additional output as won't be used.
	Write-Host "Dependabot branch, skipping rest of checks"
	return
}

$postBuildActions = (
	('dotnet', ('pack', $solutionPath, '--configuration', 'Release', '--no-build', '/bl:artifacts\\binlog\\pack.binlog', '/p:PackageOutputPath=..\artifacts\nupkg')),
	('dotnet', ('outdated', '-o', 'artifacts\outdated\outdated.json', 'src'))
	#('snitch', ('src', '--strict')),
	#('generateomd.exe', ('/source=src', '/output=artifacts\omd\index.htm', '/format=html'))
)

Foreach ($i in $postBuildActions)
{
	& $i[0] $i[1]
	if(!$?)
	{
		return 1;
	}
}

xcopy src\docfx_project\_site artifacts\docfx /E /I /Y
