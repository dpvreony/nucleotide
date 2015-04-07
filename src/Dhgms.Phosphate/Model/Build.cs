// -----------------------------------------------------------------------
// <copyright file="Build.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Dhgms.Phosphate.Model
{
    using EnvDTE;

    /// <summary>
    /// Build event helper
    /// </summary>
    public static class Build
    {
        public static void DoProject(
            Project project
            )
        {
            if (project.Object.GetType() == typeof(Microsoft.VisualStudio.VCProjectEngine.VCProject))
            {
                //DoVcProject();
            }

            if (project.Object.GetType() == typeof(Project))
            {
                
            }

            DoProjectItems(project.ProjectItems);
            DoProjectConfigurations(project.ConfigurationManager);
        }

        //private static void DoVcProject

        private static void DoProjectItems(
            ProjectItems projectItems
            )
        {
            foreach (ProjectItem projectItem in projectItems)
            {
                DoProjectItem(projectItem);
            }
        }

        private static void DoProjectItem(
            ProjectItem projectItem
            )
        {
            
        }

        private static void DoProjectConfigurations(
            ConfigurationManager configurationManager
            )
        {
            foreach (Configuration configuration in configurationManager)
            {
                DoProjectConfiguration(configuration);
            }
        }

        private static void DoProjectConfiguration(
            Configuration configuration
            )
        {

        }
    }
}
