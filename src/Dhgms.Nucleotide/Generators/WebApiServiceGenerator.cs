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
    }
}
