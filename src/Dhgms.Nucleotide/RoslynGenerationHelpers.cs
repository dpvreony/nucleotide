using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Helpers
{
    /// <summary>
    /// Helpers for generating roslyn expression sytax
    /// </summary>
    public static class RoslynGenerationHelpers
    {
        public static AttributeArgumentListSyntax GetAttributeArgumentListSyntax(IList<string> attributeArguments)
        {
            if (attributeArguments == null || attributeArguments.Count < 1)
            {
                return null;
            }

            var argumentList = SyntaxFactory.AttributeArgumentList();

            foreach (var attributeArgument in attributeArguments)
            {
                var name = SyntaxFactory.ParseName(attributeArgument);
                var attribArgSyntax = SyntaxFactory.AttributeArgument(name);
                argumentList = argumentList.AddArguments(attribArgSyntax);
            }

            return argumentList;
        }


        /// <summary>
        /// Produces the Invocation Syntax for using the nameof operator
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static InvocationExpressionSyntax GetNameOfInvocationSyntax(string parameterName)
        {
            var nameOfIdentifier = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("nameof"));
            var nameOfArgumentList = new SeparatedSyntaxList<ArgumentSyntax>();
            nameOfArgumentList = nameOfArgumentList.Add(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(parameterName))));
            return SyntaxFactory.InvocationExpression(nameOfIdentifier, SyntaxFactory.ArgumentList(nameOfArgumentList));
        }

        /// <summary>
        /// Produces the Throw Statement Syntax for an ArgumentNullException
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static ThrowStatementSyntax GetThrowArgumentNullExceptionSyntax(string parameterName)
        {
            var nameOfInvocation = GetNameOfInvocationSyntax(parameterName);

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            argsList = argsList.Add(SyntaxFactory.Argument(nameOfInvocation));

            var objectCreationEx = SyntaxFactory.ObjectCreationExpression(
                SyntaxFactory.ParseTypeName(nameof(ArgumentNullException)),
                SyntaxFactory.ArgumentList(argsList),
                null);

            return SyntaxFactory.ThrowStatement(objectCreationEx);
        }

        /// <summary>
        /// Produces the Throw Statement Syntax for an NotImplementedException
        /// </summary>
        /// <returns>Roslyn syntax</returns>
        public static ThrowStatementSyntax GetThrowNotImplementedExceptionSyntax()
        {
            var objectCreationEx = SyntaxFactory.ObjectCreationExpression(
                SyntaxFactory.ParseTypeName(nameof(NotImplementedException)),
                SyntaxFactory.ArgumentList(),
                null);

            return SyntaxFactory.ThrowStatement(objectCreationEx);
        }

        /// <summary>
        /// Produces a null guard check for a parameter
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static IfStatementSyntax GetNullGuardCheckSyntax(string parameterName)
        {
            var parameterIdentifier = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(parameterName));
            var condition = SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, parameterIdentifier,
                SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));

            var throwStatement =
                RoslynGenerationHelpers.GetThrowArgumentNullExceptionSyntax(parameterName);
            return SyntaxFactory.IfStatement(condition, throwStatement);
        }

        /// <summary>
        /// Produces syntax for creating a variable and assigning from executing a method on a field
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static LocalDeclarationStatementSyntax GetVariableAssignmentFromMethodOnFieldSyntax(string variableName, string fieldName, string methodName, string[] args, bool isAsync)
        {
            var fieldMemberAccess = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  SyntaxFactory.IdentifierName("this"),
                  name: SyntaxFactory.IdentifierName(fieldName));

            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  fieldMemberAccess,
                  name: SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {
                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            ExpressionSyntax getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));
            getCommandInvocation = GetAwaitedExpressionSyntax(true, getCommandInvocation);

            var equalsValueClause = SyntaxFactory.EqualsValueClause(
                SyntaxFactory.Token(SyntaxKind.EqualsToken),
                getCommandInvocation);
            var variableSyntax = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
            variableSyntax = variableSyntax.Add(SyntaxFactory.VariableDeclarator(variableName).WithInitializer(equalsValueClause));
            var variableDeclaration =
                SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("var")), variableSyntax);
            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
        }

        /// <summary>
        /// Produces syntax for creating a variable and assigning from executing a method on a field
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static LocalDeclarationStatementSyntax GetVariableAssignmentFromVariablePropertyAccessSyntax(
            string variableName,
            string fieldName,
            string propertyName)
        {
            var fieldMemberAccess = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName("this"),
                name: SyntaxFactory.IdentifierName(fieldName));

            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                fieldMemberAccess,
                name: SyntaxFactory.IdentifierName(propertyName));
            //var getCommandInvocation = SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, getAddCommandInvocation,) .InvocationExpression(getAddCommandInvocation);

            var equalsValueClause = SyntaxFactory.EqualsValueClause(
                SyntaxFactory.Token(SyntaxKind.EqualsToken),
                getAddCommandInvocation);
            var variableSyntax = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
            variableSyntax = variableSyntax.Add(SyntaxFactory.VariableDeclarator(variableName).WithInitializer(equalsValueClause));
            var variableDeclaration =
                SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("var")), variableSyntax);
            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
        }

        /// <summary>
        /// Produces a null guard check for a parameter
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static IfStatementSyntax GetReturnIfNullSyntax(string parameterName, string returnName)
        {
            var parameterIdentifier = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(parameterName));
            var condition = SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, parameterIdentifier,
                SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression(returnName));
            return SyntaxFactory.IfStatement(condition, returnStatement);
        }

        /// <summary>
        /// Produces a false check for a parameter
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static IfStatementSyntax GetReturnIfFalseSyntax(string parameterName, string returnName)
        {
            var parameterIdentifier = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(parameterName));
            var condition = SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, parameterIdentifier);
            //var condition = SyntaxFactory.ParseExpression(parameterName);

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression(returnName));
            return SyntaxFactory.IfStatement(condition, returnStatement);
        }

        /// <summary>
        /// Produces a null guard check for a parameter
        /// </summary>
        /// <param name="parameterName">parameter name</param>
        /// <returns>Roslyn syntax</returns>
        public static IfStatementSyntax GetReturnIfLessThanSyntax(string parameterName, int minimumValue, string returnName)
        {
            var parameterIdentifier = SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(parameterName));
            var condition = SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression, parameterIdentifier,
                SyntaxFactory.ParseExpression(minimumValue.ToString()));

            var returnStatement = SyntaxFactory.ReturnStatement(SyntaxFactory.ParseExpression(returnName));
            return SyntaxFactory.IfStatement(condition, returnStatement);
        }

        /// <summary>
        /// Gets syntax to create and assign a variable from invoking another variable
        /// </summary>
        /// <param name="variableToCreate"></param>
        /// <param name="variableToInvoke"></param>
        /// <returns></returns>
        public static StatementSyntax GetVariableAssignmentFromVariableInvocationSyntax(string variableToCreate, string variableToInvoke, bool isAsync)
        {
            ExpressionSyntax getCommandInvocation = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName(variableToInvoke));

            getCommandInvocation = GetAwaitedExpressionSyntax(isAsync, getCommandInvocation);

            var equalsValueClause = SyntaxFactory.EqualsValueClause(
                SyntaxFactory.Token(SyntaxKind.EqualsToken),
                getCommandInvocation);
            var variableSyntax = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
            variableSyntax = variableSyntax.Add(SyntaxFactory.VariableDeclarator(variableToCreate).WithInitializer(equalsValueClause));
            var variableDeclaration =
                SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("var")), variableSyntax);
            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
        }

        private static ExpressionSyntax GetAwaitedExpressionSyntax(bool isAsync, ExpressionSyntax getCommandInvocation)
        {
            if (isAsync)
            {
                var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    getCommandInvocation,
                    name: SyntaxFactory.IdentifierName("ConfigureAwait"));

                var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
                configureAwaitArgsList =
                    configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
                getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression,
                    SyntaxFactory.ArgumentList(configureAwaitArgsList));

                getCommandInvocation = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                    getCommandInvocation);
            }
            return getCommandInvocation;
        }

        /// <summary>
        /// Gets syntax to create and assign a variable from invoking another variable
        /// </summary>
        /// <param name="variableToCreate"></param>
        /// <param name="variableToReference"></param>
        /// <param name="methodToInvoke"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static StatementSyntax GetVariableAssignmentFromVariableInvocationSyntax(
            string variableToCreate,
            string variableToReference,
            string methodToInvoke,
            string[] arguments)
        {
            var fieldMemberAccess = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName(variableToReference),
                SyntaxFactory.IdentifierName(methodToInvoke));

            var argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (arguments != null && arguments.Length > 0)
            {

                foreach (var s in arguments)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var argListSyntax = SyntaxFactory.ArgumentList(argsList);

            ExpressionSyntax getCommandInvocation = SyntaxFactory.InvocationExpression(fieldMemberAccess, argListSyntax);

            getCommandInvocation = GetAwaitedExpressionSyntax(true, getCommandInvocation);

            var equalsValueClause = SyntaxFactory.EqualsValueClause(
                SyntaxFactory.Token(SyntaxKind.EqualsToken),
                getCommandInvocation);
            var variableSyntax = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
            variableSyntax = variableSyntax.Add(SyntaxFactory.VariableDeclarator(variableToCreate).WithInitializer(equalsValueClause));
            var variableDeclaration =
                SyntaxFactory.VariableDeclaration(SyntaxFactory.IdentifierName(SyntaxFactory.Identifier("var")), variableSyntax);
            return SyntaxFactory.LocalDeclarationStatement(variableDeclaration);
        }

        /// <summary>
        /// Gets the syntax for invoking a method on a field and passing in a value
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ExpressionSyntax GetMethodOnClassInvocationSyntax(string methodName, string[] args, bool isAsync)
        {
            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName("this"),
                name: SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return getCommandInvocation;
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return awaitCommand;
        }

        public static ExpressionSyntax GetStaticMethodInvocationSyntax(
            string className,
            string methodName,
            ExpressionSyntax nestedSyntax,
            bool isAsync)
        {
            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName(className),
                name: SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            argsList = argsList.Add(SyntaxFactory.Argument(nestedSyntax));

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return getCommandInvocation;
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return awaitCommand;
        }

        /// <summary>
        /// Gets the syntax for invoking a method on a field and passing in a value
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static ExpressionSyntax GetStaticMethodInvocationSyntax(string className, string methodName, string[] args, bool isAsync)
        {
            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName(className),
                name: SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return getCommandInvocation;
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return awaitCommand;
        }

        /// <summary>
        /// Gets the syntax for invoking a method on a field and passing in a value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static StatementSyntax GetMethodOnFieldInvocationSyntax(string fieldName, string methodName, string[] args, bool isAsync)
        {
            var fieldMemberAccess = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  SyntaxFactory.IdentifierName("this"),
                  name: SyntaxFactory.IdentifierName(fieldName));

            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  fieldMemberAccess,
                  name: SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return SyntaxFactory.ExpressionStatement(getCommandInvocation);
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return SyntaxFactory.ExpressionStatement(awaitCommand);
        }

        /// <summary>
        /// Gets the syntax for invoking a method on a field and passing in a value
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static StatementSyntax GetMethodOnVariableInvocationSyntax(string variableName, string methodName, string[] args, bool isAsync)
        {
            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  SyntaxFactory.IdentifierName(variableName),
                  SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return SyntaxFactory.ExpressionStatement(getCommandInvocation);
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return SyntaxFactory.ExpressionStatement(awaitCommand);
        }

        public static ExpressionSyntax GetMethodOnVariableInvocationExpression(string variableName, string methodName, string[] args, bool isAsync)
        {
            var getAddCommandInvocation = SyntaxFactory.MemberAccessExpression(
                  SyntaxKind.SimpleMemberAccessExpression,
                  SyntaxFactory.IdentifierName(variableName),
                  SyntaxFactory.IdentifierName(methodName));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var getCommandInvocation = SyntaxFactory.InvocationExpression(getAddCommandInvocation, SyntaxFactory.ArgumentList(argsList));


            if (!isAsync)
            {
                //var configureAwaitInvocation = SyntaxFactory.MemberAccessExpression()
                //getAddCommandInvocation.WithExpression()

                return getCommandInvocation;
            }

            var configureAwaitMemberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getCommandInvocation,
                name: SyntaxFactory.IdentifierName("ConfigureAwait"));

            var configureAwaitArgsList = new SeparatedSyntaxList<ArgumentSyntax>();
            configureAwaitArgsList =
                configureAwaitArgsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseExpression("false")));
            getCommandInvocation = SyntaxFactory.InvocationExpression(configureAwaitMemberAccessExpression, SyntaxFactory.ArgumentList(configureAwaitArgsList));

            var awaitCommand = SyntaxFactory.AwaitExpression(SyntaxFactory.Token(SyntaxKind.AwaitKeyword),
                getCommandInvocation);
            return awaitCommand;
        }

        public static InvocationExpressionSyntax GetFluentApiChainedInvocationExpression(ExpressionSyntax fluentApiInvocation, string name, string[] args)
        {
            var memberAccessExpression = SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                fluentApiInvocation,
                SyntaxFactory.IdentifierName(name));

            SeparatedSyntaxList<ArgumentSyntax> argsList = new SeparatedSyntaxList<ArgumentSyntax>();
            if (args != null && args.Length > 0)
            {

                foreach (var s in args)
                {
                    argsList = argsList.Add(SyntaxFactory.Argument(SyntaxFactory.ParseName(s)));
                }
            }

            var invocationExpression = SyntaxFactory.InvocationExpression(memberAccessExpression, SyntaxFactory.ArgumentList(argsList));

            return invocationExpression;
        }
    }
}
