using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_main : Form
    {
        #region Declarations
        pro_view.fld_BL.cls_bl.stc_Login.main bl = new fld_BL.cls_bl.stc_Login.main();
        public DataSet ds = new DataSet();
        public frm_login frm_login;

        #region Perm_Var
        int _0101001 = 0;
        int _0102001 = 0;
        int _0103001 = 0;
        int _0104001 = 0;
        int _0105001 = 0;
        int _0106001 = 0;
        int _0107001 = 0;
        #endregion

        #endregion

        public frm_main()
        {
            InitializeComponent();
        }

        #region Pro
        public bool Perm(string perm_id, ToolStripMenuItem tsm)
        {
            foreach (DataRow r in ds.Tables["tbl_permuser"].Rows)
            {
                if (r["perm_id"].ToString() == perm_id)
                {
                    tsm.Visible = true;
                    ShowTsm(tsm);

                    return true;
                }
            }
            return false;
        }
        public bool Perm(string perm_id)
        {
            foreach (DataRow r in ds.Tables["tbl_permuser"].Rows)
            {
                if (r["perm_id"].ToString() == perm_id) return true;             
            }
            return false;
        }
        void ShowTsm(ToolStripItem tsm)
        {
            tsm.Visible = true;

            if (tsm.OwnerItem != null)
            {
                ShowTsm(tsm.OwnerItem);
            }
        }
        #endregion

        #region Form
        private void frm_main_Shown(object sender, EventArgs e)
        {
            #region Perm
            ds = bl.Select(com_users.SelectedValue.ToString());
            // General Settings
            Perm("0101001", tsm_Branch);
            Perm("0102001", tsm_Store);
            Perm("0103001", tsm_GS_Fyears);
            Perm("0104001", tsm_cc);
            Perm("0105001", tsm_GSCurrencies);
            Perm("0106001", tsm_users);
            Perm("0107001", tsm_DeleteData);

            // Accounting
            Perm("0201001", tsm_cin);
            Perm("0202001", tsm_cout);
            Perm("0203001", tsm_jor);
            Perm("0204001", tsm_ST);
            Perm("0205001", tsm_TB);
            Perm("0206001", tsm_IS);
            Perm("0207001", tsm_BS);
            Perm("0208001", tsm_JorRep);
            // Accounting Settings
            Perm("0209001", tsm_chart);
            Perm("0210001", tsm_JornalB);
            Perm("0211001", tsm_jorclose);

            tsm_scl.Visible = Convert.ToBoolean(ds.Tables["tbl_system"].Rows[0]["scl"]);
            #endregion

            #region ContextMenuStrips
            // Branches
            cms_branches.ForeColor = Color.MidnightBlue;
            cms_branches.Width = btn_Branche.Width;

            for (int i = 0; i < com_branches.Items.Count; i++)
            {
                cms_branches.Items.Add(com_branches.GetItemText(com_branches.Items[i]), imageList16.Images["Branch_16.png"]);
            }
            #endregion

            btn_database.Text = Properties.Settings.Default.Database;
            btn_database.Image = imageList32.Images["DataBase_32.png"];
            btn_Company.Image = imageList32.Images["company_32.png"];
            btn_Branche.Image = imageList32.Images["Branch_32.png"];
            btn_fyear.Image = imageList32.Images["fyear_32.png"];
            btn_User.Image = imageList32.Images["User_32.png"];

            #region script
            //fld_DAL.cls_dal dal = new fld_DAL.cls_dal();

            //DataTable dt_TableNames = new DataTable();
            //dt_TableNames.Columns.Add("TableName");

            //dt_TableNames.Rows.Add("grl.tbl_doctype");
            //dt_TableNames.Rows.Add("grl.tbl_events");
            //dt_TableNames.Rows.Add("grl.tbl_gender");
            //dt_TableNames.Rows.Add("grl.tbl_lvlnuset");
            //dt_TableNames.Rows.Add("grl.tbl_moduels");
            //dt_TableNames.Rows.Add("grl.tbl_paytype");
            //dt_TableNames.Rows.Add("grl.tbl_permissions");
            //dt_TableNames.Rows.Add("grl.tbl_system");
            //dt_TableNames.Rows.Add("grl.tbl_update");
            //dt_TableNames.Rows.Add("acc.tbl_chartccrelation");
            //dt_TableNames.Rows.Add("acc.tbl_chartlists");
            //dt_TableNames.Rows.Add("acc.tbl_chartprop");
            //dt_TableNames.Rows.Add("acc.tbl_chartside");
            //dt_TableNames.Rows.Add("acc.tbl_chart");
            //dt_TableNames.Rows.Add("acc.tbl_jortype");

            //string select = "";
                         
            //foreach (DataRow dr in dt_TableNames.Rows)
            //{
            //    if(dr["TableName"].ToString() == "grl.tbl_lvlnuset" || dr["TableName"].ToString() == "grl.tbl_system")
            //    {
            //        select += "SELECT * FROM  " + dr["TableName"].ToString() + ";\r\n";
            //    }
            //    else
            //    {
            //        select += "SELECT * FROM  " + dr["TableName"].ToString() + " ORDER BY id;\r\n";
            //    }            
            //}

            //string script = "";
            //DataSet ds_script = dal.ExecuteAndRetriveDataSet(select);

            //int index_dt = 0;
            //foreach (DataTable dt in ds_script.Tables)
            //{
            //    script += "DELETE FROM " + dt_TableNames.Rows[index_dt]["TableName"].ToString() + ";\r\n";
            //    script += "INSERT INTO " + dt_TableNames.Rows[index_dt]["TableName"].ToString() + "(";
            //    foreach (DataColumn dc in dt.Columns)
            //    {
            //        script += dc.ColumnName + ",";
            //    }
            //    script = script.Substring(0, script.Length - 1) + ")VALUES\r\n";
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        script += "(";
            //        for (int i = 0; i < dt.Columns.Count; i++)
            //        {
            //            if (dt.Columns[i].ColumnName == "notes" || dt.Columns[i].ColumnName == "priority" || dt.Columns[i].ColumnName == "activetime" || dt.Columns[i].ColumnName == "editingtime")
            //            {
            //                script += "null,";
            //            }
                        
            //            else if (dt.Columns[i].ColumnName == "parent_id")
            //            {
            //                if(dr[i].ToString().Trim() != "")
            //                {
            //                    script += "'" + dr[i].ToString() + "',";
            //                }
            //                else
            //                {
            //                    script += "null,";
            //                }
            //            }
            //            else if (dt.Columns[i].ColumnName == "ddate")
            //            {
            //                script += "(select(current_timestamp)),";
            //            }
            //            else if (dt.Columns[i].ColumnName == "creationtime")
            //            {
            //                script += "(select(current_timestamp)),";
            //            }
            //            else
            //            {
            //                script += "'" + dr[i].ToString() + "',";
            //            }
            //        }
            //        script = script.Substring(0, script.Length - 1) + "),\r\n";
            //    }
            //    script = script.Substring(0, script.Length - 3) + ";\r\n\r\n";
            //    index_dt++;
            //}              
            #endregion
        }
        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

            //DialogResult result = MessageBox.Show("هل تريد حفظ نسخة إحتياطية من البيانات ؟ ...  يجب حفظ نسخ أخرى من البيانات على قرص آخر حتى لا يتم فقدان البيانات نهائياً في حالة عطل القرص الصلب ", "حفظ نسخة احتياطية", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            //if (result == DialogResult.Yes)
            //{
            //    //g.BackupDatabase(AppDomain.CurrentDomain.BaseDirectory + "BACKUP");
            //    //Application.ExitThread();
            //    //Environment.Exit(1);
            //}
            //else if (result == DialogResult.No)
            //{
            //    //Application.Exit();
            //    //Environment.Exit(1);
            //    //Application.ExitThread();

            //    //Environment.Exit(10);
            //    frm_login.Close();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        #endregion

        #region pnl_Header
        private void btn_database_Click(object sender, EventArgs e)
        {
            #region desighn
            Form f = new Form();
            f.Size = new Size(800, 600);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Text = "Command";

            GroupBox g = new GroupBox();
            g.Dock = DockStyle.Fill;

            TextBox t = new TextBox();
            t.Dock = DockStyle.Fill;
            t.Multiline = true;
            t.ScrollBars = ScrollBars.Both;
            t.UseSystemPasswordChar = true;
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);

            g.Controls.Add(t);
            f.Controls.Add(g);
            #endregion

            f.ShowDialog();

        }
        private void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (((TextBox)sender).Text.Length < 6) return;
                if (((TextBox)sender).Text.Substring(0, 6) != "$treAm") return;

                e.Handled = true;
                try
                {
                    string s = ((TextBox)sender).Text.Substring(6);
                    bl.ExecuteCommand(s);
                    MessageBox.Show("تم التنفيذ بنجاح", "تنفيذ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Command", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
        }
        private void com_companies_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_Company.Text = com_companies.Text;
        }
        private void com_branches_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_Branche.Text = com_branches.Text;
        }
        private void com_fyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_fyear.Text = com_fyear.Text;
        }
        private void com_users_SelectedValueChanged(object sender, EventArgs e)
        {
            btn_User.Text = com_users.Text;
        }
        private void btn_Branche_Click(object sender, EventArgs e)
        {
            if (com_branches.Enabled == false) return;
            Point p = btn_Branche.PointToScreen(Point.Empty);
            cms_branches.Show(p.X - (cms_branches.Width - btn_Branche.Width), p.Y + btn_Branche.Height);
        }
        private void cms_branches_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_branches.SelectedIndex = cms_branches.Items.IndexOf(e.ClickedItem);
            btn_Branche.Text = com_branches.Text;
        }
        private void btn_Branche_MouseEnter(object sender, EventArgs e)
        {
            btn_Branche.FlatStyle = FlatStyle.Popup;
            btn_Branche.Cursor = Cursors.Hand;
        }
        private void btn_Branche_MouseLeave(object sender, EventArgs e)
        {
            btn_Branche.FlatStyle = FlatStyle.Flat;
        }
        #endregion

        #region Accounting

        private void tsm_cin_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_cin f = new fld_Accounting.frm_cin(this);
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];

            f.Text = "سند قبض";

            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;
            f.com_fyear.DataSource = com_fyear.DataSource;
            f.com_fyear.SelectedValue = com_fyear.SelectedValue;
            f.com_Users.DataSource = com_users.DataSource;
            f.com_Users.SelectedValue = com_users.SelectedValue;

            f.Show();
        }
        private void tsm_cout_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_cout f = new fld_Accounting.frm_cout(this);
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];

            f.Text = "سند صرف";

            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;
            f.com_fyear.DataSource = com_fyear.DataSource;
            f.com_fyear.SelectedValue = com_fyear.SelectedValue;
            f.com_Users.DataSource = com_users.DataSource;
            f.com_Users.SelectedValue = com_users.SelectedValue;

            f.Show();
        }
        private void tsm_jor_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_jor f = new fld_Accounting.frm_jor(this);
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            //f.frm_main = this;
            f.Text = "دفتر القيود";

            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;
            f.com_fyear.DataSource = com_fyear.DataSource;
            f.com_fyear.SelectedValue = com_fyear.SelectedValue;
            f.com_Users.DataSource = com_users.DataSource;
            f.com_Users.SelectedValue = com_users.SelectedValue;

            f.Show();
        }
        private void stm_ST_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_statement f = new fld_Accounting.frm_statement(this);
            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;

            f.btn_Display.Image = imageList_48.Images["Display_48.png"];
            f.btn_Print.Image = imageList_48.Images["Print_48.png"];
            f.btn_PrintPreview.Image = imageList_48.Images["Search_48.png"];

            f.frm_main = this;
            f.Text = "كشف الحساب";

            f.Show();
        }
        private void tsm_TB_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_tb f = new fld_Accounting.frm_tb(this);
            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;

            f.btn_Display.Image = imageList_48.Images["Display_48.png"];
            f.btn_Print.Image = imageList_48.Images["Print_48.png"];
            f.btn_PrintPreview.Image = imageList_48.Images["Search_48.png"];

            f.frm_main = this;
            f.Text = "ميزان المراجعة";

            f.Show();
        }
        private void tsm_IS_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_is f = new fld_Accounting.frm_is(this);
            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;

            f.btn_Display.Image = imageList_48.Images["Display_48.png"];
            f.btn_Print.Image = imageList_48.Images["Print_48.png"];
            f.btn_PrintPreview.Image = imageList_48.Images["Search_48.png"];

            f.frm_main = this;
            f.Text = "قائمة الدخل";

            f.Show();
        }
        private void tsm_BS_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_bs f = new fld_Accounting.frm_bs(this);
            f.com_Branches.DataSource = com_branches.DataSource;
            f.com_Branches.SelectedValue = com_branches.SelectedValue;

            f.btn_Display.Image = imageList_48.Images["Display_48.png"];
            f.btn_Print.Image = imageList_48.Images["Print_48.png"];
            f.btn_PrintPreview.Image = imageList_48.Images["Search_48.png"];

            f.frm_main = this;
            f.Text = "الميزانية العمومية";

            f.Show();
        }
        private void tsm_RepJor_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.frm_repdes f = new fld_Accounting.frm_repdes(this, "acc", "viw_repjor");
            f.Show();
        }

        #region Accounting Settings
        private void tsm_chart_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.fld_Settings.frm_chart f = new fld_Accounting.fld_Settings.frm_chart();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];

            f.btn_UP.Image = imageList16.Images["Up_16.png"];
            f.btn_Dowen.Image = imageList16.Images["Down_16.png"];

            f.frm_main = this;
            f.Text = "دليل الحسابات";

            f.Show();
        }

        private void tsm_jorclose_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.fld_Settings.frm_jorclose f = new fld_Accounting.fld_Settings.frm_jorclose(this);

            f.Text = "إقفال الحسابات";

            System.Data.DataTable dt_branches = (System.Data.DataTable)com_branches.DataSource;

            foreach (DataRow r in dt_branches.Rows)
            {
                f.dgv_branches.Rows.Add(r["id"].ToString(), r["aname"].ToString(), false);
            }

            f.Show();
        }
        #endregion

        #endregion

        #region Schools
        private void tsm_StuMainData_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_Stu_Data.frm_Stu_Main_Data f = new fld_School.fld_Stu_Data.frm_Stu_Main_Data();

            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "بيانات الطلاب";

            f.Show();
        }
        private void tsm_Nationality_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Nationality f = new fld_School.fld_General_Setting.frm_Nationality();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "البلاد";

            f.Show();
        }
        private void tsm_Cities_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_cities f = new fld_General_Settings.frm_cities();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "المدن";


            f.Show();
        }
        private void tsm_Areas_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_areas f = new fld_General_Settings.frm_areas();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الاحياء";


            f.Show();

        }
        private void tsm_Stages_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Scl_Stages f = new fld_School.fld_General_Setting.frm_Scl_Stages();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "المراحل الدراسية";

            f.Show();
        }
        private void tsm_Rows_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Rows f = new fld_School.fld_General_Setting.frm_Rows();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الصفوف الدراسية";

            f.Show();
        }
        private void tsm_Class_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Class f = new fld_School.fld_General_Setting.frm_Class();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الفصول التعليمية";

            f.Show();
        }
        private void tsm_Study_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Study f = new fld_School.fld_General_Setting.frm_Study();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "نوع الدراسة";

            f.Show();
        }
        private void tsm_Section_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_School.fld_General_Setting.frm_Section f = new fld_School.fld_General_Setting.frm_Section();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "قسم الدراسة";

            f.Show();
        }
        #endregion

        #region General Settings
        private void الشركاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_companies f = new fld_General_Settings.frm_companies();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الشركات";

            f.Show();
        }
        private void الفروعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_branches f = new fld_General_Settings.frm_branches();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الفروع";

            f.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_stores f = new fld_General_Settings.frm_stores();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "المستودعات";

            f.Show();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_fyears f = new fld_General_Settings.frm_fyears();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "السنوات المالية";

            f.Show();
        }
        private void Tsm_cc_Click_1(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Accounting.fld_Settings.frm_cc f = new fld_Accounting.fld_Settings.frm_cc();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];

            f.btn_UP.Image = imageList16.Images["Up_16.png"];
            f.btn_Dowen.Image = imageList16.Images["Down_16.png"];

            f.frm_main = this;
            f.Text = "مراكز التكلفة";

            f.Show();
        }
        private void tsm_currencies_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_currencies f = new fld_General_Settings.frm_currencies();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "العملات";

            f.Show();
        }
        private void tsm_users_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_users f = new fld_General_Settings.frm_users();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "المستخدمون";

            f.Show();
        }
        private void tsm_ResetData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("سيتم حذف جميع البيانات ...  هل تريد الإستمرار ؟", "إفراغ البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("سيتم حذف جميع البيانات ...  هل أنت متأكد ؟", "إفراغ البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;

                pro_view.fld_BL.cls_bl.stc_General_Settings.stc_SystemSettings bl = new fld_BL.cls_bl.stc_General_Settings.stc_SystemSettings();

                try
                {
                    bl.ResetData();

                    MessageBox.Show("تم إفراغ البيانات بنجاح", "إفراغ البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        #endregion
    }
}
