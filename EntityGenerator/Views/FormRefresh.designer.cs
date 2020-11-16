namespace EntityGenerator.Views
{
    partial class FormRefresh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRefresh));
            this.entityList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEntitySelectNone = new System.Windows.Forms.Button();
            this.btnEntitySelectAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewSelectNone = new System.Windows.Forms.Button();
            this.btnViewSelectAll = new System.Windows.Forms.Button();
            this.viewList = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // entityList
            // 
            this.entityList.BackColor = System.Drawing.SystemColors.Window;
            this.entityList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.entityList.CheckOnClick = true;
            this.entityList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityList.FormattingEnabled = true;
            this.entityList.HorizontalScrollbar = true;
            this.entityList.Location = new System.Drawing.Point(16, 20);
            this.entityList.Margin = new System.Windows.Forms.Padding(5);
            this.entityList.Name = "entityList";
            this.entityList.Size = new System.Drawing.Size(213, 274);
            this.entityList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEntitySelectNone);
            this.groupBox1.Controls.Add(this.btnEntitySelectAll);
            this.groupBox1.Controls.Add(this.entityList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 342);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "尚未添加的实体列表";
            // 
            // btnEntitySelectNone
            // 
            this.btnEntitySelectNone.Location = new System.Drawing.Point(166, 302);
            this.btnEntitySelectNone.Name = "btnEntitySelectNone";
            this.btnEntitySelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnEntitySelectNone.TabIndex = 2;
            this.btnEntitySelectNone.Text = "全取消";
            this.btnEntitySelectNone.UseVisualStyleBackColor = true;
            // 
            // btnEntitySelectAll
            // 
            this.btnEntitySelectAll.Location = new System.Drawing.Point(97, 302);
            this.btnEntitySelectAll.Name = "btnEntitySelectAll";
            this.btnEntitySelectAll.Size = new System.Drawing.Size(63, 23);
            this.btnEntitySelectAll.TabIndex = 1;
            this.btnEntitySelectAll.Text = "全选";
            this.btnEntitySelectAll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewSelectNone);
            this.groupBox2.Controls.Add(this.btnViewSelectAll);
            this.groupBox2.Controls.Add(this.viewList);
            this.groupBox2.Location = new System.Drawing.Point(276, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 342);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "尚添加的未视图列表";
            // 
            // btnViewSelectNone
            // 
            this.btnViewSelectNone.Location = new System.Drawing.Point(166, 302);
            this.btnViewSelectNone.Name = "btnViewSelectNone";
            this.btnViewSelectNone.Size = new System.Drawing.Size(63, 23);
            this.btnViewSelectNone.TabIndex = 4;
            this.btnViewSelectNone.Text = "全取消";
            this.btnViewSelectNone.UseVisualStyleBackColor = true;
            // 
            // btnViewSelectAll
            // 
            this.btnViewSelectAll.Location = new System.Drawing.Point(97, 302);
            this.btnViewSelectAll.Name = "btnViewSelectAll";
            this.btnViewSelectAll.Size = new System.Drawing.Size(63, 23);
            this.btnViewSelectAll.TabIndex = 3;
            this.btnViewSelectAll.Text = "全选";
            this.btnViewSelectAll.UseVisualStyleBackColor = true;
            // 
            // viewList
            // 
            this.viewList.BackColor = System.Drawing.SystemColors.Window;
            this.viewList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewList.CheckOnClick = true;
            this.viewList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewList.FormattingEnabled = true;
            this.viewList.HorizontalScrollbar = true;
            this.viewList.Location = new System.Drawing.Point(16, 20);
            this.viewList.Margin = new System.Windows.Forms.Padding(5);
            this.viewList.Name = "viewList";
            this.viewList.Size = new System.Drawing.Size(213, 274);
            this.viewList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(292, 368);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(118, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加选中的项(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 33);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "关闭(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormRefresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 414);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRefresh";
            this.Text = "批量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox entityList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEntitySelectNone;
        private System.Windows.Forms.Button btnEntitySelectAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewSelectNone;
        private System.Windows.Forms.Button btnViewSelectAll;
        private System.Windows.Forms.CheckedListBox viewList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}