// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connect.cs" company="DHGMS Solutions">
//   2012 DHGMS Solutions. Some Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Dhgms.Phosphate
{
    using System;

    using Dhgms.Phosphate.Model;

    using Extensibility;

    using EnvDTE;

    using EnvDTE80;

    /// <summary>
    /// The object for implementing an Add-in.
    /// </summary>
    /// <seealso class="IDTExtensibility2"/>
    public class Connect : IDTExtensibility2
    {
        #region Constants and Fields

        /// <summary>
        /// The _add in instance.
        /// </summary>
        private AddIn _addInInstance;

        /// <summary>
        /// The _application object.
        /// </summary>
        private DTE2 _applicationObject;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.
        /// </summary>
        /// <param term="custom">
        /// Array of parameters that are host application specific.
        /// </param>
        /// <param name="custom">
        /// The custom.
        /// </param>
        /// <seealso class="IDTExtensibility2"/>
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.
        /// </summary>
        /// <param term="custom">
        /// Array of parameters that are host application specific.
        /// </param>
        /// <param name="custom">
        /// The custom.
        /// </param>
        /// <seealso class="IDTExtensibility2"/>
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.
        /// </summary>
        /// <param term="application">
        /// Root object of the host application.
        /// </param>
        /// <param term="connectMode">
        /// Describes how the Add-in is being loaded.
        /// </param>
        /// <param term="addInInst">
        /// Object representing this Add-in.
        /// </param>
        /// <param name="application">
        /// The application.
        /// </param>
        /// <param name="connectMode">
        /// The connect Mode.
        /// </param>
        /// <param name="addInInst">
        /// The add In Inst.
        /// </param>
        /// <param name="custom">
        /// The custom.
        /// </param>
        /// <seealso class="IDTExtensibility2"/>
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            this._applicationObject = (DTE2)application;
            this._addInInstance = (AddIn)addInInst;

            this._buildEvents = this._applicationObject.Events.BuildEvents;
            this._buildEvents.OnBuildBegin += new _dispBuildEvents_OnBuildBeginEventHandler(this.OnBuildBegin);
        }

        // Build events handler
        private BuildEvents _buildEvents;

        /// <summary>
        /// Called when a build begin event has occured.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="action">The action.</param>
        public void OnBuildBegin(vsBuildScope scope, vsBuildAction action)
        {
            if (action == vsBuildAction.vsBuildActionBuild
                || action == vsBuildAction.vsBuildActionRebuildAll)
            {
                switch (scope)
                {
                    case vsBuildScope.vsBuildScopeBatch:
                        this.OnBeginBuildBatch();
                        break;
                    case vsBuildScope.vsBuildScopeProject:
                        this.OnBeginBuildProject();
                        break;
                    case vsBuildScope.vsBuildScopeSolution:
                        this.OnBeginBuildSolution();
                        break;
                }
            }

        }

        private void OnBeginBuildBatch()
        {
        }

        private void OnBeginBuildProject()
        {
        }

        private void OnBeginBuildSolution()
        {
            foreach (Project project in this._applicationObject.Solution.Projects)
            {
                Build.DoProject(project);
            }
            
        }

        /// <summary>
        /// Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.
        /// </summary>
        /// <param term="disconnectMode">
        /// Describes how the Add-in is being unloaded.
        /// </param>
        /// <param term="custom">
        /// Array of parameters that are host application specific.
        /// </param>
        /// <param name="disconnectMode">
        /// The disconnect Mode.
        /// </param>
        /// <param name="custom">
        /// The custom.
        /// </param>
        /// <seealso class="IDTExtensibility2"/>
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>
        /// Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.
        /// </summary>
        /// <param term="custom">
        /// Array of parameters that are host application specific.
        /// </param>
        /// <param name="custom">
        /// The custom.
        /// </param>
        /// <seealso class="IDTExtensibility2"/>
        public void OnStartupComplete(ref Array custom)
        {
        }

            public void VSProjectProperties(DTE2 dte)
    {
        try
        {
            // Open a Visual C# or Visual Basic project
            // before running this add-in.
            Project project;
            project = this._applicationObject.Solution.Projects.Item(1);
            Property prop;
            /*
            prop = project.Properties.Item("AssemblyName");
            MessageBox.Show("The assembly name is: " 
+ prop.Value .ToString());
            prop.Value = "MyTestAssembly";
            MessageBox.Show("The assembly name is now: " 
+ prop.Value.ToString());
            // If the project is a Visual Basic project, set
            // the MyApplication property.
            if (project.Kind == PrjKind.prjKindCSharpProject)
            {
                MessageBox.Show
("The project is a Visual Basic Project");
                prop = project.Properties.Item("MyType");
                MessageBox.Show("The MyType value is: " 
+ prop.Value.ToString());
                prop.Value = "Class Library";
                MessageBox.Show("The MyType value is now: " 
+ prop.Value.ToString());
            }
             * */
        }
        catch(Exception ex)
        {
            //MessageBox.Show(ex.Message);
        }
    }
        #endregion
    }
}