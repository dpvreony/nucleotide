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
    /// Generates the Web API service
    /// </summary>
    public sealed class WebApiServiceGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiServiceGenerator"/> class. 
        /// </summary>
        public WebApiServiceGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "Controller";
        }

        /// <inheritdoc />
        protected override string GetBaseClass()
        {
            return "System.Web.Http.ApiController";
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            {
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}SignalRHub", "signalRHub", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            };

            return result;
        }

        /// <inheritdoc />
        protected override MemberDeclarationSyntax[] GetMethodDeclarations()
        {
            var result = new List<MemberDeclarationSyntax>();

            result.Add(GetAddMethodDeclaration());
            result.Add(GetDeleteMethodDeclaration());
            result.Add(GetListMethodDeclaration());
            result.Add(GetUpdateMethodDeclaration());

            return result.ToArray();
        }

        private MemberDeclarationSyntax GetAddMethodDeclaration()
        {
            //var parameters = GetParams(constructorArguments.Select(x => $"{x.Item1(entityName)} {x.Item2}").ToArray());
            var consoleWriteLine = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  SyntaxFactory.IdentifierName("this"),
                  name: SyntaxFactory.IdentifierName("_test"));

            var returnDeclaration = SyntaxFactory.ReturnStatement(
                SyntaxFactory.AwaitExpression(
                    SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                    SyntaxFactory.InvocationExpression(consoleWriteLine)));
            var body = new StatementSyntax[] { returnDeclaration };

            var returnType = SyntaxFactory.ParseTypeName("Task<int>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "AddAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration()
        {
            var body = new StatementSyntax[0];

            var returnType = SyntaxFactory.ParseTypeName("Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetListMethodDeclaration()
        {
            var body = new StatementSyntax[0];

            var returnType = SyntaxFactory.ParseTypeName("Task<IEnumerable<string>>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateMethodDeclaration()
        {
            var body = new StatementSyntax[0];

            var returnType = SyntaxFactory.ParseTypeName("Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
