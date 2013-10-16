﻿// -----------------------------------------------------------------------
// <copyright file="UnitTestInformation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Nucleotide.Model.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Dhgms.Nucleotide.Model.Info.PropertyInfo;

    /// <summary>
    /// Unit Test Generator for an Information Class
    /// </summary>
    public sealed class UnitTestInformation : UnitTestBase
    {
        /// <summary>
        /// Generate the unit test code for the constructor that takes parameters
        /// </summary>
        /// <param name="sb">string build to append the code to</param>
        /// <param name="className">name of the class</param>
        /// <param name="properties">collection of properties</param>
        /// <param name="baseClassName">name of the base class</param>
        /// <param name="baseClassProperties">collection of base class properties</param>
        protected override void DoConstructorWithParameters(
            StringBuilder sb,
            string className,
            Base[] properties,
            string baseClassName,
            Base[] baseClassProperties)
        {
        }

        /// <summary>
        ///     Gets the class suffix
        /// </summary>
        /// <returns>
        ///     the class suffix
        /// </returns>
        protected override string GetClassSuffix()
        {
            return null;
        }
    }
}
