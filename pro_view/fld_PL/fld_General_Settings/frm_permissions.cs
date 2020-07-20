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
    public partial class frm_permissions : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_perm bl = new fld_BL.cls_bl.stc_General_Settings.stc_perm();
        DataSet ds = new DataSet();

        DataView dv_permuser = new DataView();
        #endregion

        public frm_permissions()
        {
            InitializeComponent();
        }

        #region pro
        void FillGroups()
        {
            ds = bl.Select(txt_id.Text);

            dgv_permgroup.Rows.Clear();
            foreach (DataRow r in ds.Tables["tbl_permgroup"].Rows)
            {
                dgv_permgroup.Rows.Add(false, r["aname"].ToString(), r["id"].ToString());
            }
        }
        void FillAll()
        {
            dgv_perm.Rows.Clear();
            foreach (DataRow r in ds.Tables["tbl_perm"].Rows)
            {
                dgv_perm.Rows.Add(false, r["aname"].ToString(), r["id"].ToString());
            }

            dgv_permuser.Rows.Clear();
            foreach (DataRow r in ds.Tables["tbl_AllowedPerm"].Rows)
            {
                dgv_permuser.Rows.Add(false, r["aname"].ToString(), r["id"].ToString());
            }
        }
        void FillPerm()
        {
            dgv_perm.Rows.Clear();
            dgv_permuser.Rows.Clear();

            foreach (DataGridViewRow r in dgv_permgroup.Rows)
            {
                if (Convert.ToBoolean(r.Cells["col_OKpermGroup"].Value) == false) continue;

                foreach (DataRow dr_perm in ds.Tables["tbl_perm"].Rows)
                {
                    string x = dr_perm["permgroup_id"].ToString();
                    string y = r.Cells["col_id"].Value.ToString();

                    if (dr_perm["permgroup_id"].ToString() == r.Cells["col_id"].Value.ToString())
                    {
                        dgv_perm.Rows.Add(false, dr_perm["aname"].ToString(), dr_perm["id"].ToString());
                    }

                }
                foreach (DataRow dr_user in ds.Tables["tbl_AllowedPerm"].Rows)
                {
                    if (dr_user["permgroup_id"].ToString() == r.Cells["col_id"].Value.ToString())
                    {
                        dgv_permuser.Rows.Add(false, dr_user["aname"].ToString(), dr_user["id"].ToString());
                    }
                }
            }
        }
        void ClearPerm()
        {
            dgv_perm.Rows.Clear();
            dgv_permuser.Rows.Clear();
        }
        #endregion

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            FillGroups();
        }
        #endregion

        #region controls
        private void Btn_permGroup_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_permgroup.Rows)
            {
                r.Cells["col_OKpermGroup"].Value = true;
                r.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
            }
            FillAll ();
        }
        private void Btn_permGroup_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_permgroup.Rows)
            {
                r.Cells["col_OKpermGroup"].Value = false;
                r.DefaultCellStyle.BackColor = Color.White;
            }
            ClearPerm();
        }
        private void Btn_perm_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_perm.Rows)
            {
                r.Cells["OK"].Value = true;
                r.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
            }
        }
        private void Btn_perm_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_perm.Rows)
            {
                r.Cells["OK"].Value = false;
                r.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void Btn_permuser_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_permuser.Rows)
            {
                r.Cells["col_OKpermuser"].Value = true;
                r.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
            }
        }
        private void Btn_permuser_CancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv_permuser.Rows)
            {
                r.Cells["col_OKpermuser"].Value = false;
                r.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void Btn_f_Click(object sender, EventArgs e)
        {
            string s = "";

            for (int i = 0; i < dgv_perm.RowCount; i++)
            {
                if (Convert.ToBoolean(dgv_perm.Rows[i].Cells[0].Value) == true)
                {
                    dgv_permuser.Rows.Add(false, dgv_perm.Rows[i].Cells[1].Value.ToString(), dgv_perm.Rows[i].Cells["col_permid"].Value.ToString());
                    s += "('" + txt_id.Text + "', '" + dgv_perm.Rows[i].Cells["col_permid"].Value.ToString() + "'),";
                    dgv_perm.Rows.RemoveAt(i);
                    i--;
                }
            }

            if (s != "")
            {
                s = s.Substring(0, s.Length - 1);
                ds = bl.Insert(frm_main.com_users.SelectedValue.ToString(), s);

                frm_main.ds.Tables.Remove("tbl_permuser");
                frm_main.ds.Merge(ds.Tables["tbl_permuser"]);
            }
        }
        private void Btn_b_Click(object sender, EventArgs e)
        {
            string s = "";

            for (int i = 0; i < dgv_permuser.RowCount; i++)
            {
                if (Convert.ToBoolean(dgv_permuser.Rows[i].Cells[0].Value) == true)
                {
                    dgv_perm.Rows.Add(false, dgv_permuser.Rows[i].Cells[1].Value.ToString(), dgv_permuser.Rows[i].Cells[2].Value.ToString());
                    s += "'" + dgv_permuser.Rows[i].Cells["col_permuser_id"].Value.ToString() + "',";
                    dgv_permuser.Rows.RemoveAt(i);
                    i--;
                }
            }

            if (s != "")
            {
                s = "(" + s.Substring(0, s.Length - 1) + ")";
                ds = bl.Delete(txt_id.Text, s);

                frm_main.ds.Tables.Remove("tbl_permuser");
                frm_main.ds.Merge(ds.Tables["tbl_permuser"]);
            }
        }
        #endregion

        #region dgv
        private void Dgv_permgroup_SelectionChanged(object sender, EventArgs e)
        {
            dgv_permgroup.ClearSelection();
        }
        private void Dgv_permgroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToBoolean(dgv_permgroup.Rows[e.RowIndex].Cells["col_OKpermGroup"].Value) == true)
                {
                    dgv_permgroup.Rows[e.RowIndex].Cells["col_OKpermGroup"].Value = false;
                    dgv_permgroup.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_permgroup.Rows[e.RowIndex].Cells["col_OKpermGroup"].Value = true;
                    dgv_permgroup.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
                }
                FillPerm();
            }
        }
        private void Dgv_perm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToBoolean(dgv_perm.Rows[e.RowIndex].Cells["OK"].Value) == true)
                {
                    dgv_perm.Rows[e.RowIndex].Cells["OK"].Value = false;
                    dgv_perm.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_perm.Rows[e.RowIndex].Cells["OK"].Value = true;
                    dgv_perm.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
                }

            }
        }
        private void Dgv_perm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Btn_f_Click(null, null);
        }
        private void Dgv_perm_SelectionChanged(object sender, EventArgs e)
        {
            dgv_perm.ClearSelection();
        }
        private void Dgv_permuser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToBoolean(dgv_permuser.Rows[e.RowIndex].Cells["col_OKpermuser"].Value) == true)
                {
                    dgv_permuser.Rows[e.RowIndex].Cells["col_OKpermuser"].Value = false;
                    dgv_permuser.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv_permuser.Rows[e.RowIndex].Cells["col_OKpermuser"].Value = true;
                    dgv_permuser.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ACCBC6");
                }

            }
        }
        private void Dgv_permuser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Btn_b_Click(null, null);
        }
        private void Dgv_permuser_SelectionChanged(object sender, EventArgs e)
        {
            dgv_permuser.ClearSelection();
        }
        #endregion
    }
}
