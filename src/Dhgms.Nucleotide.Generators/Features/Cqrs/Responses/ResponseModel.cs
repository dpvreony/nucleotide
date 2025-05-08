// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Dhgms.Nucleotide.Generators.Features.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.Cqrs.Responses
{
    public sealed record ResponseModel(
        string ContainingNamespace,
        string Name,
        bool IsSealed,
        NamedTypeParameterModel[] Properties,
        Func<BaseTypeSyntax>? BaseTypeSyntaxFunc,
        string[] XmlDocSummary,
        bool Nullable)
        : NamedTypeArgumentModel(
            ContainingNamespace,
            Name,
            Nullable)
    {
        public static ResponseModel ResponseWithNoInheritance(

            string containingNamespace,
            string name,
            bool isSealed,
            NamedTypeParameterModel[] properties,
            string[] xmlDocSummary,
            bool Nullable)
        {
            return new ResponseModel(
                containingNamespace,
                name,
                isSealed,
                properties,
                null,
                xmlDocSummary,
                Nullable);
        }
    }
}
