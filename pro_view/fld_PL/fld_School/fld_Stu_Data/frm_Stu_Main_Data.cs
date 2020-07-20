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

namespace pro_view.fld_PL.fld_School.fld_Stu_Data
{
    public partial class frm_Stu_Main_Data : Form

    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.fld_School.fld_Stu_Data.cls_Stu_Data.stc_Parents module = new fld_BL.fld_School.fld_Stu_Data.cls_Stu_Data.stc_Parents();
        public DataSet ds = new DataSet();
       
        #endregion

        public frm_Stu_Main_Data()
        {
            InitializeComponent();
        }

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            Refresh_Data();         
        }
        private void frm_G_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (txt_ID.Text == "") txt_ID.Text = "-1";
        }
        #endregion

        #region pro
        void Bind()
        {
            //father
            module.f_parent_id = txt_F_ID.Text.Trim();
            if(txt_Fenddate_ID.Text.Trim() != "") module.f_enddate_id = DateTime.ParseExact(txt_Fenddate_ID.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            module.f_aname = txt_F_Aname.Text.Trim();
            module.f_ename = txt_F_Ename.Text.Trim();
            module.ff_aname = txt_FF_Aname.Text.Trim();
            module.ff_ename = txt_FF_Ename.Text.Trim();
            module.f_country = (com_F_Country.SelectedValue != null)? com_F_Country.SelectedValue.ToString() : null;
            module.f_religion = (com_F_Religion.SelectedValue != null)? com_F_Religion.SelectedValue.ToString() : null;
            module.f_mobile1 = txt_F_Mobile1.Text.Trim();
            module.f_hphone = txt_F_Hphone.Text.Trim();
            module.f_wphone = txt_F_Wphone.Text.Trim();
            module.f_haddress = txt_F_Haddress.Text.Trim();
            module.f_waddress = txt_F_Waddress.Text.Trim();
            module.f_acc = txt_F_Acc.Text.Trim();
            module.f_mail = txt_F_Mail.Text.Trim();

            //mother
            module.m_parent_id = txt_M_ID.Text.Trim();
            if (txt_Menddate_ID.Text.Trim() != "") module.m_enddate_id = DateTime.ParseExact(txt_Menddate_ID.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            module.m_aname = txt_M_Aname.Text.Trim();
            module.m_ename = txt_M_Ename.Text.Trim();
            module.mf_aname = txt_MF_Aname.Text.Trim();
            module.mf_ename = txt_MF_Ename.Text.Trim();
            module.m_country = (com_M_Country.SelectedValue != null) ? com_M_Country.SelectedValue.ToString() : null;
            module.m_religion = (com_M_Religion.SelectedValue != null) ? com_M_Religion.SelectedValue.ToString() : null;
            module.m_mobile1 = txt_M_Mobile1.Text.Trim();
            module.m_hphone = txt_M_Hphone.Text.Trim();
            module.m_wphone = txt_M_Wphone.Text.Trim();
            module.m_haddress = txt_M_Haddress.Text.Trim();
            module.m_waddress = txt_M_Waddress.Text.Trim();
            module.m_acc = txt_M_Acc.Text.Trim();
            module.m_mail = txt_M_Mail.Text.Trim();


            //other
            module.id = txt_ID.Text.Trim();
            module.user_id = frm_main.com_users.SelectedValue.ToString();
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.branch_id = frm_main.com_branches.SelectedValue.ToString();
            module.stop = chk_stop.Checked;
        }
        void ClearForm()
        {
            foreach (Control c in gbx_f_Details.Controls)
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
            foreach (Control c in gbx_M_Details.Controls)
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
            txt_ID.Text = "";
        }
        void EnableForm()
        {
            foreach (Control c in gbx_f_Details.Controls)
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
            foreach (Control c in gbx_M_Details.Controls)
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
            txt_ID.ReadOnly = true;
        }
        void DisableForm()
        {
            foreach (Control c in gbx_f_Details.Controls)
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
            foreach (Control c in gbx_M_Details.Controls)
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
            chk_stop.Enabled = false;
        }
        public void Form_Mode(string mode)
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

                    txt_F_ID.Focus();

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

                    txt_F_Aname.Select();
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

                   

                        foreach (DataRow r in ds.Tables["tbl_parents"].Rows)
                        {
                           

                                //father
                                txt_F_ID.Text = r["f_parent_id"].ToString();
                                if (!(r["f_enddate_id"] is DBNull))
                                {
                                    txt_Fenddate_ID.Text = Convert.ToDateTime(r["f_enddate_id"]).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txt_Fenddate_ID.Text = "";
                                }
                                txt_F_Aname.Text = r["f_aname"].ToString();
                                txt_F_Ename.Text = r["f_ename"].ToString();
                                txt_FF_Aname.Text = r["ff_aname"].ToString();
                                txt_FF_Ename.Text = r["ff_ename"].ToString();
                                com_F_Country.SelectedValue = r["fcountry_id"].ToString();
                                com_F_Religion.SelectedValue = r["freligion_id"].ToString();
                                txt_F_Mobile1.Text = r["f_mobile1"].ToString();
                                txt_F_Hphone.Text = r["fh_phone"].ToString();
                                txt_F_Wphone.Text = r["fw_phone"].ToString();
                                txt_F_Haddress.Text = r["fh_adress"].ToString();
                                txt_F_Waddress.Text = r["fw_adress"].ToString();
                                txt_F_Acc.Text = r["facc_code"].ToString();
                                txt_F_Mail.Text = r["f_email"].ToString();

                                //mother
                                txt_M_ID.Text = r["m_parent_id"].ToString();
                                if (!(r["m_enddate_id"] is DBNull))
                                {
                                    txt_Menddate_ID.Text = Convert.ToDateTime(r["m_enddate_id"]).ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    txt_Menddate_ID.Text = "";
                                }
                                txt_M_Aname.Text = r["m_aname"].ToString();
                                txt_M_Ename.Text = r["m_ename"].ToString();
                                txt_MF_Aname.Text = r["mf_aname"].ToString();
                                txt_MF_Ename.Text = r["mf_ename"].ToString();
                                com_M_Country.SelectedValue = r["mcountry_id"].ToString();
                                com_M_Religion.SelectedValue = r["mreligion_id"].ToString();
                                txt_M_Mobile1.Text = r["m_mobile1"].ToString();
                                txt_M_Hphone.Text = r["mh_phone"].ToString();
                                txt_M_Wphone.Text = r["mw_phone"].ToString();
                                txt_M_Haddress.Text = r["mh_adress"].ToString();
                                txt_M_Waddress.Text = r["mw_adress"].ToString();
                                txt_M_Acc.Text = r["macc_code"].ToString();
                                txt_M_Mail.Text = r["m_email"].ToString();

                                //other
                                txt_ID.Text = r["id"].ToString();
                                lbl_creationtime.Text = r["creationtime"].ToString();
                                lbl_editingtime.Text = r["editingtime"].ToString();
                                lbl_createuser_id.Text = r["createuser_id"].ToString();
                                lbl_edituser_id.Text = r["edituser_id"].ToString();
                                chk_stop.Checked = Convert.ToBoolean(r["stop"]);
                                txt_Notes.Text = r["notes"].ToString();
                            
                        }
                     

                   

                    break;
                #endregion

                #region Empty
                case "Empty":
                    Tag = "Empty";
                    btn_New.Visible = true;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = false;

                    DisableForm();
                    ClearForm();

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
            if (txt_ID.Text != "")
            {
                module.selecttype = "Login";
                ds = module.Select();
                Form_Mode("Select");
            }
            else
            {             
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
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region Validation
            if (txt_F_Aname.Text.Trim() == "" && txt_F_Ename.Text.Trim() == "")
            {
                MessageBox.Show("يجب إدخال الأسم ", "حفظ البيان", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_F_Aname.Focus();
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

        private void btn_First_Click(object sender, EventArgs e)
        {
            
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "First";

            ds = module.Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Form_Mode("Select");
            }
            else
            {
                Form_Mode("Empty");
            }
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            module.selecttype = "Last";

            ds = module.Select();

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
            module.company_id = frm_main.com_companies.SelectedValue.ToString();
            
            if (Tag.ToString() == "Select")
            {
                module.id = txt_ID.Text;
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
            if (ds.Tables[0].Rows.Count == 0) return;

            Form_Mode("Select");
           
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            
            module.company_id = frm_main.com_companies.SelectedValue.ToString();


            if (Tag.ToString() == "Select")
            {
                module.id = txt_ID.Text;
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
            if (ds.Tables[0].Rows.Count == 0) return;

            Tag = "Select";
            Form_Mode("Select");
        }

        private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            


            if (e.KeyChar == 13 && txt_Search.Text.Trim() != "")
            {
                pro_view.fld_PL.fld_School.fld_Stu_Data.frm_Stu_Search frm_search = new frm_Stu_Search(frm_main, txt_Search);

                frm_search.T = txt_Search;
                frm_search.frm_stu = this;
                frm_search.ShowDialog();
            }
        }

        private void txt_Search_Leave(object sender, EventArgs e)
        {
            txt_Search.Text = "Search";
            txt_Search.ForeColor = Color.Silver;
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
    }
}
