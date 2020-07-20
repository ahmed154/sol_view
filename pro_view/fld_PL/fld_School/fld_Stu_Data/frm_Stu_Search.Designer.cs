namespace pro_view.fld_PL.fld_School.fld_Stu_Data
{
    partial class frm_Stu_Search
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
            this.dgv_stu_search = new System.Windows.Forms.DataGridView();
            this.txt_dgv_search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stu_search)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_stu_search
            // 
            this.dgv_stu_search.AllowUserToAddRows = false;
            this.dgv_stu_search.AllowUserToDeleteRows = false;
            this.dgv_stu_search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stu_search.Location = new System.Drawing.Point(1, 38);
            this.dgv_stu_search.MultiSelect = false;
            this.dgv_stu_search.Name = "dgv_stu_search";
            this.dgv_stu_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_stu_search.Size = new System.Drawing.Size(727, 492);
            this.dgv_stu_search.TabIndex = 0;
            this.dgv_stu_search.DoubleClick += new System.EventHandler(this.dgv_stu_search_DoubleClick);
            // 
            // txt_dgv_search
            // 
            this.txt_dgv_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dgv_search.Location = new System.Drawing.Point(452, 12);
            this.txt_dgv_search.Name = "txt_dgv_search";
            this.txt_dgv_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_dgv_search.Size = new System.Drawing.Size(276, 20);
            this.txt_dgv_search.TabIndex = 191;
            this.txt_dgv_search.TabStop = false;
            this.txt_dgv_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_dgv_search.TextChanged += new System.EventHandler(this.txt_dgv_search_TextChanged);
            // 
            // frm_Stu_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(731, 529);
            this.Controls.Add(this.txt_dgv_search);
            this.Controls.Add(this.dgv_stu_search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Stu_Search";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Stu_Search";
            this.Shown += new System.EventHandler(this.frm_Stu_Search_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stu_search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_stu_search;
        public System.Windows.Forms.TextBox txt_dgv_search;
    }
}