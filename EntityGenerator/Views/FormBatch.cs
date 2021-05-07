using EntityGenerator.DAL;
using EntityGenerator.Models;
using EntityGenerator.Services;
using EntityGenerator.Utilities;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EntityGenerator.Extents;
using System.Reflection;
using Microsoft.VisualStudio.ProjectSystem;

namespace EntityGenerator.Views
{
    public partial class FormBatch : Form
    {
        private Template _template = null;
        private readonly string _currentProjectRootPath;
        private readonly Project _currentProject;
        private ProjectItems _targetProjectItems;
        private string _rootNamespace;

        private SqlStructure structure;

        public FormBatch(SqlStructure structure, string[] folders = null)
        {
            this.structure = structure;
            _currentProjectRootPath = DTEHelper.GetSelectedProjectPath(); ;
            _currentProject = DTEHelper.GetSelectedProject();
            InitializeComponent();
        }

        private void FormBatch_Load(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _rootNamespace = _currentProject.Name;
            foreach (var pi in _currentProject.Properties)
            {
                var property = pi as Property;
                if (property != null && property.Name == "RootNamespace")
                {
                    _rootNamespace = property.Value.ToString();
                    break;
                }
            }

            _template = ConfigUtil.GetTemplates()[0];
            
            structure.Tables.AddRange(structure.Views);
            structure.EntityNameFormatting = _template.ClassNameFormatting;

            InitData();

            foreach (ProjectItem item in _currentProject.ProjectItems)
            {
                if (item.Kind == Constants.vsProjectItemKindPhysicalFolder)
                {
                    this.cbSqlViewDirectory.Items.Add(item.Name);
                }
            }
        }

        private void InitData()
        {
            var dictExistEntities = GetExistsEntities();

            // 已生成的实体
            this.addedList.Items.Clear();

            // 还没生成的实体
            this.newList.Items.Clear();

            foreach (var entity in structure.Tables)
            {
                if (dictExistEntities.Any(f => f.Equals(entity.GetPascalName(_template.ClassNameFormatting), StringComparison.OrdinalIgnoreCase)))
                {
                    this.addedList.Items.Add(entity);
                }
                else
                {
                    this.newList.Items.Add(entity);
                }
            }

            // 数据库中不存在的实体
            this.unexistsList.Items.Clear();
            foreach (var entity in dictExistEntities.Except(structure.Tables.Select(s => s.GetPascalName(_template.ClassNameFormatting)), StringComparer.OrdinalIgnoreCase))
            {
                this.unexistsList.Items.Add(entity);
            }
        }


        private List<string> GetExistsEntities()
        {
            string entitiesDir = _template.path;
            _targetProjectItems = _currentProject.ProjectItems;
            if (entitiesDir.Length != 0)
            {
                string[] dirs = entitiesDir.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string dir in dirs)
                {
                    bool exists = false;
                    foreach (ProjectItem pi in _targetProjectItems)
                    {
                        if(pi.Kind == Constants.vsProjectItemKindPhysicalFolder && string.Equals(dir, pi.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            _targetProjectItems = pi.ProjectItems;
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        MessageBox.Show($"目录{entitiesDir}不存在", "404", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<string>(0);
                    }
                }
            }

            string[] notIncluded = { "Program.cs" };
            var entities = new List<string>();
            
            foreach (ProjectItem item in _targetProjectItems)
            {
                if (item.Name.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) && !notIncluded.Any(m => m == item.Name))
                    entities.Add(item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase));
            }
            return entities;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string entitiesDir = _template.path;

                string nameSpaceStr = _rootNamespace;     
                string path = _currentProject.Properties.Item("FullPath").Value.ToString();

                if(entitiesDir.Length != 0)
                {
                    string[] dirs = entitiesDir.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    nameSpaceStr = $"{nameSpaceStr}.{string.Join(".", dirs)}";
                    path = Path.Combine(path, string.Join("\\", dirs));
                }

                var entities = GetCheckedItems(this.addedList);
                var views = GetCheckedItems(this.newList);
                entities.AddRange(views);

                foreach (var entity in entities)
                {
                    var className = entity.GetPascalName(_template.ClassNameFormatting);
                    var file = Path.Combine(path, className + ".cs");
                    var columns = structure.GetColumns(entity);
                    string comment = structure.GetComment(entity);
                    var enums = columns.Where(w => w.hasEnum).Select(s => s.getColumnEnum).ToList();
 
                    var content = RefreshService.GetContent(_template.text, nameSpaceStr, entity, className, columns, comment, enumLists: enums);

                    RefreshService.AddOrUpdate(file, content);
                    _targetProjectItems.AddFromFile(file);
                }
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 表格/视图 全选/全取消

        private void btnEntitySelectAll_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.addedList, true);
        }

