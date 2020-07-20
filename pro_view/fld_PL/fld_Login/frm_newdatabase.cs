using System;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_newdatabase : Form
    {
        public frm_newdatabase()
        {
            InitializeComponent();

            txt_Password.UseSystemPasswordChar = true;
            txt_ConfirmPassword.UseSystemPasswordChar = true;
        }

        private void btn_AddDatabase_Click(object sender, EventArgs e)
        {
            #region Validation
            if(txt_databasename.Text.Trim() == "")
            {
                MessageBox.Show("يجب إدخال أسم لقاعدة البيانات الجديدة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_databasename.Focus();
                return;
            }
            #endregion

            if(rad_EmptyDatabase.Checked)
            {
                #region Validation
                if (txt_databasename.Text.Trim() == "")
                {
                    MessageBox.Show("يجب إدخال أسم قاعدة البيانات الجديدة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_databasename.Focus();
                    return;
                }
                else
                {
                    txt_databasename.Text = txt_databasename.Text.Trim().ToLower();
                }
                if (txt_UserName.Text.Trim() == "")
                {
                    MessageBox.Show("يجب إدخال أسم مستخدم قاعدة البيانات الجديدة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_UserName.Focus();
                    return;
                }
                if (txt_Password.Text.Trim() == "")
                {
                    MessageBox.Show("يجب إدخال كلمة مرور لمستخدم قاعدة البيانات الجديدة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Password.Focus();
                    return;
                }
                if (txt_ConfirmPassword.Text.Trim() == "")
                {
                    MessageBox.Show("يجب إدخال تأكيد كلمة مرور لمستخدم قاعدة البيانات الجديدة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ConfirmPassword.Focus();
                    return;
                }
                if (txt_Password.Text.Trim() != txt_ConfirmPassword.Text.Trim())
                {
                    MessageBox.Show("كلمة المرور غير متطابقة", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_ConfirmPassword.Focus();
                    return;
                }
                #endregion

                try
                {
                    btn_AddDatabase.Text = "Please Wait ...";
                    btn_AddDatabase.Enabled = false;

                    string script = "CREATE DATABASE " + txt_databasename.Text.Trim() + ";";

                    fld_DAL.cls_dal dal1 = new fld_DAL.cls_dal("postgres");
                    dal1.ExecuteAndRetriveDataSet(script);

                    script = Properties.Resources.CreateNewEmptyDatabase;

                    fld_DAL.cls_dal dal2 = new fld_DAL.cls_dal(txt_databasename.Text.Trim());
                    dal2.ExecuteAndRetriveDataSet(script);

                    script = "INSERT INTO grl.tbl_users(id, sequ, aname, ename, password, gender_id, company_id, branch_id, creationtime, createuser_id)"
                           + "VALUES('0001', 1, '" + txt_UserName.Text.Trim() + "', '" + txt_UserName.Text.Trim() + "', '" + txt_Password.Text.Trim() + "', 1, '01', '001', '" + DateTime.Now.ToString("MM/dd/yyyy") + "', '0001');\r\n";

                    script += Properties.Resources.InsertMainDataToNewDatabase;

                    fld_DAL.cls_dal dal3 = new fld_DAL.cls_dal(txt_databasename.Text.Trim());
                    dal3.ExecuteAndRetriveDataSet(script);

                    MessageBox.Show("تم اضافة قاعدة البيانات بنجاح", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_databasename.Focus();
                    Close();
                }
                catch (Exception ex)
                {
                    btn_AddDatabase.Text = "OK";
                    btn_AddDatabase.Enabled = true;

                    MessageBox.Show(ex.Message, "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else if(rad_CopyDatabase.Checked)
            {
                #region Validation
                if (com_CopyDatabase.Text == "")
                {
                    MessageBox.Show("يجب تحديد قاعدة بيانات للنسخ منها", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    com_CopyDatabase.DroppedDown = true;
                    return;
                }
                #endregion

                try
                {
                    btn_AddDatabase.Text = "Please Wait ...";
                    btn_AddDatabase.Enabled = false;

                    string script = "SELECT pg_terminate_backend(pg_stat_activity.pid) FROM pg_stat_activity "
                                  + "WHERE pg_stat_activity.datname = 'postgres' AND pid<> pg_backend_pid();";

                    script += "SELECT pg_terminate_backend(pg_stat_activity.pid) FROM pg_stat_activity "
                           + "WHERE pg_stat_activity.datname = '"+com_CopyDatabase.Text+"' AND pid<> pg_backend_pid();";

                    fld_DAL.cls_dal dal1 = new fld_DAL.cls_dal("postgres");
                    dal1.ExecuteAndRetriveDataSet(script);

                    script = "CREATE DATABASE "+ txt_databasename.Text.Trim() + " WITH TEMPLATE "+com_CopyDatabase.Text+" OWNER postgres;";

                    fld_DAL.cls_dal dal2 = new fld_DAL.cls_dal("postgres");
                    dal2.ExecuteAndRetriveDataSet(script);               

                    MessageBox.Show("تم اضافة قاعدة البيانات بنجاح", "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_databasename.Focus();
                    Close();
                }
                catch (Exception ex)
                {
                    btn_AddDatabase.Text = "OK";
                    btn_AddDatabase.Enabled = true;

                    MessageBox.Show(ex.Message, "اضافة قاعدة بيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
        private void txt_databasename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                lbl_English.Visible = true;
                return;
            }
            lbl_English.Visible = false;
        }

        private void rad_EmptyDatabase_CheckedChanged(object sender, EventArgs e)
        {
            gbx_CreatUser.Visible = rad_EmptyDatabase.Checked;
        }

        private void rad_CopyDatabase_CheckedChanged(object sender, EventArgs e)
        {
            gbx_CopyData.Visible = rad_CopyDatabase.Checked;
        }
    }
}
