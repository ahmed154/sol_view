namespace pro_view.fld_PL.fld_Accounting
{
    partial class frm_statement
    {
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_statement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Display = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_PrintPreview = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.groupBox_Header = new System.Windows.Forms.GroupBox();
            this.txt_Ghost = new System.Windows.Forms.TextBox();
            this.dgv_txt_AutoComplete = new System.Windows.Forms.DataGridView();
            this.chart_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_AutoComplete = new System.Windows.Forms.DataGridView();
            this.auto_ChartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auto_ChartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_form = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox_Details = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctype_aname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Footer_Details = new System.Windows.Forms.GroupBox();
            this.txt_TotalBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TotalCredit = new System.Windows.Forms.TextBox();
            this.txt_TotalDebit = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_TotalOpen = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.contextMenuStrip_branches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_cc1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_cc2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnl_Head = new System.Windows.Forms.Panel();
            this.com_CC2 = new System.Windows.Forms.ComboBox();
            this.com_CC1 = new System.Windows.Forms.ComboBox();
            this.com_Branches = new System.Windows.Forms.ComboBox();
            this.btn_cc2_del = new System.Windows.Forms.Button();
            this.btn_CC2 = new System.Windows.Forms.Button();
            this.btn_cc1_del = new System.Windows.Forms.Button();
            this.btn_CC1 = new System.Windows.Forms.Button();
            this.btn_DelBranch = new System.Windows.Forms.Button();
            this.btn_Branch = new System.Windows.Forms.Button();
            this.chk_PrevFyears = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_txt_AutoComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AutoComplete)).BeginInit();
            this.groupBox_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox_Footer_Details.SuspendLayout();
            this.pnl_Head.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Display);
            this.groupBox1.Controls.Add(this.btn_Print);
            this.groupBox1.Controls.Add(this.btn_PrintPreview);
            this.groupBox1.Controls.Add(this.btn_ExportToExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1167, 100);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // btn_Display
            // 
            this.btn_Display.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Display.FlatAppearance.BorderSize = 0;
            this.btn_Display.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Display.Location = new System.Drawing.Point(222, 16);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(69, 81);
            this.btn_Display.TabIndex = 4;
            this.btn_Display.Text = "عرض";
            this.btn_Display.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.button_Display_Click);
            this.btn_Display.MouseEnter += new System.EventHandler(this.button_Display_MouseEnter);
            this.btn_Display.MouseLeave += new System.EventHandler(this.button_Display_MouseLeave);
            // 
            // btn_Print
            // 
            this.btn_Print.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.ImageKey = "Print";
            this.btn_Print.Location = new System.Drawing.Point(153, 16);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 81);
            this.btn_Print.TabIndex = 8;
            this.btn_Print.Text = "طباعة";
            this.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_PrintPreview
            // 
            this.btn_PrintPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_PrintPreview.FlatAppearance.BorderSize = 0;
            this.btn_PrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PrintPreview.ImageKey = "Settings";
            this.btn_PrintPreview.Location = new System.Drawing.Point(84, 16);
            this.btn_PrintPreview.Name = "btn_PrintPreview";
            this.btn_PrintPreview.Size = new System.Drawing.Size(69, 81);
            this.btn_PrintPreview.TabIndex = 7;
            this.btn_PrintPreview.Text = "معاينة قبل الطباعة";
            this.btn_PrintPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_PrintPreview.UseVisualStyleBackColor = true;
            this.btn_PrintPreview.Click += new System.EventHandler(this.btn_PrintPreview_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ExportToExcel.FlatAppearance.BorderSize = 0;
            this.btn_ExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportToExcel.Location = new System.Drawing.Point(3, 16);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(81, 81);
            this.btn_ExportToExcel.TabIndex = 9;
            this.btn_ExportToExcel.Text = "تصدير للاكسل";
            this.btn_ExportToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_ExportToExcel.UseVisualStyleBackColor = true;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // groupBox_Header
            // 
            this.groupBox_Header.Controls.Add(this.chk_PrevFyears);
            this.groupBox_Header.Controls.Add(this.txt_Ghost);
            this.groupBox_Header.Controls.Add(this.dgv_txt_AutoComplete);
            this.groupBox_Header.Controls.Add(this.dgv_AutoComplete);
            this.groupBox_Header.Controls.Add(this.label3);
            this.groupBox_Header.Controls.Add(this.dtp_to);
            this.groupBox_Header.Controls.Add(this.label1);
            this.groupBox_Header.Controls.Add(this.dtp_form);
            this.groupBox_Header.Controls.Add(this.label7);
            this.groupBox_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Header.Location = new System.Drawing.Point(0, 153);
            this.groupBox_Header.Name = "groupBox_Header";
            this.groupBox_Header.Size = new System.Drawing.Size(1167, 112);
            this.groupBox_Header.TabIndex = 54;
            this.groupBox_Header.TabStop = false;
            this.groupBox_Header.Tag = "";
            // 
            // txt_Ghost
            // 
            this.txt_Ghost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Ghost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ghost.Location = new System.Drawing.Point(784, 19);
            this.txt_Ghost.Name = "txt_Ghost";
            this.txt_Ghost.Size = new System.Drawing.Size(327, 22);
            this.txt_Ghost.TabIndex = 154;
            this.txt_Ghost.Visible = false;
            this.txt_Ghost.TextChanged += new System.EventHandler(this.txt_Ghost_TextChanged);
            this.txt_Ghost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Ghost_KeyDown);
            this.txt_Ghost.Leave += new System.EventHandler(this.txt_Ghost_Leave);
            // 
            // dgv_txt_AutoComplete
            // 
            this.dgv_txt_AutoComplete.AllowUserToAddRows = false;
            this.dgv_txt_AutoComplete.AllowUserToDeleteRows = false;
            this.dgv_txt_AutoComplete.AllowUserToResizeRows = false;
            this.dgv_txt_AutoComplete.BackgroundColor = System.Drawing.Color.White;
            this.dgv_txt_AutoComplete.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_txt_AutoComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_txt_AutoComplete.ColumnHeadersVisible = false;
            this.dgv_txt_AutoComplete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chart_name,
            this.chart_id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_txt_AutoComplete.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_txt_AutoComplete.Location = new System.Drawing.Point(784, 19);
            this.dgv_txt_AutoComplete.MultiSelect = false;
            this.dgv_txt_AutoComplete.Name = "dgv_txt_AutoComplete";
            this.dgv_txt_AutoComplete.ReadOnly = true;
            this.dgv_txt_AutoComplete.RowHeadersVisible = false;
            this.dgv_txt_AutoComplete.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_txt_AutoComplete.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_txt_AutoComplete.Size = new System.Drawing.Size(327, 22);
            this.dgv_txt_AutoComplete.TabIndex = 157;
            this.dgv_txt_AutoComplete.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_txt_AutoComplete_CellMouseClick);
            // 
            // chart_name
            // 
            this.chart_name.DataPropertyName = "aname";
            this.chart_name.HeaderText = "auto_ChartName";
            this.chart_name.Name = "chart_name";
            this.chart_name.ReadOnly = true;
            // 
            // chart_id
            // 
            this.chart_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chart_id.DataPropertyName = "id";
            this.chart_id.HeaderText = "auto_ChartID";
            this.chart_id.Name = "chart_id";
            this.chart_id.ReadOnly = true;
            // 
            // dgv_AutoComplete
            // 
            this.dgv_AutoComplete.AllowUserToAddRows = false;
            this.dgv_AutoComplete.AllowUserToDeleteRows = false;
            this.dgv_AutoComplete.AllowUserToResizeRows = false;
            this.dgv_AutoComplete.BackgroundColor = System.Drawing.Color.White;
            this.dgv_AutoComplete.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_AutoComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AutoComplete.ColumnHeadersVisible = false;
            this.dgv_AutoComplete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.auto_ChartName,
            this.auto_ChartID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AutoComplete.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_AutoComplete.Location = new System.Drawing.Point(784, 42);
            this.dgv_AutoComplete.MultiSelect = false;
            this.dgv_AutoComplete.Name = "dgv_AutoComplete";
            this.dgv_AutoComplete.ReadOnly = true;
            this.dgv_AutoComplete.RowHeadersVisible = false;
            this.dgv_AutoComplete.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AutoComplete.Size = new System.Drawing.Size(327, 67);
            this.dgv_AutoComplete.TabIndex = 155;
            this.dgv_AutoComplete.Visible = false;
            this.dgv_AutoComplete.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AutoComplete_CellDoubleClick);
            this.dgv_AutoComplete.SelectionChanged += new System.EventHandler(this.dgv_AutoComplete_SelectionChanged);
            // 
            // auto_ChartName
            // 
            this.auto_ChartName.DataPropertyName = "aname";
            this.auto_ChartName.HeaderText = "auto_ChartName";
            this.auto_ChartName.Name = "auto_ChartName";
            this.auto_ChartName.ReadOnly = true;
            // 
            // auto_ChartID
            // 
            this.auto_ChartID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.auto_ChartID.DataPropertyName = "id";
            this.auto_ChartID.HeaderText = "auto_ChartID";
            this.auto_ChartID.Name = "auto_ChartID";
            this.auto_ChartID.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1117, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 153;
            this.label3.Text = "الحساب";
            // 
            // dtp_to
            // 
            this.dtp_to.Checked = false;
            this.dtp_to.CustomFormat = " ";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(26, 37);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.RightToLeftLayout = true;
            this.dtp_to.ShowCheckBox = true;
            this.dtp_to.Size = new System.Drawing.Size(150, 20);
            this.dtp_to.TabIndex = 36;
            this.dtp_to.Value = new System.DateTime(2015, 9, 3, 0, 0, 0, 0);
            this.dtp_to.ValueChanged += new System.EventHandler(this.dtp_to_ValueChanged);
            this.dtp_to.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dtp_to_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "إلى تاريخ";
            // 
            // dtp_form
            // 
            this.dtp_form.Checked = false;
            this.dtp_form.CustomFormat = " ";
            this.dtp_form.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_form.Location = new System.Drawing.Point(239, 36);
            this.dtp_form.Name = "dtp_form";
            this.dtp_form.RightToLeftLayout = true;
            this.dtp_form.ShowCheckBox = true;
            this.dtp_form.Size = new System.Drawing.Size(150, 20);
            this.dtp_form.TabIndex = 27;
            this.dtp_form.Value = new System.DateTime(2015, 9, 3, 18, 11, 44, 0);
            this.dtp_form.ValueChanged += new System.EventHandler(this.dtp_form_ValueChanged);
            this.dtp_form.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dtp_form_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "من تاريخ";
            // 
            // groupBox_Details
            // 
            this.groupBox_Details.Controls.Add(this.dgv);
            this.groupBox_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Details.Location = new System.Drawing.Point(0, 265);
            this.groupBox_Details.Name = "groupBox_Details";
            this.groupBox_Details.Size = new System.Drawing.Size(1167, 370);
            this.groupBox_Details.TabIndex = 55;
            this.groupBox_Details.TabStop = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Debit,
            this.Credit,
            this.Balance,
            this.Notes,
            this.jor_id,
            this.Date,
            this.doctype_aname,
            this.doc_id});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.Location = new System.Drawing.Point(3, 16);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv.RowTemplate.Height = 30;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1161, 351);
            this.dgv.TabIndex = 16;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // Debit
            // 
            this.Debit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Debit.DataPropertyName = "Debit";
            this.Debit.HeaderText = "مدين";
            this.Debit.MinimumWidth = 2;
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.Width = 150;
            // 
            // Credit
            // 
            this.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Credit.DataPropertyName = "Credit";
            this.Credit.HeaderText = "دائن";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Balance.DataPropertyName = "Balance";
            this.Balance.FillWeight = 23.87588F;
            this.Balance.HeaderText = "الرصيد";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "البيان";
            this.Notes.MinimumWidth = 100;
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // jor_id
            // 
            this.jor_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.jor_id.DataPropertyName = "jor_id";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.NullValue = null;
            this.jor_id.DefaultCellStyle = dataGridViewCellStyle5;
            this.jor_id.FillWeight = 23.87588F;
            this.jor_id.HeaderText = "رقم القيد";
            this.jor_id.Name = "jor_id";
            this.jor_id.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 23.87588F;
            this.Date.HeaderText = "تاريخ القيد";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // doctype_aname
            // 
            this.doctype_aname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.doctype_aname.DataPropertyName = "doctype_aname";
            this.doctype_aname.FillWeight = 23.87588F;
            this.doctype_aname.HeaderText = "نوع السند";
            this.doctype_aname.Name = "doctype_aname";
            this.doctype_aname.ReadOnly = true;
            this.doctype_aname.Width = 120;
            // 
            // doc_id
            // 
            this.doc_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.doc_id.DataPropertyName = "doc_id";
            this.doc_id.HeaderText = "رقم السند";
            this.doc_id.Name = "doc_id";
            this.doc_id.ReadOnly = true;
            // 
            // groupBox_Footer_Details
            // 
            this.groupBox_Footer_Details.Controls.Add(this.txt_TotalBalance);
            this.groupBox_Footer_Details.Controls.Add(this.label2);
            this.groupBox_Footer_Details.Controls.Add(this.label4);
            this.groupBox_Footer_Details.Controls.Add(this.txt_TotalCredit);
            this.groupBox_Footer_Details.Controls.Add(this.txt_TotalDebit);
            this.groupBox_Footer_Details.Controls.Add(this.label15);
            this.groupBox_Footer_Details.Controls.Add(this.label14);
            this.groupBox_Footer_Details.Controls.Add(this.txt_TotalOpen);
            this.groupBox_Footer_Details.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_Footer_Details.Location = new System.Drawing.Point(0, 635);
            this.groupBox_Footer_Details.Name = "groupBox_Footer_Details";
            this.groupBox_Footer_Details.Size = new System.Drawing.Size(1167, 100);
            this.groupBox_Footer_Details.TabIndex = 68;
            this.groupBox_Footer_Details.TabStop = false;
            // 
            // txt_TotalBalance
            // 
            this.txt_TotalBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_TotalBalance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_TotalBalance.Location = new System.Drawing.Point(172, 48);
            this.txt_TotalBalance.Name = "txt_TotalBalance";
            this.txt_TotalBalance.ReadOnly = true;
            this.txt_TotalBalance.Size = new System.Drawing.Size(100, 24);
            this.txt_TotalBalance.TabIndex = 66;
            this.txt_TotalBalance.Text = "0.00";
            this.txt_TotalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "دائن";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "رصيد نهائي";
            // 
            // txt_TotalCredit
            // 
            this.txt_TotalCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_TotalCredit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_TotalCredit.Location = new System.Drawing.Point(477, 48);
            this.txt_TotalCredit.Name = "txt_TotalCredit";
            this.txt_TotalCredit.ReadOnly = true;
            this.txt_TotalCredit.Size = new System.Drawing.Size(100, 24);
            this.txt_TotalCredit.TabIndex = 64;
            this.txt_TotalCredit.Text = "0.00";
            this.txt_TotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TotalDebit
            // 
            this.txt_TotalDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_TotalDebit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_TotalDebit.Location = new System.Drawing.Point(583, 48);
            this.txt_TotalDebit.Name = "txt_TotalDebit";
            this.txt_TotalDebit.ReadOnly = true;
            this.txt_TotalDebit.Size = new System.Drawing.Size(100, 24);
            this.txt_TotalDebit.TabIndex = 62;
            this.txt_TotalDebit.Text = "0.00";
            this.txt_TotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(885, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 59;
            this.label15.Text = "رصيد إفتتاحي";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(616, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 61;
            this.label14.Text = "مدين";
            // 
            // txt_TotalOpen
            // 
            this.txt_TotalOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_TotalOpen.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_TotalOpen.Location = new System.Drawing.Point(864, 48);
            this.txt_TotalOpen.Name = "txt_TotalOpen";
            this.txt_TotalOpen.ReadOnly = true;
            this.txt_TotalOpen.Size = new System.Drawing.Size(100, 24);
            this.txt_TotalOpen.TabIndex = 60;
            this.txt_TotalOpen.Text = "0.00";
            this.txt_TotalOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.ShowIcon = false;
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // contextMenuStrip_branches
            // 
            this.contextMenuStrip_branches.BackColor = System.Drawing.Color.Silver;
            this.contextMenuStrip_branches.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip_branches.Name = "contextMenuStrip_branches";
            this.contextMenuStrip_branches.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip_branches.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_branches.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_branches_ItemClicked);
            // 
            // contextMenuStrip_cc1
            // 
            this.contextMenuStrip_cc1.BackColor = System.Drawing.Color.Silver;
            this.contextMenuStrip_cc1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip_cc1.Name = "contextMenuStrip_cc1";
            this.contextMenuStrip_cc1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip_cc1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_cc1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_cc1_ItemClicked);
            // 
            // contextMenuStrip_cc2
            // 
            this.contextMenuStrip_cc2.BackColor = System.Drawing.Color.Silver;
            this.contextMenuStrip_cc2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip_cc2.Name = "contextMenuStrip_cc2";
            this.contextMenuStrip_cc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip_cc2.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip_cc2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_cc2_ItemClicked);
            // 
            // pnl_Head
            // 
            this.pnl_Head.BackColor = System.Drawing.Color.Silver;
            this.pnl_Head.Controls.Add(this.com_CC2);
            this.pnl_Head.Controls.Add(this.com_CC1);
            this.pnl_Head.Controls.Add(this.com_Branches);
            this.pnl_Head.Controls.Add(this.btn_cc2_del);
            this.pnl_Head.Controls.Add(this.btn_CC2);
            this.pnl_Head.Controls.Add(this.btn_cc1_del);
            this.pnl_Head.Controls.Add(this.btn_CC1);
            this.pnl_Head.Controls.Add(this.btn_DelBranch);
            this.pnl_Head.Controls.Add(this.btn_Branch);
            this.pnl_Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Head.Location = new System.Drawing.Point(0, 0);
            this.pnl_Head.Name = "pnl_Head";
            this.pnl_Head.Size = new System.Drawing.Size(1167, 53);
            this.pnl_Head.TabIndex = 76;
            // 
            // com_CC2
            // 
            this.com_CC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_CC2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.com_CC2.DisplayMember = "aname";
            this.com_CC2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_CC2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.com_CC2.FormattingEnabled = true;
            this.com_CC2.Location = new System.Drawing.Point(846, 0);
            this.com_CC2.Name = "com_CC2";
            this.com_CC2.Size = new System.Drawing.Size(93, 21);
            this.com_CC2.TabIndex = 8;
            this.com_CC2.ValueMember = "id";
            this.com_CC2.Visible = false;
            this.com_CC2.SelectedIndexChanged += new System.EventHandler(this.com_CC2_SelectedIndexChanged);
            // 
            // com_CC1
            // 
            this.com_CC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_CC1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.com_CC1.DisplayMember = "aname";
            this.com_CC1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.com_CC1.FormattingEnabled = true;
            this.com_CC1.Location = new System.Drawing.Point(948, 0);
            this.com_CC1.Name = "com_CC1";
            this.com_CC1.Size = new System.Drawing.Size(88, 21);
            this.com_CC1.TabIndex = 7;
            this.com_CC1.ValueMember = "id";
            this.com_CC1.Visible = false;
            this.com_CC1.SelectedIndexChanged += new System.EventHandler(this.com_CC1_SelectedIndexChanged);
            // 
            // com_Branches
            // 
            this.com_Branches.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_Branches.BackColor = System.Drawing.Color.WhiteSmoke;
            this.com_Branches.DisplayMember = "aname";
            this.com_Branches.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.com_Branches.FormattingEnabled = true;
            this.com_Branches.Location = new System.Drawing.Point(1042, 0);
            this.com_Branches.Name = "com_Branches";
            this.com_Branches.Size = new System.Drawing.Size(122, 21);
            this.com_Branches.TabIndex = 6;
            this.com_Branches.ValueMember = "id";
            this.com_Branches.Visible = false;
            this.com_Branches.SelectedIndexChanged += new System.EventHandler(this.com_Branches_SelectedIndexChanged);
            // 
            // btn_cc2_del
            // 
            this.btn_cc2_del.BackColor = System.Drawing.Color.Transparent;
            this.btn_cc2_del.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cc2_del.FlatAppearance.BorderSize = 0;
            this.btn_cc2_del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_cc2_del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btn_cc2_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cc2_del.Location = new System.Drawing.Point(452, 0);
            this.btn_cc2_del.Name = "btn_cc2_del";
            this.btn_cc2_del.Size = new System.Drawing.Size(20, 53);
            this.btn_cc2_del.TabIndex = 47;
            this.btn_cc2_del.UseVisualStyleBackColor = false;
            this.btn_cc2_del.Visible = false;
            this.btn_cc2_del.Click += new System.EventHandler(this.btn_cc2_del_Click);
            this.btn_cc2_del.MouseEnter += new System.EventHandler(this.btn_cc2_del_MouseEnter);
            this.btn_cc2_del.MouseLeave += new System.EventHandler(this.btn_cc2_del_MouseLeave);
            // 
            // btn_CC2
            // 
            this.btn_CC2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CC2.FlatAppearance.BorderSize = 0;
            this.btn_CC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CC2.Location = new System.Drawing.Point(472, 0);
            this.btn_CC2.Name = "btn_CC2";
            this.btn_CC2.Size = new System.Drawing.Size(232, 53);
            this.btn_CC2.TabIndex = 40;
            this.btn_CC2.Text = "مركز 2 : ";
            this.btn_CC2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CC2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CC2.UseVisualStyleBackColor = true;
            this.btn_CC2.Click += new System.EventHandler(this.btn_CC2_Click);
            this.btn_CC2.MouseEnter += new System.EventHandler(this.btn_CC2_MouseEnter);
            this.btn_CC2.MouseLeave += new System.EventHandler(this.btn_CC2_MouseLeave);
            // 
            // btn_cc1_del
            // 
            this.btn_cc1_del.BackColor = System.Drawing.Color.Transparent;
            this.btn_cc1_del.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cc1_del.FlatAppearance.BorderSize = 0;
            this.btn_cc1_del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_cc1_del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btn_cc1_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cc1_del.Location = new System.Drawing.Point(704, 0);
            this.btn_cc1_del.Name = "btn_cc1_del";
            this.btn_cc1_del.Size = new System.Drawing.Size(20, 53);
            this.btn_cc1_del.TabIndex = 46;
            this.btn_cc1_del.UseVisualStyleBackColor = false;
            this.btn_cc1_del.Visible = false;
            this.btn_cc1_del.Click += new System.EventHandler(this.btn_cc1_del_Click);
            this.btn_cc1_del.MouseEnter += new System.EventHandler(this.btn_cc1_del_MouseEnter);
            this.btn_cc1_del.MouseLeave += new System.EventHandler(this.btn_cc1_del_MouseLeave);
            // 
            // btn_CC1
            // 
            this.btn_CC1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_CC1.FlatAppearance.BorderSize = 0;
            this.btn_CC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CC1.Location = new System.Drawing.Point(724, 0);
            this.btn_CC1.Name = "btn_CC1";
            this.btn_CC1.Size = new System.Drawing.Size(220, 53);
            this.btn_CC1.TabIndex = 38;
            this.btn_CC1.Text = "مركز 1 :";
            this.btn_CC1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CC1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CC1.UseVisualStyleBackColor = true;
            this.btn_CC1.Click += new System.EventHandler(this.btn_CC1_Click);
            this.btn_CC1.MouseEnter += new System.EventHandler(this.btn_CC1_MouseEnter);
            this.btn_CC1.MouseLeave += new System.EventHandler(this.btn_CC1_MouseLeave);
            // 
            // btn_DelBranch
            // 
            this.btn_DelBranch.BackColor = System.Drawing.Color.Transparent;
            this.btn_DelBranch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_DelBranch.FlatAppearance.BorderSize = 0;
            this.btn_DelBranch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_DelBranch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btn_DelBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DelBranch.Location = new System.Drawing.Point(944, 0);
            this.btn_DelBranch.Name = "btn_DelBranch";
            this.btn_DelBranch.Size = new System.Drawing.Size(20, 53);
            this.btn_DelBranch.TabIndex = 48;
            this.btn_DelBranch.UseVisualStyleBackColor = false;
            this.btn_DelBranch.Visible = false;
            this.btn_DelBranch.Click += new System.EventHandler(this.btn_DelBranch_Click);
            // 
            // btn_Branch
            // 
            this.btn_Branch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Branch.FlatAppearance.BorderSize = 0;
            this.btn_Branch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Branch.Location = new System.Drawing.Point(964, 0);
            this.btn_Branch.Name = "btn_Branch";
            this.btn_Branch.Size = new System.Drawing.Size(203, 53);
            this.btn_Branch.TabIndex = 34;
            this.btn_Branch.Text = "الفرع :";
            this.btn_Branch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Branch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Branch.UseVisualStyleBackColor = true;
            this.btn_Branch.Click += new System.EventHandler(this.btn_Bill_Branche_Click);
            this.btn_Branch.MouseEnter += new System.EventHandler(this.lbl_bill_Branches_MouseEnter);
            this.btn_Branch.MouseLeave += new System.EventHandler(this.lbl_bill_Branches_MouseLeave);
            // 
            // chk_PrevFyears
            // 
            this.chk_PrevFyears.AutoSize = true;
            this.chk_PrevFyears.Location = new System.Drawing.Point(273, 76);
            this.chk_PrevFyears.Name = "chk_PrevFyears";
            this.chk_PrevFyears.Size = new System.Drawing.Size(116, 17);
            this.chk_PrevFyears.TabIndex = 158;
            this.chk_PrevFyears.Text = "يشمل أعوام سابقة";
            this.chk_PrevFyears.UseVisualStyleBackColor = true;
            // 
            // frm_statement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 735);
            this.Controls.Add(this.groupBox_Details);
            this.Controls.Add(this.groupBox_Footer_Details);
            this.Controls.Add(this.groupBox_Header);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnl_Head);
            this.Name = "frm_statement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب";
            this.Shown += new System.EventHandler(this.frm_ST_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_Header.ResumeLayout(false);
            this.groupBox_Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_txt_AutoComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AutoComplete)).EndInit();
            this.groupBox_Details.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox_Footer_Details.ResumeLayout(false);
            this.groupBox_Footer_Details.PerformLayout();
            this.pnl_Head.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btn_Print;
        public System.Windows.Forms.Button btn_PrintPreview;
        public System.Windows.Forms.Button btn_Display;
        public System.Windows.Forms.GroupBox groupBox_Header;
        private System.Windows.Forms.DateTimePicker dtp_form;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.GroupBox groupBox_Details;
        public System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox_Footer_Details;
        public System.Windows.Forms.TextBox txt_TotalDebit;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txt_TotalOpen;
        private System.Windows.Forms.DateTimePicker dtp_to;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_TotalBalance;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_TotalCredit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridView dgv_AutoComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn auto_ChartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn auto_ChartID;
        private System.Windows.Forms.TextBox txt_Ghost;
        private System.Windows.Forms.DataGridView dgv_txt_AutoComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn chart_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chart_id;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_branches;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_cc1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_cc2;
        private System.Windows.Forms.Panel pnl_Head;
        public System.Windows.Forms.ComboBox com_CC2;
        public System.Windows.Forms.ComboBox com_CC1;
        public System.Windows.Forms.ComboBox com_Branches;
        private System.Windows.Forms.Button btn_cc2_del;
        private System.Windows.Forms.Button btn_CC2;
        private System.Windows.Forms.Button btn_cc1_del;
        private System.Windows.Forms.Button btn_CC1;
        private System.Windows.Forms.Button btn_Branch;
        private System.Windows.Forms.Button btn_DelBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn jor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctype_aname;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_id;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.CheckBox chk_PrevFyears;
    }
}