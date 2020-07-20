using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting.fld_Settings
{
    public partial class frm_cc : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_Accounting.stc_Settings.stc_cc module = new fld_BL.cls_bl.stc_Accounting.stc_Settings.stc_cc();
        DataSet ds = new DataSet();
        int record_index;

        int level = 1;
        List<string> ParentID = new List<string>();
        DataTable dt_Path = new DataTable();
        #endregion

        public frm_cc()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;

            dt_Path.Columns.Add("id");
            dt_Path.Columns.Add("name");
        }

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            //ControlsName();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.branch_id = frm_main.com_branches.SelectedValue.ToString();
            Refresh_Data();

            if (dgv.Rows.Count > 0)
            {
                Tag = "Select";
                Form_Mode("Select");
                lbl_Level.Text = "المستوى : " + level.ToString();
            }
            else
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }

            com_branch_id.DataSource = ds.Tables["tbl_branches"];
            com_branch_id.ValueMember = "id";
            com_branch_id.DisplayMember = "aname";
            com_branch_id.SelectedValue = -1;

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

                    Tag = "Select";

                    btn_New.Visible = true;
                    btn_Edit.Visible = true;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = true;
                    btn_Cancel.Visible = false;

                    DisableForm();

                    if (dgv.RowCount > 0 && dgv.SelectedRows.Count == 0)
                    {
                        dgv.CurrentCell = dgv.Rows[0].Cells[1];
                    }

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        if (r["id"].ToString() == dgv.CurrentCell.Value.ToString())
                        {
                            txt_id.Text = r["id"].ToString();
                            txt_aname.Text = r["aname"].ToString();
                            txt_ename.Text = r["ename"].ToString();
                            chk_cc1.Checked = Convert.ToBoolean(r["cc1"]);
                            chk_cc2.Checked = Convert.ToBoolean(r["cc2"]);
                            com_branch_id.SelectedValue = r["branch_id"].ToString();
                            txt_notes.Text = r["notes"].ToString();
                            chk_stop.Checked = Convert.ToBoolean(r["stop"]);
                            lbl_creationtime.Text = r["creationtime"].ToString();
                            lbl_editingtime.Text = r["editingtime"].ToString();
                            lbl_createuser_id.Text = r["createuser_id"].ToString();
                            lbl_edituser_id.Text = r["edituser_id"].ToString();

                            if (r["edit"].ToString() != "0")
                            {
                                btn_info.Visible = true;
                                btn_info.Text = "معدل" + " " + r["edit"].ToString();
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
        void Bind()
        {
            module.id = txt_id.Text.Trim();
            module.aname = txt_aname.Text.Trim();
            module.ename = txt_ename.Text.Trim();
            module.cc1 = chk_cc1.Checked;
            module.cc2 = chk_cc2.Checked;
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.branch_id = (com_branch_id.SelectedValue != null) ? com_branch_id.SelectedValue.ToString() : string.Empty;
            module.notes = txt_notes.Text.Trim();
            module.stop = chk_stop.Checked;
            module.parent_id = (ParentID.Count > 0) ? ParentID[ParentID.Count - 1] : null;
            module.user_id = frm_main.com_users.SelectedValue.ToString();
        }

        void Refresh_Data()
        {
            ds = module.Select();
            ds.Tables["tbl_chart"].DefaultView.RowFilter = (ParentID.Count == 0) ? "parent_id is null" : "parent_id = " + ParentID[ParentID.Count - 1];
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
                    s += "\r\n,";
                    s += tabindex + "- " + c.Name.ToString();
                }
            }
            s += "\r\n,96- lbl_creationtime";
            s += "\r\n,97- lbl_editingtime";
            s += "\r\n,98- lbl_createuser_id";
            s += "\r\n,99- lbl_edituser_id\r\n";
            String[] a = s.Split(',');
            Array.Sort(a);
            s = string.Join(",", a);

            if (MessageBox.Show(s, "Click OK to copy", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            { Clipboard.SetText(s); }
        }
        string Path()
        {
            string s = "";
            foreach (DataRow r in dt_Path.Rows)
            {
                s += r["name"].ToString() + " / ";
            }

            return s;
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
            if (!frm_main.Perm("0104002"))
            {
                MessageBox.Show("ليس لديك تصريح لاضافة مركز تكلفة جديد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Tag = "New";
            Form_Mode("New");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0104003"))
            {
                MessageBox.Show("ليس لديك تصريح لتعديل مركز تكلفة", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                Refresh_Data();
                //dgv.DataSource = ds.Tables[0];
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
                Refresh_Data();
                dgv.CurrentCell = dgv.Rows[record_index].Cells[0];
            }
            Tag = "Select";
            Form_Mode("Select");
            #endregion
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0104004"))
            {
                MessageBox.Show("ليس لديك تصريح لحذف مركز تكلفة", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
            Refresh_Data();

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
        private void btn_UP_Click(object sender, EventArgs e)
        {
            if (level == 2)
            {
                level--;
                string i = ParentID[ParentID.Count - 1];
                ParentID.Clear();
                dt_Path.Rows.Clear();

                ds.Tables["tbl_chart"].DefaultView.RowFilter = "parent_id IS NULL";
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    if (r.Cells[0].Value.ToString() == i)
                    {
                        dgv.CurrentCell = dgv.Rows[r.Index].Cells[0];
                        break;
                    }
                }
                Form_Mode("Select");
                lbl_Path.Text = "";
                lbl_Level.Text = "المستوى : " + level.ToString();
            }
            else if (level > 2)
            {
                level--;
                string i = ParentID[ParentID.Count - 1];
                ParentID.RemoveAt(ParentID.Count - 1);
                dt_Path.Rows.RemoveAt(dt_Path.Rows.Count - 1);

                if (dgv.RowCount > 0) dgv.CurrentCell = dgv.SelectedRows[0].Cells[1];
                lbl_Path.Text = Path();

                ds.Tables["tbl_chart"].DefaultView.RowFilter = "parent_id = " + ParentID[ParentID.Count - 1];
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    if (r.Cells[0].Value.ToString() == i)
                    {
                        dgv.CurrentCell = dgv.Rows[r.Index].Cells[0];
                        break;
                    }
                }


                lbl_Path.Text = Path();
                lbl_Level.Text = "المستوى : " + level.ToString();
                Form_Mode("Select");
            }
        }
        private void btn_Dowen_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows != null)
            {
                dgv_CellDoubleClick(dgv, new DataGridViewCellEventArgs(dgv.CurrentCell.ColumnIndex, dgv.CurrentRow.Index));
            }
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            ParentID.Add(dgv.SelectedRows[0].Cells[0].Value.ToString());
            dt_Path.Rows.Add(dgv.SelectedRows[0].Cells[0].Value.ToString(), dgv.SelectedRows[0].Cells[1].Value.ToString());

            level++;
            dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[1];

            lbl_Path.Text += dgv.CurrentCell.Value.ToString() + " / ";
            lbl_Level.Text = "المستوى : " + level.ToString();
            ds.Tables["tbl_chart"].DefaultView.RowFilter = "parent_id = " + ParentID[ParentID.Count - 1];


            if (dgv.RowCount > 0)
            {
                Form_Mode("Select");
            }
            else
            {
                Form_Mode("Empty");
            }
        }
        private void dgv_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgv.RowCount == 0) return;

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                dgv_CellClick(null, null);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv.SelectedRows != null)
                {
                    dgv_CellDoubleClick(dgv, new DataGridViewCellEventArgs(dgv.CurrentCell.ColumnIndex, dgv.CurrentRow.Index));
                }
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty")
            {
                Tag = "Select";
                Form_Mode("Select");
            }
        }
        #endregion
    }
}
