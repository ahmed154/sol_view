namespace pro_view.fld_PL.fld_Accounting.fld_Settings
{
    partial class frm_jorclose
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
            this.dgv_branches = new System.Windows.Forms.DataGridView();
            this.branch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branch_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.com_oldfyear = new System.Windows.Forms.ComboBox();
            this.com_newfyear = new System.Windows.Forms.ComboBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.btn_CancelAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.chk_cc = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_branches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_branches
            // 
            this.dgv_branches.AllowUserToAddRows = false;
            this.dgv_branches.AllowUserToDeleteRows = false;
            this.dgv_branches.AllowUserToOrderColumns = true;
            this.dgv_branches.AllowUserToResizeColumns = false;
            this.dgv_branches.AllowUserToResizeRows = false;
            this.dgv_branches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_branches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_branches.ColumnHeadersVisible = false;
            this.dgv_branches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.branch_id,
            this.branch_name,
            this.chk});
            this.dgv_branches.Location = new System.Drawing.Point(12, 12);
            this.dgv_branches.Name = "dgv_branches";
            this.dgv_branches.ReadOnly = true;
            this.dgv_branches.RowHeadersVisible = false;
            this.dgv_branches.Size = new System.Drawing.Size(564, 274);
            this.dgv_branches.TabIndex = 0;
            this.dgv_branches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_branches_CellClick);
            this.dgv_branches.SelectionChanged += new System.EventHandler(this.dgv_branches_SelectionChanged);
            // 
            // branch_id
            // 
            this.branch_id.HeaderText = "branch_id";
            this.branch_id.Name = "branch_id";
            this.branch_id.ReadOnly = true;
            this.branch_id.Width = 50;
            // 
            // branch_name
            // 
            this.branch_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.branch_name.HeaderText = "branch_name";
            this.branch_name.Name = "branch_name";
            this.branch_name.ReadOnly = true;
            // 
            // chk
            // 
            this.chk.HeaderText = "chk";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.Width = 20;
            // 
            // com_oldfyear
            // 
            this.com_oldfyear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_oldfyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_oldfyear.FormattingEnabled = true;
            this.com_oldfyear.Location = new System.Drawing.Point(121, 360);
            this.com_oldfyear.Name = "com_oldfyear";
            this.com_oldfyear.Size = new System.Drawing.Size(121, 21);
            this.com_oldfyear.TabIndex = 1;
            // 
            // com_newfyear
            // 
            this.com_newfyear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_newfyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_newfyear.FormattingEnabled = true;
            this.com_newfyear.Location = new System.Drawing.Point(121, 401);
            this.com_newfyear.Name = "com_newfyear";
            this.com_newfyear.Size = new System.Drawing.Size(121, 21);
            this.com_newfyear.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(12, 596);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(576, 50);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "إقفال";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_notes
            // 
            this.txt_notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_notes.Location = new System.Drawing.Point(114, 558);
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.Size = new System.Drawing.Size(462, 20);
            this.txt_notes.TabIndex = 4;
            // 
            // btn_CancelAll
            // 
            this.btn_CancelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CancelAll.Location = new System.Drawing.Point(476, 292);
            this.btn_CancelAll.Name = "btn_CancelAll";
            this.btn_CancelAll.Size = new System.Drawing.Size(93, 30);
            this.btn_CancelAll.TabIndex = 7;
            this.btn_CancelAll.Text = "إلغاء الجميع";
            this.btn_CancelAll.UseVisualStyleBackColor = true;
            this.btn_CancelAll.Click += new System.EventHandler(this.btn_CancelAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectAll.Location = new System.Drawing.Point(377, 292);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(93, 30);
            this.btn_SelectAll.TabIndex = 6;
            this.btn_SelectAll.Text = "اختيار الجميع";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // chk_cc
            // 
            this.chk_cc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_cc.AutoSize = true;
            this.chk_cc.Location = new System.Drawing.Point(15, 455);
            this.chk_cc.Name = "chk_cc";
            this.chk_cc.Size = new System.Drawing.Size(114, 17);
            this.chk_cc.TabIndex = 8;
            this.chk_cc.Text = "تحليل مراكز التكلفة";
            this.chk_cc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "العام المالي المنتهي";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "العام المالي الجديد";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "بيان القيد الإفتتاحي";
            // 
            // frm_jorclose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 658);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_cc);
            this.Controls.Add(this.btn_CancelAll);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.txt_notes);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.com_newfyear);
            this.Controls.Add(this.com_oldfyear);
            this.Controls.Add(this.dgv_branches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_jorclose";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إقفال الحسابات";
            this.Shown += new System.EventHandler(this.frm_jorclose_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_branches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn branch_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        public System.Windows.Forms.DataGridView dgv_branches;
        public System.Windows.Forms.ComboBox com_oldfyear;
        public System.Windows.Forms.ComboBox com_newfyear;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Button btn_CancelAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.CheckBox chk_cc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}