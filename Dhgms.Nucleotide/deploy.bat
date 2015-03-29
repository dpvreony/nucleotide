set targetName=Dhgms.Nucleotide

nuget pack %targetName%.csproj -Prop Configuration=Release -Symbols
