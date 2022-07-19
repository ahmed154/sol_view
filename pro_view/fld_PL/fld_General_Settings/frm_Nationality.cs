using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_School.fld_General_Setting
{
    public partial class frm_Nationality : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.fld_School.fld_General_Setting.cls_General_Setting.stc_nationality module = new fld_BL.fld_School.fld_General_Setting.cls_General_Setting.stc_nationality();
        DataSet ds = new DataSet();
        int record_index;
        #endregion

        public frm_Nationality()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;         
        }

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            Refresh_Data();


            if (dgv.Rows.Count > 0)
            {
                Tag = "Select";
                Form_Mode("Select");
            }
            else
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }

            dgv.Focus();
        }
        private void frm_G_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (txt_id.Text == "") txt_id.Text = "-1";
        }
        #endregion

        #region pro
        void Bind()
        {
            module.id = txt_id.Text.Trim();
            module.aname = txt_aname.Text.Trim();
            module.ename = txt_ename.Text.Trim();
            module.user_id = frm_main.com_users.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
        }
        void ClearForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedValue = -1;
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

                    DisableForm();

                    if (dgv.SelectedRows.Count == 0) dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        if (r["ID"].ToString() == dgv.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            txt_id.Text = r["id"].ToString();
                            txt_aname.Text = r["aname"].ToString();
                            txt_ename.Text = r["ename"].ToString();
                            lbl_creationtime.Text = r["creationtime"].ToString();
                            lbl_editingtime.Text = r["editingtime"].ToString();
                            lbl_createuser_id.Text = r["createuser_id"].ToString();
                            lbl_edituser_id.Text = r["edituser_id"].ToString();
                            if (r["edit"].ToString() != "0")
                            {
                                btn_info.Visible = true;
                                btn_info.Text = "معدل" + r["edit"].ToString();
                            }
                            else
                            {
                                btn_info.Visible = false;
                                btn_info.Text = "";
                            }
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

                    DisableForm();
                    ClearForm();

                    if (dgv.CurrentRow != null) dgv.CurrentRow.Selected = false;
                    break;               
                    #endregion
            }
        }
        string[] TextToArray(string t)
        {
            List<string> lst = t.Split(new[] { "," }, StringSplitOptions.None).ToList();

            string[] a = lst.ToArray();
            return a;
        }
        void Refresh_Data()
        {
            ds = module.Select();
            dgv.DataSource = ds.Tables[0];

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
        void ControlsName()
        {
            string s = this.Name.ToString().Substring(4);
            string tabindex = "";
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox || c is ComboBox || c is CheckBox)
                {
                    tabindex = (c.TabIndex > 9) ? c.TabIndex.ToString() : "0" + c.TabIndex.ToString();
                    s += ",";
                    s += tabindex + "- " + c.Name.ToString();
                }
            }
            s += ",96- lbl_creationtime";
            s += ",97- lbl_editingtime";
            s += ",98- lbl_createuser_id";
            s += ",99- lbl_edituser_id";
            String[] a = s.Split(',');
            Array.Sort(a);
            s = string.Join(",", a);

            if (MessageBox.Show(s, "Click OK to copy", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            { Clipboard.SetText(s); }
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
                MessageBox.Show("يجب إدخال الأسم ", "حفظ البيان", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_aname.Focus();
                return;
            }
            #endregion

            Bind();

            #region New
            if (Tag.ToString() == "New")
            {
                ds = module.Insert();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["notes"] != null)
                    {
                        if (ds.Tables[0].Rows[0]["notes"].ToString().Trim().Length >= 10)
                        {
                            if (ds.Tables[0].Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = ds.Tables[0].Rows[0]["notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
                dgv.DataSource = ds.Tables[0];
                if (dgv.RowCount > 0) dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];
                dgv.Focus();
            }
            #endregion

            #region Edit
            else if (Tag.ToString() == "Edit")
            {
                ds = module.Update();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["notes"] != null)
                    {
                        if (ds.Tables[0].Rows[0]["notes"].ToString().Trim().Length >= 10)
                        {
                            if (ds.Tables[0].Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = ds.Tables[0].Rows[0]["notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
                dgv.DataSource = ds.Tables[0];
                dgv.CurrentCell = dgv.Rows[record_index].Cells[0];
            }
            Tag = "Select";
            Form_Mode("Select");
            #endregion
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل بالفعل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                return;
            }

            Bind();
            ds = module.Delete();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["notes"] != null)
                {
                    if (ds.Tables[0].Rows[0]["notes"].ToString().Trim().Length >= 10)
                    {
                        if (ds.Tables[0].Rows[0]["notes"].ToString().Substring(0, 10) == "PostgreSQL")
                        {
                            string[] arrey = ds.Tables[0].Rows[0]["notes"].ToString().Split(',');
                            MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                            return;
                        }
                    }
                }
            }
            dgv.DataSource = ds.Tables[0];

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

        private void gbx_Details_Enter(object sender, EventArgs e)
        {

        }

        private void frm_Nationality_Load(object sender, EventArgs e)
        {

        }
    }
}
