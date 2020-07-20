namespace pro_view.fld_PL.fld_General_Settings
{
    partial class frm_permissions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_aname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbx_Details = new System.Windows.Forms.GroupBox();
            this.btn_permGroup_CancelAll = new System.Windows.Forms.Button();
            this.btn_permGroup_SelectAll = new System.Windows.Forms.Button();
            this.dgv_permgroup = new System.Windows.Forms.DataGridView();
            this.col_OKpermGroup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_permuser = new System.Windows.Forms.DataGridView();
            this.col_OKpermuser = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_permuser_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_permuser_CancelAll = new System.Windows.Forms.Button();
            this.btn_permuser_SelectAll = new System.Windows.Forms.Button();
            this.btn_perm_CancelAll = new System.Windows.Forms.Button();
            this.btn_perm_SelectAll = new System.Windows.Forms.Button();
            this.btn_f = new System.Windows.Forms.Button();
            this.btn_b = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_perm = new System.Windows.Forms.DataGridView();
            this.OK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_permid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.gbx_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permgroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_perm)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_aname
            // 
            this.txt_aname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_aname.Location = new System.Drawing.Point(656, 49);
            this.txt_aname.Name = "txt_aname";
            this.txt_aname.ReadOnly = true;
            this.txt_aname.Size = new System.Drawing.Size(208, 22);
            this.txt_aname.TabIndex = 1;
            this.txt_aname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(877, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "أسم المستخدم";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(877, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "كود المستخدم";
            // 
            // gbx_Details
            // 
            this.gbx_Details.Controls.Add(this.btn_permGroup_CancelAll);
            this.gbx_Details.Controls.Add(this.btn_permGroup_SelectAll);
            this.gbx_Details.Controls.Add(this.dgv_permgroup);
            this.gbx_Details.Controls.Add(this.label3);
            this.gbx_Details.Controls.Add(this.dgv_permuser);
            this.gbx_Details.Controls.Add(this.btn_permuser_CancelAll);
            this.gbx_Details.Controls.Add(this.btn_permuser_SelectAll);
            this.gbx_Details.Controls.Add(this.btn_perm_CancelAll);
            this.gbx_Details.Controls.Add(this.btn_perm_SelectAll);
            this.gbx_Details.Controls.Add(this.btn_f);
            this.gbx_Details.Controls.Add(this.btn_b);
            this.gbx_Details.Controls.Add(this.label6);
            this.gbx_Details.Controls.Add(this.label5);
            this.gbx_Details.Controls.Add(this.dgv_perm);
            this.gbx_Details.Controls.Add(this.txt_aname);
            this.gbx_Details.Controls.Add(this.label2);
            this.gbx_Details.Controls.Add(this.txt_id);
            this.gbx_Details.Controls.Add(this.label1);
            this.gbx_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Details.Location = new System.Drawing.Point(0, 0);
            this.gbx_Details.Name = "gbx_Details";
            this.gbx_Details.Size = new System.Drawing.Size(980, 584);
            this.gbx_Details.TabIndex = 10;
            this.gbx_Details.TabStop = false;
            // 
            // btn_permGroup_CancelAll
            // 
            this.btn_permGroup_CancelAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_permGroup_CancelAll.Location = new System.Drawing.Point(731, 525);
            this.btn_permGroup_CancelAll.Name = "btn_permGroup_CancelAll";
            this.btn_permGroup_CancelAll.Size = new System.Drawing.Size(63, 26);
            this.btn_permGroup_CancelAll.TabIndex = 44;
            this.btn_permGroup_CancelAll.Text = "إلغاء الكل";
            this.btn_permGroup_CancelAll.UseVisualStyleBackColor = true;
            this.btn_permGroup_CancelAll.Click += new System.EventHandler(this.Btn_permGroup_CancelAll_Click);
            // 
            // btn_permGroup_SelectAll
            // 
            this.btn_permGroup_SelectAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_permGroup_SelectAll.Location = new System.Drawing.Point(800, 525);
            this.btn_permGroup_SelectAll.Name = "btn_permGroup_SelectAll";
            this.btn_permGroup_SelectAll.Size = new System.Drawing.Size(66, 26);
            this.btn_permGroup_SelectAll.TabIndex = 43;
            this.btn_permGroup_SelectAll.Text = "تحديد الكل";
            this.btn_permGroup_SelectAll.UseVisualStyleBackColor = true;
            this.btn_permGroup_SelectAll.Click += new System.EventHandler(this.Btn_permGroup_SelectAll_Click);
            // 
            // dgv_permgroup
            // 
            this.dgv_permgroup.AllowUserToAddRows = false;
            this.dgv_permgroup.AllowUserToDeleteRows = false;
            this.dgv_permgroup.AllowUserToResizeColumns = false;
            this.dgv_permgroup.AllowUserToResizeRows = false;
            this.dgv_permgroup.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_permgroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permgroup.ColumnHeadersVisible = false;
            this.dgv_permgroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_OKpermGroup,
            this.dataGridViewTextBoxColumn1,
            this.col_id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_permgroup.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_permgroup.GridColor = System.Drawing.SystemColors.Window;
            this.dgv_permgroup.Location = new System.Drawing.Point(656, 134);
            this.dgv_permgroup.Name = "dgv_permgroup";
            this.dgv_permgroup.ReadOnly = true;
            this.dgv_permgroup.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_permgroup.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_permgroup.RowTemplate.Height = 27;
            this.dgv_permgroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_permgroup.Size = new System.Drawing.Size(250, 385);
            this.dgv_permgroup.TabIndex = 42;
            this.dgv_permgroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_permgroup_CellClick);
            this.dgv_permgroup.SelectionChanged += new System.EventHandler(this.Dgv_permgroup_SelectionChanged);
            // 
            // col_OKpermGroup
            // 
            this.col_OKpermGroup.HeaderText = "chk";
            this.col_OKpermGroup.Name = "col_OKpermGroup";
            this.col_OKpermGroup.ReadOnly = true;
            this.col_OKpermGroup.Visible = false;
            this.col_OKpermGroup.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(764, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 41;
            this.label3.Text = "المجموعات";
            // 
            // dgv_permuser
            // 
            this.dgv_permuser.AllowUserToAddRows = false;
            this.dgv_permuser.AllowUserToDeleteRows = false;
            this.dgv_permuser.AllowUserToResizeColumns = false;
            this.dgv_permuser.AllowUserToResizeRows = false;
            this.dgv_permuser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_permuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_permuser.ColumnHeadersVisible = false;
            this.dgv_permuser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_OKpermuser,
            this.dataGridViewTextBoxColumn3,
            this.col_permuser_id});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_permuser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_permuser.GridColor = System.Drawing.SystemColors.Window;
            this.dgv_permuser.Location = new System.Drawing.Point(58, 134);
            this.dgv_permuser.Name = "dgv_permuser";
            this.dgv_permuser.ReadOnly = true;
            this.dgv_permuser.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_permuser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_permuser.RowTemplate.Height = 27;
            this.dgv_permuser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_permuser.Size = new System.Drawing.Size(250, 385);
            this.dgv_permuser.TabIndex = 39;
            this.dgv_permuser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_permuser_CellClick);
            this.dgv_permuser.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_permuser_CellMouseDoubleClick);
            this.dgv_permuser.SelectionChanged += new System.EventHandler(this.Dgv_permuser_SelectionChanged);
            // 
            // col_OKpermuser
            // 
            this.col_OKpermuser.HeaderText = "chk";
            this.col_OKpermuser.Name = "col_OKpermuser";
            this.col_OKpermuser.ReadOnly = true;
            this.col_OKpermuser.Visible = false;
            this.col_OKpermuser.Width = 20;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // col_permuser_id
            // 
            this.col_permuser_id.HeaderText = "ID";
            this.col_permuser_id.Name = "col_permuser_id";
            this.col_permuser_id.ReadOnly = true;
            this.col_permuser_id.Visible = false;
            // 
            // btn_permuser_CancelAll
            // 
            this.btn_permuser_CancelAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_permuser_CancelAll.Location = new System.Drawing.Point(122, 525);
            this.btn_permuser_CancelAll.Name = "btn_permuser_CancelAll";
            this.btn_permuser_CancelAll.Size = new System.Drawing.Size(63, 26);
            this.btn_permuser_CancelAll.TabIndex = 37;
            this.btn_permuser_CancelAll.Text = "إلغاء الكل";
            this.btn_permuser_CancelAll.UseVisualStyleBackColor = true;
            this.btn_permuser_CancelAll.Click += new System.EventHandler(this.Btn_permuser_CancelAll_Click);
            // 
            // btn_permuser_SelectAll
            // 
            this.btn_permuser_SelectAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_permuser_SelectAll.Location = new System.Drawing.Point(191, 525);
            this.btn_permuser_SelectAll.Name = "btn_permuser_SelectAll";
            this.btn_permuser_SelectAll.Size = new System.Drawing.Size(66, 26);
            this.btn_permuser_SelectAll.TabIndex = 36;
            this.btn_permuser_SelectAll.Text = "تحديد الكل";
            this.btn_permuser_SelectAll.UseVisualStyleBackColor = true;
            this.btn_permuser_SelectAll.Click += new System.EventHandler(this.Btn_permuser_SelectAll_Click);
            // 
            // btn_perm_CancelAll
            // 
            this.btn_perm_CancelAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_perm_CancelAll.Location = new System.Drawing.Point(393, 525);
            this.btn_perm_CancelAll.Name = "btn_perm_CancelAll";
            this.btn_perm_CancelAll.Size = new System.Drawing.Size(63, 26);
            this.btn_perm_CancelAll.TabIndex = 35;
            this.btn_perm_CancelAll.Text = "إلغاء الكل";
            this.btn_perm_CancelAll.UseVisualStyleBackColor = true;
            this.btn_perm_CancelAll.Click += new System.EventHandler(this.Btn_perm_CancelAll_Click);
            // 
            // btn_perm_SelectAll
            // 
            this.btn_perm_SelectAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btn_perm_SelectAll.Location = new System.Drawing.Point(462, 525);
            this.btn_perm_SelectAll.Name = "btn_perm_SelectAll";
            this.btn_perm_SelectAll.Size = new System.Drawing.Size(66, 26);
            this.btn_perm_SelectAll.TabIndex = 34;
            this.btn_perm_SelectAll.Text = "تحديد الكل";
            this.btn_perm_SelectAll.UseVisualStyleBackColor = true;
            this.btn_perm_SelectAll.Click += new System.EventHandler(this.Btn_perm_SelectAll_Click);
            // 
            // btn_f
            // 
            this.btn_f.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_f.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_f.Location = new System.Drawing.Point(314, 302);
            this.btn_f.Name = "btn_f";
            this.btn_f.Size = new System.Drawing.Size(26, 26);
            this.btn_f.TabIndex = 32;
            this.btn_f.Text = ">";
            this.btn_f.UseVisualStyleBackColor = true;
            this.btn_f.Click += new System.EventHandler(this.Btn_f_Click);
            // 
            // btn_b
            // 
            this.btn_b.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_b.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_b.Location = new System.Drawing.Point(314, 334);
            this.btn_b.Name = "btn_b";
            this.btn_b.Size = new System.Drawing.Size(26, 26);
            this.btn_b.TabIndex = 31;
            this.btn_b.Text = "<";
            this.btn_b.UseVisualStyleBackColor = true;
            this.btn_b.Click += new System.EventHandler(this.Btn_b_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(429, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "غير مسموح به";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "مسموح به";
            // 
            // dgv_perm
            // 
            this.dgv_perm.AllowUserToAddRows = false;
            this.dgv_perm.AllowUserToDeleteRows = false;
            this.dgv_perm.AllowUserToResizeColumns = false;
            this.dgv_perm.AllowUserToResizeRows = false;
            this.dgv_perm.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_perm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_perm.ColumnHeadersVisible = false;
            this.dgv_perm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OK,
            this.dataGridViewTextBoxColumn9,
            this.col_permid});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_perm.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_perm.GridColor = System.Drawing.SystemColors.Window;
            this.dgv_perm.Location = new System.Drawing.Point(346, 134);
            this.dgv_perm.Name = "dgv_perm";
            this.dgv_perm.ReadOnly = true;
            this.dgv_perm.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_perm.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_perm.RowTemplate.Height = 27;
            this.dgv_perm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_perm.Size = new System.Drawing.Size(250, 385);
            this.dgv_perm.TabIndex = 28;
            this.dgv_perm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_perm_CellClick);
            this.dgv_perm.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_perm_CellMouseDoubleClick);
            this.dgv_perm.SelectionChanged += new System.EventHandler(this.Dgv_perm_SelectionChanged);
            // 
            // OK
            // 
            this.OK.HeaderText = "chk";
            this.OK.Name = "OK";
            this.OK.ReadOnly = true;
            this.OK.Visible = false;
            this.OK.Width = 20;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn9.HeaderText = "Name";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // col_permid
            // 
            this.col_permid.HeaderText = "ID";
            this.col_permid.Name = "col_permid";
            this.col_permid.ReadOnly = true;
            this.col_permid.Visible = false;
            // 
            // txt_id
            // 
            this.txt_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_id.Location = new System.Drawing.Point(791, 22);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(73, 22);
            this.txt_id.TabIndex = 0;
            this.txt_id.TabStop = false;
            this.txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frm_permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 584);
            this.Controls.Add(this.gbx_Details);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_permissions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.frm_G_Shown);
            this.gbx_Details.ResumeLayout(false);
            this.gbx_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permgroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_permuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_perm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txt_aname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbx_Details;
        public System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button btn_permuser_CancelAll;
        private System.Windows.Forms.Button btn_permuser_SelectAll;
        private System.Windows.Forms.Button btn_perm_CancelAll;
        private System.Windows.Forms.Button btn_perm_SelectAll;
        private System.Windows.Forms.Button btn_f;
        private System.Windows.Forms.Button btn_b;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_perm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_permid;
        private System.Windows.Forms.DataGridView dgv_permuser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_OKpermuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_permuser_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_permgroup;
        private System.Windows.Forms.Button btn_permGroup_CancelAll;
        private System.Windows.Forms.Button btn_permGroup_SelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_OKpermGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
    }
}