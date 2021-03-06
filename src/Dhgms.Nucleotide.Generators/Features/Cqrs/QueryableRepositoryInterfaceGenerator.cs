﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using CodeGeneration.Roslyn;
//using Dhgms.Nucleotide.Attributes;
//using Dhgms.Nucleotide.Model;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Validation;

//namespace Dhgms.Nucleotide.Features.Cqrs
//{
//    /// <summary>
//    /// Code Generator for Repository Interface that supports Filtering via IQueryable selectors
//    /// </summary>
//    public sealed class QueryableRepositoryInterfaceGenerator : ICodeGenerator
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="QueryableRepositoryInterfaceGenerator"/> class. 
//        /// </summary>
//        public QueryableRepositoryInterfaceGenerator(AttributeData attributeData)
//        {
//            Requires.NotNull(attributeData, nameof(attributeData));
//        }

//        /// <summary>
//        /// Create the syntax tree representing the expansion of some member to which this attribute is applied.
//        /// </summary>
//        /// <param name="context">The transformation context being generated for.</param>
//        /// <param name="progress">A way to report diagnostic messages.</param>
//        /// <param name="cancellationToken">A cancellation token.</param>
//        /// <returns>The generated member syntax to be added to the project.</returns>
//        public async Task<SyntaxList<MemberDeclarationSyntax>> GenerateAsync(
//            TransformationContext context,
//            IProgress<Diagnostic> progress,
//            CancellationToken cancellationToken)
//        {
//            var applyTo = context.ProcessingMember;

//            var namespaceDetails = GetNamespaceDetails(applyTo);
//            var comments = namespaceDetails.Item1;
//            var members = namespaceDetails.Item2;

//            var namespaceDeclaration = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("Repositories"));

//            if (comments != null && comments.Length > 0)
//            {
//                var leadingTrivia = comments.Select(SyntaxFactory.Comment);

//                namespaceDeclaration = namespaceDeclaration.WithLeadingTrivia(leadingTrivia);
//            }

//            if (members != null && members.Length > 0)
//            {
//                namespaceDeclaration = namespaceDeclaration.AddMembers(members);
//            }

//            var nodes = new List<MemberDeclarationSyntax> {namespaceDeclaration};
//            var results = SyntaxFactory.List(nodes);

//            return await Task.FromResult(results);
//        }

//        private Tuple<string[], MemberDeclarationSyntax[]> GetNamespaceDetails(MemberDeclarationSyntax applyTo)
//        {
//            if (applyTo == null)
//            {
//                var comments = new[]
//                {
//                    "#error Failed to work out what the attribute is attached to."
//                };

//                return new Tuple<string[], MemberDeclarationSyntax[]>(comments, null);
//            }

//            var classDeclaration = applyTo as ClassDeclarationSyntax;
//            if (classDeclaration == null)
//            {
//                var comments = new[]
//                {
//                    $"#error The attribute for {nameof(GenerateQueryableRepositoryInterfaceAttribute)} must be placed on a ClassDeclaration. Detected type : {applyTo.Kind()}"
//                };

//                return new Tuple<string[], MemberDeclarationSyntax[]>(comments, null);
//            }

//            var typeToCreate = classDeclaration.Identifier.ValueText;
//            var t = Type.GetType(classDeclaration.Identifier.ValueText);

//            //Compilation.GetTypeByMetadataName()
//            INucleotideGenerationModel instance = null;
//            try
//            {
//                instance = Activator.CreateInstance(t) as INucleotideGenerationModel;
//            }
//            catch
//            {
//                // ignored
//            }

//            //var baselist = entityDeclaration.BaseList;
//            //var baseTypes = baselist.Types;
//            //if (baseTypes.All(bt => bt.GetType() != typeof(INucleotideGenerationModel)))
//            if (instance == null)
//            {
//                var comments = new[]
//                {
//                    $"#error The attribute for {nameof(GenerateQueryableRepositoryInterfaceAttribute)} must be placed on a Class that inherits from {typeof(INucleotideGenerationModel).FullName} Found: {typeToCreate}."
//                };

//                return new Tuple<string[], MemberDeclarationSyntax[]>(comments, null);
//            }

//            var classes = instance.EntityGenerationModel;
//            var members = GetInterfaces(/*classes*/);

