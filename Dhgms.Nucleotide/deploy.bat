set targetName=Dhgms.Nucleotide

nuget pack %targetName%.csproj -Prop Configuration=Release -Symbols
copy /Y "bin\release\%targetName%.dll" "C:\Program Files\DHGMS Solutions\Libs\"
copy /Y "bin\release\%targetName%.pdb" "C:\Program Files\DHGMS Solutions\Libs\"
copy /Y "bin\release\%targetName%.xml" "C:\Program Files\DHGMS Solutions\Libs\"
"%WindowsSdkDir%\Bin\NETFX 4.0 Tools\gacutil.exe" /u "%targetName%"
"%WindowsSdkDir%\Bin\NETFX 4.0 Tools\gacutil.exe" /f /i "C:\Program Files\DHGMS Solutions\Libs\%targetName%.dll"
"%windir%\Microsoft.NET\Framework\v4.0.30319\ngen.exe" install "C:\Program Files\DHGMS Solutions\Libs\%targetName%.dll"