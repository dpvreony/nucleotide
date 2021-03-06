﻿//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using CodeGeneration.Roslyn;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Validation;

//namespace Dhgms.Nucleotide.Features.Cqrs
//{
//    /// <summary>
//    /// Generator for Query Class
//    /// </summary>
//    public sealed class QueryClassGenerator : ICodeGenerator
//    {
//        /// <summary>
//        /// Initializes a new instance of the <see cref="QueryClassGenerator"/> class. 
//        /// </summary>
//        public QueryClassGenerator(AttributeData attributeData)
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
//            var nodes = new MemberDeclarationSyntax[]
//            {
//                SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("Queries"))
//                    .AddMembers(GetClasses())
//            };

//            var results = SyntaxFactory.List(nodes);

//            return await Task.FromResult(results);
//        }

//        private MemberDeclarationSyntax[] GetClasses()
//        {
//            return new MemberDeclarationSyntax[] { };
//        }
//    }
//}
