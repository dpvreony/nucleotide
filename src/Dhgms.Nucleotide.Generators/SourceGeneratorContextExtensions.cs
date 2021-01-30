using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Dhgms.Nucleotide.Generators
{
    internal static class SourceGeneratorContextExtensions
    {
        public static string TryCreateGeneratedSourceOutputPath(this GeneratorExecutionContext context, Guid folderGuid)
        {
            string generatedSourceOutputPath = null;
            if (context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.SaveSourceGeneratorOutput", out string saveSourceGeneratorOutputValue)
                && bool.TryParse(saveSourceGeneratorOutputValue, out bool saveSourceGeneratorOutput)
                && saveSourceGeneratorOutput
                && context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.IntermediateOutputPath", out string intermediateOutputPath))
            {
                generatedSourceOutputPath = Path.Combine(intermediateOutputPath, "Generated", folderGuid.ToString());
                Directory.CreateDirectory(generatedSourceOutputPath);
            }

            return generatedSourceOutputPath;
        }

        public static void AddSource(this GeneratorExecutionContext context, string generatedSourceOutputPath, string hintName, SourceText sourceText)
        {
            if (generatedSourceOutputPath is object && !Path.IsPathRooted(hintName) && !hintName.Contains(".."))
            {
                using FileStream stream = File.OpenWrite(Path.Combine(generatedSourceOutputPath, hintName));
                using TextWriter writer = new StreamWriter(stream, sourceText.Encoding ?? Encoding.UTF8, bufferSize: 8192, leaveOpen: true);
                sourceText.Write(writer, context.CancellationToken);
            }

            context.AddSource(hintName, sourceText);
        }
    }}
