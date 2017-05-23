using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    public sealed class KeyedModelInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedModelInterfaceGenerator"/> class. 
        /// </summary>
        public KeyedModelInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "Model";
        }

        protected override string[] GetInterfaceSummary(IClassGenerationParameters classDeclaration)
        {
            return new[]
            {
                $"Keyed model for {classDeclaration.ClassName}"
            };
        }

        protected override string GetNamespace()
        {
            return "Models";
        }

        protected override string GetClassPrefix()
        {
            return null;
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IClassGenerationParameters classGenerationParameters)
        {
            var idColumn = GetIdColumn(classGenerationParameters.KeyType);

            return new []
            {
                GetReadOnlyPropertyDeclaration(idColumn)
            };
        }

        private static PropertyInfoBase GetIdColumn(KeyType keyType)
        {
            switch (keyType)
            {
                case KeyType.Guid:
                    return new ClrGuidPropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        true,
                        null);
                case KeyType.Int32:
                    return new Integer32PropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        1,
                        int.MaxValue,
                        true,
                        null);
                case KeyType.Int64:
                    return new Integer64PropertyInfo(
                        CollectionType.None,
                        "Id",
                        "Unique Identifier for the object",
                        false,
                        1,
                        int.MaxValue,
                        true,
                        null);
                default:
                    throw new ArgumentOutOfRangeException(nameof(keyType));
            }
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IClassGenerationParameters classGenerationParameters)
        {
            return new []
            {
                $"IUnkeyed{classGenerationParameters.ClassName}Model"
            };
        }
    }
}