//            /*
//            var properties = entityDeclaration.Members.OfType<PropertyDeclarationSyntax>();
//            var classGenCollection = properties.FirstOrDefault(
//                p =>
//                    p.Identifier.Text.Equals(nameof(INucleotideGenerationModel.EntityGenerationModel),
//                        StringComparison.Ordinal));

//            if (classGenCollection == null)
//            {
//                var comments = new[]
//                {
//                    $"#error Unable to find property {nameof(INucleotideGenerationModel.EntityGenerationModel)}."
//                };

//                return new Tuple<string[], MemberDeclarationSyntax[]>(comments, null);
//            }
//            */

//            //var members = GetInterfaces();
//            return new Tuple<string[], MemberDeclarationSyntax[]>(null, members);
//        }

//        private MemberDeclarationSyntax[] GetInterfaces()
//        {
//            // TODO: get list of class generation parameters from source class

//            var name = "Test";

//            return new MemberDeclarationSyntax[]
//            {
//                SyntaxFactory.InterfaceDeclaration($"I{name}Repository")
//                    .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
//                    .AddMembers(GetInterfaceMembers(name))
//            };
//        }

//        private MemberDeclarationSyntax[] GetInterfaceMembers(string name)
//        {
//            return GetInterfaceMethods(name);
//        }

//        private MemberDeclarationSyntax[] GetInterfaceMethods(string name)
//        {
//            var result = new List<MemberDeclarationSyntax>();

//            GetAddMethod(result, name);
//            GetDeleteMethod(result, name);
//            GetDeleteManyMethod(result, name);
//            GetGetMethod(result, name);
//            GetListMethod(result, name);
//            GetUpdateMethod(result, name);
//            GetUpdateManyMethod(result, name);

//            return result.ToArray();
//        }

//        private void GetAddMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Adds an {name} item to the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
//            };

//            var parameterListSyntax = GetAddParams(name);

//            var methods = parameterListSyntax.Select(GetParams)
//                .Select(actualParams => GetMethod($"Add{name}Async", "Task<long>", leadingTrivia, actualParams, null));
//            result.AddRange(methods);
//        }

//        private void GetDeleteMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Deletes the {name} item with the specified id from the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Asynchronous Task.</returns>")
//            };

//            var parameterListSyntax = GetDeleteParams();

//            var methods = parameterListSyntax.Select(GetParams)
//                .Select(actualParams => GetMethod($"Delete{name}Async", "Task", leadingTrivia, actualParams, null));
//            result.AddRange(methods);
//        }

//        private void GetDeleteManyMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Deletes many {name} item with the specified ids from the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Asynchronous Task.</returns>")
//            };

//            var parameterListSyntax = GetDeleteManyParams(name);

//            var methods = parameterListSyntax.Select(GetParams)
//                .Select(actualParams => GetMethod($"DeleteMany{name}Async", "Task", leadingTrivia, actualParams, null));
//            result.AddRange(methods);
//        }

//        private void GetGetMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Adds an {name} item to the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
//            };

//            var getParams = GetGetParams(name);
//            var getTypeParameters = GetGetTypeParameters();

//            var methods = getParams.Select(GetParams)
//                .Select(actualParams => GetMethod($"Get{name}Async", "Task", leadingTrivia, actualParams, getTypeParameters));
//            result.AddRange(methods);
//        }

//        private void GetListMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Adds a {name} item to the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Unique Id of the item added.</returns>")
//            };

//            //var listConstraintClauses = GetListConstraintClauses();
//            var listTypeParameters = GetListTypeParameters();

//            var listParams = GetListParams(name);

//            var methods = listParams.Select(GetParams)
//                .Select(actualParams => GetMethod($"List{name}Async", "Task<IEnumerable<TResult>>", leadingTrivia, actualParams, listTypeParameters));
//            result.AddRange(methods);
//        }

//        private void GetUpdateMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Updates the {name} item in the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>The ${name} item.</returns>")
//            };

//            var updateParams = GetUpdateParams(name);

//            var methods = updateParams.Select(GetParams)
//                .Select(actualParams => GetMethod($"UpdateMany{name}Async", "Task", leadingTrivia, actualParams, null));
//            result.AddRange(methods);
//        }

//        private void GetUpdateManyMethod(List<MemberDeclarationSyntax> result, string name)
//        {
//            var leadingTrivia = new[]
//            {
//                SyntaxFactory.Comment($"/// <summary>Updates a collection of {name} items in the repository.</summary>"),
//                SyntaxFactory.Comment("/// <returns>Asynchronous Task.</returns>")
//            };

