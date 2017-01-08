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
    /// Code Generator for Repository Interface that supports Filtering via IQueryable selectors
    /// </summary>
    public class QueryableRepositoryIntefaceGenerator : ICodeGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryableRepositoryIntefaceGenerator"/> class. 
        /// </summary>
        public QueryableRepositoryIntefaceGenerator(AttributeData attributeData)
        {
            Requires.NotNull(attributeData, nameof(attributeData));
        }

        /// <summary>
        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
        /// </summary>
        /// <param name="applyTo">The syntax node this attribute is found on.</param>
        /// <param name="document">The document with the semantic model in which this attribute was found.</param>
        /// <param name="progress">A way to report diagnostic messages.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The generated member syntax to be added to the project.</returns>
        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
            MemberDeclarationSyntax applyTo,
            Document document,
            IProgress<Diagnostic> progress,
            CancellationToken cancellationToken)
        {
            var nodes = new MemberDeclarationSyntax[]
            {
                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("Repositories"))
                    .AddMembers(GetInterfaces())
            };

            var results = SyntaxFactory.List(nodes);

            return await Task.FromResult(results);
        }

        private MemberDeclarationSyntax[] GetInterfaces()
        {
            // TODO: get list of class generation parameters from source class

            var name = "Test";

            return new MemberDeclarationSyntax[]
            {
                SyntaxFactory.InterfaceDeclaration($"I{name}Repository")
                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                    .AddMembers(GetInterfaceMembers(name))
            };
        }

        private MemberDeclarationSyntax[] GetInterfaceMembers(string name)
        {
            return GetInterfaceMethods(name);
        }

        private MemberDeclarationSyntax[] GetInterfaceMethods(string name)
        {
            var result = new []
            {
                GetAddMethod(name),
                GetDeleteMethod(name),
                GetGetMethod(name),
                GetListMethod(name),
                GetUpdateMethod(name),
            };

            return result;
        }

        private MemberDeclarationSyntax GetUpdateMethod(string name)
        {
            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Gets the {name} item from the repository.</summary>"),
                SyntaxFactory.Comment("/// <returns>The ${name} item.</returns>")
            };

            var updateParams = GetUpdateParams(name);

            return GetMethod($"Update{name}Async", "Task", leadingTrivia, updateParams, null);
        }

        private MemberDeclarationSyntax GetListMethod(string name)
        {
            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Adds a {name} item to the repository.</summary>"),
                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
            };

            var listParams = GetListParams(name);
            //var listConstraintClauses = GetListConstraintClauses();
            var listTypeParameters = GetListTypeParameters();

            return GetMethod($"List{name}Async", "Task<IEnumerable<TResult>>", leadingTrivia, listParams, listTypeParameters);
        }

        private MemberDeclarationSyntax GetGetMethod(string name)
        {
            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Adds an {name} item to the repository.</summary>"),
                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
            };

            var getParams = GetGetParams(name);
            var getTypeParameters = GetGetTypeParameters();

            return GetMethod($"Get{name}Async", "Task", leadingTrivia, getParams, getTypeParameters);
        }

        private MemberDeclarationSyntax GetAddMethod(string name)
        {
            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Adds an {name} item to the repository.</summary>"),
                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
            };

            var parameterListSyntax = GetAddParams(name);

            return GetMethod($"Add{name}Async", "Task<long>", leadingTrivia, parameterListSyntax, null);
        }

        private MemberDeclarationSyntax GetDeleteMethod(string name)
        {
            var leadingTrivia = new[]
            {
                SyntaxFactory.Comment($"/// <summary>Deletes the {name} item with the specified id from the repository.</summary>"),
                SyntaxFactory.Comment("/// <returns>Asynchronous Task.</returns>")
            };

            var parameterListSyntax = GetDeleteParams();

            return GetMethod($"Delete{name}Async", "Task", leadingTrivia, parameterListSyntax, null);
        }

        private MemberDeclarationSyntax GetMethod(string methodName, string returnType, SyntaxTrivia[] leadingTrivia, ParameterListSyntax parameterListSyntax, TypeParameterListSyntax typeParameterListSyntax)
        {
            var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(returnType), methodName);

            if (parameterListSyntax != null &&
                parameterListSyntax.Parameters.Count > 0)
            {
                method = method.WithParameterList(parameterListSyntax);
            }

            if (typeParameterListSyntax != null &&
                typeParameterListSyntax.Parameters.Count > 0)
            {
                method = method.WithTypeParameterList(typeParameterListSyntax);
            }

            method = method.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            method = method.WithLeadingTrivia(leadingTrivia);
            return method;
        }

        private TypeParameterListSyntax GetGetTypeParameters()
        {
            return GetTypeParameters("TResult");
        }

        private TypeParameterListSyntax GetListTypeParameters()
        {
            return GetTypeParameters("TResult");
        }

        private TypeParameterListSyntax GetTypeParameters(params string[] identifiers)
        {
            var nodes = identifiers.Select(SyntaxFactory.TypeParameter);

            var parameters = SyntaxFactory.SeparatedList(nodes);
            var typeParameters = SyntaxFactory.TypeParameterList(parameters);

            return typeParameters;
        }

        private SyntaxList<TypeParameterConstraintClauseSyntax> GetListConstraintClauses()
        {
            var constraintClauses = SyntaxFactory.List<TypeParameterConstraintClauseSyntax>();

            return constraintClauses;
        }

        private AttributeListSyntax GetListAttributes()
        {
            var nodes = new AttributeSyntax[]
            {
                //SyntaxFactory.Attribute(SyntaxFactory.GenericName("Test"))
            };

            var attributes = SyntaxFactory.SeparatedList(nodes);

            var collection = SyntaxFactory.AttributeList(attributes);

            //var attributes = new List<AttributeListSyntax>(collection);

            //var item = SyntaxFactory.AttributeList(nodes);
            //item.Attributes.Add(node);
            //attributes.Add(item);

            return null;
        }

        private static ParameterListSyntax GetAddParams(string name)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier($"Models.IUnkeyed{name}Model newItem"));
            parameters = parameters.Add(node);
            var addParams = SyntaxFactory.ParameterList(parameters);
            return addParams;
        }

        private static ParameterListSyntax GetDeleteParams()
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier("long id"));
            parameters = parameters.Add(node);
            var addParams = SyntaxFactory.ParameterList(parameters);
            return addParams;
        }

        private static ParameterListSyntax GetGetParams(string name)
        {
            var nodes = new[]
            {
                SyntaxFactory.Parameter(SyntaxFactory.Identifier($"long id")),
                SyntaxFactory.Parameter(SyntaxFactory.Identifier($"System.Linq.Expressions.Expression<Func<Models.I{name}Model, TResult>> selector"))
            };

            var parameters = SyntaxFactory.SeparatedList(nodes);

            var addParams = SyntaxFactory.ParameterList(parameters);
            return addParams;
        }

        private static ParameterListSyntax GetListParams(string name)
        {
            var nodes = new[]
            {
                SyntaxFactory.Parameter(SyntaxFactory.Identifier($"System.Linq.Expressions.Expression<Func<Models.I{name}Model, TResult>> selector"))
            };

            var parameters = SyntaxFactory.SeparatedList(nodes);

            var addParams = SyntaxFactory.ParameterList(parameters);
            return addParams;
        }

        private static ParameterListSyntax GetUpdateParams(string name)
        {
            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

            var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier($"Models.I{name}Model item"));
            parameters = parameters.Add(node);
            var addParams = SyntaxFactory.ParameterList(parameters);
            return addParams;
        }
    }
}
