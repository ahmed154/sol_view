namespace pro_view.fld_PL.fld_Accounting
{
    partial class frm_repdes
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
            this.grx_Settings = new System.Windows.Forms.GroupBox();
            this.com_Fields = new System.Windows.Forms.ComboBox();
            this.btn_DeleteRep = new System.Windows.Forms.Button();
            this.com_SelectedRep = new System.Windows.Forms.ComboBox();
            this.btn_SaveRep = new System.Windows.Forms.Button();
            this.txt_RepName = new System.Windows.Forms.TextBox();
            this.btn_Display = new System.Windows.Forms.Button();
            this.btn_ExportToExcel = new System.Windows.Forms.Button();
            this.tab_Settings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl_SortFields = new System.Windows.Forms.Panel();
            this.btn_MoveLast = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_MoveFirst = new System.Windows.Forms.Button();
            this.lst_SelectedFields = new System.Windows.Forms.ListBox();
            this.num_FontSize = new System.Windows.Forms.NumericUpDown();
            this.lbl_FontSize = new System.Windows.Forms.Label();
            this.chk_Index = new System.Windows.Forms.CheckBox();
            this.num_RecordsNumber = new System.Windows.Forms.NumericUpDown();
            this.rad_Only = new System.Windows.Forms.RadioButton();
            this.rad_AllRecords = new System.Windows.Forms.RadioButton();
            this.pnl_MovingFields = new System.Windows.Forms.Panel();
            this.btn_BackwardAll = new System.Windows.Forms.Button();
            this.btn_ForwardAll = new System.Windows.Forms.Button();
            this.btn_Backward = new System.Windows.Forms.Button();
            this.btn_Forward = new System.Windows.Forms.Button();
            this.lst_AvailableFields = new System.Windows.Forms.ListBox();
            this.pnl_FieldsTitle = new System.Windows.Forms.Panel();
            this.lbl_SelectedFields = new System.Windows.Forms.Label();
            this.lbl_AvailableFields = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_Conditions = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_SQL = new System.Windows.Forms.TextBox();
            this.grx_Rep = new System.Windows.Forms.GroupBox();
            this.dgv_Rep = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_RepCondition = new System.Windows.Forms.Label();
            this.lbl_RepTitle = new System.Windows.Forms.Label();
            this.col_field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_not = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AndOr = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_group = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_order = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.grx_Settings.SuspendLayout();
            this.tab_Settings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnl_SortFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_FontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RecordsNumber)).BeginInit();
            this.pnl_MovingFields.SuspendLayout();
            this.pnl_FieldsTitle.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conditions)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.grx_Rep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rep)).BeginInit();
            this.SuspendLayout();
            // 
            // grx_Settings
            // 
            this.grx_Settings.Controls.Add(this.com_Fields);
            this.grx_Settings.Controls.Add(this.btn_DeleteRep);
            this.grx_Settings.Controls.Add(this.com_SelectedRep);
            this.grx_Settings.Controls.Add(this.btn_SaveRep);
            this.grx_Settings.Controls.Add(this.txt_RepName);
            this.grx_Settings.Controls.Add(this.btn_Display);
            this.grx_Settings.Controls.Add(this.btn_ExportToExcel);
            this.grx_Settings.Controls.Add(this.tab_Settings);
            this.grx_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grx_Settings.Location = new System.Drawing.Point(0, 0);
            this.grx_Settings.Name = "grx_Settings";
            this.grx_Settings.Size = new System.Drawing.Size(1401, 191);
            this.grx_Settings.TabIndex = 0;
            this.grx_Settings.TabStop = false;
            // 
            // com_Fields
            // 
            this.com_Fields.DisplayMember = "Column_Name";
            this.com_Fields.FormattingEnabled = true;
            this.com_Fields.Location = new System.Drawing.Point(397, 37);
            this.com_Fields.Name = "com_Fields";
            this.com_Fields.Size = new System.Drawing.Size(131, 21);
            this.com_Fields.TabIndex = 9;
            this.com_Fields.ValueMember = "Data_Type";
            this.com_Fields.Visible = false;
            // 
            // btn_DeleteRep
            // 
            this.btn_DeleteRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DeleteRep.Location = new System.Drawing.Point(598, 154);
            this.btn_DeleteRep.Name = "btn_DeleteRep";
            this.btn_DeleteRep.Size = new System.Drawing.Size(144, 34);
            this.btn_DeleteRep.TabIndex = 6;
            this.btn_DeleteRep.Text = "حذف التقرير   ";
            this.btn_DeleteRep.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_DeleteRep.UseVisualStyleBackColor = true;
            // 
            // com_SelectedRep
            // 
            this.com_SelectedRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_SelectedRep.FormattingEnabled = true;
            this.com_SelectedRep.Location = new System.Drawing.Point(598, 127);
            this.com_SelectedRep.Name = "com_SelectedRep";
            this.com_SelectedRep.Size = new System.Drawing.Size(144, 21);
            this.com_SelectedRep.TabIndex = 5;
            this.com_SelectedRep.SelectedIndexChanged += new System.EventHandler(this.com_SelectedRep_SelectedIndexChanged);
            // 
            // btn_SaveRep
            // 
            this.btn_SaveRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveRep.Location = new System.Drawing.Point(598, 64);
            this.btn_SaveRep.Name = "btn_SaveRep";
            this.btn_SaveRep.Size = new System.Drawing.Size(144, 34);
            this.btn_SaveRep.TabIndex = 4;
            this.btn_SaveRep.Text = "حفظ التقرير   ";
            this.btn_SaveRep.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_SaveRep.UseVisualStyleBackColor = true;
            this.btn_SaveRep.Click += new System.EventHandler(this.btn_SaveRep_Click);
            // 
            // txt_RepName
            // 
            this.txt_RepName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_RepName.Location = new System.Drawing.Point(598, 38);
            this.txt_RepName.Name = "txt_RepName";
            this.txt_RepName.Size = new System.Drawing.Size(144, 20);
            this.txt_RepName.TabIndex = 3;
            // 
            // btn_Display
            // 
            this.btn_Display.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Display.Location = new System.Drawing.Point(130, 16);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(127, 172);
            this.btn_Display.TabIndex = 2;
            this.btn_Display.Text = "عرض";
            this.btn_Display.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Display.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // btn_ExportToExcel
            // 
            this.btn_ExportToExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ExportToExcel.Location = new System.Drawing.Point(3, 16);
            this.btn_ExportToExcel.Name = "btn_ExportToExcel";
            this.btn_ExportToExcel.Size = new System.Drawing.Size(127, 172);
            this.btn_ExportToExcel.TabIndex = 1;
            this.btn_ExportToExcel.Text = "تصدير للاكسل";
            this.btn_ExportToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_ExportToExcel.UseVisualStyleBackColor = true;
            this.btn_ExportToExcel.Click += new System.EventHandler(this.btn_ExportToExcel_Click);
            // 
            // tab_Settings
            // 
            this.tab_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_Settings.Controls.Add(this.tabPage1);
            this.tab_Settings.Controls.Add(this.tabPage2);
            this.tab_Settings.Controls.Add(this.tabPage3);
            this.tab_Settings.Location = new System.Drawing.Point(741, 16);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.RightToLeftLayout = true;
            this.tab_Settings.SelectedIndex = 0;
            this.tab_Settings.Size = new System.Drawing.Size(657, 180);
            this.tab_Settings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnl_SortFields);
            this.tabPage1.Controls.Add(this.lst_SelectedFields);
            this.tabPage1.Controls.Add(this.num_FontSize);
            this.tabPage1.Controls.Add(this.lbl_FontSize);
            this.tabPage1.Controls.Add(this.chk_Index);
            this.tabPage1.Controls.Add(this.num_RecordsNumber);
            this.tabPage1.Controls.Add(this.rad_Only);
            this.tabPage1.Controls.Add(this.rad_AllRecords);
            this.tabPage1.Controls.Add(this.pnl_MovingFields);
            this.tabPage1.Controls.Add(this.lst_AvailableFields);
            this.tabPage1.Controls.Add(this.pnl_FieldsTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "محتويات التقرير";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_SortFields
            // 
            this.pnl_SortFields.Controls.Add(this.btn_MoveLast);
            this.pnl_SortFields.Controls.Add(this.btn_Down);
            this.pnl_SortFields.Controls.Add(this.btn_Up);
            this.pnl_SortFields.Controls.Add(this.btn_MoveFirst);
            this.pnl_SortFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SortFields.Location = new System.Drawing.Point(278, 30);
            this.pnl_SortFields.Name = "pnl_SortFields";
            this.pnl_SortFields.Size = new System.Drawing.Size(30, 121);
            this.pnl_SortFields.TabIndex = 4;
            // 
            // btn_MoveLast
            // 
            this.btn_MoveLast.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MoveLast.Location = new System.Drawing.Point(0, 90);
            this.btn_MoveLast.Name = "btn_MoveLast";
            this.btn_MoveLast.Size = new System.Drawing.Size(30, 30);
            this.btn_MoveLast.TabIndex = 3;
            this.btn_MoveLast.UseVisualStyleBackColor = true;
            this.btn_MoveLast.Click += new System.EventHandler(this.btn_MoveLast_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Down.Location = new System.Drawing.Point(0, 60);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(30, 30);
            this.btn_Down.TabIndex = 2;
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Up.Location = new System.Drawing.Point(0, 30);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(30, 30);
            this.btn_Up.TabIndex = 1;
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_MoveFirst
            // 
            this.btn_MoveFirst.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MoveFirst.Location = new System.Drawing.Point(0, 0);
            this.btn_MoveFirst.Name = "btn_MoveFirst";
            this.btn_MoveFirst.Size = new System.Drawing.Size(30, 30);
            this.btn_MoveFirst.TabIndex = 0;
            this.btn_MoveFirst.UseVisualStyleBackColor = true;
            this.btn_MoveFirst.Click += new System.EventHandler(this.btn_MoveFirst_Click);
            // 
            // lst_SelectedFields
            // 
            this.lst_SelectedFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_SelectedFields.FormattingEnabled = true;
            this.lst_SelectedFields.Location = new System.Drawing.Point(308, 30);
            this.lst_SelectedFields.Name = "lst_SelectedFields";
            this.lst_SelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_SelectedFields.Size = new System.Drawing.Size(143, 121);
            this.lst_SelectedFields.TabIndex = 11;
            this.lst_SelectedFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_SelectedFields_MouseDoubleClick);
            // 
            // num_FontSize
            // 
            this.num_FontSize.Location = new System.Drawing.Point(11, 93);
            this.num_FontSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.num_FontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_FontSize.Name = "num_FontSize";
            this.num_FontSize.Size = new System.Drawing.Size(40, 20);
            this.num_FontSize.TabIndex = 9;
            this.num_FontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.num_FontSize.ValueChanged += new System.EventHandler(this.num_FontSize_ValueChanged);
            // 
            // lbl_FontSize
            // 
            this.lbl_FontSize.AutoSize = true;
            this.lbl_FontSize.Location = new System.Drawing.Point(57, 96);
            this.lbl_FontSize.Name = "lbl_FontSize";
            this.lbl_FontSize.Size = new System.Drawing.Size(53, 13);
            this.lbl_FontSize.TabIndex = 1;
            this.lbl_FontSize.Text = "حجم الخط";
            // 
            // chk_Index
            // 
            this.chk_Index.AutoSize = true;
            this.chk_Index.Location = new System.Drawing.Point(56, 69);
            this.chk_Index.Name = "chk_Index";
            this.chk_Index.Size = new System.Drawing.Size(51, 17);
            this.chk_Index.TabIndex = 8;
            this.chk_Index.Text = "ترقيم";
            this.chk_Index.UseVisualStyleBackColor = true;
            this.chk_Index.CheckedChanged += new System.EventHandler(this.chk_Index_CheckedChanged);
            // 
            // num_RecordsNumber
            // 
            this.num_RecordsNumber.Location = new System.Drawing.Point(135, 91);
            this.num_RecordsNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.num_RecordsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_RecordsNumber.Name = "num_RecordsNumber";
            this.num_RecordsNumber.Size = new System.Drawing.Size(40, 20);
            this.num_RecordsNumber.TabIndex = 7;
            this.num_RecordsNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rad_Only
            // 
            this.rad_Only.AutoSize = true;
            this.rad_Only.Location = new System.Drawing.Point(181, 91);
            this.rad_Only.Name = "rad_Only";
            this.rad_Only.Size = new System.Drawing.Size(62, 17);
            this.rad_Only.TabIndex = 6;
            this.rad_Only.TabStop = true;
            this.rad_Only.Text = "فقط أول";
            this.rad_Only.UseVisualStyleBackColor = true;
            // 
            // rad_AllRecords
            // 
            this.rad_AllRecords.AutoSize = true;
            this.rad_AllRecords.Location = new System.Drawing.Point(132, 68);
            this.rad_AllRecords.Name = "rad_AllRecords";
            this.rad_AllRecords.Size = new System.Drawing.Size(111, 17);
            this.rad_AllRecords.TabIndex = 5;
            this.rad_AllRecords.TabStop = true;
            this.rad_AllRecords.Text = "عرض كل السجلات";
            this.rad_AllRecords.UseVisualStyleBackColor = true;
            // 
            // pnl_MovingFields
            // 
            this.pnl_MovingFields.Controls.Add(this.btn_BackwardAll);
            this.pnl_MovingFields.Controls.Add(this.btn_ForwardAll);
            this.pnl_MovingFields.Controls.Add(this.btn_Backward);
            this.pnl_MovingFields.Controls.Add(this.btn_Forward);
            this.pnl_MovingFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_MovingFields.Location = new System.Drawing.Point(451, 30);
            this.pnl_MovingFields.Name = "pnl_MovingFields";
            this.pnl_MovingFields.Size = new System.Drawing.Size(30, 121);
            this.pnl_MovingFields.TabIndex = 2;
            // 
            // btn_BackwardAll
            // 
            this.btn_BackwardAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_BackwardAll.Location = new System.Drawing.Point(0, 90);
            this.btn_BackwardAll.Name = "btn_BackwardAll";
            this.btn_BackwardAll.Size = new System.Drawing.Size(30, 30);
            this.btn_BackwardAll.TabIndex = 3;
            this.btn_BackwardAll.UseVisualStyleBackColor = true;
            this.btn_BackwardAll.Click += new System.EventHandler(this.btn_BackwardAll_Click);
            // 
            // btn_ForwardAll
            // 
            this.btn_ForwardAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ForwardAll.Location = new System.Drawing.Point(0, 60);
            this.btn_ForwardAll.Name = "btn_ForwardAll";
            this.btn_ForwardAll.Size = new System.Drawing.Size(30, 30);
            this.btn_ForwardAll.TabIndex = 2;
            this.btn_ForwardAll.UseVisualStyleBackColor = true;
            this.btn_ForwardAll.Click += new System.EventHandler(this.btn_ForwardAll_Click);
            // 
            // btn_Backward
            // 
            this.btn_Backward.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Backward.Location = new System.Drawing.Point(0, 30);
            this.btn_Backward.Name = "btn_Backward";
            this.btn_Backward.Size = new System.Drawing.Size(30, 30);
            this.btn_Backward.TabIndex = 1;
            this.btn_Backward.UseVisualStyleBackColor = true;
            this.btn_Backward.Click += new System.EventHandler(this.btn_Backward_Click);
            // 
            // btn_Forward
            // 
            this.btn_Forward.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Forward.Location = new System.Drawing.Point(0, 0);
            this.btn_Forward.Name = "btn_Forward";
            this.btn_Forward.Size = new System.Drawing.Size(30, 30);
            this.btn_Forward.TabIndex = 0;
            this.btn_Forward.UseVisualStyleBackColor = true;
            this.btn_Forward.Click += new System.EventHandler(this.bnt_Forward_Click);
            // 
            // lst_AvailableFields
            // 
            this.lst_AvailableFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_AvailableFields.FormattingEnabled = true;
            this.lst_AvailableFields.Location = new System.Drawing.Point(481, 30);
            this.lst_AvailableFields.Name = "lst_AvailableFields";
            this.lst_AvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_AvailableFields.Size = new System.Drawing.Size(165, 121);
            this.lst_AvailableFields.TabIndex = 10;
            this.lst_AvailableFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_AvailableFields_MouseDoubleClick);
            // 
            // pnl_FieldsTitle
            // 
            this.pnl_FieldsTitle.Controls.Add(this.lbl_SelectedFields);
            this.pnl_FieldsTitle.Controls.Add(this.lbl_AvailableFields);
            this.pnl_FieldsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_FieldsTitle.Location = new System.Drawing.Point(3, 3);
            this.pnl_FieldsTitle.Name = "pnl_FieldsTitle";
            this.pnl_FieldsTitle.Size = new System.Drawing.Size(643, 27);
            this.pnl_FieldsTitle.TabIndex = 0;
            // 
            // lbl_SelectedFields
            // 
            this.lbl_SelectedFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SelectedFields.Location = new System.Drawing.Point(268, 4);
            this.lbl_SelectedFields.Name = "lbl_SelectedFields";
            this.lbl_SelectedFields.Size = new System.Drawing.Size(161, 23);
            this.lbl_SelectedFields.TabIndex = 1;
            this.lbl_SelectedFields.Text = "الحقول المختارة";
            this.lbl_SelectedFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_AvailableFields
            // 
            this.lbl_AvailableFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AvailableFields.Location = new System.Drawing.Point(482, 4);
            this.lbl_AvailableFields.Name = "lbl_AvailableFields";
            this.lbl_AvailableFields.Size = new System.Drawing.Size(161, 23);
            this.lbl_AvailableFields.TabIndex = 0;
            this.lbl_AvailableFields.Text = "الحقول المتاحة";
            this.lbl_AvailableFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_Conditions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 154);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "شروط التقرير";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_Conditions
            // 
            this.dgv_Conditions.AllowUserToDeleteRows = false;
            this.dgv_Conditions.AllowUserToResizeRows = false;
            this.dgv_Conditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Conditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_field,
            this.col_not,
            this.col_operator,
            this.col_condition,
            this.col_AndOr,
            this.col_group,
            this.col_order,
            this.col_delete});
            this.dgv_Conditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Conditions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Conditions.Location = new System.Drawing.Point(3, 3);
            this.dgv_Conditions.Name = "dgv_Conditions";
            this.dgv_Conditions.RowHeadersVisible = false;
            this.dgv_Conditions.Size = new System.Drawing.Size(643, 148);
            this.dgv_Conditions.TabIndex = 0;
            this.dgv_Conditions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Conditions_CellClick);
            this.dgv_Conditions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Conditions_CellValueChanged);
            this.dgv_Conditions.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_Conditions_RowsAdded);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_SQL);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(649, 154);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SQL Statement";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_SQL
            // 
            this.txt_SQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_SQL.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SQL.ForeColor = System.Drawing.Color.Navy;
            this.txt_SQL.Location = new System.Drawing.Point(0, 0);
            this.txt_SQL.Multiline = true;
            this.txt_SQL.Name = "txt_SQL";
            this.txt_SQL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_SQL.Size = new System.Drawing.Size(649, 154);
            this.txt_SQL.TabIndex = 0;
            // 
            // grx_Rep
            // 
            this.grx_Rep.Controls.Add(this.dgv_Rep);
            this.grx_Rep.Controls.Add(this.lbl_RepCondition);
            this.grx_Rep.Controls.Add(this.lbl_RepTitle);
            this.grx_Rep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grx_Rep.Location = new System.Drawing.Point(0, 191);
            this.grx_Rep.Name = "grx_Rep";
            this.grx_Rep.Size = new System.Drawing.Size(1401, 457);
            this.grx_Rep.TabIndex = 1;
            this.grx_Rep.TabStop = false;
            // 
            // dgv_Rep
            // 
            this.dgv_Rep.AllowUserToAddRows = false;
            this.dgv_Rep.AllowUserToDeleteRows = false;
            this.dgv_Rep.AllowUserToResizeRows = false;
            this.dgv_Rep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Rep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index});
            this.dgv_Rep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Rep.Location = new System.Drawing.Point(3, 70);
            this.dgv_Rep.Name = "dgv_Rep";
            this.dgv_Rep.ReadOnly = true;
            this.dgv_Rep.Size = new System.Drawing.Size(1395, 384);
            this.dgv_Rep.TabIndex = 2;
            // 
            // index
            // 
            this.index.FillWeight = 50F;
            this.index.HeaderText = "#";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Visible = false;
            this.index.Width = 40;
            // 
            // lbl_RepCondition
            // 
            this.lbl_RepCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_RepCondition.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_RepCondition.Location = new System.Drawing.Point(3, 43);
            this.lbl_RepCondition.Name = "lbl_RepCondition";
            this.lbl_RepCondition.Size = new System.Drawing.Size(1395, 27);
            this.lbl_RepCondition.TabIndex = 1;
            // 
            // lbl_RepTitle
            // 
            this.lbl_RepTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_RepTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RepTitle.ForeColor = System.Drawing.Color.Navy;
            this.lbl_RepTitle.Location = new System.Drawing.Point(3, 16);
            this.lbl_RepTitle.Name = "lbl_RepTitle";
            this.lbl_RepTitle.Size = new System.Drawing.Size(1395, 27);
            this.lbl_RepTitle.TabIndex = 0;
            // 
            // col_field
            // 
            this.col_field.DataPropertyName = "Field";
            this.col_field.HeaderText = "الحقل";
            this.col_field.Name = "col_field";
            this.col_field.Width = 150;
            // 
            // col_not
            // 
            this.col_not.FillWeight = 25F;
            this.col_not.HeaderText = "لا";
            this.col_not.Name = "col_not";
            this.col_not.Width = 25;
            // 
            // col_operator
            // 
            this.col_operator.HeaderText = "المعامل";
            this.col_operator.Items.AddRange(new object[] {
            "أختيار",
            "يبدأ بـ",
            "مساو لـ",
            "أكبر من",
            "أقل من",
            "أكبر من أو يساوي",
            "أقل من أو يساوي",
            "يتضمن"});
            this.col_operator.Name = "col_operator";
            // 
            // col_condition
            // 
            this.col_condition.HeaderText = "Condition";
            this.col_condition.Name = "col_condition";
            this.col_condition.Width = 150;
            // 
            // col_AndOr
            // 
            this.col_AndOr.HeaderText = "منطقي";
            this.col_AndOr.Items.AddRange(new object[] {
            "و",
            "أو"});
            this.col_AndOr.Name = "col_AndOr";
            this.col_AndOr.Width = 50;
            // 
            // col_group
            // 
            this.col_group.HeaderText = "تجميع";
            this.col_group.Name = "col_group";
            this.col_group.Width = 50;
            // 
            // col_order
            // 
            this.col_order.HeaderText = "ترتيب";
            this.col_order.Items.AddRange(new object[] {
            "",
            "تصاعدياً",
            "تنازلياً"});
            this.col_order.Name = "col_order";
            this.col_order.Width = 50;
            // 
            // col_delete
            // 
            this.col_delete.HeaderText = "حذف";
            this.col_delete.Name = "col_delete";
            this.col_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_delete.Width = 40;
            // 
            // frm_repdes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 648);
            this.Controls.Add(this.grx_Rep);
            this.Controls.Add(this.grx_Settings);
            this.Name = "frm_repdes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التقارير";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frm_repdes_Shown);
            this.grx_Settings.ResumeLayout(false);
            this.grx_Settings.PerformLayout();
            this.tab_Settings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnl_SortFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_FontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_RecordsNumber)).EndInit();
            this.pnl_MovingFields.ResumeLayout(false);
            this.pnl_FieldsTitle.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conditions)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grx_Rep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grx_Settings;
        private System.Windows.Forms.TabControl tab_Settings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnl_FieldsTitle;
        private System.Windows.Forms.Label lbl_SelectedFields;
        private System.Windows.Forms.Label lbl_AvailableFields;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grx_Rep;
        private System.Windows.Forms.Panel pnl_MovingFields;
        private System.Windows.Forms.Button btn_BackwardAll;
        private System.Windows.Forms.Button btn_ForwardAll;
        private System.Windows.Forms.Button btn_Backward;
        private System.Windows.Forms.Button btn_Forward;
        private System.Windows.Forms.Panel pnl_SortFields;
        private System.Windows.Forms.Button btn_MoveLast;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_MoveFirst;
        private System.Windows.Forms.Button btn_Display;
        private System.Windows.Forms.Button btn_ExportToExcel;
        private System.Windows.Forms.NumericUpDown num_FontSize;
        private System.Windows.Forms.Label lbl_FontSize;
        private System.Windows.Forms.CheckBox chk_Index;
        private System.Windows.Forms.NumericUpDown num_RecordsNumber;
        private System.Windows.Forms.RadioButton rad_Only;
        private System.Windows.Forms.RadioButton rad_AllRecords;
        private System.Windows.Forms.Button btn_DeleteRep;
        private System.Windows.Forms.ComboBox com_SelectedRep;
        private System.Windows.Forms.Button btn_SaveRep;
        private System.Windows.Forms.TextBox txt_RepName;
        private System.Windows.Forms.DataGridView dgv_Conditions;
        private System.Windows.Forms.TextBox txt_SQL;
        private System.Windows.Forms.DataGridView dgv_Rep;
        private System.Windows.Forms.Label lbl_RepCondition;
        private System.Windows.Forms.Label lbl_RepTitle;
        private System.Windows.Forms.ComboBox com_Fields;
        private System.Windows.Forms.ListBox lst_SelectedFields;
        private System.Windows.Forms.ListBox lst_AvailableFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_field;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_not;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_condition;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_AndOr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_group;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_order;
        private System.Windows.Forms.DataGridViewImageColumn col_delete;
    }
}