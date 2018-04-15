using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Cqrs
{
    public sealed class CommandInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryInterfaceGenerator"/> class. 
        /// </summary>
        public CommandInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string[] GetClassPrefixes() => new []{ "Add", "Delete", "Update" };

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Command for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetClassSuffix() => "Command";

        protected override string GetNamespace() => "Commands";

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return null;
        }


        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
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
                    $"Dhgms.AspNetCoreContrib.Abstractions.IAuditableRequest<long, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
                };
            }

            return new[]
            {
                $"Dhgms.AspNetCoreContrib.Abstractions.IAuditableRequest<RequestDtos.{prefix}{entityGenerationModel.ClassName}RequestDto, ResponseDtos.{prefix}{entityGenerationModel.ClassName}ResponseDto>"
            };
        }
    }
}
