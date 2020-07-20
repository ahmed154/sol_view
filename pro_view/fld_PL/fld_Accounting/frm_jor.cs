using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting
{

    public partial class frm_jor : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_Accounting.stc_jor module = new fld_BL.cls_bl.stc_Accounting.stc_jor();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt_JorCyc = new DataTable();

        DataView dv_AutoComplete = new DataView();
        DataView dv_AutoComplete_cc1 = new DataView();
        DataView dv_AutoComplete_cc2 = new DataView();
        DataView dv_AutoComplete_branches= new DataView();
        #endregion
        public frm_jor(fld_Login.frm_main frm_MAIN)
        {
            InitializeComponent();

            frm_main = frm_MAIN;
            dgv.AutoGenerateColumns = false;
            dgv_AutoComplete.AutoGenerateColumns = false;
            dgv_Auto_cc1.AutoGenerateColumns = false;
            dgv_Auto_cc2.AutoGenerateColumns = false;
            dgv_Auto_Branch.AutoGenerateColumns = false;

            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "Login";
            ds = module.SelectLogin();

            DataRow dr_cc1 = ds.Tables["tbl_cc1"].NewRow();
            DataRow dr_cc2 = ds.Tables["tbl_cc2"].NewRow(); 

            ds.Tables["tbl_cc1"].Rows.InsertAt(dr_cc1, 0);
            ds.Tables["tbl_cc2"].Rows.InsertAt(dr_cc2, 0);

            dgv_AutoComplete.Columns["auto_ChartName"].Width = Convert.ToInt32(dgv_AutoComplete.Width * .60);
            dv_AutoComplete = ds.Tables["tbl_chart"].DefaultView;
            dv_AutoComplete_cc1 = ds.Tables["tbl_cc1"].DefaultView;
            dv_AutoComplete_cc2 = ds.Tables["tbl_cc2"].DefaultView;
            dv_AutoComplete_branches = ds.Tables["tbl_branches"].DefaultView;


            dgv_AutoComplete.Location = new Point(1, dgv.ColumnHeadersHeight + 1);


            com_jortype_id.DataSource = ds.Tables["tbl_jortype"];
            com_jortype_id.ValueMember = "id";
            com_jortype_id.DisplayMember = "aname";
            com_jortype_id.SelectedValue = -1;

            com_currency_id.DataSource = ds.Tables["tbl_currencies"];
            com_currency_id.ValueMember = "id";
            com_currency_id.DisplayMember = "aname";
            com_currency_id.SelectedValue = -1;

            com_CC1.DataSource = ds.Tables["tbl_cc1"];
            com_CC1.ValueMember = "id";
            com_CC1.DisplayMember = "aname";
            com_CC1.SelectedValue = -1;

            com_CC2.DataSource = ds.Tables["tbl_cc2"];
            com_CC2.ValueMember = "id";
            com_CC2.DisplayMember = "aname";
            com_CC2.SelectedValue = -1;

            com_doctype_id.DataSource = ds.Tables["tbl_jortype"];
            com_doctype_id.ValueMember = "id";
            com_doctype_id.DisplayMember = "aname";
            com_doctype_id.SelectedValue = -1;

            dt_JorCyc = ds.Tables["tbl_jorcyc"].Copy();
            com_JorCyc.DataSource = dt_JorCyc;
            com_JorCyc.ValueMember = "h_id";
            com_JorCyc.DisplayMember = "h_notes";
            com_JorCyc.SelectedValue = -1;

            #region dgv
            var Debit = new DataGridViewTextBoxColumn();
            Debit.Name = "debit";
            Debit.HeaderText = "مدين";
            Debit.DataPropertyName = "debit";
            Debit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Debit.Width = 70;
            Debit.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(Debit);

            var Credit = new DataGridViewTextBoxColumn();
            Credit.Name = "credit";
            Credit.HeaderText = "دائن";
            Credit.DataPropertyName = "credit";
            Credit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Credit.Width = 70;
            Credit.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(Credit);

            var ACC_Name = new DataGridViewTextBoxColumn();
            ACC_Name.Name = "chart_name";
            ACC_Name.HeaderText = "الحساب";
            ACC_Name.DataPropertyName = "aname";
            ACC_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ACC_Name.Width = 150;
            ACC_Name.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(ACC_Name);

            var ACC_ID = new DataGridViewTextBoxColumn();
            ACC_ID.Name = "chart_id";
            ACC_ID.HeaderText = "";
            ACC_ID.DataPropertyName = "chart_id";
            ACC_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ACC_ID.Width = 120;
            ACC_ID.ReadOnly = true;
            ACC_ID.Visible = true;
            ACC_ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(ACC_ID);

            var Notes = new DataGridViewTextBoxColumn();
            Notes.Name = "notes";
            Notes.HeaderText = "البيان";
            Notes.DataPropertyName = "notes";
            Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Notes.Width = 150;
            Notes.MinimumWidth = 150;
            Notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(Notes);

            var cc1_name = new DataGridViewTextBoxColumn();
            cc1_name.Name = "cc1_name";
            cc1_name.HeaderText = "مركز1";
            cc1_name.DataPropertyName = "cc1_aname";
            cc1_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc1_name.Width = 150;
            cc1_name.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(cc1_name);

            var cc1_id = new DataGridViewTextBoxColumn();
            cc1_id.Name = "cc1_id";
            cc1_id.HeaderText = "";
            cc1_id.DataPropertyName = "cc1_id";
            cc1_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc1_id.Width = 200;
            cc1_id.ReadOnly = true;
            cc1_id.Visible = false;
            cc1_id.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(cc1_id);

            var cc2_name = new DataGridViewTextBoxColumn();
            cc2_name.Name = "cc2_name";
            cc2_name.HeaderText = "مركز2";
            cc2_name.DataPropertyName = "cc2_aname";
            cc2_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc2_name.Width = 150;
            cc2_name.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(cc2_name);

            var cc2_id = new DataGridViewTextBoxColumn();
            cc2_id.Name = "cc2_id";
            cc2_id.HeaderText = "";
            cc2_id.DataPropertyName = "cc2_id";
            cc2_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc2_id.Width = 100;
            cc2_id.ReadOnly = true;
            cc2_id.Visible = false;
            cc2_id.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(cc2_id);

            var branch_name = new DataGridViewTextBoxColumn();
            branch_name.Name = "branch_name";
            branch_name.HeaderText = "الفرع";
            branch_name.DataPropertyName = "branch_aname";
            branch_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branch_name.Width = 150;
            branch_name.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(branch_name);

            var branch_id = new DataGridViewTextBoxColumn();
            branch_id.Name = "branch_id";
            branch_id.HeaderText = "";
            branch_id.DataPropertyName = "branch_id";
            branch_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branch_id.Width = 100;
            branch_id.ReadOnly = true;
            branch_id.Visible = false;
            branch_id.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgv.Columns.Add(branch_id);
            #endregion
        }

        #region Form
        private void frm_Shown(object sender, EventArgs e)
        {
            #region ContextMenuStrips
            // Branches
            contextMenuStrip_branches.ForeColor = Color.MidnightBlue;

            for (int i = 0; i < com_Branches.Items.Count; i++)
            {
                contextMenuStrip_branches.Items.Add(com_Branches.GetItemText(com_Branches.Items[i]), frm_main.imageList16.Images["Branch_16.png"]);
            }

            // CC1
            com_CC1.SelectedValue = -1;
            btn_cc1_del.Image = frm_main.imageList16.Images["Close_16.png"];
            contextMenuStrip_cc1.ForeColor = Color.MidnightBlue;

            for (int i = 0; i < com_CC1.Items.Count; i++)
            {
                contextMenuStrip_cc1.Items.Add(com_CC1.GetItemText(com_CC1.Items[i]), frm_main.imageList16.Images["CC_16.png"]);
            }

            // CC2
            com_CC2.SelectedValue = -1;
            btn_cc2_del.Image = frm_main.imageList16.Images["Close_16.png"];
            contextMenuStrip_cc2.ForeColor = Color.MidnightBlue;

            for (int i = 0; i < com_CC2.Items.Count; i++)
            {
                contextMenuStrip_cc2.Items.Add(com_CC2.GetItemText(com_CC2.Items[i]), frm_main.imageList16.Images["CC_16.png"]);
            }

            // Users
            contextMenuStrip_users.ForeColor = Color.MidnightBlue;
            for (int i = 0; i < com_Users.Items.Count; i++)
            {
                contextMenuStrip_users.Items.Add(com_Users.GetItemText(com_Users.Items[i]), frm_main.imageList16.Images["User_16.png"]);
            }
            #endregion

            dgv_AutoComplete.Columns["auto_ChartName"].Width = dgv.Columns["chart_name"].Width;
            dgv_AutoComplete.Columns["auto_ChartID"].Width = dgv.Columns["chart_id"].Width;

            if (txt_id.Text != "")
            {
                module.id = txt_id.Text.Trim();
                module.company_id = frm_main.com_companies.SelectedValue.ToString();
                module.selecttype = "Select";

                dt = module.Select().Tables["tbl_jor"];
                if (dt.Rows.Count == 0) return;

                Form_Mode("Select");
            }
            else
            {
                module.selecttype = "Login";
                Form_Mode("Empty");
            }           
        }
        private void frm_jor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btn_New_Click(null, null);
                    break;
                case Keys.F6:
                    btn_Edit_Click(null, null);
                    break;
                case Keys.F7:
                    btn_Save_Click(null, null);
                    break;
                case Keys.F8:
                    btn_Delete_Click(null, null);
                    break;
                case Keys.F9:
                    btn_Cancel_Click(null, null);
                    break;
                case Keys.F10:
                    break;
                case Keys.F11:
                    break;
                case Keys.F12:
                    break;


                case Keys.Escape:
                    txt_Ghost.Visible = false;
                    txt_Auto_cc1.Visible = false;
                    txt_Auto_cc2.Visible = false;
                    txt_Auto_Branch.Visible = false;

                    dgv_AutoComplete.Visible = false;
                    dgv_Auto_cc1.Visible = false;
                    dgv_Auto_cc2.Visible = false;
                    dgv_Auto_Branch.Visible = false;

                    dgv.Focus();
                    break;


                case Keys.Delete:
                    if ((Tag.ToString() == "New" || Tag.ToString() == "Edit") && dgv.CurrentRow != null && dgv.Focused)
                    {
                        dgv.Rows.Remove(dgv.CurrentRow);
                        Calc_Total();

                        txt_Ghost.Visible = false;
                        txt_Ghost.Text = "";
                        dgv_AutoComplete.Visible = false;
                        dv_AutoComplete.RowFilter = "";
                    }
                    break;
                case Keys.F4:
                    if ((Tag.ToString() == "New" || Tag.ToString() == "Edit") && dgv.CurrentCell != null && dgv.Focused)
                    {
                        if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
                        {
                            txt_Auto_cc1.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                            txt_Auto_cc1.Width = dgv.CurrentCell.OwningColumn.Width;
                            txt_Auto_cc1.Location = new Point(txt_Auto_cc1.Location.X + 3, txt_Auto_cc1.Location.Y + 16);
                            txt_Auto_cc1.Visible = true;

                            dgv_Auto_cc1.DataSource = null;
                            dgv_Auto_cc1.DataSource = dv_AutoComplete_cc1;

                            if (dgv_Auto_cc1.RowCount > 0)
                            {
                                dgv_Auto_cc1.CurrentCell = dgv_Auto_cc1.Rows[0].Cells[0];
                                dgv_Auto_cc1.Width = txt_Auto_cc1.Width;
                                dgv_Auto_cc1.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;

                                if (dgv_Auto_cc1.Bottom < dgv.Bottom)
                                {
                                    dgv_Auto_cc1.Location = new Point(dgv_Auto_cc1.Location.X + 3, dgv_Auto_cc1.Location.Y + txt_Auto_cc1.Size.Height + 16);
                                }
                                else
                                {
                                    dgv_Auto_cc1.Location = new Point(dgv_Auto_cc1.Location.X, dgv_Auto_cc1.Location.Y - 120);
                                }

                                dgv_Auto_cc1.Visible = true;
                            }

                            Refresh();
                            txt_Auto_cc1.Focus();
                        }
                        else if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
                        {
                            txt_Auto_cc2.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                            txt_Auto_cc2.Width = dgv.CurrentCell.OwningColumn.Width;
                            txt_Auto_cc2.Location = new Point(txt_Auto_cc2.Location.X + 3, txt_Auto_cc2.Location.Y + 16);
                            txt_Auto_cc2.Visible = true;

                            dgv_Auto_cc2.DataSource = null;
                            dgv_Auto_cc2.DataSource = dv_AutoComplete_cc2;

                            if (dgv_Auto_cc2.RowCount > 0)
                            {
                                dgv_Auto_cc2.CurrentCell = dgv_Auto_cc2.Rows[0].Cells[0];
                                dgv_Auto_cc2.Width = txt_Auto_cc2.Width;
                                dgv_Auto_cc2.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;

                                if (dgv_Auto_cc2.Bottom < dgv.Bottom)
                                {
                                    dgv_Auto_cc2.Location = new Point(dgv_Auto_cc2.Location.X + 3, dgv_Auto_cc2.Location.Y + txt_Auto_cc2.Size.Height + 16);
                                }
                                else
                                {
                                    dgv_Auto_cc2.Location = new Point(dgv_Auto_cc2.Location.X, dgv_Auto_cc2.Location.Y - 120);
                                }

                                dgv_Auto_cc2.Visible = true;
                            }

                            Refresh();
                            txt_Auto_cc2.Focus();
                        }
                        else if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
                        {
                            txt_Auto_Branch.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                            txt_Auto_Branch.Width = dgv.CurrentCell.OwningColumn.Width;
                            txt_Auto_Branch.Location = new Point(txt_Auto_Branch.Location.X + 3, txt_Auto_Branch.Location.Y + 16);
                            txt_Auto_Branch.Visible = true;

                            dgv_Auto_Branch.DataSource = null;
                            dgv_Auto_Branch.DataSource = dv_AutoComplete_branches;

                            if (dgv_Auto_Branch.RowCount > 0)
                            {
                                dgv_Auto_Branch.CurrentCell = dgv_Auto_Branch.Rows[0].Cells[0];
                                dgv_Auto_Branch.Width = txt_Auto_Branch.Width;
                                dgv_Auto_Branch.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;

                                if (dgv_Auto_Branch.Bottom < dgv.Bottom)
                                {
                                    dgv_Auto_Branch.Location = new Point(dgv_Auto_Branch.Location.X + 3, dgv_Auto_Branch.Location.Y + txt_Auto_Branch.Size.Height + 16);
                                }
                                else
                                {
                                    dgv_Auto_Branch.Location = new Point(dgv_Auto_Branch.Location.X, dgv_Auto_Branch.Location.Y - 120);
                                }

                                dgv_Auto_Branch.Visible = true;
                            }

                            Refresh();
                            txt_Auto_Branch.Focus();
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Pro
        void ClearForm()
        {
            com_CC1.SelectedValue = -1;
            com_CC2.SelectedValue = -1;

            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox || c is MaskedTextBox)
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
                dgv.Rows.Clear();

                txt_TotalDebit.Text = "";
                txt_TotalCredit.Text = "";
                btn_doc_id.Text = "";
                com_doctype_id.SelectedValue = -1;
                pnl_doc.Visible = false;
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
            dgv.ReadOnly = false;
            txt_id.ReadOnly = true;
        }
        void DisableForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is Label) continue;

                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }
                else
                {
                    c.Enabled = false;
                }
            }
            //dgv.Enabled = true;
            dgv.ReadOnly = true;
        }
        void Form_Mode(string mode)
        {
            switch (mode)
            {
                #region New
                case "New":
                    Tag = "New";

                    btn_CC1.Enabled = true;
                    btn_CC2.Enabled = true;

                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;
                    btn_Print.Visible = false;

                    EnableForm();
                    ClearForm();

                    Add_Row();

                    dgv.ClearSelection();
                    dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    dgv.BeginEdit(true);
                    dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

                    txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    com_jortype_id.SelectedIndex = 0;
                    com_currency_id.SelectedIndex = 0;
                    txt_currencyprice.Text = "1";

                    JorCyc(Tag.ToString());

                    break;
                #endregion

                #region Edit
                case "Edit":
                    Tag = "Edit";

                    btn_CC1.Enabled = true;
                    btn_CC2.Enabled = true;
                    btn_cc1_del.Visible = com_CC1.SelectedValue == null ? false : true;
                    btn_cc2_del.Visible = (com_CC2.SelectedValue == null) ? false : true;

                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;
                    btn_Print.Visible = false;

                    dgv.ReadOnly = false;

                    EnableForm();

                    JorCyc(Tag.ToString());

                    break;
                #endregion

                #region Select
                case "Select":
                    Tag = "Select";

                    com_Branches.SelectedValue = dt.Rows[0]["h_branch_id"];
                    com_fyear.SelectedValue = dt.Rows[0]["h_fyear_id"];
                    com_CC1.SelectedValue = dt.Rows[0]["h_cc1_id"];
                    com_CC2.SelectedValue = dt.Rows[0]["h_cc2_id"];
                    com_Users.SelectedValue = dt.Rows[0]["h_createuser_id"];

                    btn_CC1.Enabled = false;
                    btn_CC2.Enabled = false;
                    btn_cc1_del.Visible = false;
                    btn_cc2_del.Visible = false;

                    btn_New.Visible = (com_fyear.SelectedValue == frm_main.com_fyear.SelectedValue);
                    btn_Edit.Visible = (com_fyear.SelectedValue == frm_main.com_fyear.SelectedValue);
                    btn_Save.Visible = false;
                    btn_Delete.Visible = (com_fyear.SelectedValue == frm_main.com_fyear.SelectedValue);
                    btn_Cancel.Visible = false;
                    btn_Print.Visible = true;

                    pnl_Balance.Visible = false;

                    DisableForm();

                    txt_Ghost.Visible = false;
                    txt_Ghost.Text = "";
                    dgv_AutoComplete.Visible = false;
                    dv_AutoComplete.RowFilter = "";

                    if (Convert.ToInt32(dt.Rows[0]["h_fyear_id"]) == Convert.ToInt32(frm_main.com_fyear.SelectedValue))
                    {
                        btn_Edit.Visible = true;
                        btn_Delete.Visible = true;
                    }
                    else
                    {
                        btn_Edit.Visible = false;
                        btn_Delete.Visible = false;
                    }

                    if (Convert.ToBoolean(dt.Rows[0]["h_closed"]) == true)
                    {
                        btn_New.Visible = false;
                        btn_Edit.Visible = false;
                        btn_Delete.Visible = false;
                    }


                    txt_id.Text = dt.Rows[0]["h_id"].ToString();             
                    txt_date.Text = Convert.ToDateTime(dt.Rows[0]["h_creationtime"]).ToString("dd/MM/yyyy");
                    txt_notes.Text = dt.Rows[0]["h_notes"].ToString();
                    dt.Rows[0]["h_creationtime"].ToString();
                    if (!(dt.Rows[0]["h_doctype_id"] is DBNull)) com_doctype_id.SelectedValue = dt.Rows[0]["h_doctype_id"].ToString();
                    btn_doc_id.Text = dt.Rows[0]["h_doc_id"].ToString();
                    com_currency_id.SelectedValue = dt.Rows[0]["h_currency_id"].ToString();
                    txt_currencyprice.Text = dt.Rows[0]["h_currencyprice"].ToString();
                    com_jortype_id.SelectedValue = dt.Rows[0]["h_jortype_id"].ToString();

                    dgv.Rows.Clear();
                    decimal d = 0;
                    decimal c = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        dgv.Rows.Add(r["d_debit"], r["d_credit"], r["d_chart_aname"], r["d_chart_id"], r["d_notes"], r["d_cc1_aname"], r["d_cc1_id"], r["d_cc2_aname"], r["d_cc2_id"], r["d_branch_aname"], r["d_branch_id"]);
                        d += Convert.ToDecimal(r["d_debit"]);
                        c += Convert.ToDecimal(r["d_credit"]);
                    }

                    txt_TotalDebit.Text = d.ToString();
                    txt_TotalCredit.Text = c.ToString();

                    Hide_Zero();

                    dgv.ClearSelection();

                    JorCyc(Tag.ToString());

                    break;
                #endregion

                #region Empty
                case "Empty":
                    Tag = "Empty";

                    btn_CC1.Enabled = false;
                    btn_CC2.Enabled = false;

                    btn_New.Visible = true;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = false;
                    btn_Print.Visible = false;

                    pnl_Balance.Visible = false;

                    DisableForm();
                    ClearForm();

                    txt_Ghost.Visible = false;
                    txt_Ghost.Text = "";
                    dgv_AutoComplete.Visible = false;
                    dv_AutoComplete.RowFilter = "";

                    if (dgv.CurrentRow != null) dgv.CurrentRow.Selected = false;

                    JorCyc(Tag.ToString());

                    break;
                    #endregion
            }
        }
        void JorCyc(string tag)
        {
            switch (tag)
            {
                case "Empty":
                    btn_JorCyc.Visible = false;
                    com_JorCyc.Visible = false;
                    btn_JorCycDelete.Visible = false;
                    break;

                case "Select":

                    btn_JorCyc.Visible = true;
                    btn_JorCycDelete.Visible = false;

                    btn_JorCyc.Image = frm_main.imageList24.Images["Save_24.png"];          

                    if (dt_JorCyc.Rows.Count > 0)
                    {
                        com_JorCyc.Visible = false;
                        com_JorCyc.SelectedValue = -1;
                    }
                    else
                    {
                        com_JorCyc.Visible = false;
                    }
                    break;

                case "New":

                    btn_JorCyc.Image = frm_main.imageList24.Images["Gear_24.png"];
                    btn_JorCycDelete.Image = frm_main.imageList24.Images["Delete_24.png"];

                    if (dt_JorCyc.Rows.Count > 0)
                    {
                        btn_JorCyc.Visible = true;
                        btn_JorCycDelete.Visible = true;
                        com_JorCyc.Visible = true;

                        com_JorCyc.SelectedValue = -1;
                    }
                    else
                    {
                        btn_JorCyc.Visible = false;
                        btn_JorCycDelete.Visible = false;
                        com_JorCyc.Visible = false;
                    }
                    break;

                case "Edit":

                    btn_JorCyc.Image = frm_main.imageList24.Images["Gear_24.png"];
                    btn_JorCycDelete.Image = frm_main.imageList24.Images["Delete_24.png"];

                    if (dt_JorCyc.Rows.Count > 0)
                    {
                        btn_JorCyc.Visible = true;
                        btn_JorCycDelete.Visible = true;
                        com_JorCyc.Visible = true;

                        com_JorCyc.SelectedValue = -1;
                    }
                    else
                    {
                        btn_JorCyc.Visible = false;
                        btn_JorCycDelete.Visible = false;
                        com_JorCyc.Visible = false;
                    }
                    break;
            }
          
        }
        private DataTable DGVToDatatable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                dt.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow Row = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if(cell.Value == null)
                    {
                        if(cell.OwningColumn.Name == "debit" || cell.OwningColumn.Name == "credit")
                        {
                            Row[cell.ColumnIndex] = 0;
                        }
                        else
                        {
                            Row[cell.ColumnIndex] = null;
                        }
                    }
                    else if (cell.Value.ToString() == "")
                    {
                        Row[cell.ColumnIndex] = null;
                    }
                    else
                    {
                        Row[cell.ColumnIndex] = cell.Value;
                    }
                }
                dt.Rows.Add(Row);
            }
            dt.Columns.Remove("chart_name");
            return dt;
        }
        void Bind()
        {
            module.id = txt_id.Text.Trim();
            module.currency_id = com_currency_id.SelectedValue.ToString();
            module.currencyPrice = Convert.ToDecimal(txt_currencyprice.Text);
            module.jortype_id = com_jortype_id.SelectedValue.ToString();
            module.notes = txt_notes.Text.ToString().Trim();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.fyear_id = frm_main.com_fyear.SelectedValue.ToString();
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.cc1_id = (com_CC1.SelectedValue != null)? com_CC1.SelectedValue.ToString() : null;
            module.cc2_id = (com_CC2.SelectedValue != null) ? com_CC2.SelectedValue.ToString() : null;
            module.ddate = DateTime.ParseExact(txt_date.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            module.user_id = com_Users.SelectedValue.ToString();
            module.jorD = DGVToDatatable();
        }
        void Add_Row()
        {
            string notes = null;
            if (dgv.CurrentRow != null)
            {
                if (dgv.CurrentRow.Index == dgv.RowCount - 1)
                {
                    notes = (dgv.CurrentRow.Cells["notes"].Value != null) ? dgv.CurrentRow.Cells["notes"].Value.ToString() : null;
                }
            }

            dgv.Rows.Add(null, null, null, null, notes, com_CC1.Text, com_CC1.SelectedValue, com_CC2.Text, com_CC2.SelectedValue, com_Branches.Text, com_Branches.SelectedValue);
        }
        void Next_Cell(int col, int row)
        {
            for (int i = col + 1; i < dgv.Columns.Count - 1; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    dgv.CurrentCell = dgv[i, row];
                    dgv.Focus();
                    return;
                }
            }
            if (dgv.CurrentRow.Index == dgv.RowCount - 1)
            {
                Add_Row();
                dgv.CurrentCell = dgv[0, row + 1];
            }
            else
            {
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index + 1].Cells["debit"];
            }

            dgv.Focus();
        }
        void Hide_Auto()
        {
            txt_Ghost.Visible = false;
            txt_Auto_cc1.Visible = false;
            txt_Auto_cc2.Visible = false;
            txt_Auto_Branch.Visible = false;

            dgv_Auto_cc1.Visible = false;
            dgv_Auto_cc2.Visible = false;
            dgv_Auto_Branch.Visible = false;
        }
        void Calc_Total()
        {
            decimal d = 0; decimal c = 0;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                d += Convert.ToDecimal(r.Cells["Debit"].Value);
                c += Convert.ToDecimal(r.Cells["Credit"].Value);

            }
            txt_TotalDebit.Text = d.ToString();
            txt_TotalCredit.Text = c.ToString();

            lbl_balance.Text = (d - c).ToString();
            pnl_Balance.Visible = (d - c == 0) ? false : true;
        }
        void Hide_Zero()
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if(Convert.ToDecimal (r.Cells["debit"].Value) == 0)
                {
                    r.Cells["debit"].Style.ForeColor = Color.Transparent;
                }
                if (Convert.ToDecimal(r.Cells["credit"].Value) == 0)
                {
                    r.Cells["credit"].Style.ForeColor = Color.Transparent;
                }
            }
        }
        #endregion

        #region Panel_FRM_Header

        #region btn display
        private void btn_Bill_Branche_MouseEnter(object sender, EventArgs e)
        {
            btn_Bill_Branche.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Bill_Branche_MouseLeave(object sender, EventArgs e)
        {
            btn_Bill_Branche.FlatStyle = FlatStyle.Flat;
        }
        private void lbl_bill_Branches_MouseEnter(object sender, EventArgs e)
        {
            btn_Bill_Branche.FlatStyle = FlatStyle.Popup;
        }
        private void lbl_bill_Branches_MouseLeave(object sender, EventArgs e)
        {
            btn_Bill_Branche.FlatStyle = FlatStyle.Flat;
        }

        private void btn_CC1_MouseEnter(object sender, EventArgs e)
        {
            btn_CC1.FlatStyle = FlatStyle.Popup;
        }
        private void btn_CC1_MouseLeave(object sender, EventArgs e)
        {
            btn_CC1.FlatStyle = FlatStyle.Flat;
        }
        private void lbl_CC1_MouseEnter(object sender, EventArgs e)
        {
            btn_CC1.FlatStyle = FlatStyle.Popup;
        }
        private void lbl_CC1_MouseLeave(object sender, EventArgs e)
        {
            btn_CC1.FlatStyle = FlatStyle.Flat;
        }

        private void btn_CC2_MouseEnter(object sender, EventArgs e)
        {
            btn_CC2.FlatStyle = FlatStyle.Popup;
        }
        private void btn_CC2_MouseLeave(object sender, EventArgs e)
        {
            btn_CC2.FlatStyle = FlatStyle.Flat;
        }
        private void lbl_CC2_MouseEnter(object sender, EventArgs e)
        {
            btn_CC2.FlatStyle = FlatStyle.Popup;
        }
        private void lbl_CC2_MouseLeave(object sender, EventArgs e)
        {
            btn_CC2.FlatStyle = FlatStyle.Flat;
        }

        private void lbl_CC1_TextChanged(object sender, EventArgs e)
        {
            btn_cc1_del.Visible = (lbl_CC1.Text != "" && Tag.ToString() == "New" | Tag.ToString() == "Edit") ? true : false;
        }
        private void lbl_CC2_TextChanged(object sender, EventArgs e)
        {
            btn_cc2_del.Visible = (lbl_CC2.Text != "" && Tag.ToString() == "New" | Tag.ToString() == "Edit") ? true : false;
        }

        private void btn_Bill_User_MouseEnter(object sender, EventArgs e)
        {
            btn_Bill_User.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Bill_User_MouseLeave(object sender, EventArgs e)
        {
            btn_Bill_User.FlatStyle = FlatStyle.Flat;
        }

        private void btn_cc1_del_MouseEnter(object sender, EventArgs e)
        {
            btn_cc1_del.FlatStyle = FlatStyle.Popup;
        }
        private void btn_cc1_del_MouseLeave(object sender, EventArgs e)
        {
            btn_cc1_del.FlatStyle = FlatStyle.Flat;
        }
        private void btn_cc2_del_MouseEnter(object sender, EventArgs e)
        {
            btn_cc2_del.FlatStyle = FlatStyle.Popup;
        }
        private void btn_cc2_del_MouseLeave(object sender, EventArgs e)
        {
            btn_cc2_del.FlatStyle = FlatStyle.Flat;
        }
        #endregion

        private void com_Branches_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_bill_Branches.Text = com_Branches.Text;
        }
        private void com_CC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_CC1.Text = com_CC1.Text;
        }
        private void com_CC2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_CC2.Text = com_CC2.Text;
        }
        private void com_fyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_fyear.Text = com_fyear.Text;
        }
        private void com_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Bill_User.Text = com_Users.Text;
        }

        private void btn_Bill_Branche_Click(object sender, EventArgs e)
        {
            //if (com_Branches.Enabled == false) return;
            Point p = btn_Bill_Branche.PointToScreen(Point.Empty);
            contextMenuStrip_branches.Show(p.X - (contextMenuStrip_branches.Width - btn_Bill_Branche.Width), p.Y + btn_Bill_Branche.Height);
        }
        private void lbl_bill_Branches_Click(object sender, EventArgs e)
        {
            if(btn_Bill_Branche.Enabled)
            {
                btn_Bill_Branche_Click(null, null);
            }
        }
        private void btn_CC1_Click(object sender, EventArgs e)
        {
            //if (com_CC1.Enabled == false) return;
            Point p = btn_CC1.PointToScreen(Point.Empty);
            contextMenuStrip_cc1.Show(p.X - (contextMenuStrip_cc1.Width - btn_CC1.Width), p.Y + btn_CC1.Height);
        }
        private void lbl_CC1_Click(object sender, EventArgs e)
        {
            if (btn_CC1.Enabled)
            {
                btn_CC1_Click(null, null);
            }
        }
        private void btn_cc1_del_Click(object sender, EventArgs e)
        {
            com_CC1.SelectedValue = -1;
            btn_cc1_del.Visible = false;
        }
        private void btn_CC2_Click(object sender, EventArgs e)
        {
            //if (com_CC2.Enabled == false) return;
            Point p = btn_CC2.PointToScreen(Point.Empty);
            contextMenuStrip_cc2.Show(p.X - (contextMenuStrip_cc2.Width - btn_CC2.Width), p.Y + btn_CC2.Height);
        }
        private void lbl_CC2_Click(object sender, EventArgs e)
        {
            if (btn_CC2.Enabled)
            {
                btn_CC2_Click(null, null);
            }
        }
        private void btn_cc2_del_Click(object sender, EventArgs e)
        {
            com_CC2.SelectedValue = -1;
            btn_cc2_del.Visible = false;
        }
        private void btn_Bill_User_Click(object sender, EventArgs e)
        {
            if (com_Users.Enabled == false) return;
            Point p = btn_Bill_User.PointToScreen(Point.Empty);
            contextMenuStrip_users.Show(p.X - (contextMenuStrip_users.Width - btn_Bill_User.Width), p.Y + btn_Bill_User.Height);
        }
        private void lbl_Bill_User_Click(object sender, EventArgs e)
        {
            if(btn_Bill_User.Enabled)
            {
                btn_Bill_User_Click(null, null);
            }

        }
        private void btn_fyear_Click(object sender, EventArgs e)
        {
            if (com_fyear.Enabled == false) return;
            Point p = btn_fyear.PointToScreen(Point.Empty);
            cms_fyear.Show(p.X - (cms_fyear.Width - btn_fyear.Width), p.Y + btn_fyear.Height);
        }
        private void contextMenuStrip_branches_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_Branches.SelectedIndex = contextMenuStrip_branches.Items.IndexOf(e.ClickedItem);
            lbl_bill_Branches.Text = com_Branches.Text;
            lbl_bill_Branches.Location = new Point(lbl_bill_Branches.Left - lbl_bill_Branches.Width, lbl_bill_Branches.Location.Y);
        }
        private void contextMenuStrip_cc1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_CC1.SelectedIndex = contextMenuStrip_cc1.Items.IndexOf(e.ClickedItem);
            lbl_CC1.Text = com_CC1.Text;
            btn_cc1_del.Visible = true;
        }
        private void contextMenuStrip_cc2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_CC2.SelectedIndex = contextMenuStrip_cc2.Items.IndexOf(e.ClickedItem);
            lbl_CC2.Text = com_CC2.Text;
            btn_cc2_del.Visible = true;
        }
        private void cms_fyear_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_fyear.SelectedIndex = cms_fyear.Items.IndexOf(e.ClickedItem);
            lbl_fyear.Text = com_fyear.Text;
        }
        private void contextMenuStrip_users_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_Users.SelectedIndex = contextMenuStrip_users.Items.IndexOf(e.ClickedItem);
            lbl_Bill_User.Text = com_Users.Text;
            lbl_Bill_User.Location = new Point(lbl_Bill_User.Left - lbl_Bill_User.Width, lbl_Bill_User.Location.Y);
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
        private void btn_Print_MouseEnter(object sender, EventArgs e)
        {
            btn_Print.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Print_MouseLeave(object sender, EventArgs e)
        {
            btn_Print.FlatStyle = FlatStyle.Flat;
        }
        #endregion
        private void btn_New_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0203002"))
            {
                MessageBox.Show("ليس لديك تصريح لاضافة قيد جديد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form_Mode("New");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0203003"))
            {
                MessageBox.Show("ليس لديك تصريح لتعديل قيد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form_Mode("Edit");
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();

            #region Validation
            foreach (DataRow r in ds.Tables["tbl_fyears"].Rows)
            {
                if(r["id"].ToString() == com_fyear.SelectedValue.ToString())
                {
                    DateTime jordate = DateTime.ParseExact(txt_date.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    DateTime begindate = Convert.ToDateTime(r["beigndate"]);
                    DateTime enddate = Convert.ToDateTime(r["enddate"]);

                    string fyearname = r["aname"].ToString();

                    if (jordate < begindate || jordate > enddate)
                    {
                        MessageBox.Show("تاريخ القيد خارج حدود السنة المالية " + fyearname, "دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_date.Focus();
                        return;
                    }
                }
            }

            if (dgv.RowCount == 0)
            {
                MessageBox.Show("يلزم إدخال بيانات القيد", "دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Add_Row();
                return;
            }

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if(dgv.Rows[i].Cells["debit"].Value == null && dgv.Rows[i].Cells["credit"].Value == null)
                {
                    dgv.CurrentCell = dgv.Rows[i].Cells["debit"];
                    MessageBox.Show("لم يتم إدخال قيمة", "دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgv.Focus();
                    return;
                }

                if(dgv.Rows[i].Cells["chart_id"].Value == null)
                {
                    MessageBox.Show("لم يتم تحديد الحساب", "دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgv.CurrentCell = dgv.Rows[i].Cells["chart_name"];
                    return;
                }
            }

            if(Convert.ToDecimal(txt_TotalDebit.Text) != Convert.ToDecimal(txt_TotalCredit.Text))
            {
                MessageBox.Show("القيد غير متزن","دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion

            Bind();

            #region New
            if (Tag.ToString() == "New")
            {
                dt = module.Insert().Tables["tbl_jor"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["h_notes"] != null)
                    {
                        if (dt.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt.Rows[0]["h_notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Edit
            else if (Tag.ToString() == "Edit")
            {
                dt = module.Update().Tables["tbl_jor"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["h_notes"] != null)
                    {
                        if (dt.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt.Rows[0]["h_notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
            }
            #endregion

            Form_Mode("Select");
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0203004"))
            {
                MessageBox.Show("ليس لديك تصريح لحذف قيد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل بالفعل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                return;
            }

            Bind();
            dt = module.Delete().Tables["tbl_jor"];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["h_notes"] != null)
                {
                    if (dt.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                    {
                        if (dt.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                        {
                            string[] arrey = dt.Rows[0]["h_notes"].ToString().Split(',');
                            MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                            return;
                        }
                    }
                }
            }
            Form_Mode("Empty");
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Tag.ToString() == "New")
            {
                Form_Mode("Empty");
            }
            else if (Tag.ToString() == "Edit")
            {
                Form_Mode("Select");
            }
        }
        private void btn_CopyBalance_Click(object sender, EventArgs e)
        {
            string balance = Math.Abs(Convert.ToDecimal(lbl_balance.Text)).ToString();

            if (dgv.CurrentRow != null)
            {
                if (dgv.CurrentRow.Cells["debit"].Value == null && dgv.CurrentRow.Cells["credit"].Value == null)
                {
                    if (Convert.ToDecimal(txt_TotalDebit.Text) > Convert.ToDecimal(txt_TotalCredit.Text))
                    {
                        dgv.CurrentRow.Cells["credit"].Value = balance;
                    }
                    else if (Convert.ToDecimal(txt_TotalDebit.Text) < Convert.ToDecimal(txt_TotalCredit.Text))
                    {
                        dgv.CurrentRow.Cells["debit"].Value = balance;
                    }

                    dgv.CurrentCell = dgv.CurrentRow.Cells["chart_name"];
                }
                else
                {
                    Add_Row();
                    dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];

                    if (Convert.ToDecimal(txt_TotalDebit.Text) > Convert.ToDecimal(txt_TotalCredit.Text))
                    {
                        dgv.CurrentRow.Cells["credit"].Value = balance;
                    }
                    else if (Convert.ToDecimal(txt_TotalDebit.Text) < Convert.ToDecimal(txt_TotalCredit.Text))
                    {
                        dgv.CurrentRow.Cells["debit"].Value = balance;
                    }

                    dgv.CurrentCell = dgv.CurrentRow.Cells["chart_name"];
                }
            }
        }
        private void com_jortype_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(com_jortype_id.Focused)
            {
                if (com_jortype_id.SelectedValue.ToString() == "2")
                {
                    MessageBox.Show("إفتتاحي حسابات مخصص فقط للقيد الذي ينشأ بعد إقفال الحسابات", "دفتر القيود", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    com_jortype_id.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region Details
        private void dtp_begindate_ValueChanged(object sender, EventArgs e)
        {
            txt_date.Text = dtp_begindate.Value.ToString("dd/MM/yyyy");
            txt_date.Text =  dtp_begindate.Value.ToString("dd/MM/yyyy");
        }
        #endregion

        #region dgv
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty") return;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgv.CurrentCell.ColumnIndex;
                int iRow = dgv.CurrentCell.RowIndex;

                if (dgv.CurrentCell.OwningColumn.Name == "debit")
                {
                    if (Convert.ToDecimal(dgv.Rows[iRow].Cells["debit"].Value) > 0)
                    {
                        iColumn++;
                    }
                }


                for (int i = iColumn; i < dgv.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i + 1].Visible)
                    {
                        dgv.CurrentCell = dgv[i + 1, iRow];
                        return;
                    }
                }
                if(iRow == dgv.RowCount - 1)
                {
                    Add_Row();
                    if(dgv.CurrentRow.Cells["debit"].Value == null)
                    {
                        dgv.CurrentCell = dgv[0, iRow + 1];
                    }
                    else
                    {
                        dgv.CurrentCell = dgv[1, iRow + 1];
                    }
                }        
                else
                {
                    dgv.CurrentCell = dgv.Rows[iRow + 1].Cells["debit"];               
                }
            }
            else if (e.KeyCode == Keys.Insert)
            {
                Add_Row();
                dgv.CurrentCell = dgv[0, dgv.CurrentCell.RowIndex + 1];
            }
        }
        private void dgv_CurrentCellChanged(object sender, EventArgs e)
        {
            Hide_Auto();

            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty") return;
            if (dgv.CurrentCell == null) return;

            if (dgv.CurrentCell.OwningColumn.Name == "chart_name")
            {
                txt_Ghost.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                txt_Ghost.Width = dgv.CurrentCell.OwningColumn.Width + dgv.CurrentRow.Cells["chart_id"].OwningColumn.Width;
                txt_Ghost.Location = new Point(txt_Ghost.Location.X + 3 - dgv.CurrentRow.Cells["chart_id"].OwningColumn.Width, txt_Ghost.Location.Y + 16);
                txt_Ghost.Visible = true;

                dgv_AutoComplete.DataSource = null;
                dgv_AutoComplete.DataSource = dv_AutoComplete;

                if (dgv_AutoComplete.RowCount > 0)
                {
                    dgv_AutoComplete.CurrentCell = dgv_AutoComplete.Rows[0].Cells[0];
                    dgv_AutoComplete.Location = txt_Ghost.Location;
                    dgv_AutoComplete.Width = txt_Ghost.Width;

                    if (dgv_AutoComplete.Bottom < dgv.Bottom)
                    {
                        dgv_AutoComplete.Location = new Point(dgv_AutoComplete.Location.X, dgv_AutoComplete.Location.Y + txt_Ghost.Size.Height + 1);
                    }
                    else
                    {
                        dgv_AutoComplete.Location = new Point(dgv_AutoComplete.Location.X, dgv_AutoComplete.Location.Y - 120);
                    }

                    dgv_AutoComplete.Visible = true;
                }

                Refresh();
                txt_Ghost.Focus();
            }
            else 
            {
                txt_Ghost.Visible = false;
                txt_Ghost.Text = "";
                dgv_AutoComplete.Visible = false;
                dv_AutoComplete.RowFilter = "";
            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDecimal_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == 0 || dgv.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnDecimal_KeyPress);
                }
            }
        }
        private void ColumnDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Only Number
            // only numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                if (e.KeyChar != 043) { System.Media.SystemSounds.Hand.Play(); }
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                System.Media.SystemSounds.Hand.Play();
            }
            #endregion
        }
        private void dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {       
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                decimal d = 0; decimal c = 0;
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    d += Convert.ToDecimal(r.Cells["Debit"].Value);
                    c += Convert.ToDecimal(r.Cells["Credit"].Value);

                }
                txt_TotalDebit.Text = d.ToString();
                txt_TotalCredit.Text = c.ToString();

                lbl_balance.Text = (d - c).ToString();
                pnl_Balance.Visible = (d - c == 0) ? false : true;
            }
        }
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow.Cells["chart_id"].Selected == true)
            {
                dgv.CurrentRow.Cells["chart_name"].Selected = true;
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.CurrentCell.OwningColumn.Name == "cc1_name" || dgv.CurrentCell.OwningColumn.Name == "cc2_name" || dgv.CurrentCell.OwningColumn.Name == "branch_name")
            {
                SendKeys.Send("{F4}");
            }
        }
        #endregion

        #region AutoComplete

        #region txt_AutoComplete
        private void txt_Ghost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv_AutoComplete.Focus();
                SendKeys.Send("{DOWN}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                dgv_AutoComplete.Focus();
                SendKeys.Send("{UP}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv_AutoComplete.CurrentCell != null)
                {
                    if (dgv.CurrentCell.OwningColumn.Name == "chart_name")
                    { 
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["chart_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["cc1_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.OwningColumn.Name = "cc2_name"];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["cc2_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.OwningColumn.Name = "branch_name"];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["branch_id"].Value = id;

                        dgv_KeyDown(null, e);
                    }
                }

            }
        }
        private void txt_Ghost_TextChanged(object sender, EventArgs e)
        {
            //if (dgv.CurrentCell.OwningColumn.Name == "chart_name")
            //{
                dv_AutoComplete.RowFilter = "aname Like '%" + txt_Ghost.Text + "%' OR id Like '%" + txt_Ghost.Text + "%'";
            //}
        }
        #endregion

        #region dgv_AutoComplete
        private void dgv_AutoComplete_SelectionChanged(object sender, EventArgs e)
        {
            txt_Ghost.Focus();
            txt_Ghost.SelectionStart = txt_Ghost.Text.Length;
        }
        private void dgv_AutoComplete_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.CurrentCell.Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value;

            if(dgv.CurrentCell.OwningColumn.Name == "chart_name")
            {
                dgv.CurrentRow.Cells["chart_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
            {
                dgv.CurrentRow.Cells["cc1_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
            {
                dgv.CurrentRow.Cells["cc2_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
            {
                dgv.CurrentRow.Cells["branch_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;
                //dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }

            dgv.Focus();
        }
        #endregion

        #region txt_Auto_cc1
        private void txt_Auto_cc1_TextChanged(object sender, EventArgs e)
        {
            if(txt_Auto_cc1.Text.Trim() == "")
            {
                dv_AutoComplete_cc1.RowFilter = "";
            }
            else
            {
                dv_AutoComplete_cc1.RowFilter = "aname Like '%" + txt_Auto_cc1.Text + "%' OR id Like '%" + txt_Auto_cc1.Text + "%'";
            }
        }
        private void txt_Auto_cc1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv_Auto_cc1.Focus();
                SendKeys.Send("{DOWN}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                dgv_Auto_cc1.Focus();
                SendKeys.Send("{UP}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv_Auto_cc1.CurrentCell != null)
                {
                    if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
                    {
                        string name = dgv_Auto_cc1.CurrentRow.Cells["col_auto_cc1_name"].Value.ToString();
                        string id = dgv_Auto_cc1.CurrentRow.Cells["col_auto_cc1_id"].Value.ToString();

                        dgv.CurrentRow.Cells["cc1_name"].Value = name;
                        dgv.CurrentRow.Cells["cc1_id"].Value = id;

                        Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
                        dgv.Focus();

                        txt_Auto_cc1.Text = "";
                        txt_Auto_cc1.Focus();
                    }
                }
            }
        }
        #endregion

        #region dgv_Auto_cc1
        private void dgv_Auto_cc1_SelectionChanged(object sender, EventArgs e)
        {
            txt_Auto_cc1.Focus();
            txt_Auto_cc1.SelectionStart = txt_Auto_cc1.Text.Length;
        }
        private void dgv_Auto_cc1_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
            {
                dgv.CurrentCell.Value = dgv_Auto_cc1.CurrentRow.Cells["col_auto_cc1_name"].Value;
                dgv.CurrentRow.Cells["cc1_id"].Value = dgv_Auto_cc1.CurrentRow.Cells["col_auto_cc1_id"].Value;

                Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
            }
        }
        #endregion

        #region txt_Auto_cc2
        private void txt_Auto_cc2_TextChanged(object sender, EventArgs e)
        {
            if (txt_Auto_cc2.Text.Trim() == "")
            {
                dv_AutoComplete_cc2.RowFilter = "";
            }
            else
            {
                dv_AutoComplete_cc2.RowFilter = "aname Like '%" + txt_Auto_cc2.Text + "%' OR id Like '%" + txt_Auto_cc2.Text + "%'";
            }
        }
        private void txt_Auto_cc2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv_Auto_cc2.Focus();
                SendKeys.Send("{DOWN}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                dgv_Auto_cc2.Focus();
                SendKeys.Send("{UP}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv_Auto_cc2.CurrentCell != null)
                {
                    if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
                    {
                        string name = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_name"].Value.ToString();
                        string id = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_id"].Value.ToString();

                        dgv.CurrentRow.Cells["cc2_name"].Value = name;
                        dgv.CurrentRow.Cells["cc2_id"].Value = id;

                        Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
                        dgv.Focus();

                        txt_Auto_cc2.Text = "";
                        txt_Auto_cc2.Focus();
                    }
                }
            }
        }
        #endregion

        #region dgv_Auto_cc2
        private void dgv_Auto_cc2_SelectionChanged(object sender, EventArgs e)
        {
            txt_Auto_cc2.Focus();
            txt_Auto_cc2.SelectionStart = txt_Auto_cc2.Text.Length;
        }
        private void dgv_Auto_cc2_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
            {
                dgv.CurrentCell.Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_name"].Value;
                dgv.CurrentRow.Cells["cc2_id"].Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_id"].Value;

                Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
            }
        }
        #endregion

        #region txt_Auto_Brannch
        private void txt_Auto_Branch_TextChanged(object sender, EventArgs e)
        {
            dv_AutoComplete_branches.RowFilter = "aname Like '%" + txt_Auto_Branch.Text + "%' OR id Like '%" + txt_Auto_Branch.Text + "%'";
        }
        private void txt_Auto_Branch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv_Auto_Branch.Focus();
                SendKeys.Send("{DOWN}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                dgv_Auto_Branch.Focus();
                SendKeys.Send("{UP}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (dgv_Auto_Branch.CurrentCell != null)
                {
                    if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
                    {
                        string name = dgv_Auto_Branch.CurrentRow.Cells["col_Auto_Branch_name"].Value.ToString();
                        string id = dgv_Auto_Branch.CurrentRow.Cells["col_Auto_Branch_id"].Value.ToString();

                        dgv.CurrentRow.Cells["branch_name"].Value = name;
                        dgv.CurrentRow.Cells["branch_id"].Value = id;

                        Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
                        dgv.Focus();

                        txt_Auto_Branch.Text = "";
                        txt_Auto_Branch.Focus();

                        txt_Auto_Branch.Visible = false;
                        dgv_Auto_Branch.Visible = false;
                    }
                }
            }
        }
        #endregion

        #region dgv_Auto_Branch
        private void dgv_Auto_Branch_SelectionChanged(object sender, EventArgs e)
        {
            txt_Auto_Branch.Focus();
            txt_Auto_Branch.SelectionStart = txt_Auto_Branch.Text.Length;
        }
        private void dgv_Auto_Branch_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
            {
                dgv.CurrentCell.Value = dgv_Auto_Branch.CurrentRow.Cells["col_Auto_branch_name"].Value;
                dgv.CurrentRow.Cells["branch_id"].Value = dgv_Auto_Branch.CurrentRow.Cells["col_Auto_branch_id"].Value;

                Next_Cell(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex);
            }
        }
        #endregion

        #endregion

        #region Navigation

        #region display
        private void btn_First_MouseEnter(object sender, EventArgs e)
        {
            btn_First.FlatStyle = FlatStyle.Popup;
        }
        private void btn_First_MouseLeave(object sender, EventArgs e)
        {
            btn_First.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Prev_MouseEnter(object sender, EventArgs e)
        {
            btn_Prev.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Prev_MouseLeave(object sender, EventArgs e)
        {
            btn_Prev.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Next_MouseEnter(object sender, EventArgs e)
        {
            btn_Next.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Next_MouseLeave(object sender, EventArgs e)
        {
            btn_Next.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Last_MouseEnter(object sender, EventArgs e)
        {
            btn_Last.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Last_MouseLeave(object sender, EventArgs e)
        {
            btn_Last.FlatStyle = FlatStyle.Flat;
        }
        private void txt_Search_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Search.Text == "Search")
            {
                txt_Search.ForeColor = Color.DimGray;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
            }
        }
        private void txt_Search_MouseLeave(object sender, EventArgs e)
        {
            if (txt_Search.Text == "Search")
            {
                txt_Search.ForeColor = Color.Silver;
                txt_Search.Font = new Font(txt_Search.Font, FontStyle.Regular);
            }
        }
        private void txt_Search_Enter(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            txt_Search.ForeColor = Color.Black;
        }
        private void txt_Search_Leave(object sender, EventArgs e)
        {
            txt_Search.Text = "Search";
            txt_Search.ForeColor = Color.Silver;
        }
        #endregion
        private void btn_First_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.fyear_id = com_fyear.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "First";

            dt = module.Select().Tables["tbl_jor"];

            if (dt.Rows.Count > 0)
            {
                Form_Mode("Select");
            }
            else
            {
                Form_Mode("Empty");
            }           
        }
        private void btn_Prev_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.fyear_id = com_fyear.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();

            if(Tag.ToString() == "Select")
            {
                module.id = txt_id.Text;
                module.selecttype = "Prev" ;
            }
            else if (Tag.ToString() == "Empty")
            {
                if(module.id == null)
                {
                    module.selecttype = "Last";
                }
                else
                {
                    module.selecttype = "Prev";
                }
            }


            dt = module.Select().Tables["tbl_jor"];
            if (dt.Rows.Count == 0) return;

            Form_Mode("Select");
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.fyear_id = com_fyear.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();


            if (Tag.ToString() == "Select")
            {
                module.id = txt_id.Text;
                module.selecttype = "Next";
            }
            else if (Tag.ToString() == "Empty")
            {
                if (module.id == null)
                {
                    module.selecttype = "First";
                }
                else
                {
                    module.selecttype = "Next";
                }
            }

            dt = module.Select().Tables["tbl_jor"];
            if (dt.Rows.Count == 0) return;

            Form_Mode("Select");
        }
        private void btn_Last_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.fyear_id = com_fyear.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "Last";

            dt = module.Select().Tables["tbl_jor"];

            if (dt.Rows.Count > 0)
            {
                Form_Mode("Select");
            }
            else
            {
                Form_Mode("Empty");
            }
        }
        private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txt_Search.Text.Trim() != "")
            {
                module.id = txt_Search.Text.Trim();
                module.company_id = frm_main.com_companies.SelectedValue.ToString();
                module.selecttype = "Select";

                dt = module.Select().Tables["tbl_jor"];
                if (dt.Rows.Count == 0) return;

                Form_Mode("Select");
            }
        }
        #endregion

        #region Print

        #region Declarations
        int Page_W = 840;
        int Page_H = 1180;
        int RepHeader_H = 120;
        int PageHeader_H = 110;
        int ColumnsHeader_H = 60;
        int Row_H = 24;
        int RepFooter_H = 300;
        int PageFooter_H = 75;
        int PagesConnt = 1;

        bool Page_RL = true;
        int Page_LMargin = 15;

        Pen p = new Pen(Brushes.Black, 1);
        Font fh = new Font("Calibri", 12);
        Font fb = new Font("Calibri", 10);
        Font fs = new Font("Calibri", 8);

        int Cell_W = 200;
        int Table_W = 0;
        int row_no = 0;
        int page_no = 1;

        int rowh = 24;

        DataTable dt_PrintSettings = new DataTable();
        DataTable dt_Footer = new DataTable();
        #endregion

        #region Pro
        public int GetPageCount()
        {
            int PageCount = 1;
            int RowStart = RepHeader_H + PageHeader_H + ColumnsHeader_H;

            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (RowStart > Page_H - PageFooter_H - Row_H)
                {
                    PageCount++;
                    RowStart = RepHeader_H + PageHeader_H + ColumnsHeader_H;
                }

                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
                {
                    SizeF size = graphics.MeasureString(r.Cells["Notes"].Value.ToString(), fb);
                    decimal sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["notes_Width"]);
                    if ((decimal)size.Width > sw)
                    {
                        decimal d = Math.Ceiling((decimal)size.Width / sw);
                        RowStart += Row_H * (int)d;
                    }
                    else
                    {
                        RowStart += Row_H;
                    }
                }

            }
            return PageCount;
        }
        #endregion

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0203005"))
            {
                MessageBox.Show("ليس لديك تصريح لطباعة قيد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void btn_PrintPreview_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //if (Demo) ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            dt_PrintSettings.Columns.Clear();
            dt_PrintSettings.Rows.Clear();

            dt_PrintSettings.Columns.Add("DocName", typeof(string));
            dt_PrintSettings.Columns.Add("debit_Width", typeof(int));
            dt_PrintSettings.Columns.Add("credit_Width", typeof(int));
            dt_PrintSettings.Columns.Add("chart_name_Width", typeof(int));
            dt_PrintSettings.Columns.Add("chart_id_Width", typeof(int));
            dt_PrintSettings.Columns.Add("notes_Width", typeof(int));
            dt_PrintSettings.Columns.Add("cc1_name_Width", typeof(int));
            dt_PrintSettings.Columns.Add("cc2_name_Width", typeof(int));
            dt_PrintSettings.Columns.Add("branch_name_Width", typeof(int));

            dt_PrintSettings.Rows.Add("jor", 60, 60, 120, 80, 200, 90, 90, 90);

            dt_Footer.Columns.Clear();
            dt_Footer.Rows.Clear();

            dt_Footer.Columns.Add("Anm", typeof(string));
            dt_Footer.Columns.Add("Enm", typeof(string));
            dt_Footer.Columns.Add("Val", typeof(string));

            PagesConnt = GetPageCount();
            page_no = 1;
            row_no = 0;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", Page_W, Page_H);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var format = new StringFormat() { Alignment = (Page_RL) ? StringAlignment.Center : StringAlignment.Center };
            RectangleF rect;

            Image img = Image.FromFile(Application.StartupPath + @"\logo.png");

            #region Columns
            int top = RepHeader_H + PageHeader_H;
            int Cell_Left = Page_LMargin;
            Graphics g = this.CreateGraphics();

            Table_W = 0;

            int i = (Page_RL) ? dgv.Columns.Count - 1 : 0;
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (dgv.Columns[i].Visible == false)
                {
                    if (Page_RL) { i--; } else { i++; }
                    continue;
                }


                string s = dgv.Columns[dgv.Columns[i].Index].HeaderText.ToString();
                if (dgv.Columns[i].Name == "debit")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_Width"]);
                }
                else if (dgv.Columns[i].Name == "credit")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_Width"]);
                }
                else if (dgv.Columns[i].Name == "chart_name")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_Width"]);
                }
                else if (dgv.Columns[i].Name == "chart_id")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_Width"]);
                }
                else if (dgv.Columns[i].Name == "notes")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["notes_Width"]);
                }
                else if (dgv.Columns[i].Name == "cc1_name")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc1_name_Width"]);
                }
                else if (dgv.Columns[i].Name == "cc2_name")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc2_name_Width"]);
                }
                else if (dgv.Columns[i].Name == "branch_name")
                {
                    Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["branch_name_Width"]);
                }

                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(Cell_Left, top, Cell_W, ColumnsHeader_H));
                e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, ColumnsHeader_H));
                e.Graphics.DrawString(s, fb, Brushes.Black, new Rectangle(Cell_Left + 10, top + 8, Cell_W, ColumnsHeader_H));

                Table_W += Cell_W;
                Cell_Left += Cell_W;

                if (Page_RL) { i--; } else { i++; }
            }
            i = (Page_RL) ? dgv.Columns.Count - 1 : 0;

            #endregion

            #region Rep_Header
            rect = new RectangleF(Page_LMargin, 0, Table_W, RepHeader_H);
            e.Graphics.DrawImage(img, rect);
            #endregion

            #region Page_Header
            rect = new RectangleF((Page_W / 2) - 100, RepHeader_H, 200, 20);
            e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);
            e.Graphics.DrawString(((Page_RL) ? "قيد يومية" : "Entry"), fh, Brushes.Black, rect, format);

            format = new StringFormat() { Alignment = (Page_RL) ? StringAlignment.Far : StringAlignment.Near };

            // Draw Head Rect
            e.Graphics.DrawRectangle(p, new Rectangle(Page_LMargin, RepHeader_H, Table_W, PageHeader_H));

            rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 150, Table_W, 20);
            e.Graphics.DrawString(((Page_RL) ? "رقم القيد : " : "Entyr Number : ") + txt_id.Text.ToString(), fb, Brushes.Black, rect, format);

            rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 170, Table_W, 30);
            e.Graphics.DrawString(((Page_RL) ? "التاريخ : " : "Date : ") + txt_date.Text.ToString(), fb, Brushes.Black, rect, format);


            if (txt_notes.Text.Trim() != "")
            {
                rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 190, Table_W, 30);
                e.Graphics.DrawString(((Page_RL) ? "البيان : " : "Description : ") + txt_notes.Text.Trim(), fb, Brushes.Black, rect, format);
            }
            #endregion

            #region Page_Footer
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(Page_LMargin, Page_H - PageFooter_H, Table_W, 20));
            e.Graphics.DrawRectangle(p, new Rectangle(Page_LMargin, Page_H - PageFooter_H, Table_W, 20));
            rect = new RectangleF((Page_RL) ? (Table_W - 500) : Page_LMargin + 5, Page_H - PageFooter_H + 3, 500, 20);
            e.Graphics.DrawString(((Page_RL) ? " صفحة رقم" : "Page No ") + " : " + page_no + " / " + PagesConnt + "             طبع في تاريخ " + DateTime.Now.ToString("yyyy/MM/dd"), fs, Brushes.Black, rect, format);
            #endregion

            #region Rows

            Cell_Left = Page_LMargin;
            top = RepHeader_H + PageHeader_H + ColumnsHeader_H;


            while (row_no < dgv.RowCount)
            {
                rowh = Row_H;

                if (top > Page_H - PageFooter_H - Row_H)
                {
                    e.HasMorePages = true;
                    top = RepHeader_H + PageHeader_H + ColumnsHeader_H;
                    page_no++;
                    return;
                }

                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
                {
                    #region chart_name_rowh
                    int chart_name_rowh = Row_H;
                    SizeF chart_name_size = graphics.MeasureString(dgv.Rows[row_no].Cells["chart_name"].Value.ToString(), fb);
                    decimal chart_name_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["chart_name_Width"]);

                    if ((decimal)chart_name_size.Width > chart_name_sw)
                    {
                        decimal d = Math.Ceiling((decimal)chart_name_size.Width / chart_name_sw);
                        chart_name_rowh = rowh * (int)d;
                    }
                    #endregion

                    #region notes_rowh
                    int notes_rowh = Row_H;
                    SizeF notes_size = graphics.MeasureString(dgv.Rows[row_no].Cells["Notes"].Value.ToString(), fb);
                    decimal notes_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["notes_Width"]);

                    if ((decimal)notes_size.Width > notes_sw)
                    {
                        decimal d = Math.Ceiling((decimal)notes_size.Width / notes_sw);
                        notes_rowh = rowh * (int)d;
                    }
                    #endregion

                    #region cc1_rowh
                    int cc1_rowh = Row_H;
                    SizeF cc1_size = graphics.MeasureString(dgv.Rows[row_no].Cells["cc1_name"].Value.ToString(), fb);
                    decimal cc1_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["cc1_name_Width"]);

                    if ((decimal)cc1_size.Width > cc1_sw)
                    {
                        decimal d = Math.Ceiling((decimal)cc1_size.Width / cc1_sw);
                        cc1_rowh = rowh * (int)d;
                    }
                    #endregion

                    #region cc2_rowh
                    int cc2_rowh = Row_H;
                    SizeF cc2_size = graphics.MeasureString(dgv.Rows[row_no].Cells["cc2_name"].Value.ToString(), fb);
                    decimal cc2_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["cc2_name_Width"]);

                    if ((decimal)cc2_size.Width > cc2_sw)
                    {
                        decimal d = Math.Ceiling((decimal)cc2_size.Width / cc2_sw);
                        cc2_rowh = rowh * (int)d;
                    }
                    #endregion

                    #region branch_rowh
                    int branch_rowh = Row_H;
                    SizeF branch_size = graphics.MeasureString(dgv.Rows[row_no].Cells["branch_name"].Value.ToString(), fb);
                    decimal branch_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["branch_name_Width"]);

                    if ((decimal)branch_size.Width > branch_sw)
                    {
                        decimal d = Math.Ceiling((decimal)branch_size.Width / branch_sw);
                        branch_rowh = rowh * (int)d;
                    }
                    #endregion

                    rowh = Math.Max(Math.Max(chart_name_rowh, notes_rowh), Math.Max(Math.Max(cc1_rowh, cc2_rowh), branch_rowh));
                }


                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    if (dgv.Columns[i].Visible == false)
                    {
                        if (Page_RL) { i--; } else { i++; }
                        continue;
                    }


                    string s = s = (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value == null) ? "" : dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString();



                    if (dgv.Columns[i].Name == "debit")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_Width"]);
                        if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0")
                        {
                            s = "";
                        }
                    }
                    else if (dgv.Columns[i].Name == "credit")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_Width"]);
                        if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0")
                        {
                            s = "";
                        }
                    }
                    else if (dgv.Columns[i].Name == "chart_name")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_Width"]);
                    }
                    else if (dgv.Columns[i].Name == "chart_id")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_Width"]);
                    }
                    else if (dgv.Columns[i].Name == "notes")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["notes_Width"]);
                    }
                    else if (dgv.Columns[i].Name == "cc1_name")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc1_name_Width"]);
                    }
                    else if (dgv.Columns[i].Name == "cc2_name")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc2_name_Width"]);
                    }
                    else if (dgv.Columns[i].Name == "branch_name")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["branch_name_Width"]);
                    }

                    e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, rowh));
                    e.Graphics.DrawString(s, fb, Brushes.Black, new Rectangle(Cell_Left + 2, top + 5, Cell_W, rowh));

                    Cell_Left += Cell_W;
                    if (Page_RL) { i--; } else { i++; }
                }
                i = (Page_RL) ? dgv.Columns.Count - 1 : 0;
                row_no++;
                Cell_Left = Page_LMargin;
                top += rowh;
            }
            #endregion

            #region Rep_Footer
            dt_Footer.Rows.Add("مدين", "Debit", txt_TotalDebit.Text);
            dt_Footer.Rows.Add("دائن", "Credit", txt_TotalCredit.Text);

            i = (Page_RL) ? dt_Footer.Rows.Count - 1 : 0;
            Cell_W = Table_W / 4;


            if (top > Page_H - PageFooter_H - RepFooter_H)
            {
                e.HasMorePages = true;
                top = RepHeader_H + PageHeader_H + ColumnsHeader_H;
                page_no++;
                return;
            }

            top += Row_H;

            foreach (DataRow r in dt_Footer.Rows)
            {
                string name = ((Page_RL) ? dt_Footer.Rows[i]["Anm"].ToString() : dt_Footer.Rows[i]["Enm"].ToString()) + " :   " + dt_Footer.Rows[i]["Val"].ToString(); ;
                string val = dt_Footer.Rows[i]["Val"].ToString();

                e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, rowh));
                e.Graphics.DrawString(name, fb, Brushes.Black, new Rectangle(Cell_Left + 8, top + 5, Cell_W, rowh));

                Cell_Left += Cell_W;
                if (Page_RL) { i--; } else { i++; }
            }

            top = Page_H - PageFooter_H - 100;

            e.Graphics.DrawString("المدير المالي", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4), top, (Table_W / 4), 20));
            e.Graphics.DrawString("المحاسب", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) * 3, top, (Table_W / 4), 20));

            top += 50;

            e.Graphics.DrawString("-----------------", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) - 10, top, (Table_W / 4), 20));
            e.Graphics.DrawString("-----------------", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) * 3 - 10, top, (Table_W / 4), 20));
            #endregion
        }
        #endregion

        #region JorCyc
        private void btn_JorCyc_Click(object sender, EventArgs e)
        {
            if(Tag.ToString() == "Select")
            {
                if (MessageBox.Show("هل  تريد حفظ هذا القيد كاقيد دوري ؟", "حفظ قيد دوري", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                #region Validation
                if (txt_notes.Text.Trim() == "")
                {
                    MessageBox.Show("يجب ادخال بيان للقيد", "حفظ قيد دوري", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_notes.Focus();
                    return;
                }
                #endregion

                Bind();

                DataTable dt_temp = module.Insert_JorCyc().Tables["tbl_jorcyc"];

                if (dt_temp.Rows.Count > 0)
                {
                    if (dt_temp.Rows[0]["h_notes"] != null)
                    {
                        if (dt_temp.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt_temp.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt_temp.Rows[0]["h_notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }

                int x = 1;

                dt_JorCyc.Rows.Clear();
                for (int i = 0; i < dt_temp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt_temp.Rows[i]["h_id"]) >= x)
                    {
                        dt_JorCyc.Rows.Add(dt_temp.Rows[i]["h_id"], dt_temp.Rows[i]["h_notes"]);
                        x = Convert.ToInt32(dt_temp.Rows[i]["h_id"]) + 1;
                    }
                }

                com_JorCyc.DataSource = dt_JorCyc;

                MessageBox.Show("تم حفظ القيد الدوري بنجاح", "حفظ قيد دوري", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if(Tag.ToString() == "New" || Tag.ToString() == "Edit")
            {
                if(com_JorCyc.SelectedValue == null)
                {
                    MessageBox.Show("يجب اختيار قيد دوري ", "إستدعاء قيد دوري", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    com_JorCyc.DroppedDown = true;
                    return;
                }

                DataTable dt_cyc = module.Select_JorCyc(com_JorCyc.SelectedValue.ToString()).Tables["tbl_jorcyc"];

                com_CC1.SelectedValue = dt_cyc.Rows[0]["h_cc1_id"];
                com_CC2.SelectedValue = dt_cyc.Rows[0]["h_cc2_id"];

                txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txt_notes.Text = dt_cyc.Rows[0]["h_notes"].ToString();
                com_currency_id.SelectedValue = dt_cyc.Rows[0]["h_currency_id"].ToString();
                txt_currencyprice.Text = dt_cyc.Rows[0]["h_currencyprice"].ToString();
                com_jortype_id.SelectedValue = dt_cyc.Rows[0]["h_jortype_id"].ToString();

                dgv.Rows.Clear();
                decimal d = 0;
                decimal c = 0;
                foreach (DataRow r in dt_cyc.Rows)
                {
                    dgv.Rows.Add(r["d_debit"], r["d_credit"], r["d_chart_aname"], r["d_chart_id"], r["d_notes"], r["d_cc1_aname"], r["d_cc1_id"], r["d_cc2_aname"], r["d_cc2_id"], com_Branches.Text, com_Branches.SelectedValue);
                    d += Convert.ToDecimal(r["d_debit"]);
                    c += Convert.ToDecimal(r["d_credit"]);
                }

                txt_TotalDebit.Text = d.ToString();
                txt_TotalCredit.Text = c.ToString();

                Hide_Zero();

                dgv.ClearSelection();
            }
         
        }
        private void btn_JorCycDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل بالفعل تريد حذف القيد الدوري ؟", "حذف قيد دوري", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (com_JorCyc.SelectedValue == null)
            {
                MessageBox.Show("يجب اختيار قيد دوري ", "حذف قيد دوري", MessageBoxButtons.OK, MessageBoxIcon.Question);
                com_JorCyc.DroppedDown = true;
                return;
            }

            DataTable dt_del = module.Delete_JorCyc(com_JorCyc.SelectedValue.ToString()).Tables["tbl_jorcyc"];

            if (dt_del.Rows.Count > 0)
            {
                if (dt_del.Rows[0]["h_notes"] != null)
                {
                    if (dt_del.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                    {
                        if (dt_del.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                        {
                            string[] arrey = dt_del.Rows[0]["h_notes"].ToString().Split(',');
                            MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                            return;
                        }
                    }
                }
            }

            int x = 1;

            dt_JorCyc.Rows.Clear();
            for (int i = 0; i < dt_del.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt_del.Rows[i]["h_id"]) >= x)
                {
                    dt_JorCyc.Rows.Add(dt_del.Rows[i]["h_id"], dt_del.Rows[i]["h_notes"]);
                    x = Convert.ToInt32(dt_del.Rows[i]["h_id"]) + 1;
                }
            }

            com_JorCyc.DataSource = dt_JorCyc;
        }
        #endregion
    }
}
