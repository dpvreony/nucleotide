// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
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
            return Array.Empty<PropertyDeclarationSyntax>();
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string className, string prefix)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces(IEntityGenerationModel entityGenerationModel, string prefix)
        {
            var result = new List<string>
            {
                $"IUnkeyed{entityGenerationModel.ClassName}Model"
            };

            switch (entityGenerationModel.KeyType)
            {
                case KeyType.Guid:
                    result.Add("global::Whipstaff.Core.Entities.IGuidId");
                    break;
                case KeyType.Int32:
                    result.Add("global::Whipstaff.Core.Entities.IIntId");
                    break;
                case KeyType.Int64:
                    result.Add("global::Whipstaff.Core.Entities.ILongId");
                    break;
                case KeyType.Inherited:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityGenerationModel.KeyType));
            }

            return result.ToArray();
        }
    }
}