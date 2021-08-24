using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs
{
    public sealed class CommandInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
        protected override string[] GetClassPrefixes() => new []{ "Add", "Delete", "Update" };

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Command for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix() => "Command";

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return Array.Empty<PropertyDeclarationSyntax>();
        }


        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return Array.Empty<MethodDeclarationSyntax>();
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            // this is a temporary workaround
            // this class needs splitting into 2 levels
            // there is a namespace \ interface collection level generator
            // then a class\interface level generator
            // the prefixes thing needs to go, it's flawed
            // the collection level should create instances of a reusable interface level generator.
            if (prefix.Equals("Delete"))
            {
                return new[]
                {
                    $"Whipstaff.Core.IAuditableRequest<long, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
                };
            }

            return new[]
            {
                $"Whipstaff.Core.IAuditableRequest<RequestDtos.{prefix}{entityGenerationModel.ClassName}RequestDto, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
            };
        }
    }
}
