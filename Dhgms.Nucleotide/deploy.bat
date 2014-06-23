set targetName=Dhgms.Nucleotide

nuget pack %targetName%.csproj -Prop Configuration=Release -Symbols
REM copy /Y "bin\release\%targetName%.dll" "C:\Program Files\DHGMS Solutions\Libs\"
REM copy /Y "bin\release\%targetName%.pdb" "C:\Program Files\DHGMS Solutions\Libs\"
REM copy /Y "bin\release\%targetName%.xml" "C:\Program Files\DHGMS Solutions\Libs\"
REM "%WindowsSdkDir%\Bin\NETFX 4.0 Tools\gacutil.exe" /u "%targetName%"
REM "%WindowsSdkDir%\Bin\NETFX 4.0 Tools\gacutil.exe" /f /i "C:\Program Files\DHGMS Solutions\Libs\%targetName%.dll"
REM "%windir%\Microsoft.NET\Framework\v4.0.30319\ngen.exe" install "C:\Program Files\DHGMS Solutions\Libs\%targetName%.dll"