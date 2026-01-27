// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.PropertyInfo
{
    /// <summary>
    /// base class for property information types. used for defining properties
    /// in information, search filter and view filter classes
    /// </summary>
    public abstract class PropertyInfoBase
    {
        /// <summary>
        /// The data type for the property.
        /// </summary>
        private readonly Type dataType;

        /// <summary>
        /// List of .NET keywords
        /// </summary>
        private readonly string[] keywords =
            {
                // C#
                "abstract",
                "event",
                "new",
                "struct",
                "as",
                "explicit",
                "null",
                "switch",
                "base",
                "extern",
                "object",
                "this",
                "bool",
                "false",
                "operator",
                "throw",
                "break",
                "finally",
                "out",
                "true",
                "byte",
                "fixed",
                "override",
                "try",
                "case",
                "float",
                "params",
                "typeof",
                "catch",
                "for",
                "private",
                "uint",
                "char",
                "foreach",
                "protected",
                "ulong",
                "checked",
                "goto",
                "public",
                "unchecked",
                "class",
                "if",
                "readonly",
                "unsafe",
                "const",
                "implicit",
                "ref",
                "ushort",
                "continue",
                "in",
                "return",
                "using",
                "decimal",
                "int",
                "sbyte",
                "virtual",
                "default",
                "interface",
                "sealed",
                "volatile",
                "delegate",
                "internal",
                "short",
                "void",
                "do",
                "is",
                "sizeof",
                "while",
                "double",
                "lock",
                "stackalloc",
                "else",
                "long",
                "static",
                "enum",
                "namespace",
                "string",

                // VB
                "AddHandler",
                "AddressOf",
                "Alias",
                "And",
                "Ansi",
                "As",
                "Assembly",
                "Auto",
                "Base",
                "Boolean",
                "ByRef",
                "Byte",
                "ByVal",
                "Call",
                "Case",
                "Catch",
                "CBool",
                "CByte",
                "CChar",
                "CDate",
                "CDec",
                "CDbl",
                "Char",
                "CInt",
                "Class",
                "CLng",
                "CObj",
                "Const",
                "CShort",
                "CSng",
                "CStr",
                "CType",
                "Date",
                "Decimal",
                "Declare",
                "Default",
                "Delegate",
                "Dim",
                "Do",
                "Double",
                "Each",
                "Else",
                "ElseIf",
                "End",
                "Enum",
                "Erase",
                "Error",
                "Event",
                "Exit",
                "ExternalSource",
                "False",
                "Finalize",
                "Finally",
                "Float",
                "For",
                "Friend",
                "Function",
                "Get",
                "GetType",
                "Goto",
                "Handles",
                "If",
                "Implements",
                "Imports",
                "In",
                "Inherits",
                "Integer",
                "Interface",
                "Is",
                "Let",
                "Lib",
                "Like",
                "Long",
                "Loop",
                "Me",
                "Mod",
                "Module",
                "MustInherit",
                "MustOverride",
                "MyBase",
                "MyClass",
                "Namespace",
                "New",
                "Next",
                "Not",
                "Nothing",
                "NotInheritable",
                "NotOverridable",
                "Object",
                "On",
                "Option",
                "Optional",
                "Or",
                "Overloads",
                "Overridable",
                "Overrides",
                "ParamArray",
                "Preserve",
                "Private",
                "Property",
                "Protected",
                "Public",
                "RaiseEvent",
                "ReadOnly",
                "ReDim",
                "Region",
                "REM",
                "RemoveHandler",
                "Resume",
                "Return",
                "Select",
                "Set",
                "Shadows",
                "Shared",
                "Short",
                "Single",
                "Static",
                "Step",
                "Stop",
                "String",
                "Structure",
                "Sub",
                "SyncLock",
                "Then",
                "Throw",
                "To",
                "True",
                "Try",
                "TypeOf",
                "Unicode",
                "Until",
                "volatile",
                "When",
                "While",
                "With",
                "WithEvents",
                "WriteOnly",
                "Xor",
                "eval",
                "extends",
                "instanceof",
                "package",
                "var",

                // C++
                "__abstract",
                "__alignof",
                "__asm",
                "__assume",
                "__based",
                "__box",
                "__cdecl",
                "__declspec",
                "__delegate",
                "__event",
                "__except",
                "__fastcall",
                "__finally",
                "__forceinline",
                "__gc",
                "__hook",
                "__identifier",
                "__if_exists",
                "__if_not_exists",
                "__inline",
                "__int16",
                "__int32",
                "__int64",
                "__int8",
                "__interface",
                "__leave",
                "__m128",
                "__m128d",
                "__m128i",
                "__m64",
                "__multiple_inheritance",
                "__nogc",
                "__noop",
                "__pin",
                "__property",
                "__raise",
                "__sealed",
                "__single_inheritance",
                "__stdcall",
                "__super",
                "__thiscall",
                "__try",
                "__except",
                "__finally",
                "__try_cast",
                "__unaligned",
                "__unhook",
                "__uuidof",
                "__value",
                "__virtual_inheritance",
                "__w64",
                "__wchar_t",
                "wchar_t",
                "abstract",
                "array",
                "auto",
                "bool",
                "break",
                "case",
                "catch",
                "char",
                "class",
                "const",
                "const_cast",
                "continue",
                "decltype",
                "default",
                "delegate",
                "delete",
                "deprecated",
                "dllexport",
                "dllimport",
                "do",
                "double",
                "dynamic_cast",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "float",
                "for",
                "each",
                "in",
                "friend",
                "friend_as",
                "gcnew",
                "generic",
                "goto",
                "if",
                "initonly",
                "inline",
                "int",
                "interface",
                "interior_ptr",
                "literal",
                "long",
                "mutable",
                "naked",
                "namespace",
                "new",
                "noinline",
                "noreturn",
                "nothrow",
                "novtable",
                "nullptr",
                "operator",
                "private",
                "property",
                "protected",
                "public",
                "ref",
                "register",
                "reinterpret_cast",
                "return",
                "safecast",
                "sealed",
                "selectany",
                "short",
                "signed",
                "sizeof",
                "static",
                "static_assert",
                "static_cast",
                "struct",
                "switch",
                "template",
                "this",
                "thread",
                "true",
                "try",
                "typedef",
                "typeid",
                "typename",
                "union",
                "unsigned",
                "using",
                "uuid",
                "value",
                "virtual",
                "void",
                "volatile",
                "while"
            };

        /// <summary>
        /// The default value.
        /// </summary>
        private string defaultValue;

        /// <summary>
        /// Description of the property
        /// </summary>
        private string description;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyInfoBase"/> class. 
        /// Constructor
        /// </summary>
        /// <param name="collection">
        /// Whether the property represents a collection
        /// </param>
        /// <param name="name">
        /// Name of the property
        /// </param>
        /// <param name="description">
        /// Description of the property
        /// </param>
        /// <param name="optional">
        /// Whether the property is optional (i.e. nullable)
        /// </param>
        /// <param name="netDataType">
        /// The .NET data type
        /// </param>
        /// <param name="sqlDataReaderType">
        /// The SQL DataReader type
        /// </param>
        /// <param name="requiresSqlMapping">
        /// Whether the type needs mapping in order to be used with SQL
        /// </param>
        /// <param name="defaultValue">
        /// The default value of the type
        /// </param>
        /// <param name="nullableType">
        /// Whether the .NET data type is nullable
        /// </param>
        /// <param name="isKey">
        /// Whether the property is the primary key
        /// </param>
        /// <param name="xmlIsCdataElement">
        /// The xml element produced is a CDATA Element.
        /// </param>
        /// <param name="dataType">
        /// The data Type.
        /// </param>
        /// <param name="alternativeDatabaseColumnName">
        /// Name of the database column name, if it's different from the .NET property name.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected PropertyInfoBase(
            CollectionType collection, 
            string name, 
            string description, 
            bool optional, 
            string netDataType, 
            string sqlDataReaderType, 
            bool requiresSqlMapping, 
            string defaultValue, 
            bool nullableType,
            bool isKey,
            bool xmlIsCdataElement,
            Type dataType,
            string? alternativeDatabaseColumnName)
        {
            this.dataType = dataType;

            if (this.keywords.Any(keyword => keyword.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Property name can not be the same as a .NET keyword.", "name");
            }

            if (name.ToCharArray().Any(currentChar => !char.IsLetterOrDigit(currentChar) || currentChar > 255))
            {
                throw new ArgumentException("Property name contains a character that cant be used in a name.", "name");
            }

            this.Collection = collection;
            this.Name = name;
            this.Description = description;
            this.Optional = optional;
            this.NetDataType = netDataType;
            this.SqlDataReaderType = sqlDataReaderType;
            this.RequiresSqlMapping = requiresSqlMapping;
            this.DefaultValue = defaultValue;
            this.NullableType = nullableType;
            this.IsKey = isKey;
            this.XmlIsCdataElement = xmlIsCdataElement;
            this.AlternativeDatabaseColumnName = alternativeDatabaseColumnName;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the xml element produced is a CDATA Element.
        /// </summary>
        public bool XmlIsCdataElement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the property represents a collection
        /// </summary>
        public CollectionType Collection { get; set; }

        /// <summary>
        /// Gets or sets the default value for the type
        /// </summary>
        public string DefaultValue
        {
            get
            {
                switch (this.Collection)
                {
                    case CollectionType.GenericList:
                        return "new System.Collections.Generic.List<" + this.NetDataType + ">()";
                    case CollectionType.GenericLinkedList:
                        return "new System.Collections.Generic.LinkedList<" + this.NetDataType + ">()";
                    case CollectionType.Array:
                        return "new " + this.NetDataType + "[]()";
                    case CollectionType.None:
                        return this.defaultValue;
                    default:
                        throw new InvalidOperationException();
                }
            }

            set
            {
                this.defaultValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the property. Appears in the generated comment.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value");
                }

                char[] seperator = { ' ' };
                if (value.Split(seperator).Length < 1)
                {
                    throw new ArgumentException("Description should be more than 1 word.");
                }

                this.description = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the .NET data type
        /// </summary>
        public string NetDataType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether .NET data type is nullable
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool NullableType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is optional. i.e. nullable
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Optional { get; set; }

        public string SqlDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the type needs mapping to be used with SQL
        /// </summary>
        public bool RequiresSqlMapping { get; set; }

        /// <summary>
        /// Gets or sets the SQL DataReader Type
        /// </summary>
        public string SqlDataReaderType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property is the primary key
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// Gets or sets the alternative database column name.
        /// Used where the database naming convention doesn't match the .NET naming convention
        /// </summary>
        public string? AlternativeDatabaseColumnName { get; set; }

        public string SqlComputedColumn { get; set; }

        //#region Public Methods and Operators

        ///// <summary>
        ///// Gets the C# for carrying out a compare.
        ///// </summary>
        ///// <param name="checkResultDeclared">
        ///// The check Result Declared.
        ///// </param>
        ///// <returns>
        ///// C# for carrying out a compare
        ///// </returns>
        //public virtual string GetCSharpCompareCode(bool checkResultDeclared)
        //{
        //    var sb = new StringBuilder();

        //    if (this.Optional)
        //    {
        //        if (!this.NullableType)
        //        {
        //            if (!checkResultDeclared)
        //            {
        //                sb.Append("var checkResult = 0;");
        //            }

        //            sb.AppendLine("            if (this." + this.Name + " != null)");
        //            sb.AppendLine("            {");
        //            sb.AppendLine("                if (other." + this.Name + " == null)");
        //            sb.AppendLine("                {");
        //            sb.AppendLine("                    checkResult = -1;");
        //            sb.AppendLine("                }");
        //            sb.AppendLine("                else");
        //            sb.AppendLine("                {");
        //            sb.AppendLine(
        //                "                    checkResult = this." + this.Name + ".Value.CompareTo(other." + this.Name + ".Value);");
        //            sb.AppendLine("                }");
        //            sb.AppendLine("            }");
        //            sb.AppendLine("            else if (other." + this.Name + " != null)");
        //            sb.AppendLine("            {");
        //            sb.AppendLine("                checkResult = 1;");
        //            sb.AppendLine("            }");
        //        }
        //        else
        //        {
        //            sb.Append("            ");
        //            if (!checkResultDeclared)
        //            {
        //                sb.Append("var ");
        //            }

        //            sb.AppendLine("checkResult = this." + this.Name + ".CompareTo(other." + this.Name + ");");
        //        }
        //    }
        //    else
        //    {
        //        sb.Append("            ");
        //        if (!checkResultDeclared)
        //        {
        //            sb.Append("var ");
        //        }

        //        sb.AppendLine("checkResult = this." + this.Name + ".CompareTo(other." + this.Name + ");");
        //    }

        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Gets the C# for the data type declaration
        ///// </summary>
        ///// <returns>
        ///// C# for the data type declaration
        ///// </returns>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        //public string GetCSharpDataTypeDeclaration()
        //{
        //    switch (this.Collection)
        //    {
        //        case CollectionType.GenericList:
        //            return "System.Collections.Generic.List<" + this.NetDataType + ">";
        //        case CollectionType.GenericLinkedList:
        //            return "System.Collections.Generic.LinkedList<" + this.NetDataType + ">";
        //        case CollectionType.Array:
        //            return this.NetDataType + "[]";
        //        case CollectionType.None:
        //            return this.NetDataType;
        //        default:
        //            throw new InvalidOperationException();
        //    }
        //}

        ///// <summary>
        ///// Gets the setter code for a property
        ///// </summary>
        ///// <returns>
        ///// the setter code for a property
        ///// </returns>
        //public virtual string GetMutator()
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine("        set");
        //    sb.AppendLine("        {");

        //    sb.AppendLine("            this." + OldHelpers.GetVariableName(this.Name) + " = value;");

        //    sb.AppendLine("        }");
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// Gets the logic for checking the hash code
        ///// </summary>
        ///// <returns>
        ///// logic for checking the hash code
        ///// </returns>
        //public virtual string GetHashcodeOperation()
        //{
        //    //if (this.dataType.IsClass || this.dataType.FullName.Equals("System.String", StringComparison.Ordinal))
        //    //{
        //    //    return "(this." + this.Name + " != null ? this." + this.Name + ".GetHashCode() : 0)";
        //    //}

        //    return "this." + this.Name + ".GetHashCode()";
        //}

        //#endregion
        
        ///// <summary>
        ///// Produces the data annotations specific to the property
        ///// </summary>
        ///// <returns>
        ///// Data annotation code
        ///// </returns>
        //public abstract string GetDataAnnotations();
    }
}