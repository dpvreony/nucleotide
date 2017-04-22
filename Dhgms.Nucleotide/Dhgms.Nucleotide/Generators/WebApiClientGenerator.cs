using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators
{
    class WebApiClientGenerator : BaseClassLevelCodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiServiceGenerator"/> class. 
        /// </summary>
        public WebApiClientGenerator(AttributeData attributeData) : base(attributeData)
        {
        }

        /// <inheritdoc />
        protected override string GetClassSuffix()
        {
            return "ApiClient";
        }

        protected override string GetNamespace()
        {
            return "ApiClients";
        }

        /// <inheritdoc />
        protected override string GetBaseClass()
        {
            return null;
        }

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return new List<string>
            {
                $"Services.I{entityName}Service"
            };
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            return null;
            //var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            //{
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}SignalRHub", "signalRHub", Accessibility.Private),
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
            //    new Tuple<Func<string, string>, string, Accessibility>(entityName => $"I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            //};

            //return result;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes()
        {
            return null;
        }

        /// <inheritdoc />
        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            var result = new List<MemberDeclarationSyntax>();

            result.Add(GetAddMethodDeclaration(entityName));
            result.Add(GetDeleteMethodDeclaration(entityName));
            result.Add(GetListMethodDeclaration(entityName));
            result.Add(GetUpdateMethodDeclaration(entityName));
            result.Add(GetViewMethodDeclaration(entityName));

            return result.ToArray();
        }

        private MemberDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "AddAsync";
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<int>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };
            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.List{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var throwStatement = RoslynGenerationHelpers.GetThrowNotImplementedExceptionSyntax() as StatementSyntax;

            var body = new[] { throwStatement };

            var returnType = SyntaxFactory.ParseTypeName($"System.Threading.Tasks.Task<ResponseDtos.View{entityName}ResponseDto>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

    }
}
