using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Npgsql;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_serverinfo : Form
    {
        NpgsqlConnection con;
        Thread thread;
        string lbl;

        public frm_serverinfo()
        {
            InitializeComponent();

            txt_Password.UseSystemPasswordChar = true;
           
            textBox_Server.Text = Properties.Settings.Default.Server;
            txt_Port.Text = Properties.Settings.Default.Port;
            textBox_ID.Text = Properties.Settings.Default.PostgresUser;
            txt_Password.Text = Properties.Settings.Default.PostgresPassword;


        }

        #region Pro
        void GetAllDatabase()
        {
            fld_DAL.cls_dal dal = new fld_DAL.cls_dal("postgres");
            com_database.Items.Clear();
            foreach (DataRow r in dal.ExecuteAndRetriveDataSet("SELECT * FROM pg_database WHERE datistemplate = false;").Tables[0].Rows)
            {
                com_database.Items.Add(r["datname"].ToString());
            }
            com_database.Items.Remove("postgres");
            com_database.Text = Properties.Settings.Default.Database;
        }
        void SaveSettings()
        {
            Properties.Settings.Default.Server = textBox_Server.Text.Trim();
            Properties.Settings.Default.Port = txt_Port.Text.Trim();
            Properties.Settings.Default.PostgresUser = textBox_ID.Text;
            Properties.Settings.Default.PostgresPassword = txt_Password.Text;
            Properties.Settings.Default.Database = com_database.Text;

            Properties.Settings.Default.Save();
        }
        void RestoreDatabase(string path)
        {
            con = new NpgsqlConnection(@"Server= " + Properties.Settings.Default.Server +
                                       ";Port=" + Properties.Settings.Default.Port +
                                       ";user id= " + Properties.Settings.Default.PostgresUser +
                                       "; Password= " + Properties.Settings.Default.PostgresPassword +
                                       ";Database= " + Properties.Settings.Default.Database);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string s = "USE MASTER RESTORE DATABASE [Farm] FROM DISK='" + path + "'WITH REPLACE;";
                NpgsqlCommand cmd = new NpgsqlCommand(s, con);

                lbl = "جارٍ اضافة قاعدة البيانات ...";
                Start_Waiting();
                cmd.ExecuteNonQuery();
                con.Close();
                Abort_Waiting();

                MessageBox.Show("تم اضافة قاعدة البيانات بنجاح", "اضافة قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                con.Close();
                Abort_Waiting();
                MessageBox.Show(ex.ToString());
            }
        }
        void Start_Waiting()
        {
            thread = new Thread(Waiting);
            thread.IsBackground = true;
            thread.Start();
        }
        void Waiting()
        {
            //PL.G.frm_Waiting w = new PL.G.frm_Waiting();
            //w.lbl.Text = lbl;

            //w.ShowDialog();
        }
        void Abort_Waiting()
        {
            thread.Abort();
        }
        #endregion

        #region Form
        private void frm_serverinfo_Shown(object sender, EventArgs e)
        {
            try
            {
                GetAllDatabase();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        private void lnk_AddNewDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_newdatabase f = new frm_newdatabase();
            f.com_CopyDatabase.Items.Clear();
            foreach (string i in com_database.Items)
            {
                f.com_CopyDatabase.Items.Add(i);
            }
            com_database.Items.Remove("postgres");

            f.ShowDialog();

            GetAllDatabase();
            com_database.SelectedIndex = com_database.Items.Count - 1;
        }
        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }


    }
}