        private void btnEntitySelectNone_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.addedList, false);
        }

        private void btnViewSelectAll_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.newList, true);
        }

        private void btnViewSelectNone_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.newList, false);
        }

        private void btnUnExistsSelectAll_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.unexistsList, true);
        }

        private void btnUnExistsSelectNone_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.unexistsList, false);
        }

        private void btnSqlViewSelectAll_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.cbSqlViewAdded, true);
        }

        private void btnSqlViewSelectNone_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.cbSqlViewAdded, false);
        }

        private void btnSqlViewAddingSelectAll_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.cbSqlViewAdding, true);
        }

        private void btnSqlViewAddingSelectNone_Click(object sender, EventArgs e)
        {
            SetItemsChecked(this.cbSqlViewAdding, false);
        }

        #endregion

        #region CheckedListBox Helpers

        private void SetItemsChecked(CheckedListBox list, bool isChecked)
        {
            for (int i = 0, total = list.Items.Count; i < total; i++)
            {
                list.SetItemChecked(i, isChecked);
            }
        }

        private List<string> GetCheckedItems(CheckedListBox listBox)
        {
            var list = new List<string>();
            for (int i = 0, total = listBox.Items.Count; i < total; i++)
            {
                if (listBox.GetItemChecked(i))
                    list.Add(listBox.GetItemText(listBox.Items[i]));
            }
            return list;
        }

        private void RemoveCheckedItems(CheckedListBox listBox)
        {
            for (int i = 0, total = listBox.CheckedItems.Count; i < total; i++)
            {
                listBox.Items.RemoveAt(i);
            }
        }

        #endregion

        private void btnDelUnExistsEntity_Click(object sender, EventArgs e)
        {
            var entities = GetCheckedItems(this.unexistsList);
            var path = _currentProject.Properties.Item("FullPath").Value.ToString();
            foreach (var entity in entities)
            {
                foreach (ProjectItem item in _targetProjectItems)
                {
                    if (item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase) == entity)
                    {
                        item.Remove();
                    }
                }
            }
            RemoveCheckedItems(this.unexistsList);
        }

        private void tabCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlView
            if (tabCreate.SelectedTab.Name == "tabSqlView")
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbSqlViewDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlViewEntityDirectory.Items.Clear();
            ddlViewEntityDirectory.Items.Add("项目主目录");
            foreach (var item in cbSqlViewDirectory.Items)
            {
                if (item.ToString() != cbSqlViewDirectory.SelectedItem.ToString())
                    ddlViewEntityDirectory.Items.Add(item);
            }

            InitSqlView();
        }

        private void InitSqlView()
        {
            cbSqlViewAdded.Items.Clear();
            cbSqlViewAdding.Items.Clear();
            cbSqlViewNotExists.Items.Clear();

            string sqlViewDirectory = cbSqlViewDirectory.SelectedItem.ToString();
            string entityDirectory = ddlViewEntityDirectory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sqlViewDirectory) || string.IsNullOrEmpty(entityDirectory))
            {
                return;
            }
            if (ddlViewEntityDirectory.SelectedIndex == 0)
            {
                entityDirectory = string.Empty;
            }

            string sqlViewFullDir = Path.Combine(_currentProjectRootPath, sqlViewDirectory);

            var allViews = new List<string>();
            var existsViews = GetExistsEntities(entityDirectory);

            TraverseDirectory(sqlViewFullDir, allViews);

            // 已生成的实体
            foreach (var entity in allViews.Intersect(existsViews, StringComparer.OrdinalIgnoreCase))
            {
                this.cbSqlViewAdded.Items.Add(entity);
            }

            // 还没生成的实体
            foreach (var entity in allViews.Except(existsViews, StringComparer.OrdinalIgnoreCase))
            {
                this.cbSqlViewAdding.Items.Add(entity);
            }

            // 可能不存在的实体
            foreach (var entity in existsViews.Except(allViews, StringComparer.OrdinalIgnoreCase))
            {
                this.cbSqlViewNotExists.Items.Add(entity);
            }
        }

        private void TraverseDirectory(string dir, List<string> list)
        {
            foreach (var file in Directory.GetFiles(dir))
            {
                if (Path.GetExtension(file).Equals(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    list.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            foreach (var child in Directory.GetDirectories(dir))
            {
                TraverseDirectory(child, list);
            }
        }

        private string[] GetExistsEntities(string secondFolder)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ProjectItem folderTarget = null;
            var result = new List<string>();

            if (!string.IsNullOrEmpty(secondFolder))
            {
                foreach (ProjectItem folderItem in _currentProject.ProjectItems)
                {
                    if (folderItem.Name == secondFolder && folderItem.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                    {
                        folderTarget = folderItem;
                        break;
                    }
                }
                if (folderTarget == null) return new string[0];
                foreach (ProjectItem item in folderTarget.ProjectItems)
                {
                    if (item.Name.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase));
                    }
                }
            }
            else
            {
                foreach (ProjectItem item in _currentProject.ProjectItems)
                {
                    if (item.Name.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase));
                    }
                }
            }

            return result.ToArray();
        }

        private void ddlViewEntityDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitSqlView();
        }

        private void btnRemoveSqlViewEntity_Click(object sender, EventArgs e)
        {
            var entities = GetCheckedItems(this.cbSqlViewNotExists);

            ProjectItems items = null;
            if (ddlViewEntityDirectory.SelectedIndex == 0)
            {
                items = _currentProject.ProjectItems;
            }
            else
            {
                foreach (ProjectItem folderItem in _currentProject.ProjectItems)
                {
                    if (folderItem.Name == ddlViewEntityDirectory.SelectedItem.ToString()
                        && folderItem.Kind == EnvDTE.Constants.vsProjectItemKindPhysicalFolder)
                    {
                        items = folderItem.ProjectItems;
                        break;
                    }
                }
            }

            foreach (var entity in entities)
            {
                foreach (ProjectItem item in items)
                {
                    if (item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase) == entity)
                    {
                        item.Remove();
                    }
                }
            }
            RemoveCheckedItems(this.cbSqlViewNotExists);
        }

        private void btnRefleshViews_Click(object sender, EventArgs e)
        {
            if (cbSqlViewDirectory.SelectedIndex == -1 || ddlViewEntityDirectory.SelectedIndex == -1)
            {
                Close();
                return;
            }

            string entityDirectory = ddlViewEntityDirectory.SelectedIndex == 0 ? string.Empty : ddlViewEntityDirectory.SelectedItem.ToString();
            string sqlViewDirectory = cbSqlViewDirectory.SelectedItem.ToString();
            string nameSpaceStr = _template.path;

            try
            {
                var path = _currentProject.Properties.Item("FullPath").Value.ToString();
                var entities = GetCheckedItems(this.cbSqlViewAdded);
                var views = GetCheckedItems(this.cbSqlViewAdding);
                entities.AddRange(views);
                foreach (var entity in entities)
                {
                    var className = entity.GetPascalName(_template.ClassNameFormatting);
                    var file = Path.Combine(path, entityDirectory, className + ".cs");

                    var sqlpath = Path.Combine(path, sqlViewDirectory, entity + ".sql");
                    var viewSql = File.ReadAllText(sqlpath);

                    var columns = structure.GetViewSqlColumns(entity, viewSql);

                    var content = RefreshService.GetContent(_template.text, nameSpaceStr, entity, className, columns, null, viewSql);

                    RefreshService.AddOrUpdate(file, content);
                    _currentProject.ProjectItems.AddFromFile(file);
                }
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                structure.CloseConnection();
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
