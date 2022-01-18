// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Model
{
    public sealed class KeyedModelInterfaceGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<IEntityGenerationModel>
    {
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

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
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