using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityGenerator.DAL;
using EntityGenerator.Utilities;
using EntityGenerator.Views;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace EntityGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class Command1
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("3a67dc42-a63c-4aac-98b2-41911fb4c65f");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command1"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private Command1(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            //var menuCommandID = new CommandID(CommandSet, CommandId);
            //var menuItem = new MenuCommand(this.Execute, menuCommandID);
            //commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static Command1 Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in Command1's constructor requires
            // the UI thread.
            // await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService mcs = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;

            Instance = new Command1(package, mcs);

            if (null != mcs)
            {
                // 更新实体
                CommandID updateCmdId = new CommandID(CommandSet, (int)PackageCmdIDs.EntitiesUpdate);
                OleMenuCommand updateItem = new OleMenuCommand(Instance.UpdateCallback, updateCmdId);
                updateItem.BeforeQueryStatus += Instance.updateItem_BeforeQueryStatus;
                mcs.AddCommand(updateItem);

                // 批量更新实体
                CommandID batchCmdId = new CommandID(CommandSet, (int)PackageCmdIDs.EntitiesBatch);
                OleMenuCommand batchItem = new OleMenuCommand(Instance.BatchCallback, batchCmdId);
                batchItem.BeforeQueryStatus += Instance.batchItem_BeforeQueryStatus;
                mcs.AddCommand(batchItem);

                // 设置
                CommandID configCmdId = new CommandID(CommandSet, (int)PackageCmdIDs.ViewEntitiesBatch);
                OleMenuCommand configItem = new OleMenuCommand(Instance.BatchViewCallback, configCmdId);
                mcs.AddCommand(configItem);

                // 设置
                //CommandID addCmdId = new CommandID(CommandSet, (int)PackageCmdIDs.EntitiesAdd);
                //OleMenuCommand addItem = new OleMenuCommand(Instance.AddCallback, addCmdId);
                //mcs.AddCommand(addItem);

                // 设置
                //CommandID deleteCmdId = new CommandID(CommandSet, (int)PackageCmdIDs.EntitiesDelete);
                //OleMenuCommand deleteItem = new OleMenuCommand(Instance.DeleteCallback, deleteCmdId);
                //mcs.AddCommand(deleteItem);
            }
        }

        void batchItem_BeforeQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand menuCommand = sender as OleMenuCommand;
            var fileName = getProjectItemName(menuCommand);
            menuCommand.Visible = (fileName == "app.config" || fileName == "web.config");
        }

        void updateItem_BeforeQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand menuCommand = sender as OleMenuCommand;
            var fileName = getProjectItemName(menuCommand);
            menuCommand.Visible = fileName.EndsWith(".cs");
        }

        /// <summary>
        /// 根据菜单动作获取操作的文件名
        /// </summary>
        /// <param name="menuCommand"></param>
        /// <returns></returns>
        private string getProjectItemName(OleMenuCommand menuCommand)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            if (menuCommand != null)
            {
                IntPtr hierarchyPtr, selectionContainerPtr;
                uint projectItemId;
                IVsMultiItemSelect mis;
                IVsMonitorSelection monitorSelection = (IVsMonitorSelection)Package.GetGlobalService(typeof(SVsShellMonitorSelection));
                monitorSelection.GetCurrentSelection(out hierarchyPtr, out projectItemId, out mis, out selectionContainerPtr);

                IVsHierarchy hierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
                if (hierarchy != null)
                {
                    object value;
                    hierarchy.GetProperty(projectItemId, (int)__VSHPROPID.VSHPROPID_Name, out value);

                    if (value != null)
                    {
                        return value.ToString().ToLower();
                    }
                }
            }
            return string.Empty;
        }

        private void UpdateCallback(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            DTE dte = ServiceProvider.GetServiceAsync(typeof(DTE)).Result as DTE;
            if (dte == null)
                return;

            TextSelection section = dte.ActiveDocument.Selection as TextSelection;

            // 光标移动至第一行第一列
            section.MoveToLineAndOffset(1, 1);
            bool result = section.FindText("database", (int)vsFindOptions.vsFindOptionsRegularExpression);

            if (!result)
            {
                section.SelectAll();
                section.Delete();
            }
            else
            {
                //需要添加此操作，否则不会替换成功
                section.SelectAll();
                section.Text = "";
            }
        }

        private void BatchCallback(object sender, EventArgs e)
        {
            //var project = getProjectItemName(sender as OleMenuCommand);
            var path = GetSelectedProjectPath();

            var structure = GetDbStructure();
            if (structure == null) return;

            var form = new FormBatch(structure);
            form.ShowDialog();
        }

        private void BatchViewCallback(object sender, EventArgs e)
        {
            var structure = GetDbStructure();
            if (structure == null) return;
        }

        private void AddCallback(object sender, EventArgs e)
        {
            // 获取项目下配置文件的连接字符串
            //var project = getProjectItemName(sender as OleMenuCommand);
            //var path = GetSelectedProjectPath();

            //var structure = GetDbStructure();
            //if (structure == null) return;

            //var form = new FormBatch(structure);
            //form.ShowDialog();
        }

        private void DeleteCallback(object sender, EventArgs e)
        {
        }

        private SqlStructure GetDbStructure()
        {
            try
            {
                var xml = ConfigUtil.GetConfigXml();
                if (string.IsNullOrEmpty(xml))
                {
                    MessageBox.Show("__entity.xml配置不正确");
                    return null;
                }
                var connString = ConfigUtil.GetConnString(xml);
                var dbtype = ConfigUtil.GetDbType(xml);
                var filters = ConfigUtil.GetFilters(xml);
                return new SqlStructure(connString, filters, dbtype);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接到数据库失败：\r\n" + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);
            string title = "GenerateEntity";

            // Show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        #region IDE 帮助函数

        /// <summary>
        /// 获取当前活动文档内容
        /// </summary>
        /// <returns></returns>
        public string GetActiveDocument()
        {
            DTE dte = ServiceProvider.GetServiceAsync(typeof(DTE)) as DTE;
            if (dte == null)
                return string.Empty;

            var selection = dte.ActiveDocument.Selection as TextSelection;

            // 光标移动至第一行第一列
            selection.MoveToLineAndOffset(1, 1);
            selection.SelectAll();
            var text = selection.Text;
            selection.MoveToLineAndOffset(1, 1);
            return text;
        }

        private string GetFileContent(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                return reader.ReadToEnd();
            }
        }

        public string GetSelectedProjectPath()
        {
            var items = (Array)DTEHelper.DTE2.ToolWindows.SolutionExplorer.SelectedItems;
            foreach (UIHierarchyItem selItem in items)
            {
                var item = selItem.Object as Project;
                if (item != null)
                    return item.Properties.Item("FullPath").Value.ToString();
            }
            return string.Empty;
        }

        public string GetSelectedFilePath()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            DTE dte = ServiceProvider.GetServiceAsync(typeof(DTE)) as DTE;
            if (dte == null)
                return string.Empty;

            return dte.SelectedItems.Item(1).ProjectItem.Document.Path;
        }

        #endregion

    }
}
