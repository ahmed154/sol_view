using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_School.fld_Stu_Data
{
    public partial class frm_Stu_Search : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        public pro_view.fld_PL.fld_School.fld_Stu_Data.frm_Stu_Main_Data frm_stu;
        pro_view.fld_BL.fld_School.fld_Stu_Data.cls_Stu_Data.stc_Parents module = new fld_BL.fld_School.fld_Stu_Data.cls_Stu_Data.stc_Parents();
        DataSet ds = new DataSet();      
        public TextBox T;
        #endregion

        public frm_Stu_Search(pro_view.fld_PL.fld_Login.frm_main frm_Main, TextBox t)
        {
            InitializeComponent();

            frm_main = frm_Main;          
            txt_dgv_search.Text = t.Text;

            #region dgv_parents_search
            dgv_stu_search.AutoGenerateColumns = false;

            var id = new DataGridViewTextBoxColumn();
            id.Name = "id";
            id.HeaderText = "المسلسل";
            id.DataPropertyName = "id";
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            id.Width = 100;
            dgv_stu_search.Columns.Add(id);

            var f_parent_id = new DataGridViewTextBoxColumn();
            f_parent_id.Name = "f_parent_id";
            f_parent_id.HeaderText = "رقم هوية الاب";
            f_parent_id.DataPropertyName = "f_parent_id";
            f_parent_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            f_parent_id.Width = 100;
            dgv_stu_search.Columns.Add(f_parent_id);

            var f_aname = new DataGridViewTextBoxColumn();
            f_aname.Name = "f_aname";
            f_aname.HeaderText = "اسم الاب";
            f_aname.DataPropertyName = "f_aname";
            f_aname.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            f_aname.Width = 100;
            dgv_stu_search.Columns.Add(f_aname);

            var f_mobile1 = new DataGridViewTextBoxColumn();
            f_mobile1.Name = "f_mobile1";
            f_mobile1.HeaderText = "جوال الاب";
            f_mobile1.DataPropertyName = "f_mobile1";
            f_mobile1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            f_mobile1.Width = 100;
            dgv_stu_search.Columns.Add(f_mobile1);

            var m_parent_id = new DataGridViewTextBoxColumn();
            m_parent_id.Name = "m_parent_id";
            m_parent_id.HeaderText = "رقم هويةالام";
            m_parent_id.DataPropertyName = "m_parent_id";
            m_parent_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            m_parent_id.Width = 100;
            dgv_stu_search.Columns.Add(m_parent_id);

            var m_aname = new DataGridViewTextBoxColumn();
            m_aname.Name = "m_aname";
            m_aname.HeaderText = "اسم الام";
            m_aname.DataPropertyName = "m_aname";
            m_aname.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            m_aname.Width = 100;
            dgv_stu_search.Columns.Add(m_aname);

            var m_mobile1 = new DataGridViewTextBoxColumn();
            m_mobile1.Name = "m_mobile1";
            m_mobile1.HeaderText = "جوال الام";
            m_mobile1.DataPropertyName = "m_mobile1";
            m_mobile1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            m_mobile1.Width = 100;
            dgv_stu_search.Columns.Add(m_mobile1);

            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "Select_All";

            ds = module.Select();
            ds.Tables[0].DefaultView.RowFilter = "id like'%" + t.Text + "%' or f_parent_id like '%" + t.Text + "%' or f_aname like '%" + t.Text + "%' or f_mobile1 like '%" + t.Text + "%'";
            dgv_stu_search.Rows.Clear();

            foreach (DataRowView r in ds.Tables[0].DefaultView)
            {
                dgv_stu_search.Rows.Add(r["id"], r["f_parent_id"], r["f_aname"],r["f_mobile1"], r["m_parent_id"], r["m_aname"], r["m_mobile1"]);
            }

            dgv_stu_search.ClearSelection();
            

        }
        #endregion


        private void txt_dgv_search_TextChanged(object sender, EventArgs e)
        {
            if(T != null)
            {
                T.Text = txt_dgv_search.Text;
            }
            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].DefaultView.RowFilter = "id like'%" + txt_dgv_search.Text + "%' or f_parent_id like '%" + txt_dgv_search.Text + "%' or f_aname like '%" + txt_dgv_search.Text + "%' or f_mobile1 like '%" + txt_dgv_search.Text + "%'";
                dgv_stu_search.Rows.Clear();
            foreach (DataRowView r in ds.Tables[0].DefaultView)
            {
                    dgv_stu_search.Rows.Add(r["id"], r["f_parent_id"], r["f_aname"], r["f_mobile1"], r["m_parent_id"], r["m_aname"], r["m_mobile1"]);
                }

            dgv_stu_search.ClearSelection();
            }
        }

        private void dgv_stu_search_DoubleClick(object sender, EventArgs e)
        {       
            module.id = dgv_stu_search.CurrentRow.Cells[0].Value.ToString();

            module.selecttype = "Select";
            frm_stu.ds = module.Select();

            frm_stu.Form_Mode("Select");

            //foreach (DataRow r in ds.Tables[0].Rows)
            //{


            //    //father
            //    frm_stu.txt_F_ID.Text = r["f_parent_id"].ToString();
            //    frm_stu.txt_Fenddate_ID.Text = Convert.ToDateTime(r["f_enddate_id"]).ToString("dd/MM/yyyy");
            //    frm_stu.txt_F_Aname.Text = r["f_aname"].ToString();
            //    frm_stu.txt_F_Ename.Text = r["f_ename"].ToString();
            //    frm_stu.txt_FF_Aname.Text = r["ff_aname"].ToString();
            //    frm_stu.txt_FF_Ename.Text = r["ff_ename"].ToString();
            //    frm_stu.com_F_Country.SelectedValue = r["fcountry_id"].ToString();
            //    frm_stu.com_F_Religion.SelectedValue = r["freligion_id"].ToString();
            //    frm_stu.txt_F_Mobile1.Text = r["f_mobile1"].ToString();
            //    frm_stu.txt_F_Hphone.Text = r["fh_phone"].ToString();
            //    frm_stu.txt_F_Wphone.Text = r["fw_phone"].ToString();
            //    frm_stu.txt_F_Haddress.Text = r["fh_adress"].ToString();
            //    frm_stu.txt_F_Waddress.Text = r["fw_adress"].ToString();
            //    frm_stu.txt_F_Acc.Text = r["facc_code"].ToString();
            //    frm_stu.txt_F_Mail.Text = r["f_email"].ToString();

            //    //mother
            //    frm_stu.txt_M_ID.Text = r["m_parent_id"].ToString();
            //    frm_stu.txt_Menddate_ID.Text = Convert.ToDateTime(r["m_enddate_id"]).ToString("dd/MM/yyyy");
            //    frm_stu.txt_M_Aname.Text = r["m_aname"].ToString();
            //    frm_stu.txt_M_Ename.Text = r["m_ename"].ToString();
            //    frm_stu.txt_MF_Aname.Text = r["mf_aname"].ToString();
            //    frm_stu.txt_MF_Ename.Text = r["mf_ename"].ToString();
            //    frm_stu.com_M_Country.SelectedValue = r["mcountry_id"].ToString();
            //    frm_stu.com_M_Religion.SelectedValue = r["mreligion_id"].ToString();
            //    frm_stu.txt_M_Mobile1.Text = r["m_mobile1"].ToString();
            //    frm_stu.txt_M_Hphone.Text = r["mh_phone"].ToString();
            //    frm_stu.txt_M_Wphone.Text = r["mw_phone"].ToString();
            //    frm_stu.txt_M_Haddress.Text = r["mh_adress"].ToString();
            //    frm_stu.txt_M_Waddress.Text = r["mw_adress"].ToString();
            //    frm_stu.txt_M_Acc.Text = r["macc_code"].ToString();
            //    frm_stu.txt_M_Mail.Text = r["m_email"].ToString();

            //    //other
            //    frm_stu.txt_ID.Text = r["id"].ToString();
            //    frm_stu.lbl_creationtime.Text = r["creationtime"].ToString();
            //    frm_stu.lbl_editingtime.Text = r["editingtime"].ToString();
            //    frm_stu.lbl_createuser_id.Text = r["createuser_id"].ToString();
            //    frm_stu.lbl_edituser_id.Text = r["edituser_id"].ToString();
            //    frm_stu.chk_stop.Checked = Convert.ToBoolean(r["stop"]);
            //    frm_stu.txt_Notes.Text = r["notes"].ToString();
            //   

            //}
            Close();
        }

        private void frm_Stu_Search_Shown(object sender, EventArgs e)
        {
            txt_dgv_search.Focus();
        }
    }
}
