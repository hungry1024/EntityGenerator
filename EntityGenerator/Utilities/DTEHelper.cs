using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityGenerator.Utilities
{
    public static class DTEHelper
    {
        #region DTE2

        private static DTE2 _dte2;

        internal static DTE2 DTE2
        {
            get
            {
                if (_dte2 == null)
                    _dte2 = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;

                return _dte2;
            }
        }

        #endregion

        #region DTE

        private static DTE _dte;

        internal static DTE DTE
        {
            get
            {
                if (_dte == null)
                    _dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE;

                return _dte;
            }
        }


        #endregion

        public static Project GetSelectedProject()
        {
            var items = (Array)DTE2.ToolWindows.SolutionExplorer.SelectedItems;
            foreach (UIHierarchyItem selItem in items)
            {
                var item = selItem.Object as Project;
                if (item != null)
                    return item;
            }
            return null;
        }

        public static string GetSelectedProjectPath()
        {
            var project = GetSelectedProject();
            if (project == null) return string.Empty;
            return project.Properties.Item("FullPath").Value.ToString();
        }
    }
}
