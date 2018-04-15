using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.Model
{
    /// <summary>
    /// Generates models
    /// </summary>
    public class KeyedModelClassGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedModelClassGenerator"/> class.
        /// </summary>
        public KeyedModelClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override bool GetWhetherClassShouldBePartialClass() => false;

        protected override bool GetWhetherClassShouldBeSealedClass() => false;

        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix() => "Model";

        protected override string GetNamespace() => "Models";

        protected override IList<string> GetBaseConstructorArguments() => null;

        protected override IList<string> GetUsings()
        {
            return null;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Keyed Model Class for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return null;
        }

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override MemberDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            var idColumn = GetIdColumn(entityGenerationModel.KeyType);

            return new[]
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

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        protected override string GetBaseClass(string entityName)
        {
            return $"Unkeyed{entityName}Model";
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return new List<string>
            {
                $"I{entityName}Model"
            };
        }
    }
}
