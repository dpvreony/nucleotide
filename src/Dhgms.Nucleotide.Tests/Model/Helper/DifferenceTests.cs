// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Difference.cs" company="DHGMS Solutions">
//   Licensed under GNU General Public License version 2 (GPLv2)
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Dhgms.Nucleotide.Tests.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Dhgms.Nucleotide.Generators;
    using Dhgms.Nucleotide.Model;
    using Dhgms.Nucleotide.PropertyInfo;

    using TestDhgms.NucleotideMocking;

    using Xunit;

    /// <summary>
    /// The difference.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DifferenceTests
    {
        #region Constants

        /// <summary>
        /// The class name default base.
        /// </summary>
        private const string ClassNameDefaultBase = "ClassNameDefaultBase";

        /// <summary>
        /// The class name inheriting.
        /// </summary>
        private const string ClassNameInheriting = "ClassNameInheriting";

        /// <summary>
        /// The class remarks.
        /// </summary>
        private const string ClassRemarks = "Unit test for Difference class code generation";

        /// <summary>
        /// The main namespace name.
        /// </summary>
        private const string MainNamespaceName = "TestDhgms.Nucleotide";

        /// <summary>
        /// The sub namespace.
        /// </summary>
        private const string SubNamespace = "SubNamespace";

        #endregion

        #region Fields

        /// <summary>
        /// The properties default.
        /// </summary>
        private readonly PropertyInfoBase[] propertiesDefault = new PropertyInfoBase[]
            {
                new ClrBooleanPropertyInfo(CollectionType.None, "BooleanItem", "A Boolean Item", false, false, null), 
                new ClrDateTimePropertyInfo(CollectionType.None, "DateTimeItem", "A DateTime Item", false, null, null, false, null)
            };

        /// <summary>
        /// The properties inheriting.
        /// </summary>
        private readonly PropertyInfoBase[] propertiesInheriting = new PropertyInfoBase[]
            {
                new ClrBooleanPropertyInfo(CollectionType.None, "BooleanNullableItem", "A Boolean Item", true, false, null), 
                new ClrDateTimePropertyInfo(CollectionType.None, "DateTimeNullableItem", "A DateTime Item", true, null, null, false, null)
            };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Tests for the Generate Method
        /// </summary>
        public class GenerateMethod
        {
            /// <summary>
            /// The test difference all arguments null.
            /// </summary>
            [Fact]
            public void ThrowsExceptionCgpNull()
            {
                var instance = new DifferenceClassGenerator();

                var ex = Assert.Throws<ArgumentNullException>(() => instance.Generate(null));

                Assert.Equal("cgp", ex.ParamName);
            }

            /// <summary>
            /// Throws Exception because the Difference Class Name is null
            /// </summary>
            [Fact]
            public void ThrowsExceptionDifferenceClassNameNull()
            {
                var instance = new DifferenceClassGenerator();

                var cgp = new MockClassGenerationParameters(MainNamespaceName, SubNamespace, null, null, TestInputs.PropertiesDefault, null, null, 2010, null, null);
                var classes = new List<IClassGenerationParameters> { cgp };

                var ex = Assert.Throws<ArgumentException>(() => instance.Generate(classes));

                Assert.Equal("cgp", ex.ParamName);
            }
        }


        /*
        /// <summary>
        /// The test difference class name null.
        /// </summary>
        [Fact]
        public void TestDifferenceClassNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

            var cgp = new MockClassGenerationParameters(MainNamespaceName);

            var ex = Assert.Throws<ArgumentException>(() => instance.Generate(cgp));
            Assert.Equal("cgp", ex.ParamName);
        }

        /// <summary>
        /// The test difference class remarks null.
        /// </summary>
        [Fact]
        public void TestDifferenceClassRemarksNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

            var cgp = new MockClassGenerationParameters(
                MainNamespaceName,
                SubNamespace,
                ClassNameDefaultBase,
                this.propertiesDefault,
                null,
                null,
                null,
                2010,
                null,
                null);

            var ex = Assert.Throws<ArgumentException>(() => instance.Generate(cgp));
            Assert.Equal("classRemarks", ex.ParamName);
        }

        /// <summary>
        /// The test difference inheriting should succeed.
        /// </summary>
        [Fact]
        public void TestDifferenceInheritingShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();
            instance.Generate(
                MainNamespaceName, 
                SubNamespace, 
                ClassNameInheriting, 
                ClassRemarks, 
                this.propertiesInheriting, 
                ClassNameDefaultBase, 
                this.propertiesDefault);
        }

        /// <summary>
        /// The test difference main namespace name null.
        /// </summary>
        [Fact]
        public void TestDifferenceMainNamespaceNameNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();



            try
            {
                instance.Generate(
                    null, SubNamespace, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("mainNamespaceName", e.ParamName);
                return;
            }

            Assert.Fail("Expected System.NullReferenceException");
        }

        /// <summary>
        /// The test difference no base should succeed.
        /// </summary>
        [Fact]
        public void TestDifferenceNoBaseShouldSucceed()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();
            instance.Generate(
                MainNamespaceName, SubNamespace, ClassNameDefaultBase, ClassRemarks, this.propertiesDefault, null, null);
        }

        /// <summary>
        /// The test difference properties null.
        /// </summary>
        [Fact]
        public void TestDifferencePropertiesNull()
        {
            var instance = new Dhgms.Nucleotide.Model.Helper.Difference();

            var cgp = new MockClassGenerationParameters(MainNamespaceName, SubNamespace, ClassNameDefaultBase, null, null, null, null, 2010, null, ClassRemarks);

            var ex = Assert.Throws<ArgumentException>(() => instance.Generate(cgp));
            Assert.Equal("cgp", ex.ParamName);
        }
         * */

        #endregion
    }
}