using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.EntityFramework
{
    public sealed class EntityFrameworkModelGenerator : BaseClassLevelCodeGenerator
    {
        public EntityFrameworkModelGenerator(AttributeData attributeData) : base(attributeData)
        {
        }


        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;


        protected override MemberDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override string GetClassSuffix()
        {
            return "EfModel";
        }

        protected override string GetNamespace()
        {
            return "EfModels";
        }

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            return null;
        }

        protected override IList<string> GetUsings()
        {
            return null;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Entity Framework Model for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes()
        {
            return null;
        }

        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
        }

        protected override string GetBaseClass(string entityName)
        {
            return null;
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return null;
        }

        protected override string GetClassPrefix()
        {
            return null;
        }
    }
}
