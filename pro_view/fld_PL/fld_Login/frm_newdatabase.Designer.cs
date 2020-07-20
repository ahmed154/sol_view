namespace pro_view.fld_PL.fld_Login
{
    partial class frm_newdatabase
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
            this.btn_AddDatabase = new System.Windows.Forms.Button();
            this.rad_EmptyDatabase = new System.Windows.Forms.RadioButton();
            this.rad_CopyDatabase = new System.Windows.Forms.RadioButton();
            this.gbx_CopyData = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_English = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_databasename = new System.Windows.Forms.TextBox();
            this.gbx_CreatUser = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.com_CopyDatabase = new System.Windows.Forms.ComboBox();
            this.gbx_CopyData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbx_CreatUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_AddDatabase
            // 
            this.btn_AddDatabase.Location = new System.Drawing.Point(164, 459);
            this.btn_AddDatabase.Name = "btn_AddDatabase";
            this.btn_AddDatabase.Size = new System.Drawing.Size(196, 46);
            this.btn_AddDatabase.TabIndex = 1;
            this.btn_AddDatabase.Text = "OK";
            this.btn_AddDatabase.UseVisualStyleBackColor = true;
            this.btn_AddDatabase.Click += new System.EventHandler(this.btn_AddDatabase_Click);
            // 
            // rad_EmptyDatabase
            // 
            this.rad_EmptyDatabase.AutoSize = true;
            this.rad_EmptyDatabase.Checked = true;
            this.rad_EmptyDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.rad_EmptyDatabase.Location = new System.Drawing.Point(0, 82);
            this.rad_EmptyDatabase.Name = "rad_EmptyDatabase";
            this.rad_EmptyDatabase.Padding = new System.Windows.Forms.Padding(15);
            this.rad_EmptyDatabase.Size = new System.Drawing.Size(546, 47);
            this.rad_EmptyDatabase.TabIndex = 5;
            this.rad_EmptyDatabase.TabStop = true;
            this.rad_EmptyDatabase.Text = "Empty Database";
            this.rad_EmptyDatabase.UseVisualStyleBackColor = true;
            this.rad_EmptyDatabase.CheckedChanged += new System.EventHandler(this.rad_EmptyDatabase_CheckedChanged);
            // 
            // rad_CopyDatabase
            // 
            this.rad_CopyDatabase.AutoSize = true;
            this.rad_CopyDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.rad_CopyDatabase.Location = new System.Drawing.Point(0, 298);
            this.rad_CopyDatabase.Name = "rad_CopyDatabase";
            this.rad_CopyDatabase.Padding = new System.Windows.Forms.Padding(15);
            this.rad_CopyDatabase.Size = new System.Drawing.Size(546, 47);
            this.rad_CopyDatabase.TabIndex = 7;
            this.rad_CopyDatabase.Text = "Copy Database";
            this.rad_CopyDatabase.UseVisualStyleBackColor = true;
            this.rad_CopyDatabase.CheckedChanged += new System.EventHandler(this.rad_CopyDatabase_CheckedChanged);
            // 
            // gbx_CopyData
            // 
            this.gbx_CopyData.Controls.Add(this.com_CopyDatabase);
            this.gbx_CopyData.Controls.Add(this.label9);
            this.gbx_CopyData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_CopyData.Location = new System.Drawing.Point(0, 345);
            this.gbx_CopyData.Name = "gbx_CopyData";
            this.gbx_CopyData.Size = new System.Drawing.Size(546, 93);
            this.gbx_CopyData.TabIndex = 8;
            this.gbx_CopyData.TabStop = false;
            this.gbx_CopyData.Text = "Select the copy source";
            this.gbx_CopyData.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Copy from";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_English);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_databasename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 82);
            this.panel1.TabIndex = 9;
            // 
            // lbl_English
            // 
            this.lbl_English.AutoSize = true;
            this.lbl_English.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_English.Location = new System.Drawing.Point(177, 47);
            this.lbl_English.Name = "lbl_English";
            this.lbl_English.Size = new System.Drawing.Size(155, 13);
            this.lbl_English.TabIndex = 11;
            this.lbl_English.Text = "Only English Characters Please";
            this.lbl_English.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "New Database Name";
            // 
            // txt_databasename
            // 
            this.txt_databasename.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_databasename.Location = new System.Drawing.Point(176, 20);
            this.txt_databasename.Name = "txt_databasename";
            this.txt_databasename.Size = new System.Drawing.Size(196, 23);
            this.txt_databasename.TabIndex = 9;
            this.txt_databasename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_databasename_KeyPress);
            // 
            // gbx_CreatUser
            // 
            this.gbx_CreatUser.Controls.Add(this.label4);
            this.gbx_CreatUser.Controls.Add(this.txt_ConfirmPassword);
            this.gbx_CreatUser.Controls.Add(this.label3);
            this.gbx_CreatUser.Controls.Add(this.txt_Password);
            this.gbx_CreatUser.Controls.Add(this.label2);
            this.gbx_CreatUser.Controls.Add(this.txt_UserName);
            this.gbx_CreatUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbx_CreatUser.Location = new System.Drawing.Point(0, 129);
            this.gbx_CreatUser.Name = "gbx_CreatUser";
            this.gbx_CreatUser.Size = new System.Drawing.Size(546, 169);
            this.gbx_CreatUser.TabIndex = 10;
            this.gbx_CreatUser.TabStop = false;
            this.gbx_CreatUser.Text = "Create Adminstrator User For New Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Confirm Password";
            // 
            // txt_ConfirmPassword
            // 
            this.txt_ConfirmPassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfirmPassword.Location = new System.Drawing.Point(164, 100);
            this.txt_ConfirmPassword.Name = "txt_ConfirmPassword";
            this.txt_ConfirmPassword.Size = new System.Drawing.Size(196, 23);
            this.txt_ConfirmPassword.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(164, 71);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(196, 23);
            this.txt_Password.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Adminstrator User Name";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(164, 42);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(196, 23);
            this.txt_UserName.TabIndex = 9;
            // 
            // com_CopyDatabase
            // 
            this.com_CopyDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.com_CopyDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_CopyDatabase.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.com_CopyDatabase.ForeColor = System.Drawing.Color.LightGray;
            this.com_CopyDatabase.FormattingEnabled = true;
            this.com_CopyDatabase.Location = new System.Drawing.Point(164, 34);
            this.com_CopyDatabase.Name = "com_CopyDatabase";
            this.com_CopyDatabase.Size = new System.Drawing.Size(196, 24);
            this.com_CopyDatabase.TabIndex = 33;
            // 
            // frm_newdatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 523);
            this.Controls.Add(this.gbx_CopyData);
            this.Controls.Add(this.rad_CopyDatabase);
            this.Controls.Add(this.btn_AddDatabase);
            this.Controls.Add(this.gbx_CreatUser);
            this.Controls.Add(this.rad_EmptyDatabase);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_newdatabase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Database";
            this.gbx_CopyData.ResumeLayout(false);
            this.gbx_CopyData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbx_CreatUser.ResumeLayout(false);
            this.gbx_CreatUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddDatabase;
        private System.Windows.Forms.RadioButton rad_EmptyDatabase;
        private System.Windows.Forms.RadioButton rad_CopyDatabase;
        private System.Windows.Forms.GroupBox gbx_CopyData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_English;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_databasename;
        private System.Windows.Forms.GroupBox gbx_CreatUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ConfirmPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        public System.Windows.Forms.ComboBox com_CopyDatabase;
    }
}