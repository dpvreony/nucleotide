using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators;
using Dhgms.Nucleotide.Helpers;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Features.WebApi
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
        protected override PropertyDeclarationSyntax[] GetPropertyDeclarations(IEntityGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override string[] GetClassPrefixes() => null;

        protected override string GetClassSuffix()
        {
            return "Controller";
        }

        protected override string GetNamespace()
        {
            return "ApiControllers";
        }

        protected override IList<string> GetUsings()
        {
            return new List<string>
            {
                "System.Threading.Tasks",
                "Microsoft.Extensions.Logging",
                "Microsoft.AspNetCore.Authorization",
                "Microsoft.AspNetCore.Mvc"
            };
        }

        protected override bool GetWhetherClassShouldBePartialClass() => true;

        protected override bool GetWhetherClassShouldBeSealedClass() => true;

        /// <inheritdoc />
        protected override string GetBaseClass(string entityName) =>
            $"Dhgms.AspNetCoreContrib.Controllers.CrudController<{entityName}Controller, Queries.IList{entityName}Query, RequestDtos.List{entityName}RequestDto, ResponseDtos.List{entityName}ResponseDto, Queries.IView{entityName}Query, ResponseDtos.View{entityName}ResponseDto, Commands.IAdd{entityName}Command, RequestDtos.Add{entityName}RequestDto, ResponseDtos.Add{entityName}ResponseDto, Commands.IDelete{entityName}Command, ResponseDtos.Delete{entityName}ResponseDto, Commands.IUpdate{entityName}Command, RequestDtos.Update{entityName}RequestDto, ResponseDtos.Update{entityName}ResponseDto>";

        protected override IList<string> GetImplementedInterfaces(string entityName)
        {
            return null;

            /*
            return new List<string>
            {
                $"Services.I{entityName}Service"
            };
            */
        }

        /// <inheritdoc />
        protected override IList<Tuple<Func<string, string>, string, Accessibility>> GetConstructorArguments()
        {
            var result = new List<Tuple<Func<string, string>, string, Accessibility>>
            {
                new Tuple<Func<string, string>, string, Accessibility>(_ => "Microsoft.AspNetCore.Authorization.IAuthorizationService", "authorizationService", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"Microsoft.Extensions.Logging.ILogger<{entityName}Controller>", "logger", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"MediatR.IMediator", "mediator", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"CommandFactories.I{entityName}CommandFactory", "commandFactory", Accessibility.Private),
                new Tuple<Func<string, string>, string, Accessibility>(entityName => $"QueryFactories.I{entityName}QueryFactory", "queryFactory", Accessibility.Private),
            };

            return result;
        }

        protected override IList<string> GetBaseConstructorArguments()
        {
            var result = new List<string>
            {
                "authorizationService",
                "logger",
                "mediator",
                "commandFactory",
                "queryFactory",
            };

            return result;
        }

        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Web API Service for {entityName}"
            };
        }

        protected override string[] GetClassLevelCommentRemarks(string entityName)
        {
            return null;
        }

        protected override List<Tuple<string, IList<string>>> GetClassAttributes(IEntityGenerationModel entityDeclaration)
        {
            return new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Mvc.Route", new[]{ $"\"api/{entityDeclaration.ClassName.ToLower()}\"" })
            };
        }

        /// <inheritdoc />
        protected override MemberDeclarationSyntax[] GetMethodDeclarations(string entityName)
        {
            var result = new List<MemberDeclarationSyntax>
            {
                GetAddActionResultAsyncDeclaration(entityName),
                GetDeleteActionResultAsyncDeclaration(entityName),
                GetListActionResultAsyncDeclaration(entityName),
                GetUpdateActionResultAsyncDeclaration(entityName),
                GetViewActionResultAsyncDeclaration(entityName),
                //GetAddMethodDeclaration(entityName),
                //GetDeleteMethodDeclaration(entityName),
                //GetListMethodDeclaration(entityName),
                //GetUpdateMethodDeclaration(entityName),
                //GetViewMethodDeclaration(entityName),
                GetPolicyMethodDeclaration(entityName, "Add"),
                GetPolicyMethodDeclaration(entityName, "Delete"),
                GetPolicyMethodDeclaration(entityName, "List"),
                GetPolicyMethodDeclaration(entityName, "Update"),
                GetPolicyMethodDeclaration(entityName, "View"),
                GetEventIdMethodDeclaration(entityName, "Add"),
                GetEventIdMethodDeclaration(entityName, "Delete"),
                GetEventIdMethodDeclaration(entityName, "List"),
                GetEventIdMethodDeclaration(entityName, "Update"),
                GetEventIdMethodDeclaration(entityName, "View"),
            };


            return result.ToArray();
        }

        protected override SeparatedSyntaxList<AttributeSyntax> GetAttributesForProperty(PropertyInfoBase propertyInfo)
        {
            return default(SeparatedSyntaxList<AttributeSyntax>);
        }

        private MemberDeclarationSyntax GetPolicyMethodDeclaration(string entityName, string action)
        {
            var methodName = $"Get{action}PolicyAsync";

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression($"await Task.FromResult(\"Api.{entityName}.{action}\").ConfigureAwait(false)"));

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var returnType = SyntaxFactory.ParseTypeName("Task<string>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetAddActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "add");
        }

        private MemberDeclarationSyntax GetDeleteActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "delete");
        }

        private MemberDeclarationSyntax GetListActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "list");
        }

        private MemberDeclarationSyntax GetUpdateActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "update");
        }

        private MemberDeclarationSyntax GetViewActionResultAsyncDeclaration(string entityName)
        {
            return GetOkActionResultDeclaration(entityName, "view");
        }

        private MemberDeclarationSyntax GetOkActionResultDeclaration(string entityName, string action)
        {
            var camelAction = action.Substring(0, 1).ToUpper() + action.Substring(1);
            var lowerAction = action.Substring(0, 1).ToLower() + action.Substring(1);

            var methodName = $"Get{camelAction}ActionResultAsync";

            var baseMethodInvocationSyntax =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax("Ok", new [] {$"{lowerAction}Response"}, false);

            var taskFromResult =
                RoslynGenerationHelpers.GetStaticMethodInvocationSyntax("Task", "FromResult",
                    baseMethodInvocationSyntax, true);
            var returnStatement = SyntaxFactory.ReturnStatement(taskFromResult);

            var body = new StatementSyntax[]
            {
                returnStatement
            };

            var parameters = GetParams(new []{ $"ResponseDtos.{camelAction}{entityName}ResponseDto {lowerAction}Response"});

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.ProtectedKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword), SyntaxFactory.Token(SyntaxKind.OverrideKeyword))
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetAddMethodDeclaration(string entityName)
        {
            var methodName = "AddAsync";

            var eventId = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("eventId", "GetAddEventId", true);

            var logMethodEntryArgs = new[]
            {
                $"eventId",
                $"\"Entered {methodName}\""
            };

            var logMethodEntryInvocation = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax(
                "_logger",
                "LogDebug",
                logMethodEntryArgs,
                false);


            var catchDeclaration = SyntaxFactory.CatchDeclaration(SyntaxFactory.IdentifierName("Exception"),
                    SyntaxFactory.Identifier("ex"));

            var loggerExceptionArgs = new[]
            {
                $"eventId",
                "ex",
                $"\"Exception in On{methodName}\"",
            };
            var exceptionLoggingInvocation = RoslynGenerationHelpers.GetMethodOnFieldInvocationSyntax(
                "_logger",
                "LogWarning",
                loggerExceptionArgs,
                false);
            var rethrow = SyntaxFactory.ThrowStatement();
            var catchBlockStatements = new []
            {
                exceptionLoggingInvocation,
                rethrow
            };

            var catchBlock = SyntaxFactory.Block(catchBlockStatements);
            var catchClause = SyntaxFactory.CatchClause(catchDeclaration, null, catchBlock);

            var baseMethodInvocationSyntax =
                RoslynGenerationHelpers.GetMethodOnClassInvocationSyntax("OnAddAsync", new [] {"requestDto"}, true);
            var returnStatement = SyntaxFactory.ReturnStatement(baseMethodInvocationSyntax);

            var tryOnAddAsync = SyntaxFactory.TryStatement(SyntaxFactory.Block(returnStatement), new SyntaxList<CatchClauseSyntax>().Add(catchClause), null);

            var body = new []
            {
                eventId,
                logMethodEntryInvocation,
                tryOnAddAsync
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpPost", null),
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ "typeof(int)"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", "Type = typeof(int)"})
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new []{ $"Models.Unkeyed{entityName}Model requestDto"});

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, methodName)
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetDeleteMethodDeclaration(string entityName)
        {
            var userLocalDeclaration =
                RoslynGenerationHelpers
                    .GetVariableAssignmentFromVariablePropertyAccessSyntax("user", "HttpContext", "User");
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetDeleteCommandAsync", null, true);
            var arguments = new[]
            {
                "id",
                "user"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync", arguments);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[]
            {
                userLocalDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpDelete", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Delete\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[] { $"int id" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "DeleteAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetListMethodDeclaration(string entityName)
        {
            var userLocalDeclaration =
                RoslynGenerationHelpers
                    .GetVariableAssignmentFromVariablePropertyAccessSyntax("user", "HttpContext", "User");
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetListQueryAsync", null, true);
            var arguments = new[]
            {
                "requestDto",
                "user"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query", "ExecuteAsync", arguments);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[]
            {
                userLocalDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpGet", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_List\""}),
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ $"typeof(Models.{entityName}Model[])"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", $"Type = typeof(Models.{entityName}Model[])"}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            //var parameters = GetParams(new[] { $"RequestDtos.List{entityName}RequestDto requestDto" });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ListAsync")
                //.WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetUpdateMethodDeclaration(string entityName)
        {
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("command", "_commandFactory", "GetUpdateCommandAsync", null, true);
            var arguments = new[]
            {
                "requestDto"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "command", "ExecuteAsync", arguments);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            var body = new StatementSyntax[] { commandLocalDeclaration, commandExecutionDeclaration, returnStatement };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpPatch", null),
                new Tuple<string, IList<string>>("Microsoft.AspNetCore.Authorization.Authorize", new List<string> { $"Roles=\"API_{entityName}_Update\""}),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[]
            {
                $"RequestDtos.Update{entityName}RequestDto requestDto"
            });
            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "UpdateAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }

        private MemberDeclarationSyntax GetViewMethodDeclaration(string entityName)
        {
            var entityIdVariableName = "id";
            const string notFoundResult = "new Microsoft.AspNetCore.Mvc.NotFoundResult()";
            var numberTooLowCheckDeclaration =
                RoslynGenerationHelpers.GetReturnIfLessThanSyntax(entityIdVariableName, 1, notFoundResult);
            var commandLocalDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromMethodOnFieldSyntax("query", "_queryFactory", "GetViewQueryAsync", null, true);

            var arguments = new[]
            {
                "id"
            };
            var commandExecutionDeclaration = RoslynGenerationHelpers.GetVariableAssignmentFromVariableInvocationSyntax("result", "query", "Execute", arguments);
            var nullQueryResultCheckDeclaration = RoslynGenerationHelpers.GetReturnIfNullSyntax("result", notFoundResult);
            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("result"));

            // todo: https://github.com/blowdart/AspNetAuthorizationWorkshop/blob/master/src/Step_7_Resource_Based_Requirements/Controllers/DocumentController.cs

            var body = new []
            {
                numberTooLowCheckDeclaration,
                commandLocalDeclaration,
                commandExecutionDeclaration,
                nullQueryResultCheckDeclaration,
                returnStatement
            };

            var attributes = new List<Tuple<string, IList<string>>>
            {
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.HttpGet", null),
                new Tuple<string, IList<string>>("Microsoft​.AspNetCore​.Mvc.Produces", new List<string>{ $"typeof(Models.{entityName}Model)"}),
                new Tuple<string, IList<string>>("Swashbuckle.AspNetCore.SwaggerGen.SwaggerResponse", new List<string>{ "200", $"Type = typeof(Models.{entityName}Model)" }),
            };

            var attributeListSyntax = GetAttributeListSyntax(attributes);

            var parameters = GetParams(new[]
            {
                "int id"
            });

            var returnType = SyntaxFactory.ParseTypeName("System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult>");
            var declaration = SyntaxFactory.MethodDeclaration(returnType, "ViewAsync")
                .WithParameterList(parameters)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.AsyncKeyword))
                .AddAttributeLists(attributeListSyntax)
                .AddBodyStatements(body);
            return declaration;
        }
    }
}
