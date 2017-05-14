﻿using System;
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
    /// <summary>
    /// Generator for Query Factory Interface
    /// </summary>
    public sealed class QueryFactoryInterfaceGenerator : BaseInterfaceLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryFactoryInterfaceGenerator"/> class. 
        /// </summary>
        public QueryFactoryInterfaceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        protected override string GetClassSuffix()
        {
            return "QueryFactory";
        }

        protected override string GetNamespace()
        {
            return "QueryFactories";
        }

        protected override FieldDeclarationSyntax[] GetFieldDeclarations(IClassGenerationParameters classGenerationParameters)
        {
            return null;
        }

        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(PropertyInfoBase[] properties)
        {
            return null;
        }

        protected override MethodDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override string[] GetBaseInterfaces()
        {
            return null;
        }
    }
}
