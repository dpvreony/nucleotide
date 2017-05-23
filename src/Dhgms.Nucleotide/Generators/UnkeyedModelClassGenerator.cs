using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Validation;

namespace Dhgms.Nucleotide.Generators
{
    /// <summary>
    /// Generates models
    /// </summary>
    public class UnkeyedModelClassGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnkeyedModelClassGenerator"/> class. 
        /// </summary>
        public UnkeyedModelClassGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        private MemberDeclarationSyntax[] GetMembers()
        {
            var members = GetUnkeyedClasses()
                .Concat(GetKeyedClasses())
                .ToArray();

            return members;
        }

        private MemberDeclarationSyntax[] GetKeyedClasses()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Represents the {name} model.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"Unkeyed{name}Model")),
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"I{name}Model"))
            };

            var accessor = new[]
            {
                SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword))
            };

            var members = new MemberDeclarationSyntax[]
            {
                SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName("long"), "Id").AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword)).AddAccessorListAccessors(accessor)
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.ClassDeclaration($"{name}Model")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(baseTypes)
                .AddMembers(members)
                .WithLeadingTrivia(leadingTrivia)
            };
        }

        private MemberDeclarationSyntax[] GetUnkeyedClasses()
        {
            var name = "Test";

            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Represents the Unkeyed {name} model. Typically used for adding a new record.</summary>"),
            };

            var baseTypes = new BaseTypeSyntax[]
            {
                SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName($"IUnkeyed{name}Model"))
            };

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.ClassDeclaration($"Unkeyed{name}Model")
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddBaseListTypes(baseTypes)
                .WithLeadingTrivia(leadingTrivia)
            };
        }

        protected override string GetClassPrefix() => "Unkeyed";

        protected override string GetClassSuffix() => "Model";

        protected override string GetNamespace() => "Models";

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Unkeyed Model Class for {entityName}"
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

        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
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
            return new List<string>
            {
                $"IUnkeyed{entityName}Model"
            };
        }
    }
}
