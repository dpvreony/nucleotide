using System;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
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

        protected override string[] GetInterfaceSummary(IEntityGenerationModel entityDeclaration)
        {
            return new[]
            {
                $"Keyed model for {entityDeclaration.ClassName}"
            };
        }

        protected override string GetNamespace()
        {
            return "Models";
        }

        protected override string[] GetClassPrefixes() => null;

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(
            IEntityGenerationModel entityGenerationModel, string prefix)
        {
            var idColumn = GetIdColumn(entityGenerationModel.KeyType);

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

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string entityName)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            return new []
            {
                $"IUnkeyed{entityGenerationModel.ClassName}Model"
            };
        }
    }
}