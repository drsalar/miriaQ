namespace miriaQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importBT = new System.Windows.Forms.Button();
            this.exportBT = new System.Windows.Forms.Button();
            this.selectCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.queryBT = new System.Windows.Forms.Button();
            this.warningLB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.account,
            this.password,
            this.name,
            this.tel,
            this.school,
            this.course,
            this.times});
            this.dataGridView1.Location = new System.Drawing.Point(69, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(743, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // account
            // 
            this.account.HeaderText = "账号";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            // 
            // password
            // 
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // tel
            // 
            this.tel.HeaderText = "手机号";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            // 
            // school
            // 
            this.school.HeaderText = "学校";
            this.school.Name = "school";
            this.school.ReadOnly = true;
            // 
            // course
            // 
            this.course.HeaderText = "课程完成度";
            this.course.Name = "course";
            this.course.ReadOnly = true;
            // 
            // times
            // 
            this.times.HeaderText = "剩余天数";
            this.times.Name = "times";
            this.times.ReadOnly = true;
            // 
            // importBT
            // 
            this.importBT.Location = new System.Drawing.Point(69, 496);
            this.importBT.Name = "importBT";
            this.importBT.Size = new System.Drawing.Size(140, 51);
            this.importBT.TabIndex = 1;
            this.importBT.Text = "批量导入";
            this.importBT.UseVisualStyleBackColor = true;
            this.importBT.Click += new System.EventHandler(this.importBT_Click);
            // 
            // exportBT
            // 
            this.exportBT.Location = new System.Drawing.Point(301, 496);
            this.exportBT.Name = "exportBT";
            this.exportBT.Size = new System.Drawing.Size(141, 51);
            this.exportBT.TabIndex = 2;
            this.exportBT.Text = "导出EXCEL";
            this.exportBT.UseVisualStyleBackColor = true;
            this.exportBT.Click += new System.EventHandler(this.exportBT_Click);
            // 
            // selectCB
            // 
            this.selectCB.FormattingEnabled = true;
            this.selectCB.Items.AddRange(new object[] {
            "朗文交互英语第一级",
            "朗文交互英语第二级",
            "朗文交互英语第三级",
            "朗文交互英语第四级",
            "新交互大学英语1",
            "新交互大学英语2",
            "新交互大学英语3",
            "新交互大学英语4",
            "大学英语实用技能",
            "Academic Connections 1",
            "Academic Connections 2",
            "Academic Connections 3",
            "Academic Connections 4"});
            this.selectCB.Location = new System.Drawing.Point(569, 512);
            this.selectCB.Name = "selectCB";
            this.selectCB.Size = new System.Drawing.Size(121, 20);
            this.selectCB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择课程";
            // 
            // queryBT
            // 
            this.queryBT.Location = new System.Drawing.Point(710, 510);
            this.queryBT.Name = "queryBT";
            this.queryBT.Size = new System.Drawing.Size(75, 23);
            this.queryBT.TabIndex = 7;
            this.queryBT.Text = "查询课程";
            this.queryBT.UseVisualStyleBackColor = true;
            this.queryBT.Click += new System.EventHandler(this.queryBT_Click);
            // 
            // warningLB
            // 
            this.warningLB.AutoSize = true;
            this.warningLB.ForeColor = System.Drawing.Color.Red;
            this.warningLB.Location = new System.Drawing.Point(567, 548);
            this.warningLB.Name = "warningLB";
            this.warningLB.Size = new System.Drawing.Size(137, 12);
            this.warningLB.TabIndex = 8;
            this.warningLB.Text = "请选择课程或者输入课程";
            this.warningLB.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 617);
            this.Controls.Add(this.warningLB);
            this.Controls.Add(this.queryBT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectCB);
            this.Controls.Add(this.exportBT);
            this.Controls.Add(this.importBT);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn school;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn times;
        private System.Windows.Forms.Button importBT;
        private System.Windows.Forms.Button exportBT;
        private System.Windows.Forms.ComboBox selectCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button queryBT;
        private System.Windows.Forms.Label warningLB;
    }
}

