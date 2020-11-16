namespace EntityGenerator.Views
{
    partial class FormBatchView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatchView));
            this.addedList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEntitySelectNone = new System.Windows.Forms.Button();
            this.btnEntitySelectAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewSelectNone = new System.Windows.Forms.Button();
            this.btnViewSelectAll = new System.Windows.Forms.Button();
            this.newList = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelUnExistsEntity = new System.Windows.Forms.Button();
            this.btnUnExistsSelectNone = new System.Windows.Forms.Button();
            this.btnUnExistsSelectAll = new System.Windows.Forms.Button();
            this.unexistsList = new System.Windows.Forms.CheckedListBox();
            this.tabCreate = new System.Windows.Forms.TabControl();
            this.tabEntity = new System.Windows.Forms.TabPage();
            this.tabTemp = new System.Windows.Forms.TabPage();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.path = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.fileName = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.cmbList = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.tabEntity.SuspendLayout();
            this.tabTemp.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // addedList
            // 
            this.addedList.BackColor = System.Drawing.SystemColors.Window;
            this.addedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addedList.CheckOnClick = true;
            this.addedList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addedList.FormattingEnabled = true;
            this.addedList.HorizontalScrollbar = true;
            this.addedList.Location = new System.Drawing.Point(21, 25);
            this.addedList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.addedList.Name = "addedList";
            this.addedList.Size = new System.Drawing.Size(283, 338);
            this.addedList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEntitySelectNone);
            this.groupBox1.Controls.Add(this.btnEntitySelectAll);
            this.groupBox1.Controls.Add(this.addedList);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(325, 428);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已添加的实体列表";
            // 
            // btnEntitySelectNone
            // 
            this.btnEntitySelectNone.Location = new System.Drawing.Point(221, 378);
            this.btnEntitySelectNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntitySelectNone.Name = "btnEntitySelectNone";
            this.btnEntitySelectNone.Size = new System.Drawing.Size(84, 29);
            this.btnEntitySelectNone.TabIndex = 2;
            this.btnEntitySelectNone.Text = "全取消";
            this.btnEntitySelectNone.UseVisualStyleBackColor = true;
            this.btnEntitySelectNone.Click += new System.EventHandler(this.btnEntitySelectNone_Click);
            // 
            // btnEntitySelectAll
            // 
            this.btnEntitySelectAll.Location = new System.Drawing.Point(129, 378);
            this.btnEntitySelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntitySelectAll.Name = "btnEntitySelectAll";
            this.btnEntitySelectAll.Size = new System.Drawing.Size(84, 29);
            this.btnEntitySelectAll.TabIndex = 1;
            this.btnEntitySelectAll.Text = "全选";
            this.btnEntitySelectAll.UseVisualStyleBackColor = true;
            this.btnEntitySelectAll.Click += new System.EventHandler(this.btnEntitySelectAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(657, 442);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 41);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "添加或刷新选中的项(&A)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewSelectNone);
            this.groupBox2.Controls.Add(this.btnViewSelectAll);
            this.groupBox2.Controls.Add(this.newList);
            this.groupBox2.Location = new System.Drawing.Point(345, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(325, 428);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "尚添加的实体";
            // 
            // btnViewSelectNone
            // 
            this.btnViewSelectNone.Location = new System.Drawing.Point(221, 378);
            this.btnViewSelectNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSelectNone.Name = "btnViewSelectNone";
            this.btnViewSelectNone.Size = new System.Drawing.Size(84, 29);
            this.btnViewSelectNone.TabIndex = 4;
            this.btnViewSelectNone.Text = "全取消";
            this.btnViewSelectNone.UseVisualStyleBackColor = true;
            this.btnViewSelectNone.Click += new System.EventHandler(this.btnViewSelectNone_Click);
            // 
            // btnViewSelectAll
            // 
            this.btnViewSelectAll.Location = new System.Drawing.Point(129, 378);
            this.btnViewSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSelectAll.Name = "btnViewSelectAll";
            this.btnViewSelectAll.Size = new System.Drawing.Size(84, 29);
            this.btnViewSelectAll.TabIndex = 3;
            this.btnViewSelectAll.Text = "全选";
            this.btnViewSelectAll.UseVisualStyleBackColor = true;
            this.btnViewSelectAll.Click += new System.EventHandler(this.btnViewSelectAll_Click);
            // 
            // newList
            // 
            this.newList.BackColor = System.Drawing.SystemColors.Window;
            this.newList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newList.CheckOnClick = true;
            this.newList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newList.FormattingEnabled = true;
            this.newList.HorizontalScrollbar = true;
            this.newList.Location = new System.Drawing.Point(21, 25);
            this.newList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.newList.Name = "newList";
            this.newList.Size = new System.Drawing.Size(283, 338);
            this.newList.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(865, 442);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(139, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelUnExistsEntity);
            this.groupBox3.Controls.Add(this.btnUnExistsSelectNone);
            this.groupBox3.Controls.Add(this.btnUnExistsSelectAll);
            this.groupBox3.Controls.Add(this.unexistsList);
            this.groupBox3.Location = new System.Drawing.Point(679, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(325, 428);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "多余的实体";
            // 
            // btnDelUnExistsEntity
            // 
            this.btnDelUnExistsEntity.Location = new System.Drawing.Point(205, 378);
            this.btnDelUnExistsEntity.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelUnExistsEntity.Name = "btnDelUnExistsEntity";
            this.btnDelUnExistsEntity.Size = new System.Drawing.Size(100, 29);
            this.btnDelUnExistsEntity.TabIndex = 5;
            this.btnDelUnExistsEntity.Text = "删除实体";
            this.btnDelUnExistsEntity.UseVisualStyleBackColor = true;
            this.btnDelUnExistsEntity.Click += new System.EventHandler(this.btnDelUnExistsEntity_Click);
            // 
            // btnUnExistsSelectNone
            // 
            this.btnUnExistsSelectNone.Location = new System.Drawing.Point(113, 378);
            this.btnUnExistsSelectNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnExistsSelectNone.Name = "btnUnExistsSelectNone";
            this.btnUnExistsSelectNone.Size = new System.Drawing.Size(84, 29);
            this.btnUnExistsSelectNone.TabIndex = 4;
            this.btnUnExistsSelectNone.Text = "全取消";
            this.btnUnExistsSelectNone.UseVisualStyleBackColor = true;
            this.btnUnExistsSelectNone.Click += new System.EventHandler(this.btnUnExistsSelectNone_Click);
            // 
            // btnUnExistsSelectAll
            // 
            this.btnUnExistsSelectAll.Location = new System.Drawing.Point(21, 378);
            this.btnUnExistsSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnExistsSelectAll.Name = "btnUnExistsSelectAll";
            this.btnUnExistsSelectAll.Size = new System.Drawing.Size(84, 29);
            this.btnUnExistsSelectAll.TabIndex = 3;
            this.btnUnExistsSelectAll.Text = "全选";
            this.btnUnExistsSelectAll.UseVisualStyleBackColor = true;
            this.btnUnExistsSelectAll.Click += new System.EventHandler(this.btnUnExistsSelectAll_Click);
            // 
            // unexistsList
            // 
            this.unexistsList.BackColor = System.Drawing.SystemColors.Window;
            this.unexistsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unexistsList.CheckOnClick = true;
            this.unexistsList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unexistsList.FormattingEnabled = true;
            this.unexistsList.HorizontalScrollbar = true;
            this.unexistsList.Location = new System.Drawing.Point(21, 25);
            this.unexistsList.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.unexistsList.Name = "unexistsList";
            this.unexistsList.Size = new System.Drawing.Size(283, 338);
            this.unexistsList.TabIndex = 0;
            // 
            // tabCreate
            // 
            this.tabCreate.Controls.Add(this.tabEntity);
            this.tabCreate.Controls.Add(this.tabTemp);
            this.tabCreate.Location = new System.Drawing.Point(16, 15);
            this.tabCreate.Margin = new System.Windows.Forms.Padding(4);
            this.tabCreate.Name = "tabCreate";
            this.tabCreate.Padding = new System.Drawing.Point(16, 8);
            this.tabCreate.SelectedIndex = 0;
            this.tabCreate.Size = new System.Drawing.Size(1027, 540);
            this.tabCreate.TabIndex = 6;
            this.tabCreate.SelectedIndexChanged += new System.EventHandler(this.tabCreate_SelectedIndexChanged);
            // 
            // tabEntity
            // 
            this.tabEntity.Controls.Add(this.groupBox1);
            this.tabEntity.Controls.Add(this.btnCancel);
            this.tabEntity.Controls.Add(this.btnRefresh);
            this.tabEntity.Controls.Add(this.groupBox3);
            this.tabEntity.Controls.Add(this.groupBox2);
            this.tabEntity.Location = new System.Drawing.Point(4, 35);
            this.tabEntity.Margin = new System.Windows.Forms.Padding(4);
            this.tabEntity.Name = "tabEntity";
            this.tabEntity.Padding = new System.Windows.Forms.Padding(4);
            this.tabEntity.Size = new System.Drawing.Size(1019, 501);
            this.tabEntity.TabIndex = 0;
            this.tabEntity.Text = "生成实体";
            this.tabEntity.UseVisualStyleBackColor = true;
            // 
            // tabTemp
            // 
            this.tabTemp.Controls.Add(this.txtPath);
            this.tabTemp.Controls.Add(this.path);
            this.tabTemp.Controls.Add(this.txtFileName);
            this.tabTemp.Controls.Add(this.fileName);
            this.tabTemp.Controls.Add(this.txtType);
            this.tabTemp.Controls.Add(this.labInfo);
            this.tabTemp.Controls.Add(this.groupBox5);
            this.tabTemp.Controls.Add(this.cmbList);
            this.tabTemp.Controls.Add(this.groupBox4);
            this.tabTemp.Location = new System.Drawing.Point(4, 35);
            this.tabTemp.Margin = new System.Windows.Forms.Padding(4);
            this.tabTemp.Name = "tabTemp";
            this.tabTemp.Padding = new System.Windows.Forms.Padding(4);
            this.tabTemp.Size = new System.Drawing.Size(1019, 501);
            this.tabTemp.TabIndex = 1;
            this.tabTemp.Text = "模版配置";
            this.tabTemp.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(644, 462);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(363, 25);
            this.txtPath.TabIndex = 7;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(592, 466);
            this.path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(39, 15);
            this.path.TabIndex = 6;
            this.path.Text = "path";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(395, 462);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(181, 25);
            this.txtFileName.TabIndex = 5;
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(313, 466);
            this.fileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(71, 15);
            this.fileName.TabIndex = 4;
            this.fileName.Text = "fileName";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(265, 462);
            this.txtType.Margin = new System.Windows.Forms.Padding(4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(33, 25);
            this.txtType.TabIndex = 3;
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Location = new System.Drawing.Point(219, 466);
            this.labInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(39, 15);
            this.labInfo.TabIndex = 2;
            this.labInfo.Text = "type";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtTemplate);
            this.groupBox5.Location = new System.Drawing.Point(8, 8);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1000, 448);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "实体模版";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(825, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 320);
            this.label2.TabIndex = 1;
            this.label2.Text = "单个实体结构：\r\n{ \r\n  name: 表名\r\n  cols: 列数组\r\n}\r\n\r\n列结构：\r\n{\r\n  name: 列名\r\n  clrtype: 类型\r\n  " +
    "length: 长度\r\n  allownull: 是否可空\r\n  identity: 是否标识列\r\n  desc: 列描述\r\n  iskey: 是否主键\r\n}";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTemplate.Location = new System.Drawing.Point(8, 25);
            this.txtTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.txtTemplate.Multiline = true;
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTemplate.Size = new System.Drawing.Size(795, 402);
            this.txtTemplate.TabIndex = 0;
            this.txtTemplate.Text = "using System;\r\npublic class $entity.name {\r\n#foreach($c in $entity.cols)\r\n#if($c." +
    "desc != $c.name)\r\n\t/// <summary>\r\n\t/// $c.desc\r\n\t/// </summary>\r\n#end\r\n\tpublic $" +
    "c.clrtype $c.name{ get; set; }\r\n#end\r\n}";
            // 
            // cmbList
            // 
            this.cmbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbList.FormattingEnabled = true;
            this.cmbList.Location = new System.Drawing.Point(8, 462);
            this.cmbList.Margin = new System.Windows.Forms.Padding(4);
            this.cmbList.Name = "cmbList";
            this.cmbList.Size = new System.Drawing.Size(201, 23);
            this.cmbList.TabIndex = 1;
            this.cmbList.SelectedIndexChanged += new System.EventHandler(this.cmbList_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtEntity);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1000, 416);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "实体模版";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(825, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 320);
            this.label1.TabIndex = 1;
            this.label1.Text = "单个实体结构：\r\n{ \r\n  name: 表名\r\n  cols: 列数组\r\n}\r\n\r\n列结构：\r\n{\r\n  name: 列名\r\n  clrtype: 类型\r\n  " +
    "length: 长度\r\n  allownull: 是否可空\r\n  identity: 是否标识列\r\n  desc: 列描述\r\n  iskey: 是否主键\r\n}";
            // 
            // txtEntity
            // 
            this.txtEntity.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEntity.Location = new System.Drawing.Point(8, 25);
            this.txtEntity.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntity.Multiline = true;
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEntity.Size = new System.Drawing.Size(795, 379);
            this.txtEntity.TabIndex = 0;
            this.txtEntity.Text = "using System;\r\npublic class $entity.name {\r\n#foreach($c in $entity.cols)\r\n#if($c." +
    "desc != $c.name)\r\n\t/// <summary>\r\n\t/// $c.desc\r\n\t/// </summary>\r\n#end\r\n\tpublic $" +
    "c.clrtype $c.name{ get; set; }\r\n#end\r\n}";
            // 
            // FormBatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 571);
            this.Controls.Add(this.tabCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormBatchView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量添加/更新";
            this.Load += new System.EventHandler(this.FormAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabCreate.ResumeLayout(false);
            this.tabEntity.ResumeLayout(false);
            this.tabTemp.ResumeLayout(false);
            this.tabTemp.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox addedList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox newList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEntitySelectNone;
        private System.Windows.Forms.Button btnEntitySelectAll;
        private System.Windows.Forms.Button btnViewSelectNone;
        private System.Windows.Forms.Button btnViewSelectAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUnExistsSelectNone;
        private System.Windows.Forms.Button btnUnExistsSelectAll;
        private System.Windows.Forms.CheckedListBox unexistsList;
        private System.Windows.Forms.Button btnDelUnExistsEntity;
        private System.Windows.Forms.TabControl tabCreate;
        private System.Windows.Forms.TabPage tabEntity;
        private System.Windows.Forms.TabPage tabTemp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.ComboBox cmbList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.TextBox txtType;
    }
}