namespace pro_view.fld_PL.fld_Accounting
{
    partial class frm_cinsettings
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
            this.tab_Settings = new System.Windows.Forms.TabControl();
            this.tab_Fields = new System.Windows.Forms.TabPage();
            this.flp_Fields = new System.Windows.Forms.FlowLayoutPanel();
            this.tab_Print = new System.Windows.Forms.TabPage();
            this.btn_PrintSettings = new System.Windows.Forms.Button();
            this.tab_Settings.SuspendLayout();
            this.tab_Fields.SuspendLayout();
            this.tab_Print.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.tab_Fields);
            this.tab_Settings.Controls.Add(this.tab_Print);
            this.tab_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Settings.Location = new System.Drawing.Point(0, 0);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.SelectedIndex = 0;
            this.tab_Settings.Size = new System.Drawing.Size(698, 579);
            this.tab_Settings.TabIndex = 0;
            // 
            // tab_Fields
            // 
            this.tab_Fields.Controls.Add(this.flp_Fields);
            this.tab_Fields.Location = new System.Drawing.Point(4, 22);
            this.tab_Fields.Name = "tab_Fields";
            this.tab_Fields.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Fields.Size = new System.Drawing.Size(690, 553);
            this.tab_Fields.TabIndex = 0;
            this.tab_Fields.Text = "الحقول";
            this.tab_Fields.UseVisualStyleBackColor = true;
            // 
            // flp_Fields
            // 
            this.flp_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Fields.Location = new System.Drawing.Point(3, 3);
            this.flp_Fields.Name = "flp_Fields";
            this.flp_Fields.Size = new System.Drawing.Size(684, 547);
            this.flp_Fields.TabIndex = 0;
            // 
            // tab_Print
            // 
            this.tab_Print.Controls.Add(this.btn_PrintSettings);
            this.tab_Print.Location = new System.Drawing.Point(4, 22);
            this.tab_Print.Name = "tab_Print";
            this.tab_Print.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Print.Size = new System.Drawing.Size(690, 553);
            this.tab_Print.TabIndex = 1;
            this.tab_Print.Text = "الطباعة";
            this.tab_Print.UseVisualStyleBackColor = true;
            // 
            // btn_PrintSettings
            // 
            this.btn_PrintSettings.Location = new System.Drawing.Point(550, 6);
            this.btn_PrintSettings.Name = "btn_PrintSettings";
            this.btn_PrintSettings.Size = new System.Drawing.Size(132, 35);
            this.btn_PrintSettings.TabIndex = 0;
            this.btn_PrintSettings.Text = "إعدادات الطباعة";
            this.btn_PrintSettings.UseVisualStyleBackColor = true;
            this.btn_PrintSettings.Click += new System.EventHandler(this.btn_PrintSettings_Click);
            // 
            // frm_cinsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 579);
            this.Controls.Add(this.tab_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_cinsettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tab_Settings.ResumeLayout(false);
            this.tab_Fields.ResumeLayout(false);
            this.tab_Print.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Settings;
        private System.Windows.Forms.TabPage tab_Fields;
        public System.Windows.Forms.FlowLayoutPanel flp_Fields;
        private System.Windows.Forms.TabPage tab_Print;
        private System.Windows.Forms.Button btn_PrintSettings;
    }
}