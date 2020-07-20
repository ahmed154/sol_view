using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace pro_view.fld_DAL
{
    class cls_dal
    {
        NpgsqlConnection con;

        public cls_dal()
        {
            con = new NpgsqlConnection(@"Server= " + Properties.Settings.Default.Server +
                                       ";Port=" + Properties.Settings.Default.Port +
                                       ";user id= " + Properties.Settings.Default.PostgresUser +
                                       ";Password= " + Properties.Settings.Default.PostgresPassword +
                                       ";Database= " + Properties.Settings.Default.Database);
        }
        public cls_dal(string database)
        {
            con = new NpgsqlConnection(@"Server= " + Properties.Settings.Default.Server +
                                       ";Port=" + Properties.Settings.Default.Port +
                                       ";user id= " + Properties.Settings.Default.PostgresUser +
                                       ";Password= " + Properties.Settings.Default.PostgresPassword +
                                       ";Database= " + database);
        }

        public void open()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();

                if (con.State != ConnectionState.Open)
                {
                    MessageBox.Show("Connection currently {0} when it should be open.", "Data Access Open", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataSet ExecuteAndRetriveDataSet(string Function, NpgsqlParameter[] param)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Function;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }

            foreach (IDataParameter p in cmd.Parameters)
            {
                if (p.Value == null) p.Value = DBNull.Value;
            }

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet ExecuteAndRetriveDataSet(string txt)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataSet ds = new DataSet();
            using (con)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = txt;
                cmd.Connection = con;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds;
        }

        public DataTable UpdateDatabase()
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataTable dt = new DataTable();
            int DatabaseUpdate = 0;

            using (con)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT MAX(id) FROM grl.tbl_update";
                cmd.Connection = con;

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);


                DatabaseUpdate = Convert.ToInt32(dt.Rows[0][0]);


                while (Convert.ToInt32(Properties.Resources.CurrentUpdate) > DatabaseUpdate)
                {
                    switch (DatabaseUpdate)
                    {
                        case 1:
                            cmd.CommandText = Properties.Resources._2;
                            break;
                        case 2:
                            cmd.CommandText = Properties.Resources._3;
                            break;
                        case 3:
                            cmd.CommandText = Properties.Resources._4;
                            break;
                        case 4:
                            cmd.CommandText = Properties.Resources._5;
                            break;
                        case 5:
                            cmd.CommandText = Properties.Resources._6;
                            break;
                        case 6:
                            cmd.CommandText = Properties.Resources._7;
                            break;
                        case 7:
                            cmd.CommandText = Properties.Resources._8;
                            break;
                        case 8:
                            cmd.CommandText = Properties.Resources._9;
                            break;
                        case 9:
                            cmd.CommandText = Properties.Resources._10;
                            break;
                        case 10:
                            cmd.CommandText = Properties.Resources._11;
                            break;
                        case 11:
                            cmd.CommandText = Properties.Resources._12;
                            break;
                        case 12:
                            cmd.CommandText = Properties.Resources._13;
                            break;
                        case 13:
                            cmd.CommandText = Properties.Resources._14;
                            break;
                        case 14:
                            cmd.CommandText = Properties.Resources._15;
                            break;
                        case 15:
                            cmd.CommandText = Properties.Resources._16;
                            break;
                        case 16:
                            cmd.CommandText = Properties.Resources._17;
                            break;
                        case 17:
                            cmd.CommandText = Properties.Resources._18;
                            break;
                        case 18:
                            cmd.CommandText = Properties.Resources._19;
                            break;
                    }

                    cmd.CommandText += "-------------------------------------------------------------------------------------------------------Update Database\r\n"
                                     + "INSERT INTO grl.tbl_update(\r\n"
                                     + "id, ddate)\r\n"
                                     + "VALUES((select max(id) + 1 from grl.tbl_update), (select(current_timestamp)));\r\n"
                                     + "SELECT MAX(id) FROM grl.tbl_update;";

                    dt.Rows.Clear();
                    dt.Columns.Clear();

                    da.Fill(dt);
                    DatabaseUpdate = Convert.ToInt32(dt.Rows[0][0]);

                    if(Convert.ToInt32(Properties.Resources.CurrentUpdate) == DatabaseUpdate)
                        MessageBox.Show("تم تحديث قاعدة البيانات بنجاح","تحديث قاعدة البيانات",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            return dt;
        }
    }
}