//            var updateParams = GetUpdateManyParams(name);

//            var methods = updateParams.Select(GetParams)
//                .Select(actualParams => GetMethod($"UpdateMany{name}Async", "Task", leadingTrivia, actualParams, null));
//            result.AddRange(methods);
//        }

//        private static MemberDeclarationSyntax GetMethod(string methodName, string returnType, SyntaxTrivia[] leadingTrivia, ParameterListSyntax parameterListSyntax, TypeParameterListSyntax typeParameterListSyntax)
//        {
//            var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(returnType), methodName);

//            if (parameterListSyntax != null &&
//                parameterListSyntax.Parameters.Count > 0)
//            {
//                method = method.WithParameterList(parameterListSyntax);
//            }

//            if (typeParameterListSyntax != null &&
//                typeParameterListSyntax.Parameters.Count > 0)
//            {
//                method = method.WithTypeParameterList(typeParameterListSyntax);
//            }

//            method = method.WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
//            method = method.WithLeadingTrivia(leadingTrivia);
//            return method;
//        }

//        private TypeParameterListSyntax GetGetTypeParameters()
//        {
//            return GetTypeParameters("TResult");
//        }

//        private TypeParameterListSyntax GetListTypeParameters()
//        {
//            return GetTypeParameters("TResult");
//        }

//        private TypeParameterListSyntax GetTypeParameters(params string[] identifiers)
//        {
//            var nodes = identifiers.Select(SyntaxFactory.TypeParameter);

//            var parameters = SyntaxFactory.SeparatedList(nodes);
//            var typeParameters = SyntaxFactory.TypeParameterList(parameters);

//            return typeParameters;
//        }

//        private SyntaxList<TypeParameterConstraintClauseSyntax> GetListConstraintClauses()
//        {
//            var constraintClauses = SyntaxFactory.List<TypeParameterConstraintClauseSyntax>();

//            return constraintClauses;
//        }

//        private AttributeListSyntax GetListAttributes()
//        {
//            var nodes = new AttributeSyntax[]
//            {
//                //SyntaxFactory.Attribute(SyntaxFactory.GenericName("Test"))
//            };

//            var attributes = SyntaxFactory.SeparatedList(nodes);

//            var collection = SyntaxFactory.AttributeList(attributes);

//            //var attributes = new List<AttributeListSyntax>(collection);

//            //var item = SyntaxFactory.AttributeList(nodes);
//            //item.Attributes.Add(node);
//            //attributes.Add(item);

//            return null;
//        }

//        private static IEnumerable<string[]> GetAddParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        $"Models.IUnkeyed{name}Model newItem"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetDeleteParams()
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        "long id"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetDeleteManyParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        "IEnumerable<long> ids"
//                    },
//                new []
//                    {
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, bool>> predicate"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetGetParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        "long id",
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, TResult>> selector"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetListParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, TResult>> selector"
//                    },
//                new []
//                    {
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, bool>> predicate",
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, TResult>> selector"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetUpdateParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        $"long id",
//                        $"System.Linq.Expressions.Expression<Action<Models.IUnkeyed{name}Model>> updateAction"
//                    }
//            };

//            return args;
//        }

//        private static IEnumerable<string[]> GetUpdateManyParams(string name)
//        {
//            var args = new[]
//            {
//                new []
//                    {
//                        $"IEnumerable<long> ids",
//                        $"System.Linq.Expressions.Expression<Action<Models.IUnkeyed{name}Model>> updateAction"
//                    },
//                new []
//                    {
//                        $"System.Linq.Expressions.Expression<Func<Models.I{name}Model, bool>> predicate",
//                        $"System.Linq.Expressions.Expression<Action<Models.IUnkeyed{name}Model>> updateAction"
//                    },
//            };

//            return args;
//        }

//        private static ParameterListSyntax GetParams(string[] argCollection)
//        {
//            var parameters = SyntaxFactory.SeparatedList<ParameterSyntax>();

//            foreach (var s in argCollection)
//            {
//                var node = SyntaxFactory.Parameter(SyntaxFactory.Identifier(s));
//                parameters = parameters.Add(node);
//            }

//            return SyntaxFactory.ParameterList(parameters);
//        }
//    }
//}
