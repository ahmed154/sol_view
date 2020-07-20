using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting
{
    public partial class frm_cin : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_Accounting.stc_cin module = new fld_BL.cls_bl.stc_Accounting.stc_cin();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        DataView dv_AutoComplete = new DataView();
        DataView dv_AutoComplete_cc1 = new DataView();
        DataView dv_AutoComplete_cc2 = new DataView();
        DataView dv_AutoComplete_branches = new DataView();
        #endregion

        public frm_cin(fld_Login.frm_main frm_MAIN)
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

            dgv_AutoComplete.Columns["auto_Name"].Width = Convert.ToInt32(dgv_AutoComplete.Width * .60);
            dv_AutoComplete = ds.Tables["tbl_chart"].DefaultView;
            dv_AutoComplete_cc1 = ds.Tables["tbl_cc1"].DefaultView;
            dv_AutoComplete_cc2 = ds.Tables["tbl_cc2"].DefaultView;
            dv_AutoComplete_branches = ds.Tables["tbl_branches"].DefaultView;


            dgv_AutoComplete.Location = new Point(1, dgv.ColumnHeadersHeight + 1);


            com_CC1.DataSource = ds.Tables["tbl_cc1"];
            com_CC1.ValueMember = "id";
            com_CC1.DisplayMember = "aname";
            com_CC1.SelectedValue = -1;

            com_CC2.DataSource = ds.Tables["tbl_cc2"];
            com_CC2.ValueMember = "id";
            com_CC2.DisplayMember = "aname";
            com_CC2.SelectedValue = -1;

            com_paytype.DataSource = ds.Tables["tbl_paytype"];
            com_bank.DataSource = ds.Tables["tbl_bank"];
            com_currency.DataSource = ds.Tables["tbl_currencies"];
            dgv_Auto_cc1.DataSource = ds.Tables["tbl_cc1"];
            dgv_Auto_cc2.DataSource = ds.Tables["tbl_cc2"];

            #region dgv
            var amount = new DataGridViewTextBoxColumn();
            amount.Name = "amount";
            amount.HeaderText = "المبلغ";
            amount.DataPropertyName = "amount";
            amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            amount.Width = 100;
            dgv.Columns.Add(amount);

            var chart_cin_name = new DataGridViewTextBoxColumn();
            chart_cin_name.Name = "chart_cin_name";
            chart_cin_name.HeaderText = "حساب القبض";
            chart_cin_name.DataPropertyName = "chart_cin_name";
            chart_cin_name.Tag = "name";
            chart_cin_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chart_cin_name.Width = 150;
            dgv.Columns.Add(chart_cin_name);

            var chart_cin_id = new DataGridViewTextBoxColumn();
            chart_cin_id.Name = "chart_cin_id";
            chart_cin_id.HeaderText = "";
            chart_cin_id.DataPropertyName = "chart_cin_id";
            chart_cin_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chart_cin_id.Width = 120;
            chart_cin_id.ReadOnly = true;
            chart_cin_id.Visible = true;
            dgv.Columns.Add(chart_cin_id);

            var chart_cout_name = new DataGridViewTextBoxColumn();
            chart_cout_name.Name = "chart_cout_name";
            chart_cout_name.HeaderText = "حساب الدفع";
            chart_cout_name.DataPropertyName = "chart_cout_name";
            chart_cout_name.Tag = "name";
            chart_cout_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chart_cout_name.Width = 150;

            dgv.Columns.Add(chart_cout_name);

            var chart_cout_id = new DataGridViewTextBoxColumn();
            chart_cout_id.Name = "chart_cout_id";
            chart_cout_id.HeaderText = "";
            chart_cout_id.DataPropertyName = "chart_cout_id";
            chart_cout_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chart_cout_id.Width = 120;
            chart_cout_id.ReadOnly = true;
            chart_cout_id.Visible = true;
            dgv.Columns.Add(chart_cout_id);

            var Notes = new DataGridViewTextBoxColumn();
            Notes.Name = "notes";
            Notes.HeaderText = "البيان";
            Notes.DataPropertyName = "notes";
            Notes.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Notes.Width = 300;
            Notes.MinimumWidth = 150;
            dgv.Columns.Add(Notes);

            var paytype_name = new DataGridViewTextBoxColumn();
            paytype_name.Name = "paytype_name";
            paytype_name.HeaderText = "طريقة الدفع";
            paytype_name.DataPropertyName = "paytype_name";
            paytype_name.Tag = "name";
            paytype_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            paytype_name.Width = 70;
            dgv.Columns.Add(paytype_name);

            var paytype_id = new DataGridViewTextBoxColumn();
            paytype_id.Name = "paytype_id";
            paytype_id.HeaderText = "";
            paytype_id.DataPropertyName = "paytype_id";
            paytype_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            paytype_id.Width = 50;
            paytype_id.ReadOnly = true;
            paytype_id.Visible = false;
            paytype_id.Tag = "Hiden";
            dgv.Columns.Add(paytype_id);

            var bank_name = new DataGridViewTextBoxColumn();
            bank_name.Name = "bank_name";
            bank_name.HeaderText = "البنك";
            bank_name.DataPropertyName = "bank_name";
            bank_name.Tag = "name";
            bank_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bank_name.Width = 70;
            bank_name.Visible = false;
            dgv.Columns.Add(bank_name);

            var bank_id = new DataGridViewTextBoxColumn();
            bank_id.Name = "bank_id";
            bank_id.HeaderText = "";
            bank_id.DataPropertyName = "bank_id";
            bank_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bank_id.Width = 50;
            bank_id.ReadOnly = true;
            bank_id.Visible = false;
            bank_id.Tag = "Hiden";
            dgv.Columns.Add(bank_id);

            var checkcardno = new DataGridViewTextBoxColumn();
            checkcardno.Name = "checkcardno";
            checkcardno.HeaderText = "رقم الشيك / البطاقة";
            checkcardno.DataPropertyName = "checkcardno";
            checkcardno.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            checkcardno.Width = 150;
            checkcardno.Visible = false;
            dgv.Columns.Add(checkcardno);

            var checkcarddate = new DataGridViewTextBoxColumn();
            checkcarddate.Name = "checkcarddate";
            checkcarddate.HeaderText = "تاريخ الشيك / البطاقة";
            checkcarddate.DataPropertyName = "checkcarddate";
            checkcarddate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            checkcarddate.Width = 150;
            checkcarddate.Visible = false;
            dgv.Columns.Add(checkcarddate);

            var sorno = new DataGridViewTextBoxColumn();
            sorno.Name = "sorno";
            sorno.HeaderText = "رقم أمر البيع";
            sorno.DataPropertyName = "sorno";
            sorno.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            sorno.Width = 150;
            sorno.Visible = false;
            dgv.Columns.Add(sorno);

            var salno = new DataGridViewTextBoxColumn();
            salno.Name = "salno";
            salno.HeaderText = "رقم فاتورة البيع";
            salno.DataPropertyName = "salno";
            salno.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            salno.Width = 150;
            salno.Visible = false;
            dgv.Columns.Add(salno);

            var billdate = new DataGridViewTextBoxColumn();
            billdate.Name = "billdate";
            billdate.HeaderText = "تاريخها";
            billdate.DataPropertyName = "billdate";
            billdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            billdate.Width = 150;
            billdate.Visible = false;
            dgv.Columns.Add(billdate);

            var manualno = new DataGridViewTextBoxColumn();
            manualno.Name = "manualno";
            manualno.HeaderText = "رقم السند اليدوي";
            manualno.DataPropertyName = "manualno";
            manualno.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            manualno.Width = 150;
            manualno.Visible = false;
            dgv.Columns.Add(manualno);

            var currency_name = new DataGridViewTextBoxColumn();
            currency_name.Name = "currency_name";
            currency_name.HeaderText = "العملة";
            currency_name.DataPropertyName = "currency_name";
            currency_name.Tag = "name";
            currency_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currency_name.Width = 100;
            currency_name.Visible = false;
            dgv.Columns.Add(currency_name);

            var currency_id = new DataGridViewTextBoxColumn();
            currency_id.Name = "currency_id";
            currency_id.HeaderText = "";
            currency_id.DataPropertyName = "currency_id";
            currency_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currency_id.Width = 200;
            currency_id.ReadOnly = true;
            currency_id.Visible = false;
            currency_id.Tag = "Hiden";
            dgv.Columns.Add(currency_id);

            var currency_price = new DataGridViewTextBoxColumn();
            currency_price.Name = "currency_price";
            currency_price.HeaderText = "سعر العملة";
            currency_price.DataPropertyName = "currency_price";
            currency_price.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            currency_price.Width = 100;
            currency_price.Visible = false;
            dgv.Columns.Add(currency_price);

            var cc1_name = new DataGridViewTextBoxColumn();
            cc1_name.Name = "cc1_name";
            cc1_name.HeaderText = "مركز1";
            cc1_name.DataPropertyName = "cc1_aname";
            cc1_name.Tag = "name";
            cc1_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc1_name.Width = 150;
            cc1_name.ReadOnly = true;
            dgv.Columns.Add(cc1_name);

            var cc1_id = new DataGridViewTextBoxColumn();
            cc1_id.Name = "cc1_id";
            cc1_id.HeaderText = "";
            cc1_id.DataPropertyName = "cc1_id";
            cc1_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc1_id.Width = 200;
            cc1_id.ReadOnly = true;
            cc1_id.Visible = false;
            cc1_id.Tag = "Hiden";
            dgv.Columns.Add(cc1_id);

            var cc2_name = new DataGridViewTextBoxColumn();
            cc2_name.Name = "cc2_name";
            cc2_name.HeaderText = "مركز2";
            cc2_name.DataPropertyName = "cc2_aname";
            cc2_name.Tag = "name";
            cc2_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc2_name.Width = 150;
            cc2_name.ReadOnly = true;
            dgv.Columns.Add(cc2_name);

            var cc2_id = new DataGridViewTextBoxColumn();
            cc2_id.Name = "cc2_id";
            cc2_id.HeaderText = "";
            cc2_id.DataPropertyName = "cc2_id";
            cc2_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cc2_id.Width = 100;
            cc2_id.ReadOnly = true;
            cc2_id.Visible = false;
            cc2_id.Tag = "Hiden";
            dgv.Columns.Add(cc2_id);

            var branch_name = new DataGridViewTextBoxColumn();
            branch_name.Name = "branch_name";
            branch_name.HeaderText = "الفرع";
            branch_name.DataPropertyName = "branch_aname";
            branch_name.Tag = "name";
            branch_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branch_name.Width = 150;
            dgv.Columns.Add(branch_name);

            var branch_id = new DataGridViewTextBoxColumn();
            branch_id.Name = "branch_id";
            branch_id.HeaderText = "";
            branch_id.DataPropertyName = "branch_id";
            branch_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branch_id.Width = 100;
            branch_id.ReadOnly = true;
            branch_id.Visible = false;
            branch_id.Tag = "Hiden";
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

            //dgv_AutoComplete.Columns["auto_Name"].Width = dgv.Columns["chart_name"].Width;
            //dgv_AutoComplete.Columns["auto_ID"].Width = dgv.Columns["chart_id"].Width;

            if (txt_id.Text != "")
            {
                module.id = txt_id.Text;
                module.selecttype = "Login";
                ds = module.Select();

                dt = ds.Tables["tbl_cin"].Clone();
                for (int i = 0; i < ds.Tables["tbl_cin"].Rows.Count; i++)
                {
                    dt.ImportRow(ds.Tables["tbl_cin"].Rows[i]);
                }

                Form_Mode("Select");
            }
            else
            {
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
                        txt_Ghost.Visible = false;
                        txt_Ghost.Text = "";
                        dgv_AutoComplete.Visible = false;
                        dv_AutoComplete.RowFilter = "";
                    }
                    break;
                case Keys.F4:
                    if ((Tag.ToString() == "New" || Tag.ToString() == "Edit") && dgv.CurrentCell != null && dgv.Focused)
                    {
                        if(dgv.CurrentCell.OwningColumn.Name == "cc1_name")
                        {
                            txt_Auto_cc1.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                            txt_Auto_cc1.Width = dgv.CurrentCell.OwningColumn.Width;
                            txt_Auto_cc1.Location = new Point(txt_Auto_cc1.Location.X + 3 , txt_Auto_cc1.Location.Y + 16);
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

                btn_jorID.Text = "";
                txt_Total.Text = "";
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
            btn_jorID.Enabled = true;
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
                    btn_Post.Visible = false;
                    btn_Print.Visible = false;

                    EnableForm();
                    ClearForm();

                    Add_Row();
                    dgv.ClearSelection();
                    dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    dgv.BeginEdit(true);
                    dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

                    dgv.Columns["cc1_name"].ReadOnly = true;
                    dgv.Columns["cc2_name"].ReadOnly = true;
                    dgv.Columns["branch_name"].ReadOnly = true;

                    txt_date.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    break;
                #endregion

                #region Edit
                case "Edit":
                    Tag = "Edit";

                    btn_CC1.Enabled = true;
                    btn_CC2.Enabled = true;

                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;
                    btn_Post.Visible = false;
                    btn_Print.Visible = false;

                    dgv.Columns["cc1_name"].ReadOnly = true;
                    dgv.Columns["cc2_name"].ReadOnly = true;
                    dgv.Columns["branch_name"].ReadOnly = true;

                    dgv.ReadOnly = false;

                    EnableForm();

                    break;
                #endregion

                #region Select
                case "Select":
                    Tag = "Select";

                    btn_CC1.Enabled = false;
                    btn_CC2.Enabled = false;

                    btn_New.Visible = true;

                    btn_Save.Visible = false;

                    btn_Cancel.Visible = false;
                    btn_Post.Visible = true;
                    btn_Print.Visible = true;

                    DisableForm();

                    txt_Ghost.Visible = false;
                    txt_Ghost.Text = "";
                    dgv_AutoComplete.Visible = false;
                    dv_AutoComplete.RowFilter = "";

                    com_Branches.SelectedValue = dt.Rows[0]["h_branch_id"];
                    com_CC1.SelectedValue = dt.Rows[0]["h_cc1_id"];
                    com_CC2.SelectedValue = dt.Rows[0]["h_cc2_id"];
                    com_Users.SelectedValue = dt.Rows[0]["h_createuser_id"];

                    txt_id.Text = dt.Rows[0]["h_id"].ToString();
                    btn_jorID.Text = dt.Rows[0]["h_jor_id"].ToString();
                    txt_date.Text = Convert.ToDateTime(dt.Rows[0]["h_creationtime"]).ToString("dd/MM/yyyy");
                    txt_notes.Text = dt.Rows[0]["h_notes"].ToString();
                    btn_Post.Text = (Convert.ToBoolean(dt.Rows[0]["h_posted"]) == false) ? "ترحيل": "إلغاء الترحيل";

                    dgv.Rows.Clear();
                    decimal a = 0;

                    foreach (DataRow r in dt.Rows)
                    {
                        dgv.Rows.Add(r["d_amount"], r["d_chart_cin_aname"], r["d_chart_cin_id"], r["d_chart_cout_aname"], r["d_chart_cout_id"], r["d_notes"], r["d_paytype_aname"], r["d_paytype_id"], 
                            r["d_bank_aname"], r["d_bank_id"], r["d_checkcardno"], r["d_checkcarddate"], r["d_sorno"], r["d_salno"], r["d_billdate"], r["d_manualno"],
                            r["d_currency_aname"], r["d_currency_id"], r["d_currency_price"],
                            r["d_cc1_aname"], r["d_cc1_id"], r["d_cc2_aname"], r["d_cc2_id"], r["d_branch_aname"], r["d_branch_id"]);

                        a += Convert.ToDecimal(r["d_amount"]);
                    }

                    txt_Total.Text = a.ToString();

                    if(btn_Post.Text == "ترحيل" && Convert.ToInt32(dt.Rows[0]["h_fyear_id"]) == Convert.ToInt32(frm_main.com_fyear.SelectedValue))
                    {
                        btn_Edit.Visible = true;
                        btn_Delete.Visible = true;
                    }
                    else
                    {
                        btn_Edit.Visible = false;
                        btn_Delete.Visible = false;
                    }

                    dgv.ClearSelection();
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
                    btn_Post.Visible = false;
                    btn_Print.Visible = false;

                    DisableForm();
                    ClearForm();

                    txt_Ghost.Visible = false;
                    txt_Ghost.Text = "";
                    dgv_AutoComplete.Visible = false;
                    dv_AutoComplete.RowFilter = "";

                    if (dgv.CurrentRow != null) dgv.CurrentRow.Selected = false;
                    break;
                    #endregion
            }
        }
        DataTable DGVToDatatable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Tag != null)
                {
                    if (col.Tag.ToString() == "name") continue;
                }

                dt.Columns.Add(col.Name);              
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow Row = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Tag != null)
                    {
                        if (cell.OwningColumn.Tag.ToString() == "name") continue;
                    }

                    if (cell.Value == null)
                    {
                        if (cell.OwningColumn.Name == "debit" || cell.OwningColumn.Name == "credit")
                        {
                            Row[cell.OwningColumn.Name.ToString()] = 0;
                        }
                        else
                        {
                            Row[cell.OwningColumn.Name.ToString()] = null;
                        }
                    }
                    else if (cell.Value.ToString() == "")
                    {
                        Row[cell.OwningColumn.Name.ToString()] = null;
                    }
                    else
                    {
                        Row[cell.OwningColumn.Name.ToString()] = cell.Value;
                    }
                }
                dt.Rows.Add(Row);
            }

            return dt;
        }
        void Bind()
        {
            module.id = txt_id.Text.Trim();
            module.jor_id = (btn_jorID.Text != "") ? btn_jorID.Text : null;
            module.notes = txt_notes.Text.ToString().Trim();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.fyear_id = frm_main.com_fyear.SelectedValue.ToString();
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.cc1_id = (com_CC1.SelectedValue != null) ? ((com_CC1.SelectedValue.ToString() != "")?com_CC1.SelectedValue.ToString() : null) : null;
            module.cc2_id = (com_CC2.SelectedValue != null) ? ((com_CC2.SelectedValue.ToString() != "") ? com_CC2.SelectedValue.ToString() : null) : null;
            module.ddate = DateTime.ParseExact(txt_date.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            module.user_id = com_Users.SelectedValue.ToString();
            module.cinD = DGVToDatatable();
        }
        void Add_Row()
        {
            string notes = null;
            if(dgv.CurrentRow != null)
            {
                if (dgv.CurrentRow.Index == dgv.RowCount - 1)
                {
                    notes = (dgv.CurrentRow.Cells["notes"].Value != null)? dgv.CurrentRow.Cells["notes"].Value.ToString() : null;
                }
            }


            string paytype_id = ds.Tables["tbl_paytype"].Rows[0][0].ToString();
            string paytype_name = ds.Tables["tbl_paytype"].Rows[0]["aname"].ToString();

            //string bank_id = ds.Tables["tbl_bank"].Rows[0][0].ToString();
            //string bank_name = ds.Tables["tbl_bank"].Rows[0]["aname"].ToString();

            string currency_id = ds.Tables["tbl_currencies"].Rows[0][0].ToString();
            string currency_name = ds.Tables["tbl_currencies"].Rows[0]["aname"].ToString();
            string currency_price = ds.Tables["tbl_currencies"].Rows[0]["price"].ToString();

            dgv.Rows.Add(null, null, null, null, null, notes, paytype_name, paytype_id, null, null, null, null, null, null, null, null, currency_name, currency_id, currency_price, com_CC1.Text, com_CC1.SelectedValue, com_CC2.Text, com_CC2.SelectedValue, com_Branches.Text, com_Branches.SelectedValue);
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
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index + 1].Cells["amount"];
            }
            dgv.Focus();
        }
        void Hide_Auto()
        {
            txt_Ghost.Visible = false;
            txt_Auto_cc1.Visible = false;
            txt_Auto_cc2.Visible = false;
            txt_Auto_Branch.Visible = false;

            com_paytype.Visible = false;
            com_bank.Visible = false;
            com_currency.Visible = false;

            dgv_Auto_cc1.Visible = false;
            dgv_Auto_cc2.Visible = false;
            dgv_Auto_Branch.Visible = false;
        }
        void Calc_Total()
        {
            decimal t = 0;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                t += Convert.ToDecimal(r.Cells["amount"].Value);
            }
            txt_Total.Text = t.ToString();
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

        private void cms_fyear_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_fyear.SelectedIndex = cms_fyear.Items.IndexOf(e.ClickedItem);
            lbl_fyear.Text = com_fyear.Text;
        }
        private void btn_fyear_Click(object sender, EventArgs e)
        {
            if (com_fyear.Enabled == false) return;
            Point p = btn_fyear.PointToScreen(Point.Empty);
            cms_fyear.Show(p.X - (cms_fyear.Width - btn_fyear.Width), p.Y + btn_fyear.Height);
        }
        private void com_fyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_fyear.Text = com_fyear.Text;
        }

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
            btn_Bill_Branche_Click(null, null);
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
            if (btn_Bill_User.Enabled)
            {
                btn_Bill_User_Click(null, null);
            }

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
            if (!frm_main.Perm("0201002"))
            {
                MessageBox.Show("ليس لديك تصريح لاضافة سند قبض جديد", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form_Mode("New");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0201003"))
            {
                MessageBox.Show("ليس لديك تصريح لتعديل سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (r["id"].ToString() == com_fyear.SelectedValue.ToString())
                {
                    DateTime date = DateTime.ParseExact(txt_date.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    DateTime begindate = Convert.ToDateTime(r["beigndate"]);
                    DateTime enddate = Convert.ToDateTime(r["enddate"]);

                    string fyearname = r["aname"].ToString();

                    if (date < begindate || date > enddate)
                    {
                        MessageBox.Show("تاريخ السند خارج حدود السنة المالية " + fyearname, "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_date.Focus();
                        return;
                    }
                }
            }

            if (dgv.RowCount == 0)
            {
                MessageBox.Show("يلزم إدخال بيانات السند", "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Add_Row();
                return;
            }

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells["chart_cin_id"].Value == null)
                {
                    MessageBox.Show("لم يتم تحديد الحساب", "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgv.CurrentCell = dgv.Rows[i].Cells["chart_cin_name"];
                    return;
                }
                if (dgv.Rows[i].Cells["chart_cout_id"].Value == null)
                {
                    MessageBox.Show("لم يتم تحديد الحساب", "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgv.CurrentCell = dgv.Rows[i].Cells["chart_cout_name"];
                    return;
                }
            }
            #endregion

            Bind();

            #region New
            if (Tag.ToString() == "New")
            {
                dt = module.Insert().Tables[0];

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
                dt = module.Update().Tables[0];

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
            if (!frm_main.Perm("0201004"))
            {
                MessageBox.Show("ليس لديك تصريح لحذف سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل بالفعل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                return;
            }

            Bind();
            dt = module.Delete().Tables[0];
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
        private void btn_Post_Click(object sender, EventArgs e)
        {
            if (Tag.ToString() == "Select")
            {
                Bind();
                if (btn_Post.Text == "ترحيل")
                {
                    if (!frm_main.Perm("0201005"))
                    {
                        MessageBox.Show("ليس لديك تصريح لترحيل سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    dt = module.Post().Tables[0];

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
                    Form_Mode("Select");
                    MessageBox.Show("تم الترحيل بنجاح", "ترحيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Post.Text = "إلغاء الترحيل";
                }
                else if (btn_Post.Text == "إلغاء الترحيل")
                {
                    if (!frm_main.Perm("0201006"))
                    {
                        MessageBox.Show("ليس لديك تصريح لإلغاء ترحيل سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    dt = module.PostCancel().Tables[0];

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
                    Form_Mode("Select");
                    MessageBox.Show("تم إلغاء الترحيل بنجاح", "إلغاء الترحيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_Post.Text = "ترحيل";
                }
            }
        }
        #endregion

        #region Details
        private void dtp_begindate_ValueChanged(object sender, EventArgs e)
        {
            txt_date.Text = dtp_begindate.Value.ToString("dd/MM/yyyy");
            txt_date.Text = dtp_begindate.Value.ToString("dd/MM/yyyy");
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

                for (int i = iColumn; i < dgv.Columns.Count - 1; i++)
                {
                    if (dgv.Columns[i + 1].Visible)
                    {
                        dgv.CurrentCell = dgv[i + 1, iRow];
                        return;
                    }
                }
                if (iRow == dgv.RowCount - 1)
                {
                    Add_Row();
                    dgv.CurrentCell = dgv[0, iRow + 1];
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
            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty") return;
            if (dgv.CurrentCell == null) return;

            Hide_Auto();

            if (dgv.CurrentCell.OwningColumn.Name == "chart_cin_name" || dgv.CurrentCell.OwningColumn.Name == "chart_cout_name")
            {
                txt_Ghost.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                txt_Ghost.Width = dgv.CurrentCell.OwningColumn.Width + dgv.CurrentRow.Cells["chart_cin_id"].OwningColumn.Width;
                txt_Ghost.Location = new Point(txt_Ghost.Location.X + 3 - dgv.CurrentRow.Cells["chart_cin_id"].OwningColumn.Width, txt_Ghost.Location.Y + 16);
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
            else if (dgv.CurrentCell.OwningColumn.Name == "paytype_name")
            {
                com_paytype.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                com_paytype.Width = dgv.CurrentCell.OwningColumn.Width;
                com_paytype.Location = new Point(com_paytype.Location.X + 3 , com_paytype.Location.Y + 16);
                com_paytype.Visible = true;

                com_paytype.Text = dgv.CurrentCell.Value.ToString();

                Refresh();
                com_paytype.Focus();
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "bank_name")
            {
                com_bank.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                com_bank.Width = dgv.CurrentCell.OwningColumn.Width;
                com_bank.Location = new Point(com_bank.Location.X + 3, com_bank.Location.Y + 16);
                com_bank.Visible = true;

                if(dgv.CurrentCell.Value != null) com_bank.Text = dgv.CurrentCell.Value.ToString();

                Refresh();
                com_bank.Focus();
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "currency_name")
            {
                com_currency.Location = dgv.GetCellDisplayRectangle(dgv.CurrentCell.ColumnIndex, dgv.CurrentCell.RowIndex, false).Location;
                com_currency.Width = dgv.CurrentCell.OwningColumn.Width;
                com_currency.Location = new Point(com_currency.Location.X + 3, com_currency.Location.Y + 16);
                com_currency.Visible = true;

                com_currency.Text = dgv.CurrentCell.Value.ToString();

                Refresh();
                com_currency.Focus();
            }
            else
            {
                txt_Ghost.Visible = false;
                txt_Ghost.Text = "";
                dgv_AutoComplete.Visible = false;
                dv_AutoComplete.RowFilter = "";

                txt_Auto_cc1.Visible = false;
                txt_Auto_cc1.Text = "";
                dgv_AutoComplete.Visible = false;
                dv_AutoComplete_cc1.RowFilter = "";
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
            if (e.ColumnIndex == 0)
            {
                decimal t = 0;
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    t += Convert.ToDecimal(r.Cells["amount"].Value);
                }
                txt_Total.Text = t.ToString();
            }
        }
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow.Cells["chart_cin_id"].Selected == true)
            {
                dgv.CurrentRow.Cells["chart_cin_name"].Selected = true;
            }
            if (dgv.CurrentRow.Cells["chart_cout_id"].Selected == true)
            {
                dgv.CurrentRow.Cells["chart_cout_name"].Selected = true;
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentCell.OwningColumn.Name == "cc1_name" || dgv.CurrentCell.OwningColumn.Name == "cc2_name" || dgv.CurrentCell.OwningColumn.Name == "branch_name")
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
                    if (dgv.CurrentCell.OwningColumn.Name == "chart_cin_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["chart_cin_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns["chart_cout_name"].Index];
                        dgv.Focus();

                        txt_Ghost.Text = "";
                        txt_Ghost.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "chart_cout_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["chart_cout_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns["notes"].Index];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["cc1_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.OwningColumn.Name = "cc2_name"];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value.ToString();

                        dgv.CurrentCell.Value = name;
                        dgv.CurrentRow.Cells["cc2_id"].Value = id;

                        dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.OwningColumn.Name = "branch_name"];
                        dgv.Focus();
                    }
                    else if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
                    {
                        string name = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value.ToString();
                        string id = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value.ToString();

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
            dgv.CurrentCell.Value = dgv_AutoComplete.CurrentRow.Cells["auto_Name"].Value;

            if (dgv.CurrentCell.OwningColumn.Name == "chart_cin_name")
            {
                dgv.CurrentRow.Cells["chart_cin_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells["chart_cout_name"];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "chart_cout_name")
            {
                dgv.CurrentRow.Cells["chart_cout_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells["notes"];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
            {
                dgv.CurrentRow.Cells["cc1_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "cc2_name")
            {
                dgv.CurrentRow.Cells["cc2_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value;
                dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }
            else if (dgv.CurrentCell.OwningColumn.Name == "branch_name")
            {
                dgv.CurrentRow.Cells["branch_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ID"].Value;
                //dgv.CurrentCell = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dgv.CurrentCell.ColumnIndex + 2];
            }

            dgv.Focus();
        }
        #endregion

        #region com_paytype
        private void com_paytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_paytype.Focused)
            {
                dgv.CurrentRow.Cells["paytype_name"].Value = com_paytype.Text;
                dgv.CurrentRow.Cells["paytype_id"].Value = com_paytype.SelectedValue.ToString();
            }
        }
        private void com_paytype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(dgv.Columns["bank_name"].Visible == true) dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns["bank_name"].Index];
            }
        }
        #endregion

        #region com_bank
        private void com_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_bank.Focused)
            {
                dgv.CurrentRow.Cells["bank_name"].Value = com_bank.Text;
                dgv.CurrentRow.Cells["bank_id"].Value = com_bank.SelectedValue.ToString();
            }
        }
        private void com_bank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns["checkcardno"].Index];
                dgv.Focus();
            }
        }
        #endregion

        #region com_currency
        private void com_currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_currency.Focused)
            {
                dgv.CurrentRow.Cells["currency_name"].Value = com_currency.Text;
                dgv.CurrentRow.Cells["currency_id"].Value = com_currency.SelectedValue.ToString();
            }
        }
        private void com_currency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.Columns["cc1_name"].Index];
                dgv.Focus();
            }
        }
        #endregion

        #region txt_Auto_cc1
        private void txt_Auto_cc1_TextChanged(object sender, EventArgs e)
        {
            dv_AutoComplete_cc1.RowFilter = "aname Like '%" + txt_Auto_cc1.Text + "%' OR id Like '%" + txt_Auto_cc1.Text + "%'";
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
            dv_AutoComplete_cc1.RowFilter = "aname Like '%" + txt_Auto_cc2.Text + "%' OR id Like '%" + txt_Auto_cc2.Text + "%'";
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
            if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
            {
                dgv.CurrentCell.Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_name"].Value;
                dgv.CurrentRow.Cells["cc1_id"].Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_id"].Value;

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

                        dgv.Focus();
                    }
                }
            }
        }
        #endregion

        #region dgv_Auto_Branch
        private void dgv_Auto_Branch_SelectionChanged(object sender, EventArgs e)
        {
            txt_Auto_cc2.Focus();
            txt_Auto_cc2.SelectionStart = txt_Auto_cc2.Text.Length;
        }
        private void dgv_Auto_Branch_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.OwningColumn.Name == "cc1_name")
            {
                dgv.CurrentCell.Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_name"].Value;
                dgv.CurrentRow.Cells["cc1_id"].Value = dgv_Auto_cc2.CurrentRow.Cells["col_Auto_cc2_id"].Value;

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
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "First";

            ds = module.Select();
            dt = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
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
            module.company_id = frm_main.com_companies.SelectedValue.ToString();

            if (Tag.ToString() == "Select")
            {
                module.id = txt_id.Text;
                module.selecttype = "Prev";
            }
            else if (Tag.ToString() == "Empty")
            {
                if (module.id == null)
                {
                    module.selecttype = "Last";
                }
                else
                {
                    module.selecttype = "Prev";
                }
            }


            ds = module.Select();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) return;

            Form_Mode("Select");
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
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

            ds = module.Select();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) return;

            Tag = "Select";
            Form_Mode("Select");
        }
        private void btn_Last_Click(object sender, EventArgs e)
        {
            module.branch_id = com_Branches.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "Last";

            ds = module.Select();
            dt = ds.Tables[0];

            if (ds.Tables[0].Rows.Count > 0)
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

                ds = module.Select();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count == 0) return;

                Tag = "Select";
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
                    //SizeF size = graphics.MeasureString(r.Cells["Notes"].Value.ToString(), fb);
                    //decimal sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["notes_Width"]);
                    //if ((decimal)size.Width > sw)
                    //{
                    //    decimal d = Math.Ceiling((decimal)size.Width / sw);
                    //    RowStart += Row_H * (int)d;
                    //}
                    //else
                    //{
                    //    RowStart += Row_H;
                    //}
                }

            }
            return PageCount;
        }
        #endregion

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0201007"))
            {
                MessageBox.Show("ليس لديك تصريح لطباعة سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void btn_PrintPreview_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0201007"))
            {
                MessageBox.Show("ليس لديك تصريح لطباعة سند قبض", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //if (Demo) ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


            PagesConnt = GetPageCount();
            page_no = 1;
            row_no = 0;

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", Page_W, Page_H);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            if (!(dt.Columns.Contains("h_total"))) dt.Columns.Add("h_total", typeof(string), txt_Total.Text);

            var format = new StringFormat() { Alignment = (Page_RL) ? StringAlignment.Far : StringAlignment.Near };
            RectangleF rect;

            Image img = Image.FromFile(Application.StartupPath + @"\logo.png");

            DataTable dt_print = new DataTable();
            dt_print.Columns.Clear();
            dt_print.Rows.Clear();

            dt_print.Columns.Add("form");
            dt_print.Columns.Add("desname");
            dt_print.Columns.Add("repHeader_h");
            dt_print.Columns.Add("pageHeader_h");
            dt_print.Columns.Add("details_h");
            dt_print.Columns.Add("fieldname");
            dt_print.Columns.Add("fieldtype");
            dt_print.Columns.Add("text");
            dt_print.Columns.Add("zone");
            dt_print.Columns.Add("x");
            dt_print.Columns.Add("y");
            dt_print.Columns.Add("fontName");
            dt_print.Columns.Add("fontSize");
            dt_print.Columns.Add("visable");

            int rep_h = 0;
            int page_h = 50;
            int details_h = 5;

            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "title", "rect", "", "Page_Header", 130, 10, "Calibri", 5, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "title", "lable", "سند قبض", "Page_Header", 128, 10, "Calibri", 20, true);

            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "id", "lable",  "رقم السند", "Page_Header", 190, 30, "Calibri", 12, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "id", "value", null, "Page_Header", 170, 30, "Calibri", 12, true);

            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "amount", "lable", "المبلغ", "Page_Header", 190, 50, "Calibri", 10, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "amount", "lable", "الحساب", "Page_Header", 170, 50, "Calibri", 10, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "amount", "lable", "", "Page_Header", 140, 50, "Calibri", 12, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "amount", "lable", "البيان", "Page_Header", 110, 50, "Calibri", 10, true);


            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "amount", "value", null, "Details", 190, 60, "Calibri", 10, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "chart_cin_aname", "value", null, "Details", 170, 60, "Calibri", 10, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "chart_cin_id", "value", null, "Details", 140, 60, "Calibri", 10, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "notes", "value", null, "Details", 110, 60, "Calibri", 10, true);

            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "total", "value", null, "Page_Footer", 190, 10, "Calibri", 12, true);
            dt_print.Rows.Add("frm_cin", "1", rep_h, page_h, details_h, "total", "lable", "الإجمالي", "Page_Footer", 170, 10, "Calibri", 12, true);


            foreach (DataRow r in dt_print.Rows)
            {
                if (r["zone"].ToString() == "Page_Header")
                {
                    if (r["fieldtype"].ToString() == "rect")
                    {
                        e.Graphics.DrawRectangle(p, new Rectangle(new Point(Convert.ToInt32(r["x"]) - 30, Convert.ToInt32(r["y"])), new Size(30, 10)));
                        //e.Graphics.DrawString(r["text"].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"])), format);
                    }
                    else if (r["fieldtype"].ToString() == "lable")
                    {
                        e.Graphics.DrawString(r["text"].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"])), format);
                    }
                    else if (r["fieldtype"].ToString() == "value")
                    {
                        e.Graphics.DrawString(dt.Rows[0]["h_" + r["fieldname"].ToString()].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"])), format);
                    }
                }
            }

            int Top = Convert.ToInt32(dt_print.Rows[0]["repHeader_h"]) + Convert.ToInt32(dt_print.Rows[0]["pageHeader_h"]);
            int Row_H = Convert.ToInt32(dt_print.Rows[0]["details_h"]);
            Top += Row_H * 2;

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataRow r in dt_print.Rows)
                {
                    if (r["zone"].ToString() == "Details")
                    {
                        if (r["fieldtype"].ToString() == "lable")
                        {
                            e.Graphics.DrawString(r["text"].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Top), format);
                        }
                        else if (r["fieldtype"].ToString() == "value")
                        {
                            e.Graphics.DrawString(dr["d_" + r["fieldname"].ToString()].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Top), format);
                        }
                    }
                }
                Top += Row_H;
            }

            foreach (DataRow r in dt_print.Rows)
            {
                if (r["zone"].ToString() == "Page_Footer")
                {
                    if (r["fieldtype"].ToString() == "lable")
                    {
                        e.Graphics.DrawString(r["text"].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Top + Convert.ToInt32(r["y"])), format);
                    }
                    else if (r["fieldtype"].ToString() == "value")
                    {
                        e.Graphics.DrawString(dt.Rows[0]["h_" + r["fieldname"].ToString()].ToString(), new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"])), Brushes.Black, new Point(Convert.ToInt32(r["x"]), Top + Convert.ToInt32(r["y"])), format);
                    }
                }
            }


            //#region Columns
            //int top = RepHeader_H + PageHeader_H;
            //int Cell_Left = Page_LMargin;
            //Graphics g = this.CreateGraphics();

            //Table_W = 0;

            //int i = (Page_RL) ? dgv.Columns.Count - 1 : 0;
            //foreach (DataGridViewColumn c in dgv.Columns)
            //{
            //    if (dgv.Columns[i].Visible == false)
            //    {
            //        if (Page_RL) { i--; } else { i++; }
            //        continue;
            //    }


            //    string s = dgv.Columns[dgv.Columns[i].Index].HeaderText.ToString();
            //    if (dgv.Columns[i].Name == "debit")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "credit")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "chart_name")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "chart_id")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "notes")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["notes_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "cc1_name")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc1_name_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "cc2_name")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc2_name_Width"]);
            //    }
            //    else if (dgv.Columns[i].Name == "branch_name")
            //    {
            //        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["branch_name_Width"]);
            //    }

            //    e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(Cell_Left, top, Cell_W, ColumnsHeader_H));
            //    e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, ColumnsHeader_H));
            //    e.Graphics.DrawString(s, fb, Brushes.Black, new Rectangle(Cell_Left + 10, top + 8, Cell_W, ColumnsHeader_H));

            //    Table_W += Cell_W;
            //    Cell_Left += Cell_W;

            //    if (Page_RL) { i--; } else { i++; }
            //}
            //i = (Page_RL) ? dgv.Columns.Count - 1 : 0;

            //#endregion

            //#region Rep_Header
            //rect = new RectangleF(Page_LMargin, 0, Table_W, RepHeader_H);
            //e.Graphics.DrawImage(img, rect);
            //#endregion

            //#region Page_Header
            //rect = new RectangleF((Page_W / 2) - 100, RepHeader_H, 200, 20);
            //e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);
            //e.Graphics.DrawString(((Page_RL) ? "قيد يومية" : "Entry"), fh, Brushes.Black, rect, format);

            //format = new StringFormat() { Alignment = (Page_RL) ? StringAlignment.Far : StringAlignment.Near };

            //// Draw Head Rect
            //e.Graphics.DrawRectangle(p, new Rectangle(Page_LMargin, RepHeader_H, Table_W, PageHeader_H));

            //rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 150, Table_W, 20);
            //e.Graphics.DrawString(((Page_RL) ? "رقم القيد : " : "Entyr Number : ") + txt_id.Text.ToString(), fb, Brushes.Black, rect, format);

            //rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 170, Table_W, 30);
            //e.Graphics.DrawString(((Page_RL) ? "التاريخ : " : "Date : ") + txt_date.Text.ToString(), fb, Brushes.Black, rect, format);


            //if (txt_notes.Text.Trim() != "")
            //{
            //    rect = new RectangleF((Page_RL) ? 0 : Page_LMargin + 5, 190, Table_W, 30);
            //    e.Graphics.DrawString(((Page_RL) ? "البيان : " : "Description : ") + txt_notes.Text.Trim(), fb, Brushes.Black, rect, format);
            //}
            //#endregion

            //#region Page_Footer
            //e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(Page_LMargin, Page_H - PageFooter_H, Table_W, 20));
            //e.Graphics.DrawRectangle(p, new Rectangle(Page_LMargin, Page_H - PageFooter_H, Table_W, 20));
            //rect = new RectangleF((Page_RL) ? (Table_W - 500) : Page_LMargin + 5, Page_H - PageFooter_H + 3, 500, 20);
            //e.Graphics.DrawString(((Page_RL) ? " صفحة رقم" : "Page No ") + " : " + page_no + " / " + PagesConnt + "             طبع في تاريخ " + DateTime.Now.ToString("yyyy/MM/dd"), fs, Brushes.Black, rect, format);
            //#endregion

            //#region Rows

            //Cell_Left = Page_LMargin;
            //top = RepHeader_H + PageHeader_H + ColumnsHeader_H;


            //while (row_no < dgv.RowCount)
            //{
            //    rowh = Row_H;

            //    if (top > Page_H - PageFooter_H - Row_H)
            //    {
            //        e.HasMorePages = true;
            //        top = RepHeader_H + PageHeader_H + ColumnsHeader_H;
            //        page_no++;
            //        return;
            //    }

            //    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            //    {
            //        #region chart_name_rowh
            //        int chart_name_rowh = Row_H;
            //        SizeF chart_name_size = graphics.MeasureString(dgv.Rows[row_no].Cells["chart_cin_name"].Value.ToString(), fb);
            //        decimal chart_name_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["chart_name_Width"]);

            //        if ((decimal)chart_name_size.Width > chart_name_sw)
            //        {
            //            decimal d = Math.Ceiling((decimal)chart_name_size.Width / chart_name_sw);
            //            chart_name_rowh = rowh * (int)d;
            //        }
            //        #endregion

            //        #region notes_rowh
            //        int notes_rowh = Row_H;
            //        SizeF notes_size = graphics.MeasureString(dgv.Rows[row_no].Cells["Notes"].Value.ToString(), fb);
            //        decimal notes_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["notes_Width"]);

            //        if ((decimal)notes_size.Width > notes_sw)
            //        {
            //            decimal d = Math.Ceiling((decimal)notes_size.Width / notes_sw);
            //            notes_rowh = rowh * (int)d;
            //        }
            //        #endregion

            //        #region cc1_rowh
            //        int cc1_rowh = Row_H;
            //        SizeF cc1_size = graphics.MeasureString(dgv.Rows[row_no].Cells["cc1_name"].Value.ToString(), fb);
            //        decimal cc1_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["cc1_name_Width"]);

            //        if ((decimal)cc1_size.Width > cc1_sw)
            //        {
            //            decimal d = Math.Ceiling((decimal)cc1_size.Width / cc1_sw);
            //            cc1_rowh = rowh * (int)d;
            //        }
            //        #endregion

            //        #region cc2_rowh
            //        int cc2_rowh = Row_H;
            //        SizeF cc2_size = graphics.MeasureString(dgv.Rows[row_no].Cells["cc2_name"].Value.ToString(), fb);
            //        decimal cc2_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["cc2_name_Width"]);

            //        if ((decimal)cc2_size.Width > cc2_sw)
            //        {
            //            decimal d = Math.Ceiling((decimal)cc2_size.Width / cc2_sw);
            //            cc2_rowh = rowh * (int)d;
            //        }
            //        #endregion

            //        #region branch_rowh
            //        int branch_rowh = Row_H;
            //        SizeF branch_size = graphics.MeasureString(dgv.Rows[row_no].Cells["branch_name"].Value.ToString(), fb);
            //        decimal branch_sw = Convert.ToDecimal(dt_PrintSettings.Rows[0]["branch_name_Width"]);

            //        if ((decimal)branch_size.Width > branch_sw)
            //        {
            //            decimal d = Math.Ceiling((decimal)branch_size.Width / branch_sw);
            //            branch_rowh = rowh * (int)d;
            //        }
            //        #endregion

            //        rowh = Math.Max(Math.Max(chart_name_rowh, notes_rowh), Math.Max(Math.Max(cc1_rowh, cc2_rowh), branch_rowh));
            //    }


            //    foreach (DataGridViewColumn c in dgv.Columns)
            //    {
            //        if (dgv.Columns[i].Visible == false)
            //        {
            //            if (Page_RL) { i--; } else { i++; }
            //            continue;
            //        }


            //        string s = s = (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value == null) ? "" : dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString();



            //        if (dgv.Columns[i].Name == "debit")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_Width"]);
            //            if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0")
            //            {
            //                s = "";
            //            }
            //        }
            //        else if (dgv.Columns[i].Name == "credit")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_Width"]);
            //            if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0")
            //            {
            //                s = "";
            //            }
            //        }
            //        else if (dgv.Columns[i].Name == "chart_name")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_Width"]);
            //        }
            //        else if (dgv.Columns[i].Name == "chart_id")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_Width"]);
            //        }
            //        else if (dgv.Columns[i].Name == "notes")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["notes_Width"]);
            //        }
            //        else if (dgv.Columns[i].Name == "cc1_name")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc1_name_Width"]);
            //        }
            //        else if (dgv.Columns[i].Name == "cc2_name")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["cc2_name_Width"]);
            //        }
            //        else if (dgv.Columns[i].Name == "branch_name")
            //        {
            //            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["branch_name_Width"]);
            //        }

            //        e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, rowh));
            //        e.Graphics.DrawString(s, fb, Brushes.Black, new Rectangle(Cell_Left + 2, top + 5, Cell_W, rowh));

            //        Cell_Left += Cell_W;
            //        if (Page_RL) { i--; } else { i++; }
            //    }
            //    i = (Page_RL) ? dgv.Columns.Count - 1 : 0;
            //    row_no++;
            //    Cell_Left = Page_LMargin;
            //    top += rowh;
            //}
            //#endregion

            //#region Rep_Footer
            ////dt_Footer.Rows.Add("مدين", "Debit", txt_TotalDebit.Text);
            ////dt_Footer.Rows.Add("دائن", "Credit", txt_TotalCredit.Text);

            //i = (Page_RL) ? dt_Footer.Rows.Count - 1 : 0;
            //Cell_W = Table_W / 4;


            //if (top > Page_H - PageFooter_H - RepFooter_H)
            //{
            //    e.HasMorePages = true;
            //    top = RepHeader_H + PageHeader_H + ColumnsHeader_H;
            //    page_no++;
            //    return;
            //}

            //top += Row_H;

            //foreach (DataRow r in dt_Footer.Rows)
            //{
            //    string name = ((Page_RL) ? dt_Footer.Rows[i]["Anm"].ToString() : dt_Footer.Rows[i]["Enm"].ToString()) + " :   " + dt_Footer.Rows[i]["Val"].ToString(); ;
            //    string val = dt_Footer.Rows[i]["Val"].ToString();

            //    e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, rowh));
            //    e.Graphics.DrawString(name, fb, Brushes.Black, new Rectangle(Cell_Left + 8, top + 5, Cell_W, rowh));

            //    Cell_Left += Cell_W;
            //    if (Page_RL) { i--; } else { i++; }
            //}

            //top = Page_H - PageFooter_H - 100;

            //e.Graphics.DrawString("المدير المالي", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4), top, (Table_W / 4), 20));
            //e.Graphics.DrawString("المحاسب", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) * 3, top, (Table_W / 4), 20));

            //top += 50;

            //e.Graphics.DrawString("-----------------", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) - 10, top, (Table_W / 4), 20));
            //e.Graphics.DrawString("-----------------", fb, Brushes.Black, new Rectangle(Page_LMargin + (Table_W / 4) * 3 - 10, top, (Table_W / 4), 20));
            //#endregion
        }
        #endregion

        private void btn_jorID_Click(object sender, EventArgs e)
        {
            if (btn_jorID.Text == "") return;

            pro_view.fld_PL.fld_Accounting.frm_jor f = new frm_jor(frm_main);
            f.btn_New.Image = frm_main.imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = frm_main.imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = frm_main.imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = frm_main.imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = frm_main.imageList_48.Images["Delete_48.png"];

            f.com_Branches.DataSource = frm_main.com_branches.DataSource;
            f.com_Branches.SelectedValue = frm_main.com_branches.SelectedValue;
            f.com_fyear.DataSource = frm_main.com_fyear.DataSource;
            f.com_fyear.SelectedValue = frm_main.com_fyear.SelectedValue;
            f.com_Users.DataSource = frm_main.com_users.DataSource;
            f.com_Users.SelectedValue = frm_main.com_users.SelectedValue;

            f.Text = "قيود اليومية";
            f.txt_id.Text = btn_jorID.Text;

            f.Show();
        }
        private void btn_jorID_MouseEnter(object sender, EventArgs e)
        {
            if (btn_jorID.Text != "")
            {
                btn_jorID.Cursor = Cursors.Hand;
            }
            else
            {
                btn_jorID.Cursor = Cursors.Arrow;
            }
        }
        private void btn_Settings_Click(object sender, EventArgs e)
        {
            frm_cinsettings f = new frm_cinsettings();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if(col.Tag != null) if (col.Tag.ToString() == "Hiden") continue;

                CheckBox chk = new CheckBox();
                chk.Name = col.Name;
                chk.Text = col.HeaderText;
                chk.Checked = col.Visible;
                chk.CheckedChanged += new System.EventHandler(chk_CheckedChanged);

                f.flp_Fields.Controls.Add(chk);
            }

            f.Show();
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            dgv.Columns[((CheckBox)sender).Name].Visible = ((CheckBox)sender).Checked;
        }

        private void btn_PrintPreview_Click_1(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //if (Demo) ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            printPreviewDialog1.ShowDialog();
        }
    }
}
