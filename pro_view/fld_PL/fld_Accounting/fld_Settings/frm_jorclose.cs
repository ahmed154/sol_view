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
    public partial class frm_jorclose : Form
    {
        #region Declarations
        pro_view.fld_BL.cls_bl.stc_Accounting.stc_Settings.stc_close bl = new fld_BL.cls_bl.stc_Accounting.stc_Settings.stc_close();
        pro_view.fld_PL.fld_Login.frm_main frm_main;
        DataSet ds = new DataSet();
        #endregion

        public frm_jorclose(pro_view.fld_PL.fld_Login.frm_main frm_Main)
        {
            frm_main = frm_Main;

            InitializeComponent();


            bl.company_id = frm_main.com_companies.SelectedValue.ToString();
            ds = bl.Select();

            com_oldfyear.ValueMember = "id";
            com_oldfyear.DisplayMember = "aname";
            com_oldfyear.DataSource = ds.Tables["tbl_oldfyear"];
            if(ds.Tables["tbl_oldfyear"].Rows.Count > 1)
            {
                com_oldfyear.SelectedValue = ds.Tables["tbl_oldfyear"].Rows[1]["id"];
            }

            com_newfyear.ValueMember = "id";
            com_newfyear.DisplayMember = "aname";
            com_newfyear.DataSource = ds.Tables["tbl_newfyear"];
        }

        #region Pro
        DataTable dt_branches()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");

            foreach (DataGridViewRow r in dgv_branches.Rows)
            {
                if(Convert.ToBoolean(r.Cells["chk"].Value) == true)
                {
                    dt.Rows.Add(r.Cells["branch_id"].Value.ToString());
                }
            }

            return dt;
        }
        void Bind()
        {
            bl.company_id = frm_main.com_companies.SelectedValue.ToString();
            bl.branches = dt_branches();
            bl.oldfyear = com_oldfyear.SelectedValue.ToString();
            bl.newfyear = com_newfyear.SelectedValue.ToString();
            bl.cc = chk_cc.Checked;
            bl.user_id = frm_main.com_users.SelectedValue.ToString();
            bl.date = DateTime.Now;
            bl.notes = txt_notes.Text.Trim();
        }
        #endregion

        private void frm_jorclose_Shown(object sender, EventArgs e)
        {
            btn_SelectAll_Click(null,null);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            #region Validation
            if (com_oldfyear.SelectedValue.ToString() == com_newfyear.SelectedValue.ToString())
            {
                MessageBox.Show("يجب تحديد عام مالي جديد مختلف عن العام المالي االمنتهي", "إقفال الحسابات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (bl.Select_Chart().Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد حساب مسجل في دليل الحسابات خاص للأرباح المدورة", "إقفال الحسابات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (bl.Select_Chart().Tables[1].Rows.Count == 0)
            {
                MessageBox.Show("لا يوجد حساب مسجل في دليل الحسابات خاص للخسائر المدورة", "إقفال الحسابات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion

            Bind();

            DataTable dt = bl.Close().Tables[0];

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

            MessageBox.Show("تم إقفال الحسابات بنجاح", "إقفال الحسابات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_branches.Rows)
            {
                r.Cells["chk"].Value = true;
                r.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
            }
        }
        private void btn_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_branches.Rows)
            {
                r.Cells["chk"].Value = false;
                r.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void dgv_branches_SelectionChanged(object sender, EventArgs e)
        {
            dgv_branches.ClearSelection();
        }
        private void dgv_branches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToBoolean(dgv_branches.Rows[e.RowIndex].Cells["chk"].Value) == true)
                {
                    dgv_branches.Rows[e.RowIndex].Cells["chk"].Value = false;
                    dgv_branches.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_branches.Rows[e.RowIndex].Cells["chk"].Value = true;
                    dgv_branches.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
                }

            }
        }
    }
}
