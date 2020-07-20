namespace pro_view.fld_PL.fld_Login
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.lbl_UserNameE = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_PassE = new System.Windows.Forms.Label();
            this.lbl_PassA = new System.Windows.Forms.Label();
            this.lbl_UserNameA = new System.Windows.Forms.Label();
            this.btn_Demo = new System.Windows.Forms.Button();
            this.btn_ServerConSettings = new System.Windows.Forms.Button();
            this.com_fyear = new System.Windows.Forms.ComboBox();
            this.com_company = new System.Windows.Forms.ComboBox();
            this.btn_login2 = new System.Windows.Forms.Button();
            this.btn_Lock = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_UserNameE
            // 
            this.lbl_UserNameE.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_UserNameE.Location = new System.Drawing.Point(16, 238);
            this.lbl_UserNameE.Name = "lbl_UserNameE";
            this.lbl_UserNameE.Size = new System.Drawing.Size(123, 17);
            this.lbl_UserNameE.TabIndex = 0;
            this.lbl_UserNameE.Text = "User Name";
            this.lbl_UserNameE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(147, 236);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(193, 24);
            this.txt_Name.TabIndex = 0;
            this.txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Name_KeyPress);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Login.Location = new System.Drawing.Point(147, 329);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(193, 35);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "LOGIN";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(147, 266);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(193, 24);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Password_KeyPress);
            // 
            // lbl_PassE
            // 
            this.lbl_PassE.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_PassE.Location = new System.Drawing.Point(3, 267);
            this.lbl_PassE.Name = "lbl_PassE";
            this.lbl_PassE.Size = new System.Drawing.Size(138, 21);
            this.lbl_PassE.TabIndex = 3;
            this.lbl_PassE.Text = "Password";
            this.lbl_PassE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PassA
            // 
            this.lbl_PassA.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_PassA.Location = new System.Drawing.Point(346, 269);
            this.lbl_PassA.Name = "lbl_PassA";
            this.lbl_PassA.Size = new System.Drawing.Size(150, 19);
            this.lbl_PassA.TabIndex = 5;
            this.lbl_PassA.Text = "كلمة المرور";
            this.lbl_PassA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_UserNameA
            // 
            this.lbl_UserNameA.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_UserNameA.Location = new System.Drawing.Point(346, 236);
            this.lbl_UserNameA.Name = "lbl_UserNameA";
            this.lbl_UserNameA.Size = new System.Drawing.Size(123, 20);
            this.lbl_UserNameA.TabIndex = 4;
            this.lbl_UserNameA.Text = "أسم المستخدم";
            this.lbl_UserNameA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Demo
            // 
            this.btn_Demo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Demo.BackColor = System.Drawing.Color.Transparent;
            this.btn_Demo.FlatAppearance.BorderSize = 0;
            this.btn_Demo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Demo.ForeColor = System.Drawing.Color.Navy;
            this.btn_Demo.Location = new System.Drawing.Point(323, 516);
            this.btn_Demo.Name = "btn_Demo";
            this.btn_Demo.Size = new System.Drawing.Size(167, 35);
            this.btn_Demo.TabIndex = 3;
            this.btn_Demo.Text = "دخول النسخة التجريبية";
            this.btn_Demo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Demo.UseVisualStyleBackColor = false;
            this.btn_Demo.Click += new System.EventHandler(this.btn_Demo_Click);
            this.btn_Demo.MouseEnter += new System.EventHandler(this.btn_Demo_MouseEnter);
            this.btn_Demo.MouseLeave += new System.EventHandler(this.btn_Demo_MouseLeave);
            // 
            // btn_ServerConSettings
            // 
            this.btn_ServerConSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ServerConSettings.BackColor = System.Drawing.Color.Transparent;
            this.btn_ServerConSettings.FlatAppearance.BorderSize = 0;
            this.btn_ServerConSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ServerConSettings.ForeColor = System.Drawing.Color.Navy;
            this.btn_ServerConSettings.Location = new System.Drawing.Point(12, 516);
            this.btn_ServerConSettings.Name = "btn_ServerConSettings";
            this.btn_ServerConSettings.Size = new System.Drawing.Size(167, 35);
            this.btn_ServerConSettings.TabIndex = 4;
            this.btn_ServerConSettings.Text = "إعدادات الإتصال بالسيرفر";
            this.btn_ServerConSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ServerConSettings.UseVisualStyleBackColor = false;
            this.btn_ServerConSettings.Click += new System.EventHandler(this.btn_ServerConSettings_Click);
            this.btn_ServerConSettings.MouseEnter += new System.EventHandler(this.btn_ServerConSettings_MouseEnter);
            this.btn_ServerConSettings.MouseLeave += new System.EventHandler(this.btn_ServerConSettings_MouseLeave);
            // 
            // com_fyear
            // 
            this.com_fyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_fyear.FormattingEnabled = true;
            this.com_fyear.Location = new System.Drawing.Point(147, 441);
            this.com_fyear.Name = "com_fyear";
            this.com_fyear.Size = new System.Drawing.Size(193, 24);
            this.com_fyear.TabIndex = 7;
            this.com_fyear.Visible = false;
            // 
            // com_company
            // 
            this.com_company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_company.FormattingEnabled = true;
            this.com_company.Location = new System.Drawing.Point(147, 411);
            this.com_company.Name = "com_company";
            this.com_company.Size = new System.Drawing.Size(193, 24);
            this.com_company.TabIndex = 8;
            this.com_company.Visible = false;
            // 
            // btn_login2
            // 
            this.btn_login2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_login2.FlatAppearance.BorderSize = 0;
            this.btn_login2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_login2.Location = new System.Drawing.Point(147, 296);
            this.btn_login2.Name = "btn_login2";
            this.btn_login2.Size = new System.Drawing.Size(193, 35);
            this.btn_login2.TabIndex = 9;
            this.btn_login2.Text = "OK";
            this.btn_login2.UseVisualStyleBackColor = false;
            this.btn_login2.Visible = false;
            this.btn_login2.Click += new System.EventHandler(this.btn_login2_Click);
            // 
            // btn_Lock
            // 
            this.btn_Lock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Lock.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Lock.FlatAppearance.BorderSize = 0;
            this.btn_Lock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Lock.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Lock.Image = ((System.Drawing.Image)(resources.GetObject("btn_Lock.Image")));
            this.btn_Lock.Location = new System.Drawing.Point(150, 48);
            this.btn_Lock.Name = "btn_Lock";
            this.btn_Lock.Size = new System.Drawing.Size(193, 153);
            this.btn_Lock.TabIndex = 6;
            this.btn_Lock.TabStop = false;
            this.btn_Lock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Lock.UseVisualStyleBackColor = false;
            this.btn_Lock.MouseEnter += new System.EventHandler(this.btn_Lock_MouseEnter);
            this.btn_Lock.MouseLeave += new System.EventHandler(this.btn_Lock_MouseLeave);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.Location = new System.Drawing.Point(440, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(50, 50);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.TabStop = false;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Back.FlatAppearance.BorderSize = 0;
            this.btn_Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Back.Location = new System.Drawing.Point(147, 370);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(193, 35);
            this.btn_Back.TabIndex = 11;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Visible = false;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(502, 563);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_login2);
            this.Controls.Add(this.com_company);
            this.Controls.Add(this.com_fyear);
            this.Controls.Add(this.btn_ServerConSettings);
            this.Controls.Add(this.btn_Demo);
            this.Controls.Add(this.btn_Lock);
            this.Controls.Add(this.lbl_PassA);
            this.Controls.Add(this.lbl_UserNameA);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_PassE);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_UserNameE);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_login";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Login_FormClosed);
            this.Shown += new System.EventHandler(this.frm_Login_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserNameE;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_PassE;
        private System.Windows.Forms.Label lbl_PassA;
        private System.Windows.Forms.Label lbl_UserNameA;
        private System.Windows.Forms.Button btn_Lock;
        private System.Windows.Forms.Button btn_Demo;
        private System.Windows.Forms.Button btn_ServerConSettings;
        private System.Windows.Forms.ComboBox com_fyear;
        private System.Windows.Forms.ComboBox com_company;
        private System.Windows.Forms.Button btn_login2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Back;
    }
}