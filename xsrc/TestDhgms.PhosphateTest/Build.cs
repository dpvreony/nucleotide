// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Build.cs" company="DHGMS Solutions">
//   2009-2012 DHGMS Solutions. Some Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.PhosphateTest
{
    using System;

    using EnvDTE80;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for Build Events
    /// </summary>
    [TestClass]
    public class Build
    {
        #region Constants and Fields

        /// <summary>
        /// Visual Studio Automation Object
        /// </summary>
        private static DTE2 dte;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Use ClassCleanup to run code after all tests in a class have run
        /// </summary>
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            // All done, so shut down the IDE...
            dte.Quit();

            // and turn off the IOleMessageFilter.
            MessageFilter.Revoke();

            dte = null;
        }

        /// <summary>
        /// Initialises code run before the unit tests take place
        /// </summary>
        /// <param name="testContext">
        /// The test context.
        /// </param>
        /// <remarks>
        /// Taken from http://msdn.microsoft.com/en-us/library/ms228772(VS.80).aspx
        /// </remarks>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            // Get the ProgID for DTE 10.0.
            var type = Type.GetTypeFromProgID("VisualStudio.DTE.10.0", true);

            // Create a new instance of the IDE.
            var obj = Activator.CreateInstance(type, true);

            // Cast the instance to DTE2 and assign to variable dte.
            dte = (DTE2)obj;

            // Register the IOleMessageFilter to handle any threading 
            // errors.
            MessageFilter.Register();

            // Open our test bed solution
            dte.Solution.Open(@"TestBedDhgms.PhosphateTestBed.sln");

            // Display the Visual Studio IDE.
            // dte.MainWindow.Activate();
        }

        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }

        /// <summary>
        /// Test of a C# Project
        /// </summary>
        [TestMethod]
        public void TestCSharp()
        {
            // Dhgms.Phosphate.Model.Build.DoProject();
        }

        /// <summary>
        /// Test of a C++ Project
        /// </summary>
        [TestMethod]
        public void TestCPlusPlus()
        {
            // Dhgms.Phosphate.Model.Build.DoProject();
        }
        #endregion
    }
}