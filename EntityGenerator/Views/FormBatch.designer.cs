namespace EntityGenerator.Views
{
    partial class FormBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatch));
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
            this.tabSqlView = new System.Windows.Forms.TabPage();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.ddlViewEntityDirectory = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSqlViewDirectory = new System.Windows.Forms.ComboBox();
            this.btnRefleshViews = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSqlViewEntity = new System.Windows.Forms.Button();
            this.cbSqlViewNotExists = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSqlViewAddingSelectNone = new System.Windows.Forms.Button();
            this.btnSqlViewAddingSelectAll = new System.Windows.Forms.Button();
            this.cbSqlViewAdding = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSqlViewSelectNone = new System.Windows.Forms.Button();
            this.btnSqlViewSelectAll = new System.Windows.Forms.Button();
            this.cbSqlViewAdded = new System.Windows.Forms.CheckedListBox();
            this.lbl_namespace = new System.Windows.Forms.Label();
            this.tbx_namespace = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabCreate.SuspendLayout();
            this.tabEntity.SuspendLayout();
            this.tabSqlView.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.addedList.Location = new System.Drawing.Point(16, 20);
            this.addedList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.addedList.Name = "addedList";
            this.addedList.Size = new System.Drawing.Size(213, 274);
            this.addedList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEntitySelectNone);
            this.groupBox1.Controls.Add(this.btnEntitySelectAll);
            this.groupBox1.Controls.Add(this.addedList);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 349);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已添加的实体列表";
            // 
            // btnEntitySelectNone
            // 
            this.btnEntitySelectNone.Location = new System.Drawing.Point(166, 319);
            this.btnEntitySelectNone.Name = "btnEntitySelectNone";
            this.btnEntitySelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnEntitySelectNone.TabIndex = 2;
            this.btnEntitySelectNone.Text = "全取消";
            this.btnEntitySelectNone.UseVisualStyleBackColor = true;
            this.btnEntitySelectNone.Click += new System.EventHandler(this.btnEntitySelectNone_Click);
            // 
            // btnEntitySelectAll
            // 
            this.btnEntitySelectAll.Location = new System.Drawing.Point(97, 319);
            this.btnEntitySelectAll.Name = "btnEntitySelectAll";
            this.btnEntitySelectAll.Size = new System.Drawing.Size(63, 23);
            this.btnEntitySelectAll.TabIndex = 1;
            this.btnEntitySelectAll.Text = "全选";
            this.btnEntitySelectAll.UseVisualStyleBackColor = true;
            this.btnEntitySelectAll.Click += new System.EventHandler(this.btnEntitySelectAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(502, 362);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "添加/刷新选中的项(&A)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewSelectNone);
            this.groupBox2.Controls.Add(this.btnViewSelectAll);
            this.groupBox2.Controls.Add(this.newList);
            this.groupBox2.Location = new System.Drawing.Point(260, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 349);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "尚未添加的实体";
            // 
            // btnViewSelectNone
            // 
            this.btnViewSelectNone.Location = new System.Drawing.Point(165, 319);
            this.btnViewSelectNone.Name = "btnViewSelectNone";
            this.btnViewSelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnViewSelectNone.TabIndex = 4;
            this.btnViewSelectNone.Text = "全取消";
            this.btnViewSelectNone.UseVisualStyleBackColor = true;
            this.btnViewSelectNone.Click += new System.EventHandler(this.btnViewSelectNone_Click);
            // 
            // btnViewSelectAll
            // 
            this.btnViewSelectAll.Location = new System.Drawing.Point(97, 319);
            this.btnViewSelectAll.Name = "btnViewSelectAll";
            this.btnViewSelectAll.Size = new System.Drawing.Size(63, 23);
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
            this.newList.Location = new System.Drawing.Point(16, 20);
            this.newList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.newList.Name = "newList";
            this.newList.Size = new System.Drawing.Size(213, 274);
            this.newList.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(664, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
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
            this.groupBox3.Location = new System.Drawing.Point(509, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 349);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据库中不存在的实体";
            // 
            // btnDelUnExistsEntity
            // 
            this.btnDelUnExistsEntity.Location = new System.Drawing.Point(154, 319);
            this.btnDelUnExistsEntity.Name = "btnDelUnExistsEntity";
            this.btnDelUnExistsEntity.Size = new System.Drawing.Size(75, 23);
            this.btnDelUnExistsEntity.TabIndex = 5;
            this.btnDelUnExistsEntity.Text = "移除实体";
            this.btnDelUnExistsEntity.UseVisualStyleBackColor = true;
            this.btnDelUnExistsEntity.Click += new System.EventHandler(this.btnDelUnExistsEntity_Click);
            // 
            // btnUnExistsSelectNone
            // 
            this.btnUnExistsSelectNone.Location = new System.Drawing.Point(85, 319);
            this.btnUnExistsSelectNone.Name = "btnUnExistsSelectNone";
            this.btnUnExistsSelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnUnExistsSelectNone.TabIndex = 4;
            this.btnUnExistsSelectNone.Text = "全取消";
            this.btnUnExistsSelectNone.UseVisualStyleBackColor = true;
            this.btnUnExistsSelectNone.Click += new System.EventHandler(this.btnUnExistsSelectNone_Click);
            // 
            // btnUnExistsSelectAll
            // 
            this.btnUnExistsSelectAll.Location = new System.Drawing.Point(16, 319);
            this.btnUnExistsSelectAll.Name = "btnUnExistsSelectAll";
            this.btnUnExistsSelectAll.Size = new System.Drawing.Size(63, 23);
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
            this.unexistsList.Location = new System.Drawing.Point(16, 20);
            this.unexistsList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.unexistsList.Name = "unexistsList";
            this.unexistsList.Size = new System.Drawing.Size(213, 274);
            this.unexistsList.TabIndex = 0;
            // 
            // tabCreate
            // 
            this.tabCreate.Controls.Add(this.tabEntity);
            this.tabCreate.Controls.Add(this.tabSqlView);
            this.tabCreate.Location = new System.Drawing.Point(12, 12);
            this.tabCreate.Name = "tabCreate";
            this.tabCreate.Padding = new System.Drawing.Point(16, 8);
            this.tabCreate.SelectedIndex = 0;
            this.tabCreate.Size = new System.Drawing.Size(770, 432);
            this.tabCreate.TabIndex = 6;
            this.tabCreate.SelectedIndexChanged += new System.EventHandler(this.tabCreate_SelectedIndexChanged);
            // 
            // tabEntity
            // 
            this.tabEntity.Controls.Add(this.tbx_namespace);
            this.tabEntity.Controls.Add(this.lbl_namespace);
            this.tabEntity.Controls.Add(this.groupBox1);
            this.tabEntity.Controls.Add(this.btnCancel);
            this.tabEntity.Controls.Add(this.btnRefresh);
            this.tabEntity.Controls.Add(this.groupBox3);
            this.tabEntity.Controls.Add(this.groupBox2);
            this.tabEntity.Location = new System.Drawing.Point(4, 32);
            this.tabEntity.Name = "tabEntity";
            this.tabEntity.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabEntity.Size = new System.Drawing.Size(762, 396);
            this.tabEntity.TabIndex = 0;
            this.tabEntity.Text = "DB实体";
            this.tabEntity.UseVisualStyleBackColor = true;
            // 
            // tabSqlView
            // 
            this.tabSqlView.Controls.Add(this.btnClose2);
            this.tabSqlView.Controls.Add(this.ddlViewEntityDirectory);
            this.tabSqlView.Controls.Add(this.label22);
            this.tabSqlView.Controls.Add(this.label1);
            this.tabSqlView.Controls.Add(this.cbSqlViewDirectory);
            this.tabSqlView.Controls.Add(this.btnRefleshViews);
            this.tabSqlView.Controls.Add(this.groupBox6);
            this.tabSqlView.Controls.Add(this.groupBox5);
            this.tabSqlView.Controls.Add(this.groupBox4);
            this.tabSqlView.Location = new System.Drawing.Point(4, 32);
            this.tabSqlView.Name = "tabSqlView";
            this.tabSqlView.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabSqlView.Size = new System.Drawing.Size(762, 396);
            this.tabSqlView.TabIndex = 1;
            this.tabSqlView.Text = "SqlView实体";
            this.tabSqlView.UseVisualStyleBackColor = true;
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(664, 362);
            this.btnClose2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(88, 32);
            this.btnClose2.TabIndex = 13;
            this.btnClose2.Text = "关闭(&C)";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // ddlViewEntityDirectory
            // 
            this.ddlViewEntityDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlViewEntityDirectory.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ddlViewEntityDirectory.FormattingEnabled = true;
            this.ddlViewEntityDirectory.Location = new System.Drawing.Point(317, 374);
            this.ddlViewEntityDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlViewEntityDirectory.Name = "ddlViewEntityDirectory";
            this.ddlViewEntityDirectory.Size = new System.Drawing.Size(151, 21);
            this.ddlViewEntityDirectory.TabIndex = 12;
            this.ddlViewEntityDirectory.SelectedIndexChanged += new System.EventHandler(this.ddlViewEntityDirectory_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(251, 376);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 11;
            this.label22.Text = "实体目录：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 376);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "SqlView目录：";
            // 
            // cbSqlViewDirectory
            // 
            this.cbSqlViewDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSqlViewDirectory.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSqlViewDirectory.FormattingEnabled = true;
            this.cbSqlViewDirectory.Location = new System.Drawing.Point(90, 372);
            this.cbSqlViewDirectory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSqlViewDirectory.Name = "cbSqlViewDirectory";
            this.cbSqlViewDirectory.Size = new System.Drawing.Size(142, 21);
            this.cbSqlViewDirectory.TabIndex = 9;
            this.cbSqlViewDirectory.SelectedIndexChanged += new System.EventHandler(this.cbSqlViewDirectory_SelectedIndexChanged);
            // 
            // btnRefleshViews
            // 
            this.btnRefleshViews.Location = new System.Drawing.Point(502, 362);
            this.btnRefleshViews.Name = "btnRefleshViews";
            this.btnRefleshViews.Size = new System.Drawing.Size(142, 33);
            this.btnRefleshViews.TabIndex = 7;
            this.btnRefleshViews.Text = "添加/刷新选中的项(&A)";
            this.btnRefleshViews.UseVisualStyleBackColor = true;
            this.btnRefleshViews.Click += new System.EventHandler(this.btnRefleshViews_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRemoveSqlViewEntity);
            this.groupBox6.Controls.Add(this.cbSqlViewNotExists);
            this.groupBox6.Location = new System.Drawing.Point(509, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(244, 349);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "可能多余的实体类";
            // 
            // btnRemoveSqlViewEntity
            // 
            this.btnRemoveSqlViewEntity.Location = new System.Drawing.Point(153, 319);
            this.btnRemoveSqlViewEntity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveSqlViewEntity.Name = "btnRemoveSqlViewEntity";
            this.btnRemoveSqlViewEntity.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSqlViewEntity.TabIndex = 1;
            this.btnRemoveSqlViewEntity.Text = "移除实体";
            this.btnRemoveSqlViewEntity.UseVisualStyleBackColor = true;
            this.btnRemoveSqlViewEntity.Click += new System.EventHandler(this.btnRemoveSqlViewEntity_Click);
            // 
            // cbSqlViewNotExists
            // 
            this.cbSqlViewNotExists.BackColor = System.Drawing.SystemColors.Window;
            this.cbSqlViewNotExists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbSqlViewNotExists.CheckOnClick = true;
            this.cbSqlViewNotExists.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSqlViewNotExists.FormattingEnabled = true;
            this.cbSqlViewNotExists.HorizontalScrollbar = true;
            this.cbSqlViewNotExists.Location = new System.Drawing.Point(16, 20);
            this.cbSqlViewNotExists.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbSqlViewNotExists.Name = "cbSqlViewNotExists";
            this.cbSqlViewNotExists.Size = new System.Drawing.Size(213, 274);
            this.cbSqlViewNotExists.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSqlViewAddingSelectNone);
            this.groupBox5.Controls.Add(this.btnSqlViewAddingSelectAll);
            this.groupBox5.Controls.Add(this.cbSqlViewAdding);
            this.groupBox5.Location = new System.Drawing.Point(260, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 349);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "尚未添加的实体";
            // 
            // btnSqlViewAddingSelectNone
            // 
            this.btnSqlViewAddingSelectNone.Location = new System.Drawing.Point(165, 319);
            this.btnSqlViewAddingSelectNone.Name = "btnSqlViewAddingSelectNone";
            this.btnSqlViewAddingSelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnSqlViewAddingSelectNone.TabIndex = 4;
            this.btnSqlViewAddingSelectNone.Text = "全取消";
            this.btnSqlViewAddingSelectNone.UseVisualStyleBackColor = true;
            this.btnSqlViewAddingSelectNone.Click += new System.EventHandler(this.btnSqlViewAddingSelectNone_Click);
            // 
            // btnSqlViewAddingSelectAll
            // 
            this.btnSqlViewAddingSelectAll.Location = new System.Drawing.Point(97, 319);
            this.btnSqlViewAddingSelectAll.Name = "btnSqlViewAddingSelectAll";
            this.btnSqlViewAddingSelectAll.Size = new System.Drawing.Size(63, 23);
            this.btnSqlViewAddingSelectAll.TabIndex = 3;
            this.btnSqlViewAddingSelectAll.Text = "全选";
            this.btnSqlViewAddingSelectAll.UseVisualStyleBackColor = true;
            this.btnSqlViewAddingSelectAll.Click += new System.EventHandler(this.btnSqlViewAddingSelectAll_Click);
            // 
            // cbSqlViewAdding
            // 
            this.cbSqlViewAdding.BackColor = System.Drawing.SystemColors.Window;
            this.cbSqlViewAdding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbSqlViewAdding.CheckOnClick = true;
            this.cbSqlViewAdding.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSqlViewAdding.FormattingEnabled = true;
            this.cbSqlViewAdding.HorizontalScrollbar = true;
            this.cbSqlViewAdding.Location = new System.Drawing.Point(16, 20);
            this.cbSqlViewAdding.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbSqlViewAdding.Name = "cbSqlViewAdding";
            this.cbSqlViewAdding.Size = new System.Drawing.Size(213, 274);
            this.cbSqlViewAdding.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSqlViewSelectNone);
            this.groupBox4.Controls.Add(this.btnSqlViewSelectAll);
            this.groupBox4.Controls.Add(this.cbSqlViewAdded);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(244, 349);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "已添加的实体列表";
            // 
            // btnSqlViewSelectNone
            // 
            this.btnSqlViewSelectNone.Location = new System.Drawing.Point(166, 319);
            this.btnSqlViewSelectNone.Name = "btnSqlViewSelectNone";
            this.btnSqlViewSelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnSqlViewSelectNone.TabIndex = 2;
            this.btnSqlViewSelectNone.Text = "全取消";
            this.btnSqlViewSelectNone.UseVisualStyleBackColor = true;
            this.btnSqlViewSelectNone.Click += new System.EventHandler(this.btnSqlViewSelectNone_Click);
            // 
            // btnSqlViewSelectAll
            // 
            this.btnSqlViewSelectAll.Location = new System.Drawing.Point(97, 319);
            this.btnSqlViewSelectAll.Name = "btnSqlViewSelectAll";
            this.btnSqlViewSelectAll.Size = new System.Drawing.Size(63, 23);
            this.btnSqlViewSelectAll.TabIndex = 1;
            this.btnSqlViewSelectAll.Text = "全选";
            this.btnSqlViewSelectAll.UseVisualStyleBackColor = true;
            this.btnSqlViewSelectAll.Click += new System.EventHandler(this.btnSqlViewSelectAll_Click);
            // 
            // cbSqlViewAdded
            // 
            this.cbSqlViewAdded.BackColor = System.Drawing.SystemColors.Window;
            this.cbSqlViewAdded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbSqlViewAdded.CheckOnClick = true;
            this.cbSqlViewAdded.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSqlViewAdded.FormattingEnabled = true;
            this.cbSqlViewAdded.HorizontalScrollbar = true;
            this.cbSqlViewAdded.Location = new System.Drawing.Point(16, 20);
            this.cbSqlViewAdded.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbSqlViewAdded.Name = "cbSqlViewAdded";
            this.cbSqlViewAdded.Size = new System.Drawing.Size(213, 274);
            this.cbSqlViewAdded.TabIndex = 0;
            // 
            // lbl_namespace
            // 
            this.lbl_namespace.AutoSize = true;
            this.lbl_namespace.Location = new System.Drawing.Point(6, 368);
            this.lbl_namespace.Name = "lbl_namespace";
            this.lbl_namespace.Size = new System.Drawing.Size(59, 12);
            this.lbl_namespace.TabIndex = 6;
            this.lbl_namespace.Text = "命名空间:";
            // 
            // tbx_namespace
            // 
            this.tbx_namespace.Location = new System.Drawing.Point(71, 364);
            this.tbx_namespace.Name = "tbx_namespace";
            this.tbx_namespace.Size = new System.Drawing.Size(179, 21);
            this.tbx_namespace.TabIndex = 7;
            // 
            // FormBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 457);
            this.Controls.Add(this.tabCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量添加/更新";
            this.Load += new System.EventHandler(this.FormBatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabCreate.ResumeLayout(false);
            this.tabEntity.ResumeLayout(false);
            this.tabEntity.PerformLayout();
            this.tabSqlView.ResumeLayout(false);
            this.tabSqlView.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabSqlView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSqlViewSelectNone;
        private System.Windows.Forms.Button btnSqlViewSelectAll;
        private System.Windows.Forms.CheckedListBox cbSqlViewAdded;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox cbSqlViewNotExists;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnSqlViewAddingSelectNone;
        private System.Windows.Forms.Button btnSqlViewAddingSelectAll;
        private System.Windows.Forms.CheckedListBox cbSqlViewAdding;
        private System.Windows.Forms.Button btnRefleshViews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSqlViewDirectory;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox ddlViewEntityDirectory;
        private System.Windows.Forms.Button btnRemoveSqlViewEntity;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.TextBox tbx_namespace;
        private System.Windows.Forms.Label lbl_namespace;
    }
}