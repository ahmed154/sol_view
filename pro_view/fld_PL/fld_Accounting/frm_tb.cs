using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting
{
    public partial class frm_tb : Form
    {
        #region Declarations
        public fld_Login.frm_main frm_main = new fld_Login.frm_main();
        public bool Demo;
        fld_BL.cls_bl.stc_Accounting.TB module = new fld_BL.cls_bl.stc_Accounting.TB();
        DataSet ds = new DataSet();
        DataTable dt_result = new DataTable();
        DataView dv_AutoComplete = new DataView();

        #region ExportToExcel
        Microsoft.Office.Interop.Excel.Range myRange;
        Microsoft.Office.Interop.Excel.Range StartCell;
        Microsoft.Office.Interop.Excel.Range EndCell;
        #endregion

        #endregion



        public frm_tb(fld_Login.frm_main frm_MAIN)
        {
            InitializeComponent();

            frm_main = frm_MAIN;

            btn_Branch.Image = frm_main.imageList32.Images["branch1_32.png"];
            btn_CC1.Image = frm_main.imageList32.Images["cc_32.png"];
            btn_CC2.Image = frm_main.imageList32.Images["cc_32.png"];

            dgv.AutoGenerateColumns = false;
            dgv_AutoComplete.AutoGenerateColumns = false;
            dgv_txt_AutoComplete.AutoGenerateColumns = false;

            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            ds = module.SelectLogin();

            com_Branches.DataSource = ds.Tables["tbl_branches"];
            com_CC1.DataSource = ds.Tables["tbl_cc1"];
            com_CC2.DataSource = ds.Tables["tbl_cc2"];

            com_Branches.SelectedValue = frm_main.com_branches.SelectedValue;

            dgv_AutoComplete.Columns["auto_ChartName"].Width = Convert.ToInt32(dgv_AutoComplete.Width * .60);
            dgv_txt_AutoComplete.Columns["chart_name"].Width = Convert.ToInt32(dgv_txt_AutoComplete.Width * .60);

            dv_AutoComplete = ds.Tables["tbl_chart"].DefaultView;
            dgv_AutoComplete.DataSource = dv_AutoComplete;

            dgv_txt_AutoComplete.Rows.Add();

            #region dgv
            var chart_id = new DataGridViewTextBoxColumn();
            chart_id.Name = "chart_id";
            chart_id.HeaderText = "كود الحساب";
            chart_id.DataPropertyName = "id";
            chart_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chart_id.Width = 150;
            chart_id.ReadOnly = true;
            chart_id.Visible = true;
            dgv.Columns.Add(chart_id);

            var chart_name = new DataGridViewTextBoxColumn();
            chart_name.Name = "chart_name";
            chart_name.HeaderText = "الحساب";
            chart_name.DataPropertyName = "aname";
            chart_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            chart_name.Width = 200;
            dgv.Columns.Add(chart_name);

            var open_debit = new DataGridViewTextBoxColumn();
            open_debit.Name = "open_debit";
            open_debit.HeaderText = "افتتاحي مدين";
            open_debit.DataPropertyName = "open_debit";
            open_debit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            open_debit.Width = 120;
            dgv.Columns.Add(open_debit);

            var open_credit = new DataGridViewTextBoxColumn();
            open_credit.Name = "open_credit";
            open_credit.HeaderText = "افتتاحي دائن";
            open_credit.DataPropertyName = "open_credit";
            open_credit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            open_credit.Width = 120;
            dgv.Columns.Add(open_credit);

            var debit = new DataGridViewTextBoxColumn();
            debit.Name = "debit";
            debit.HeaderText = "مدين";
            debit.DataPropertyName = "debit";
            debit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            debit.Width = 120;
            dgv.Columns.Add(debit);

            var credit = new DataGridViewTextBoxColumn();
            credit.Name = "credit";
            credit.HeaderText = "دائن";
            credit.DataPropertyName = "credit";
            credit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            credit.Width = 120;
            dgv.Columns.Add(credit);

            var balance_debit = new DataGridViewTextBoxColumn();
            balance_debit.Name = "balance_debit";
            balance_debit.HeaderText = "رصيد مدين";
            balance_debit.DataPropertyName = "balance_debit";
            balance_debit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            balance_debit.Width = 120;
            dgv.Columns.Add(balance_debit);

            var balance_credit = new DataGridViewTextBoxColumn();
            balance_credit.Name = "balance_credit";
            balance_credit.HeaderText = "رصيد دائن";
            balance_credit.DataPropertyName = "balance_credit";
            balance_credit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            balance_credit.Width = 120;
            dgv.Columns.Add(balance_credit);

            var net_balance = new DataGridViewTextBoxColumn();
            net_balance.Name = "net_balance";
            net_balance.HeaderText = "رصيد نهائي";
            net_balance.DataPropertyName = "net_balance";
            net_balance.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            net_balance.Width = 120;
            dgv.Columns.Add(net_balance);

            var level = new DataGridViewTextBoxColumn();
            level.Name = "level";
            level.HeaderText = "level";
            level.DataPropertyName = "level";
            level.Visible = false;
            dgv.Columns.Add(level);

            var parent = new DataGridViewTextBoxColumn();
            parent.Name = "parent";
            parent.HeaderText = "parent";
            parent.DataPropertyName = "parent";
            parent.Visible = false;
            dgv.Columns.Add(parent);
            #endregion
        }

        #region Pro
        void EmptyZero()
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                for (int i = 2; i < 9; i++)
                {
                    if (Convert.ToDecimal(r.Cells[i].Value) == 0) { r.Cells[i].Style.ForeColor = Color.Transparent; }
                }
            }
        }
        #endregion

        #region Form
        private void frm_ST_Shown(object sender, EventArgs e)
        {
            #region ContextMenuStrips
            // Branches
            btn_DelBranch.Visible = true;
            btn_DelBranch.Image = frm_main.imageList16.Images["Close_16.png"];
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

            #endregion

            if (dgv.SelectedRows.Count > 0) { dgv.SelectedRows[0].Selected = false; }

            if (Parent == null & dgv.RowCount > 0)
            {
                // Balance
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    if (dgv.Rows[r.Index].Index >= 1)
                    {
                        r.Cells["Balance"].Value = Convert.ToDecimal(dgv.Rows[r.Index - 1].Cells["Balance"].Value) + (Convert.ToDecimal(r.Cells["Debit"].Value) - Convert.ToDecimal(r.Cells["Credit"].Value));
                    }
                    else if (dgv.Rows[r.Index].Cells["Balance"].RowIndex >= 0)
                    {
                        r.Cells["Balance"].Value = (Convert.ToDecimal(r.Cells["Debit"].Value) - Convert.ToDecimal(r.Cells["Credit"].Value));
                    }
                }
            }

            btn_ExportToExcel.Image = frm_main.imageList_48.Images["excel_48.png"];
        }
        #endregion

        #region Panel_FRM_Header

        #region btn display
        private void btn_Bill_Branche_MouseEnter(object sender, EventArgs e)
        {
            btn_Branch.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Bill_Branche_MouseLeave(object sender, EventArgs e)
        {
            btn_Branch.FlatStyle = FlatStyle.Flat;
        }
        private void lbl_bill_Branches_MouseEnter(object sender, EventArgs e)
        {
            btn_Branch.FlatStyle = FlatStyle.Popup;
        }
        private void lbl_bill_Branches_MouseLeave(object sender, EventArgs e)
        {
            btn_Branch.FlatStyle = FlatStyle.Flat;
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

        private void btn_CC1_TextChanged(object sender, EventArgs e)
        {
            btn_cc1_del.Visible = (btn_CC1.Text != "مركز1" && Tag.ToString() == "New" | Tag.ToString() == "Edit") ? true : false;
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
            btn_Branch.Text = "الفرع : " + com_Branches.Text;
        }
        private void com_CC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_CC1.Text = "مركز1 : " + com_CC1.Text;
        }
        private void com_CC2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_CC2.Text = "مركز2 : " + com_CC2.Text;
        }

        private void btn_Bill_Branche_Click(object sender, EventArgs e)
        {
            if (com_Branches.Enabled == false) return;
            Point p = btn_Branch.PointToScreen(Point.Empty);

            contextMenuStrip_branches.Show(p.X - (contextMenuStrip_branches.Width - btn_Branch.Width), p.Y + btn_Branch.Height);
        }
        private void btn_CC1_Click(object sender, EventArgs e)
        {
            if (com_CC1.Enabled == false) return;
            Point p = btn_CC1.PointToScreen(Point.Empty);
            contextMenuStrip_cc1.Show(p.X - (contextMenuStrip_cc1.Width - btn_CC1.Width), p.Y + btn_CC1.Height);
        }
        private void btn_CC2_Click(object sender, EventArgs e)
        {
            if (com_CC2.Enabled == false) return;
            Point p = btn_CC2.PointToScreen(Point.Empty);
            contextMenuStrip_cc2.Show(p.X - (contextMenuStrip_cc2.Width - btn_CC2.Width), p.Y + btn_CC2.Height);
        }

        private void btn_DelBranch_Click(object sender, EventArgs e)
        {
            com_Branches.SelectedValue = -1;
            btn_DelBranch.Visible = false;
            btn_Branch.Image = frm_main.imageList32.Images["branch_32.png"];
        }
        private void btn_cc1_del_Click(object sender, EventArgs e)
        {
            com_CC1.SelectedValue = -1;
            btn_cc1_del.Visible = false;
            btn_CC1.Image = frm_main.imageList32.Images["cc_32.png"];
        }
        private void btn_cc2_del_Click(object sender, EventArgs e)
        {
            com_CC2.SelectedValue = -1;
            btn_cc2_del.Visible = false;
            btn_CC2.Image = frm_main.imageList32.Images["cc_32.png"];
        }

        private void contextMenuStrip_branches_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_Branches.SelectedIndex = contextMenuStrip_branches.Items.IndexOf(e.ClickedItem);
            btn_Branch.Image = frm_main.imageList32.Images["branch1_32.png"];
            btn_DelBranch.Visible = true;
        }
        private void contextMenuStrip_cc1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_CC1.SelectedIndex = contextMenuStrip_cc1.Items.IndexOf(e.ClickedItem);
            btn_CC1.Image = frm_main.imageList32.Images["cc1_32.png"];
            btn_cc1_del.Visible = true;
        }
        private void contextMenuStrip_cc2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            com_CC2.SelectedIndex = contextMenuStrip_cc2.Items.IndexOf(e.ClickedItem);
            btn_CC2.Image = frm_main.imageList32.Images["cc2_32.png"];
            btn_cc2_del.Visible = true;
        }

        #endregion

        #region Controls

        #region Display
        private void button_Display_MouseEnter(object sender, EventArgs e)
        {
            btn_Display.FlatStyle = FlatStyle.Popup;
        }
        private void button_Display_MouseLeave(object sender, EventArgs e)
        {
            btn_Display.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Print_MouseEnter(object sender, EventArgs e)
        {
            btn_Print.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Print_MouseLeave(object sender, EventArgs e)
        {
            btn_Print.FlatStyle = FlatStyle.Flat;
        }
        private void btn_PrintPreview_MouseEnter(object sender, EventArgs e)
        {
            btn_PrintPreview.FlatStyle = FlatStyle.Popup;
        }
        private void btn_PrintPreview_MouseLeave(object sender, EventArgs e)
        {
            btn_PrintPreview.FlatStyle = FlatStyle.Flat;
        }
        #endregion

        private void chk_Only_Balances_CheckedChanged(object sender, EventArgs e)
        {
            dgv.Columns["open_debit"].Visible = !chk_Only_Balances.Checked;
            dgv.Columns["open_credit"].Visible = !chk_Only_Balances.Checked;
            dgv.Columns["debit"].Visible = !chk_Only_Balances.Checked;
            dgv.Columns["credit"].Visible = !chk_Only_Balances.Checked;
        }
        private void btn_chart_del_Click(object sender, EventArgs e)
        {
            dgv_txt_AutoComplete.Rows[0].Cells["chart_name"].Value = null;
            dgv_txt_AutoComplete.Rows[0].Cells["chart_id"].Value = null;
            btn_chart_del.Visible = false;
        }
        public void button_Display_Click(object sender, EventArgs e)
        {
            #region Validate values
            module.ID = (dgv_txt_AutoComplete.Rows[0].Cells["chart_id"].Value != null)? dgv_txt_AutoComplete.Rows[0].Cells["chart_id"].Value.ToString() : "";
            if (dtp_form.Checked == false) { module.date_From = "01/01/0001"; } else { module.date_From = dtp_form.Value.Date.ToString("MM/dd/yyyy"); }
            if (dtp_to.Checked == false) { module.date_To = "12/31/9999"; } else { module.date_To = dtp_to.Value.Date.ToString("MM/dd/yyyy"); }
            #endregion

            #region Bind
            module.level = (com_Level.SelectedIndex == -1)? 10 : com_Level.SelectedIndex + 1; 
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.branch_id = (com_Branches.SelectedValue == null) ? null : com_Branches.SelectedValue.ToString();
            module.cc1_id = (com_CC1.SelectedValue == null) ? null : com_CC1.SelectedValue.ToString();
            module.cc2_id = (com_CC2.SelectedValue == null) ? null : com_CC2.SelectedValue.ToString();
            #endregion

            // Get data from database
            dt_result = module.Select().Tables[0];

            // Remove record which not has balance
            for (int i = 0; i < dt_result.Rows.Count; i++)
            {
                if (Convert.ToDecimal(dt_result.Rows[i]["balance_debit"]) == 0 && Convert.ToDecimal(dt_result.Rows[i]["balance_credit"]) == 0)
                {
                    dt_result.Rows.RemoveAt(i);
                    i--;
                }
            }

            dgv.DataSource = null;
            dgv.DataSource = dt_result;


            dt_result = dt_result.DefaultView.ToTable();

            if (dt_result.Rows.Count == 0) return;

            // Total Debit & Total Credit
            decimal tod = 0;
            decimal toc = 0;
            decimal d = 0;
            decimal c = 0;
            decimal tbd = 0;
            decimal tbc = 0;

            int MinLevel = dgv.Rows.Cast<DataGridViewRow>().Min(r => Convert.ToInt32(r.Cells["level"].Value));

            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if(Convert.ToInt32(dr.Cells["level"].Value) == MinLevel)
                {
                    tod += Convert.ToDecimal(dr.Cells["open_debit"].Value);
                    toc += Convert.ToDecimal(dr.Cells["open_credit"].Value);
                    d += Convert.ToDecimal(dr.Cells["debit"].Value);
                    c += Convert.ToDecimal(dr.Cells["credit"].Value);
                    tbd += Convert.ToDecimal(dr.Cells["balance_debit"].Value);
                    tbc += Convert.ToDecimal(dr.Cells["balance_credit"].Value);
                }

            }

            txt_TotalOpenDebit.Text = tod.ToString();
            txt_TotalOpenCredit.Text = toc.ToString();
            txt_TotalDebit.Text = d.ToString();
            txt_TotalCredit.Text = c.ToString();
            txt_TotalBalanceDebit.Text = tbd.ToString();
            txt_TotalBalanceCredit.Text = tbc.ToString();
            
            if (dgv.SelectedRows.Count > 0) { dgv.SelectedRows[0].Selected = false; }
            EmptyZero();

            chk_OnlyLastLevel_CheckedChanged(null, null);
        }
        private void dtp_form_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_form.Checked == true) { dtp_form.Format = DateTimePickerFormat.Short; }
        }
        private void dtp_form_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtp_form.Checked == true) { dtp_form.Format = DateTimePickerFormat.Short; }
            if (dtp_form.Checked == false) { dtp_form.Format = DateTimePickerFormat.Custom; }
        }
        private void dtp_to_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_to.Checked == true) { dtp_to.Format = DateTimePickerFormat.Short; }
        }
        private void dtp_to_MouseUp(object sender, MouseEventArgs e)
        {
            if (dtp_to.Checked == true) { dtp_to.Format = DateTimePickerFormat.Short; }
            if (dtp_to.Checked == false) { dtp_to.Format = DateTimePickerFormat.Custom; }
        }

        #endregion

        #region Details
        private void chk_OnlyLastLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (dgv.RowCount == 0) return;

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgv.DataSource];
            currencyManager1.SuspendBinding();

            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (Convert.ToBoolean(r.Cells["parent"].Value) == true)
                {
                    r.Visible = !chk_OnlyLastLevel.Checked;
                }
            }


            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Visible == true)
                {
                    dgv.CurrentCell = r.Cells[0];
                    break;
                }
            }

            currencyManager1.ResumeBinding();
            dgv.ClearSelection();
        }
        #endregion

        #region AutoComplete

        #region dgv_txt_AutoComplete
        private void dgv_txt_AutoComplete_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_AutoComplete.RowCount > 0)
            {
                dgv_AutoComplete.Visible = true;
            }

            txt_Ghost.Visible = true;
            txt_Ghost.Focus();
        }
        #endregion
        #region txt_Ghost
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
                    dgv_txt_AutoComplete.Rows[0].Cells["chart_name"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value;
                    dgv_txt_AutoComplete.Rows[0].Cells["chart_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;

                    btn_chart_del.Visible = true;
                    txt_Ghost.Text = "";

                    btn_Display.Focus();
                }
            }
        }
        private void txt_Ghost_TextChanged(object sender, EventArgs e)
        {
            dv_AutoComplete.RowFilter = "aname Like '%" + txt_Ghost.Text + "%' OR id Like '%" + txt_Ghost.Text + "%'";
        }
        private void txt_Ghost_Leave(object sender, EventArgs e)
        {
            if (dgv_AutoComplete.Focused) return;
            txt_Ghost.Visible = false;
            dgv_AutoComplete.Visible = false;
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
            dgv_txt_AutoComplete.Rows[0].Cells["chart_name"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartName"].Value;
            dgv_txt_AutoComplete.Rows[0].Cells["chart_id"].Value = dgv_AutoComplete.CurrentRow.Cells["auto_ChartID"].Value;

            btn_chart_del.Visible = true;
            txt_Ghost.Visible = false;
            dgv_AutoComplete.Visible = false;
            txt_Ghost.Text = "";

            btn_Display.Focus();
        }
        #endregion

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
        Font fb = new Font("Calibri", 8);
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

                RowStart += Row_H;
            }
            return PageCount;
        }
        #endregion

        private void btn_PrintPreview_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0205002"))
            {
                MessageBox.Show("ليس لديك تصريح لطباعة ميزان المراجعة", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            if (Demo) ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            printPreviewDialog1.ShowDialog();
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0205002"))
            {
                MessageBox.Show("ليس لديك تصريح لطباعة ميزان المراجعة", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            dt_PrintSettings.Columns.Clear();
            dt_PrintSettings.Rows.Clear();

            dt_PrintSettings.Columns.Add("DocName", typeof(string));
            dt_PrintSettings.Columns.Add("chart_id_w", typeof(int));
            dt_PrintSettings.Columns.Add("chart_name_w", typeof(int));
            dt_PrintSettings.Columns.Add("open_debit_w", typeof(int));
            dt_PrintSettings.Columns.Add("open_credit_w", typeof(int));
            dt_PrintSettings.Columns.Add("debit_w", typeof(int));
            dt_PrintSettings.Columns.Add("credit_w", typeof(int));
            dt_PrintSettings.Columns.Add("balance_debit_w", typeof(int));
            dt_PrintSettings.Columns.Add("balance_credit_w", typeof(int));
            dt_PrintSettings.Columns.Add("net_balance_w", typeof(int));

            if (chk_Only_Balances.Checked)
            {
                dt_PrintSettings.Rows.Add("TB", 110, 450, 0, 0, 0, 0, 80, 80, 80);
            }
            else
            {
                dt_PrintSettings.Rows.Add("TB", 110, 200, 70, 70, 70, 70, 70, 70, 70);
            }

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

                switch (dgv.Columns[i].Name)
                {
                    case "chart_id":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_w"]);
                        break;
                    case "chart_name":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_w"]);
                        break;
                    case "open_debit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["open_debit_w"]);
                        break;
                    case "open_credit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["open_credit_w"]);
                        break;
                    case "debit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_w"]);
                        break;
                    case "credit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_w"]);
                        break;
                    case "balance_debit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["balance_debit_w"]);
                        break;
                    case "balance_credit":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["balance_credit_w"]);
                        break;
                    case "net_balance":
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["net_balance_w"]);
                        break;
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
            e.Graphics.DrawString(((Page_RL) ? "ميزان المراجعة" : "Trial Balance"), fh, Brushes.Black, rect, format);

            format = new StringFormat() { Alignment = (Page_RL) ? StringAlignment.Far : StringAlignment.Near };

            // Draw Head Rect
            e.Graphics.DrawRectangle(p, new Rectangle(Page_LMargin, RepHeader_H, Table_W, PageHeader_H));

            rect = new RectangleF((Page_RL) ? Table_W - 200 : Page_LMargin + 5, 170, 200, 30);
            e.Graphics.DrawString(((Page_RL) ? "من : " : "From : ") + dtp_form.Value.ToString("dd/MM/yyyy"), fb, Brushes.Black, rect, format);

            rect = new RectangleF((Page_RL) ? Table_W - 200 : Page_LMargin + 5, 190, 200, 30);
            e.Graphics.DrawString(((Page_RL) ? "إلى : " : "To : ") + dtp_to.Value.ToString("dd/MM/yyyy"), fb, Brushes.Black, rect, format);
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
                if (top > Page_H - PageFooter_H - Row_H)
                {
                    e.HasMorePages = true;
                    top = RepHeader_H + PageHeader_H + ColumnsHeader_H;
                    page_no++;
                    return;
                }
                rowh = Row_H;

                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    if (dgv.Columns[i].Visible == false)
                    {
                        if (Page_RL) { i--; } else { i++; }
                        continue;
                    }

                    while (dgv.Rows[row_no].Visible == false)
                    {
                        row_no++;
                    }


                    string s = (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value == null) ? "" : dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString();


                    if (dgv.Columns[i].Name == "Debit")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["DebitWidth"]);
                        if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0.00")
                        {
                            s = "";
                        }
                    }
                    else if (dgv.Columns[i].Name == "Credit")
                    {
                        Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["CreditWidth"]);
                        if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0.00")
                        {
                            s = "";
                        }
                    }


                    switch (dgv.Columns[i].Name)
                    {
                        case "chart_id":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_id_w"]);
                            break;
                        case "chart_name":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["chart_name_w"]);
                            break;
                        case "open_debit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["open_debit_w"]);
                            break;
                        case "open_credit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["open_credit_w"]);
                            break;
                        case "debit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["debit_w"]);
                            break;
                        case "credit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["credit_w"]);
                            break;
                        case "balance_debit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["balance_debit_w"]);
                            break;
                        case "balance_credit":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["balance_credit_w"]);
                            break;
                        case "net_balance":
                            Cell_W = Convert.ToInt32(dt_PrintSettings.Rows[0]["net_balance_w"]);
                            break;
                    }

                    if (dgv.Rows[row_no].Cells[dgv.Columns[i].Index].Value.ToString() == "0")
                    {
                        s = "";
                    }
                    e.Graphics.DrawRectangle(p, new Rectangle(Cell_Left, top, Cell_W, rowh));
                    e.Graphics.DrawString(s, fb, Brushes.Black, new Rectangle(Cell_Left + 8, top + 5, Cell_W, rowh));

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
            //dt_Footer.Rows.Add("رصيد افتتاحي", "Opening Balance", txt_TotalOpen.Text);
            dt_Footer.Rows.Add("مدين", "Debit", txt_TotalDebit.Text);
            dt_Footer.Rows.Add("دائن", "Credit", txt_TotalCredit.Text);
            //dt_Footer.Rows.Add("الرصيد", "Balance", txt_TotalBalance.Text);

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

        #region ExportToExcel
        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0205003"))
            {
                MessageBox.Show("ليس لديك تصريح لتصدير ميزان المراجعة للاكسيل", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgv.Rows.Count == 0) { return; }
            //try
            //{

            button_Display_Click(null, null);

            DataGridView dgv_temp = new DataGridView();


           foreach (DataGridViewColumn col in dgv.Columns)
           {
                if (col.Visible) dgv_temp.Columns.Add(col.Clone() as DataGridViewColumn);
           }
           foreach (DataGridViewRow row in dgv.Rows)
           {
                if (row.Visible)
                {
                    DataGridViewRow r = new DataGridViewRow();

                    foreach (DataGridViewCell cel  in row.Cells)
                    {
                        if (cel.OwningColumn.Visible)
                        {
                            r.Cells.Add(cel.Clone() as DataGridViewCell);
                            r.Cells[r.Cells.Count - 1].Value = cel.Value;
                        }
                    }
                    dgv_temp.Rows.Add(r);
                }
           }

            int VisibleColCount = dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible);

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                excel.DefaultSheetDirection = (int)dgv.RightToLeft;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;
                int ColIndex = 0;
                if (dgv.Columns[0].Visible == true) { ColIndex = 0; } else { ColIndex = 1; }

                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range["A1", "Z10000"];
                myRange.RowHeight = 20;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Name = "Tahoma";
                myRange.Font.Size = 8;

                // Report Title
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, VisibleColCount];

                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range["A1", EndCell];
                myRange.MergeCells = true;
                myRange.Value2 = "ميزان المراجعة";
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                //myRange.Interior.Color = Color.White;
                myRange.Font.Name = "Tahoma";
                myRange.Font.Color = dgv_txt_AutoComplete.ForeColor;
                myRange.Font.Size = 10;

                StartRow++;
                
                // Branch & CC
                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, VisibleColCount];


                string scenter = "";
                if (com_Branches.SelectedValue != null)
                {
                    scenter = "الفرع" + " : " + com_Branches.Text + "          ";
                }
                if (com_CC1.SelectedValue != null)
                {
                    scenter += "مركز 1" + " : " + com_CC1.Text + "          ";
                }
                if (com_CC2.SelectedValue != null)
                {
                    scenter += "مركز 2" + " : " + com_CC2.Text;
                }

                if (scenter != "")
                {
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                    myRange.MergeCells = true;
                    myRange.Value2 = scenter;
                    myRange.RowHeight = 30;
                    myRange.HorizontalAlignment = 1;

                    StartRow++;
                }

                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, VisibleColCount ];

                string sdate = "";
                if (dtp_form.Checked == true)
                {
                    sdate = "من" + " : " + dtp_form.Text + "          ";
                }

                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                myRange.MergeCells = true;
                myRange.Value2 = sdate + "إلى" + " : " + ((dtp_to.Checked) ? dtp_to.Text : DateTime.Now.ToString("yyyy/MM/dd"));
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 1;

                StartRow++;

                //Write Headers     
                int EcxColIndex = 1;
                for (j = 0; j <= dgv.Columns.Count - 1; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, EcxColIndex];

                        myRange.Value2 = dgv.Columns[j + ColIndex].HeaderText;
                        myRange.RowHeight = 30;
                        myRange.ColumnWidth = dgv.Columns[j + ColIndex].Width / 6;
                        myRange.Font.Size = 10;
                        myRange.Font.FontStyle = FontStyle.Bold;
                        myRange.Borders.Color = Color.Gray;
                        myRange.Interior.Color = Color.Silver;

                        EcxColIndex++;
                    }

                }

                StartRow++;

            //Write datagridview content
            for (i = 0; i < dgv_temp.Rows.Count - 1; i++)
            {
                EcxColIndex = 1;
                for (j = 0; j < dgv_temp.Columns.Count; j++)
                {              
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, EcxColIndex];
                    myRange.Borders.Color = Color.Gray;

                    if ((i % 2) > 0)
                    {
                        myRange.Interior.Color = Color.OldLace;
                    }
                    myRange.Value2 = dgv_temp[j, i].Value == null ? "" : dgv_temp[j, i].Value.ToString();

                    EcxColIndex++;                                       
                }                       
            }
                #region Footer

                #region Head
                StartRow = StartRow + i + 1;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "افتتاحي مدين";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 2];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 2];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "افتتاحي دائن";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 3];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 3];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "مدين";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 4];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 4];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "دائن";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 5];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 5];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "رصيد نهائي مدين";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 6];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 6];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = "رصيد نهائي دائن";
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            myRange.Borders.Color = Color.Gray;
            myRange.Interior.Color = Color.Silver;
            #endregion

            #region Details
            StartRow++;

                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 1];
                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                myRange.Value2 = txt_TotalOpenDebit.Text;
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Size = 10;
                myRange.Font.FontStyle = FontStyle.Bold;
                //myRange.Borders.Color = Color.Gray;
                //myRange.Interior.Color = Color.Silver;

                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 2];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 2];
                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                myRange.Value2 = txt_TotalOpenCredit.Text;
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Size = 10;
                myRange.Font.FontStyle = FontStyle.Bold;
                //myRange.Borders.Color = Color.Gray;
                //myRange.Interior.Color = Color.Silver;

                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 3];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 3];
                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                myRange.Value2 = txt_TotalDebit.Text;
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Size = 10;
                myRange.Font.FontStyle = FontStyle.Bold;
                //myRange.Borders.Color = Color.Gray;
                //myRange.Interior.Color = Color.Silver;

                StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 4];
                EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 4];
                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
                myRange.Value2 = txt_TotalCredit.Text;
                myRange.RowHeight = 30;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Size = 10;
                myRange.Font.FontStyle = FontStyle.Bold;
            //myRange.Borders.Color = Color.Gray;
            //myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 5];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 5];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = txt_TotalBalanceDebit.Text;
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            //myRange.Borders.Color = Color.Gray;
            //myRange.Interior.Color = Color.Silver;

            StartCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 6];
            EndCell = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, 6];
            myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[StartCell, EndCell];
            myRange.Value2 = txt_TotalBalanceCredit.Text;
            myRange.RowHeight = 30;
            myRange.HorizontalAlignment = 3;
            myRange.VerticalAlignment = 2;
            myRange.Font.Size = 10;
            myRange.Font.FontStyle = FontStyle.Bold;
            //myRange.Borders.Color = Color.Gray;
            //myRange.Interior.Color = Color.Silver;
            #endregion

            #endregion

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion
    }
}
