using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_General_Settings
{
    public partial class frm_companies : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_companies module = new fld_BL.cls_bl.stc_General_Settings.stc_companies();
        DataTable dt = new DataTable();
        int record_index;
        #endregion

        public frm_companies()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;
            Refresh_Data();
        }

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            dgv.Focus();
        }
        #endregion

        #region Pro
        void ClearForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }
        void EnableForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = false;
                }
                else
                {
                    c.Enabled = true;
                }
            }
            dgv.Enabled = false;
            txt_id.ReadOnly = true;
        }
        void DisableForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }
                else
                {
                    c.Enabled = false;
                }
            }
            dgv.Enabled = true;
        }
        void Form_Mode(string mode)
        {
            switch (mode)
            {
                #region New
                case "New":
                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;
                    btn_info.Visible = false;
                    gbx_info.Visible = false;

                    EnableForm();
                    ClearForm();

                    txt_aname.Focus();
                    break;
                #endregion

                #region Edit
                case "Edit":

                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;
                    btn_info.Visible = false;
                    gbx_info.Visible = false;

                    EnableForm();

                    txt_aname.Select();
                    break;
                #endregion

                #region Select
                case "Select":

                    btn_New.Visible = true;
                    btn_Edit.Visible = true;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = true;
                    btn_Cancel.Visible = false;
                    btn_info.Visible = false;
                    gbx_info.Visible = true;

                    DisableForm();

                    if (dgv.SelectedRows.Count == 0) dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["ID"].ToString() == dgv.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            txt_id.Text = r["id"].ToString();
                            txt_aname.Text = r["aname"].ToString();
                            txt_ename.Text = r["ename"].ToString();
                            txt_notes.Text = r["notes"].ToString();
                            chk_stop.Checked = Convert.ToBoolean(r["stop"]);
                            lbl_creationtime.Text = r["creationtime"].ToString();
                            lbl_editingtime.Text = r["editingtime"].ToString();
                            lbl_createuser_id.Text = r["createuser_id"].ToString();
                            lbl_edituser_id.Text = r["edituser_id"].ToString();
                            if (r["edit"].ToString() != "0")
                            {
                                btn_info.Visible = true;
                                btn_info.Text = "معدل" + r["edit"].ToString();
                            }
                            break;
                        }
                    }

                    break;
                #endregion

                #region Empty
                case "Empty":

                    btn_New.Visible = true;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_info.Visible = false;
                    gbx_info.Visible = false;

                    DisableForm();
                    ClearForm();

                    if (dgv.CurrentRow != null) dgv.CurrentRow.Selected = false;
                    break;
                    #endregion
            }
        }
        void Bind()
        {
            module.id = txt_id.Text.Trim();
            module.aname = txt_aname.Text.Trim();
            module.ename = txt_ename.Text.Trim();
            module.notes = txt_notes.Text.Trim();
            module.stop = chk_stop.Checked;
            module.activetime = null;
            module.user_id = frm_main.com_users.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
        }
        void Refresh_Data()
        {
            dt = module.Select().Tables[0];
            dgv.DataSource = dt;

            if (dgv.Rows.Count > 0)
            {
                dgv.CurrentCell = dgv.Rows[0].Cells[0];
                Tag = "Select";
                Form_Mode("Select");
            }
            else
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }
        }
        #endregion

        #region Controls
        #region display
        private void btn_New_MouseEnter(object sender, EventArgs e)
        {
            btn_New.FlatStyle = FlatStyle.Popup;
        }
        private void btn_New_MouseLeave(object sender, EventArgs e)
        {
            btn_New.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Edit_MouseEnter(object sender, EventArgs e)
        {
            btn_Edit.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Edit_MouseLeave(object sender, EventArgs e)
        {
            btn_Edit.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Save_MouseEnter(object sender, EventArgs e)
        {
            btn_Save.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Save_MouseLeave(object sender, EventArgs e)
        {
            btn_Save.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Delete_MouseEnter(object sender, EventArgs e)
        {
            btn_Delete.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Delete_MouseLeave(object sender, EventArgs e)
        {
            btn_Delete.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_Cancel.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancel.FlatStyle = FlatStyle.Flat;
        }
        private void btn_info_MouseEnter(object sender, EventArgs e)
        {
            btn_info.FlatStyle = FlatStyle.Popup;
        }

        private void btn_info_MouseLeave(object sender, EventArgs e)
        {
            btn_info.FlatStyle = FlatStyle.Flat;
        }
        #endregion
        private void btn_New_Click(object sender, EventArgs e)
        {
            Tag = "New";
            Form_Mode("New");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Tag = "Edit";
            Form_Mode("Edit");
            record_index = dgv.SelectedRows[0].Index;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txt_aname.Text.Trim() == "" && txt_ename.Text.Trim() == "")
            {
                MessageBox.Show("يجب إدخال أسم الشركة ", "حفظ البيان", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_aname.Focus();
                return;
            }
            #endregion

            Bind();

            #region New
            if (Tag.ToString() == "New")
            {
                dt = module.Insert().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["notes"] != null)
                    {
                        if (dt.Rows[0]["notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt.Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt.Rows[0]["notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }

                dgv.DataSource = dt;
                if (dgv.RowCount > 0) dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];
                dgv.Focus();
            }
            #endregion

            #region Edit
            else if (Tag.ToString() == "Edit")
            {
                dt = module.Update().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["notes"] != null)
                    {
                        if (dt.Rows[0]["notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt.Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt.Rows[0]["notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
                dgv.DataSource = dt;
                dgv.CurrentCell = dgv.Rows[record_index].Cells[0];
            }
            #endregion

            Tag = "Select";
            Form_Mode("Select");
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            #region Confirm Deleting
            if (MessageBox.Show("هل بالفعل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                return;
            }
            #endregion

            Bind();

            #region Delete
            dt = module.Delete().Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["notes"] != null)
                {
                    if (dt.Rows[0]["notes"].ToString().Trim().Length >= 10)
                    {
                        if (dt.Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                        {
                            string[] arrey = dt.Rows[0]["notes"].ToString().Split(',');
                            MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                            return;
                        }
                    }
                }
            }
            dgv.DataSource = dt;
            #endregion

            Tag = "Empty";
            Form_Mode("Empty");
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Tag.ToString() == "New")
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }
            else if (Tag.ToString() == "Edit")
            {
                Tag = "Select";
                Form_Mode("Select");
            }
        }
        #endregion

        #region dgv
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (Tag == null || dgv.Focused == false) return;
            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty")
            {
                Tag = "Select";
                Form_Mode("Select");
            }
        }
        #endregion
    }
}
