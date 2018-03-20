﻿using System.Linq;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    public sealed class UnkeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class. 
        /// </summary>
        public UnkeyedModelInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "Model";
        }

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Unkeyed Model Interface for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetNamespace()
        {
            return "Models";
        }

        protected override string[] GetClassPrefixes()
        {
            return new[] { "Unkeyed"};
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return entityGenerationModel.Properties?.Select(GetPropertyDeclaration).ToArray();
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }
    }
}
