using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_login : Form
    {
        #region Declarations
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_users model = new fld_BL.cls_bl.stc_General_Settings.stc_users();
        pro_view.fld_BL.cls_bl.stc_Login login = new fld_BL.cls_bl.stc_Login();
        pro_view.fld_PL.fld_Login.frm_main frm_main = new pro_view.fld_PL.fld_Login.frm_main();
        private static string Key = "dofkrfayurdedofkrfaosrdestfkrfao";
        private static string IV = "zxcvbhkdfrasdaeh";
        string user_id;
        string id;
        int CurrentDate;
        DataSet ds_CompaniesAndFyears = new DataSet();
        DataSet ds_BranchesAndStores = new DataSet();
        DataTable dt = new DataTable();
        
        #endregion

        public frm_login()
        {
            InitializeComponent();

            txt_Password.UseSystemPasswordChar = true;
            txt_Name.Text = Properties.Settings.Default.LoginUser;
        }

        #region Form
        private void frm_Login_Shown(object sender, EventArgs e)
        {
            if (txt_Name.Text != "") txt_Password.Focus();
        }
        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
        #endregion

        #region Pro
        int IntDate(DateTime dd)
        {
            string s = "";

            string m = dd.Month.ToString();
            if (m.Length == 1) m = "0" + m;

            string d = dd.Day.ToString();
            if (d.Length == 1) d = "0" + d;

            s = dd.Year.ToString() + m + d;

            return Convert.ToInt32(s);
        }
        public static string Decrypt(string encrypted)
        {
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);

        }
        string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            string MACAddress = String.Empty;

            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                { // only return MAC Address from first card
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            return MACAddress;
        }
        string UniqueMachineId()
        {
            StringBuilder builder = new StringBuilder();

            String query = "SELECT * FROM Win32_BIOS";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementClass mc = new ManagementClass("Win32_Processor");
            //  This should only find one
            foreach (ManagementObject item in searcher.Get())
            {
                Object obj = item["Manufacturer"];
                builder.Append(Convert.ToString(obj));
                builder.Append(':');
                obj = item["SerialNumber"];
                builder.Append(Convert.ToString(obj));
            }

            return builder.ToString();
        }
        string cpuID()
        {
            string cpuID = "";
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuID == "")
                {
                    //Remark gets only the first CPU ID
                    cpuID = mo.Properties["processorID"].Value.ToString();

                }
            }
            return cpuID;
        }
        string CheckAth()
        {
            string value = "";
            int ExpireDate = 0;
            //id = UniqueMachineId() + GetMACAddress() + cpuID();
            id = UniqueMachineId() + cpuID();
            CurrentDate = IntDate(DateTime.Today);
            try
            {
                value = Decrypt(Properties.Settings.Default.PreventID);
                ExpireDate = (Properties.Settings.Default.PreventDays != "") ? Convert.ToInt32(Decrypt(Properties.Settings.Default.PreventDays)) : ExpireDate;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "error";
            }

            if (id != value)
            {
                return "id";
            }
            else if (CurrentDate > ExpireDate)
            {
                return "date";
            }
            else
            {
                return "OK";
            }

        }

        #endregion

        #region Details

        #region Dispaly
        private void btn_Lock_MouseEnter(object sender, EventArgs e)
        {
            btn_Lock.FlatStyle = FlatStyle.Popup;
        }

        private void btn_Lock_MouseLeave(object sender, EventArgs e)
        {
            btn_Lock.FlatStyle = FlatStyle.Flat;
        }

        private void btn_Demo_MouseEnter(object sender, EventArgs e)
        {
            btn_Demo.FlatStyle = FlatStyle.Popup;
        }

        private void btn_Demo_MouseLeave(object sender, EventArgs e)
        {
            btn_Demo.FlatStyle = FlatStyle.Flat;
        }

        private void btn_ServerConSettings_MouseEnter(object sender, EventArgs e)
        {
            btn_ServerConSettings.FlatStyle = FlatStyle.Popup;
        }

        private void btn_ServerConSettings_MouseLeave(object sender, EventArgs e)
        {
            btn_ServerConSettings.FlatStyle = FlatStyle.Flat;
        }
        #endregion

        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) SendKeys.Send("{TAB}");
        }
        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btn_Login_Click(null, null);
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {        
            model.aname = txt_Name.Text.Trim();
            model.ename = txt_Name.Text.Trim();
            model.password = txt_Password.Text.Trim();


            dt = model.Select().Tables[0];

            foreach (DataRow r in dt.Rows)
            {
                if ((r["aname"].ToString() == model.aname || r["ename"].ToString() == model.ename) && r["password"].ToString() == model.password)
                {
                    user_id = r["id"].ToString();

                    ds_CompaniesAndFyears = login.SelectAllowedCompaniesAndFyears(user_id);

                    txt_Name.Visible = false;
                    txt_Password.Visible = false;
                    btn_Demo.Visible = false;
                    btn_ServerConSettings.Visible = false;
                    btn_Lock.Image = Properties.Resources.LockOpen_128;
                    btn_Login.Visible = false;


                    //lbl_UserNameA.Text = "الشركة";
                    //lbl_UserNameE.Text = "Company";

                    lbl_UserNameA.Visible = false;
                    lbl_UserNameE.Visible = false;
                    lbl_PassA.Text = "السنة المالية";
                    lbl_PassE.Text = "Financial year";
                    

                    //com_company.Visible = true;
                    com_company.Location = txt_Name.Location;
                    com_fyear.Visible = true;
                    com_fyear.Location = txt_Password.Location;
                    btn_Back.Visible = true;
                    btn_login2.Visible = true;
                    btn_login2.Focus();

                    com_company.DataSource = ds_CompaniesAndFyears.Tables["tbl_companies"];
                    com_company.ValueMember = "id";
                    com_company.DisplayMember = "aname";

                    com_fyear.DataSource = ds_CompaniesAndFyears.Tables["tbl_fyears"];
                    com_fyear.ValueMember = "id";
                    com_fyear.DisplayMember = "aname";

                    if (ds_CompaniesAndFyears.Tables["tbl_fyears"].Rows.Count == 1)
                    {
                        btn_login2_Click(null, null);
                    }

                    return;
                }
            }
            MessageBox.Show("أسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في بيانات الدخول", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void btn_login2_Click(object sender, EventArgs e)
        {
            Hide();
            string c = CheckAth();
            if (c == "OK")
            {
                ds_BranchesAndStores = login.SelectAllowedBranchesAndStores(user_id, com_company.SelectedValue.ToString());

                frm_main.com_companies.DataSource = ds_CompaniesAndFyears.Tables["tbl_companies"];
                frm_main.com_companies.ValueMember = "id";
                frm_main.com_companies.DisplayMember = "aname";
                frm_main.com_companies.SelectedValue = com_company.SelectedValue;

                frm_main.com_fyear.DataSource = ds_CompaniesAndFyears.Tables["tbl_fyears"];
                frm_main.com_fyear.ValueMember = "id";
                frm_main.com_fyear.DisplayMember = "aname";
                frm_main.com_fyear.SelectedValue = com_fyear.SelectedValue;

                frm_main.com_branches.DataSource = ds_BranchesAndStores.Tables["tbl_branches"];
                frm_main.com_branches.ValueMember = "id";
                frm_main.com_branches.DisplayMember = "aname";
                frm_main.com_branches.SelectedIndex = 0;

                frm_main.com_users.DataSource = dt;
                frm_main.com_users.ValueMember = "id";
                frm_main.com_users.DisplayMember = "aname";
                frm_main.com_users.SelectedValue = user_id;

                frm_main.frm_login = this;

                login.UpdateDatabase();

                frm_main.Show();
                Properties.Settings.Default.LoginUser = txt_Name.Text;
                Properties.Settings.Default.Save();
                return;
            }
            else
            {
                pro_view.fld_PL.fld_Login.frm_preventnu p = new frm_preventnu();
                p.UserID = user_id;
                p.Case = c;
                p.frm_main = frm_main;
                p.ShowDialog();
                return;
            }
        }
        private void btn_Demo_Click(object sender, EventArgs e)
        {
            dt = model.Select().Tables[0];
            ds_CompaniesAndFyears = login.SelectAllowedCompaniesAndFyears("demo");
            ds_BranchesAndStores = login.SelectAllowedBranchesAndStores("demo", "01");

            frm_main.com_companies.DataSource = ds_CompaniesAndFyears.Tables["tbl_companies"];
            frm_main.com_companies.ValueMember = "id";
            frm_main.com_companies.DisplayMember = "aname";
            frm_main.com_companies.SelectedIndex = 0;

            frm_main.com_fyear.DataSource = ds_CompaniesAndFyears.Tables["tbl_fyears"];
            frm_main.com_fyear.ValueMember = "id";
            frm_main.com_fyear.DisplayMember = "aname";
            frm_main.com_fyear.SelectedIndex = 0;

            frm_main.com_branches.DataSource = ds_BranchesAndStores.Tables["tbl_branches"];
            frm_main.com_branches.ValueMember = "id";
            frm_main.com_branches.DisplayMember = "aname";
            frm_main.com_branches.SelectedIndex = 0;

            frm_main.com_users.DataSource = dt;
            frm_main.com_users.ValueMember = "id";
            frm_main.com_users.DisplayMember = "aname";
            frm_main.com_users.SelectedValue = "demo";

            Hide();

            login.UpdateDatabase();

            frm_main.frm_login = this;
            frm_main.Show();
        }
        private void btn_ServerConSettings_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Login.frm_serverinfo s = new frm_serverinfo();
            s.ShowDialog();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            txt_Name.Visible = true;
            txt_Password.Visible = true;
            btn_Demo.Visible = true;
            btn_ServerConSettings.Visible = true;
            btn_Lock.Image = Properties.Resources.LockClose_128;
            btn_Login.Visible = true;


            //lbl_UserNameA.Text = "أسم المستخدم";
            //lbl_UserNameE.Text = "User Name";

            lbl_UserNameA.Visible = true;
            lbl_UserNameE.Visible = true;
            lbl_PassA.Text = "كلمة المرور";
            lbl_PassE.Text = "Password";


            com_company.Visible = false;
            com_fyear.Visible = false;
            btn_login2.Visible = false;
            btn_Back.Visible = false;

            txt_Password.Text = "";
            txt_Password.Focus();
        }
        #endregion
    }
}
