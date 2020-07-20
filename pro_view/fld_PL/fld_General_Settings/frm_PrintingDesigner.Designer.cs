namespace pro_view.fld_PL.fld_General_Settings
{
    partial class frm_PrintingDesigner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl = new System.Windows.Forms.Panel();
            this.tab_Settings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_SelectedFields = new System.Windows.Forms.DataGridView();
            this.fieldname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldzone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontsize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fontstyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_SortFields = new System.Windows.Forms.Panel();
            this.btn_MoveLast = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_MoveFirst = new System.Windows.Forms.Button();
            this.lst_SelectedFields = new System.Windows.Forms.ListBox();
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
            this.col_field = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_not = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_AndOr = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_group = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_order = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_SQL = new System.Windows.Forms.TextBox();
            this.btn_AddLbl = new System.Windows.Forms.Button();
            this.btn_AddRec = new System.Windows.Forms.Button();
            this.btn_AddImg = new System.Windows.Forms.Button();
            this.btn_AddLin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_DesigenName = new System.Windows.Forms.TextBox();
            this.com_Desigen = new System.Windows.Forms.ComboBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tab_Settings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedFields)).BeginInit();
            this.pnl_SortFields.SuspendLayout();
            this.pnl_MovingFields.SuspendLayout();
            this.pnl_FieldsTitle.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conditions)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1463, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_Save});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsm_Save
            // 
            this.tsm_Save.Name = "tsm_Save";
            this.tsm_Save.Size = new System.Drawing.Size(98, 22);
            this.tsm_Save.Text = "Save";
            this.tsm_Save.Click += new System.EventHandler(this.tsm_Save_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.White;
            this.pnl.Location = new System.Drawing.Point(0, 24);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(800, 549);
            this.pnl.TabIndex = 0;
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.tabPage1);
            this.tab_Settings.Controls.Add(this.tabPage2);
            this.tab_Settings.Controls.Add(this.tabPage3);
            this.tab_Settings.Location = new System.Drawing.Point(800, 24);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tab_Settings.RightToLeftLayout = true;
            this.tab_Settings.SelectedIndex = 0;
            this.tab_Settings.Size = new System.Drawing.Size(663, 180);
            this.tab_Settings.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_SelectedFields);
            this.tabPage1.Controls.Add(this.pnl_SortFields);
            this.tabPage1.Controls.Add(this.lst_SelectedFields);
            this.tabPage1.Controls.Add(this.pnl_MovingFields);
            this.tabPage1.Controls.Add(this.lst_AvailableFields);
            this.tabPage1.Controls.Add(this.pnl_FieldsTitle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 154);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "محتويات التقرير";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_SelectedFields
            // 
            this.dgv_SelectedFields.AllowUserToAddRows = false;
            this.dgv_SelectedFields.AllowUserToDeleteRows = false;
            this.dgv_SelectedFields.AllowUserToOrderColumns = true;
            this.dgv_SelectedFields.AllowUserToResizeRows = false;
            this.dgv_SelectedFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelectedFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldname,
            this.fieldtext,
            this.fieldtype,
            this.fieldzone,
            this.x,
            this.y,
            this.fontname,
            this.fontsize,
            this.fontstyle,
            this.visable,
            this.notes});
            this.dgv_SelectedFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SelectedFields.Location = new System.Drawing.Point(3, 30);
            this.dgv_SelectedFields.Name = "dgv_SelectedFields";
            this.dgv_SelectedFields.ReadOnly = true;
            this.dgv_SelectedFields.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_SelectedFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_SelectedFields.Size = new System.Drawing.Size(221, 121);
            this.dgv_SelectedFields.TabIndex = 12;
            // 
            // fieldname
            // 
            this.fieldname.HeaderText = "fieldname";
            this.fieldname.Name = "fieldname";
            this.fieldname.ReadOnly = true;
            // 
            // fieldtext
            // 
            this.fieldtext.HeaderText = "fieldtext";
            this.fieldtext.Name = "fieldtext";
            this.fieldtext.ReadOnly = true;
            // 
            // fieldtype
            // 
            this.fieldtype.HeaderText = "fieldtype";
            this.fieldtype.Name = "fieldtype";
            this.fieldtype.ReadOnly = true;
            // 
            // fieldzone
            // 
            this.fieldzone.HeaderText = "fieldzone";
            this.fieldzone.Name = "fieldzone";
            this.fieldzone.ReadOnly = true;
            // 
            // x
            // 
            this.x.HeaderText = "x";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            this.y.ReadOnly = true;
            // 
            // fontname
            // 
            this.fontname.HeaderText = "fontname";
            this.fontname.Name = "fontname";
            this.fontname.ReadOnly = true;
            // 
            // fontsize
            // 
            this.fontsize.HeaderText = "fontsize";
            this.fontsize.Name = "fontsize";
            this.fontsize.ReadOnly = true;
            // 
            // fontstyle
            // 
            this.fontstyle.HeaderText = "fontstyle";
            this.fontstyle.Name = "fontstyle";
            this.fontstyle.ReadOnly = true;
            // 
            // visable
            // 
            this.visable.HeaderText = "visable";
            this.visable.Name = "visable";
            this.visable.ReadOnly = true;
            // 
            // notes
            // 
            this.notes.HeaderText = "notes";
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            // 
            // pnl_SortFields
            // 
            this.pnl_SortFields.Controls.Add(this.btn_MoveLast);
            this.pnl_SortFields.Controls.Add(this.btn_Down);
            this.pnl_SortFields.Controls.Add(this.btn_Up);
            this.pnl_SortFields.Controls.Add(this.btn_MoveFirst);
            this.pnl_SortFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SortFields.Location = new System.Drawing.Point(224, 30);
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
            // 
            // btn_Down
            // 
            this.btn_Down.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Down.Location = new System.Drawing.Point(0, 60);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(30, 30);
            this.btn_Down.TabIndex = 2;
            this.btn_Down.UseVisualStyleBackColor = true;
            // 
            // btn_Up
            // 
            this.btn_Up.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Up.Location = new System.Drawing.Point(0, 30);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(30, 30);
            this.btn_Up.TabIndex = 1;
            this.btn_Up.UseVisualStyleBackColor = true;
            // 
            // btn_MoveFirst
            // 
            this.btn_MoveFirst.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_MoveFirst.Location = new System.Drawing.Point(0, 0);
            this.btn_MoveFirst.Name = "btn_MoveFirst";
            this.btn_MoveFirst.Size = new System.Drawing.Size(30, 30);
            this.btn_MoveFirst.TabIndex = 0;
            this.btn_MoveFirst.UseVisualStyleBackColor = true;
            // 
            // lst_SelectedFields
            // 
            this.lst_SelectedFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_SelectedFields.FormattingEnabled = true;
            this.lst_SelectedFields.Location = new System.Drawing.Point(254, 30);
            this.lst_SelectedFields.Name = "lst_SelectedFields";
            this.lst_SelectedFields.Size = new System.Drawing.Size(143, 121);
            this.lst_SelectedFields.TabIndex = 11;
            this.lst_SelectedFields.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedFields_SelectedIndexChanged);
            // 
            // pnl_MovingFields
            // 
            this.pnl_MovingFields.Controls.Add(this.btn_BackwardAll);
            this.pnl_MovingFields.Controls.Add(this.btn_ForwardAll);
            this.pnl_MovingFields.Controls.Add(this.btn_Backward);
            this.pnl_MovingFields.Controls.Add(this.btn_Forward);
            this.pnl_MovingFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_MovingFields.Location = new System.Drawing.Point(397, 30);
            this.pnl_MovingFields.Name = "pnl_MovingFields";
            this.pnl_MovingFields.Size = new System.Drawing.Size(90, 121);
            this.pnl_MovingFields.TabIndex = 2;
            // 
            // btn_BackwardAll
            // 
            this.btn_BackwardAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_BackwardAll.Location = new System.Drawing.Point(0, 90);
            this.btn_BackwardAll.Name = "btn_BackwardAll";
            this.btn_BackwardAll.Size = new System.Drawing.Size(90, 30);
            this.btn_BackwardAll.TabIndex = 3;
            this.btn_BackwardAll.Text = "Page Footer";
            this.btn_BackwardAll.UseVisualStyleBackColor = true;
            this.btn_BackwardAll.Click += new System.EventHandler(this.btn_BackwardAll_Click);
            // 
            // btn_ForwardAll
            // 
            this.btn_ForwardAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_ForwardAll.Location = new System.Drawing.Point(0, 60);
            this.btn_ForwardAll.Name = "btn_ForwardAll";
            this.btn_ForwardAll.Size = new System.Drawing.Size(90, 30);
            this.btn_ForwardAll.TabIndex = 2;
            this.btn_ForwardAll.Text = "Details";
            this.btn_ForwardAll.UseVisualStyleBackColor = true;
            this.btn_ForwardAll.Click += new System.EventHandler(this.btn_ForwardAll_Click);
            // 
            // btn_Backward
            // 
            this.btn_Backward.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Backward.Location = new System.Drawing.Point(0, 30);
            this.btn_Backward.Name = "btn_Backward";
            this.btn_Backward.Size = new System.Drawing.Size(90, 30);
            this.btn_Backward.TabIndex = 1;
            this.btn_Backward.Text = "Page Header";
            this.btn_Backward.UseVisualStyleBackColor = true;
            this.btn_Backward.Click += new System.EventHandler(this.btn_Backward_Click);
            // 
            // btn_Forward
            // 
            this.btn_Forward.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Forward.Location = new System.Drawing.Point(0, 0);
            this.btn_Forward.Name = "btn_Forward";
            this.btn_Forward.Size = new System.Drawing.Size(90, 30);
            this.btn_Forward.TabIndex = 0;
            this.btn_Forward.Text = ">";
            this.btn_Forward.UseVisualStyleBackColor = true;
            this.btn_Forward.Click += new System.EventHandler(this.btn_Forward_Click);
            // 
            // lst_AvailableFields
            // 
            this.lst_AvailableFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.lst_AvailableFields.FormattingEnabled = true;
            this.lst_AvailableFields.Location = new System.Drawing.Point(487, 30);
            this.lst_AvailableFields.Name = "lst_AvailableFields";
            this.lst_AvailableFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_AvailableFields.Size = new System.Drawing.Size(165, 121);
            this.lst_AvailableFields.TabIndex = 10;
            // 
            // pnl_FieldsTitle
            // 
            this.pnl_FieldsTitle.Controls.Add(this.lbl_SelectedFields);
            this.pnl_FieldsTitle.Controls.Add(this.lbl_AvailableFields);
            this.pnl_FieldsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_FieldsTitle.Location = new System.Drawing.Point(3, 3);
            this.pnl_FieldsTitle.Name = "pnl_FieldsTitle";
            this.pnl_FieldsTitle.Size = new System.Drawing.Size(649, 27);
            this.pnl_FieldsTitle.TabIndex = 0;
            // 
            // lbl_SelectedFields
            // 
            this.lbl_SelectedFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SelectedFields.Location = new System.Drawing.Point(274, 4);
            this.lbl_SelectedFields.Name = "lbl_SelectedFields";
            this.lbl_SelectedFields.Size = new System.Drawing.Size(161, 23);
            this.lbl_SelectedFields.TabIndex = 1;
            this.lbl_SelectedFields.Text = "الحقول المختارة";
            this.lbl_SelectedFields.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_AvailableFields
            // 
            this.lbl_AvailableFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_AvailableFields.Location = new System.Drawing.Point(488, 4);
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
            this.tabPage2.Size = new System.Drawing.Size(655, 154);
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
            this.dgv_Conditions.Size = new System.Drawing.Size(649, 148);
            this.dgv_Conditions.TabIndex = 0;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_SQL);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(655, 154);
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
            this.txt_SQL.Size = new System.Drawing.Size(655, 154);
            this.txt_SQL.TabIndex = 0;
            // 
            // btn_AddLbl
            // 
            this.btn_AddLbl.Location = new System.Drawing.Point(1220, 210);
            this.btn_AddLbl.Name = "btn_AddLbl";
            this.btn_AddLbl.Size = new System.Drawing.Size(121, 23);
            this.btn_AddLbl.TabIndex = 3;
            this.btn_AddLbl.Text = "Add Label";
            this.btn_AddLbl.UseVisualStyleBackColor = true;
            this.btn_AddLbl.Click += new System.EventHandler(this.btn_AddLbl_Click);
            // 
            // btn_AddRec
            // 
            this.btn_AddRec.Location = new System.Drawing.Point(1220, 239);
            this.btn_AddRec.Name = "btn_AddRec";
            this.btn_AddRec.Size = new System.Drawing.Size(121, 23);
            this.btn_AddRec.TabIndex = 4;
            this.btn_AddRec.Text = "Add Rectangel";
            this.btn_AddRec.UseVisualStyleBackColor = true;
            this.btn_AddRec.Click += new System.EventHandler(this.btn_AddRec_Click);
            // 
            // btn_AddImg
            // 
            this.btn_AddImg.Location = new System.Drawing.Point(1220, 268);
            this.btn_AddImg.Name = "btn_AddImg";
            this.btn_AddImg.Size = new System.Drawing.Size(121, 23);
            this.btn_AddImg.TabIndex = 5;
            this.btn_AddImg.Text = "Add Image";
            this.btn_AddImg.UseVisualStyleBackColor = true;
            // 
            // btn_AddLin
            // 
            this.btn_AddLin.Location = new System.Drawing.Point(1220, 297);
            this.btn_AddLin.Name = "btn_AddLin";
            this.btn_AddLin.Size = new System.Drawing.Size(121, 23);
            this.btn_AddLin.TabIndex = 6;
            this.btn_AddLin.Text = "Add Line";
            this.btn_AddLin.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1185, 440);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(891, 326);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_DesigenName
            // 
            this.txt_DesigenName.Location = new System.Drawing.Point(807, 300);
            this.txt_DesigenName.Name = "txt_DesigenName";
            this.txt_DesigenName.Size = new System.Drawing.Size(221, 20);
            this.txt_DesigenName.TabIndex = 9;
            // 
            // com_Desigen
            // 
            this.com_Desigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Desigen.FormattingEnabled = true;
            this.com_Desigen.Location = new System.Drawing.Point(807, 270);
            this.com_Desigen.Name = "com_Desigen";
            this.com_Desigen.Size = new System.Drawing.Size(221, 21);
            this.com_Desigen.TabIndex = 10;
            this.com_Desigen.SelectedIndexChanged += new System.EventHandler(this.com_Desigen_SelectedIndexChanged);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(807, 326);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(75, 23);
            this.btn_New.TabIndex = 11;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // frm_PrintingDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1463, 573);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.com_Desigen);
            this.Controls.Add(this.txt_DesigenName);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_AddLin);
            this.Controls.Add(this.btn_AddImg);
            this.Controls.Add(this.btn_AddRec);
            this.Controls.Add(this.btn_AddLbl);
            this.Controls.Add(this.tab_Settings);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_PrintingDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frm_PrintingDesigner_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_Settings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedFields)).EndInit();
            this.pnl_SortFields.ResumeLayout(false);
            this.pnl_MovingFields.ResumeLayout(false);
            this.pnl_FieldsTitle.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Conditions)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.TabControl tab_Settings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnl_SortFields;
        private System.Windows.Forms.Button btn_MoveLast;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_MoveFirst;
        private System.Windows.Forms.ListBox lst_SelectedFields;
        private System.Windows.Forms.Panel pnl_MovingFields;
        private System.Windows.Forms.Button btn_BackwardAll;
        private System.Windows.Forms.Button btn_ForwardAll;
        private System.Windows.Forms.Button btn_Backward;
        private System.Windows.Forms.Button btn_Forward;
        private System.Windows.Forms.ListBox lst_AvailableFields;
        private System.Windows.Forms.Panel pnl_FieldsTitle;
        private System.Windows.Forms.Label lbl_SelectedFields;
        private System.Windows.Forms.Label lbl_AvailableFields;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_Conditions;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_field;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_not;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_condition;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_AndOr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_group;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_order;
        private System.Windows.Forms.DataGridViewImageColumn col_delete;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_SQL;
        private System.Windows.Forms.ToolStripMenuItem tsm_Save;
        private System.Windows.Forms.Button btn_AddLbl;
        private System.Windows.Forms.Button btn_AddRec;
        private System.Windows.Forms.Button btn_AddImg;
        private System.Windows.Forms.Button btn_AddLin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridView dgv_SelectedFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldzone;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn fontname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fontsize;
        private System.Windows.Forms.DataGridViewTextBoxColumn fontstyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn visable;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.TextBox txt_DesigenName;
        private System.Windows.Forms.ComboBox com_Desigen;
        private System.Windows.Forms.Button btn_New;
    }
}