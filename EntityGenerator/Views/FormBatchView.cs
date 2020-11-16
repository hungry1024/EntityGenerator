using EntityGenerator.DAL;
using EntityGenerator.Models;
using EntityGenerator.Services;
using EntityGenerator.Utilities;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityGenerator.Extents;


namespace EntityGenerator.Views
{
    public partial class FormBatchView : Form
    {
        private SqlStructure structure;

        public FormBatchView(SqlStructure structure)
        {
            this.structure = structure;
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            var templates = ConfigUtil.GetTemplates();
            txtTemplate.Text = templates[0].text;

            var dictExistEntities = GetExistsEntities();

            structure.Tables.AddRange(structure.Views);

            // 已生成的实体
            foreach (var entity in structure.Tables.Intersect(dictExistEntities, StringComparer.OrdinalIgnoreCase))
            {
                this.addedList.Items.Add(entity);
            }

            // 还没生成的实体
            foreach (var entity in structure.Tables.Except(dictExistEntities, StringComparer.OrdinalIgnoreCase))
            {
                this.newList.Items.Add(entity);
            }

            // 数据库中不存在的实体
            foreach (var entity in dictExistEntities.Except(structure.Tables, StringComparer.OrdinalIgnoreCase))
            {
                this.unexistsList.Items.Add(entity);
            }
        }

        private List<string> GetExistsEntities()
        {
            var entities = new List<string>();
            var project = DTEHelper.GetSelectedProject();
            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.Name.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
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
                //string nameSpaceStr = tbx_namespace.Text;

                //if (string.IsNullOrEmpty(nameSpaceStr))
                //    MessageBox.Show("请输入命名空间 例：TY.Project.Entities");

                var project = DTEHelper.GetSelectedProject();
                var path = project.Properties.Item("FullPath").Value.ToString();
                var entities = GetCheckedItems(this.addedList);
                var views = GetCheckedItems(this.newList);
                entities.AddRange(views);
                foreach (var entity in entities)
                {
                    var className = entity.GetPascalName();
                    var file = path + entity + ".cs";

                    var columns = structure.GetColumns(entity);
                    string comment = structure.GetComment(entity);

                    var content = RefreshService.GetContent(txtTemplate.Text, "", className, entity, columns, comment);

                    RefreshService.AddOrUpdate(file, content);
                    project.ProjectItems.AddFromFile(file);
                }
                this.Close();
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
            var project = DTEHelper.GetSelectedProject();
            var path = project.Properties.Item("FullPath").Value.ToString();
            foreach (var entity in entities)
            {
                foreach (ProjectItem item in project.ProjectItems)
                {
                    if (item.Name.TrimSuffix(".cs", StringComparison.OrdinalIgnoreCase) == entity)
                    {
                        item.Remove();
                        //var file = path + item.Name;
                        //File.Delete(file);
                    }
                }
            }
            RemoveCheckedItems(this.unexistsList);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hehe");
        }

        private void tabCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCreate.SelectedTab.Name == "tabTemp")
            {
                var templates = ConfigUtil.GetTemplates();
                if (templates == null || templates.Count == 0)
                {
                    MessageBox.Show("配置文件中不包含模版定义，请先定义");
                    return;
                }

                foreach (var temp in templates)
                {
                    cmbList.Items.Add(temp.name);
                }

                cmbList.Text = templates.First().name;
                SetTemplateInfo(templates);
            }
        }

        private void SetTemplateInfo(Template temp)
        {
            txtType.Text = temp.type;
            txtFileName.Text = temp.fileName;
            txtPath.Text = temp.path;
            txtTemplate.Text = temp.text;
        }

        private void SetTemplateInfo(List<Template> templates)
        {
            var name = cmbList.Text;
            var temp = templates.FirstOrDefault(t => t.name == name);
            if (temp != null)
                SetTemplateInfo(temp);
        }

        private void cmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var templates = ConfigUtil.GetTemplates();
            SetTemplateInfo(templates);
        }
    }
}
