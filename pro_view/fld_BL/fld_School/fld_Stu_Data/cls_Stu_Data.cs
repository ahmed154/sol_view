using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_view.fld_BL.fld_School.fld_Stu_Data
{
    class cls_Stu_Data
    {
        public struct stc_Parents
        {

            #region properties
            // father properties
            public string id { get; set; }
            public string f_parent_id { get; set; }
            public DateTime? f_enddate_id { get; set; }
            public string f_aname { get; set; }
            public string f_ename { get; set; }
            public string ff_aname { get; set; }
            public string ff_ename { get; set; }
            public string f_religion { get; set; }
            public string f_country { get; set; }
            public string f_haddress { get; set; }
            public string f_waddress { get; set; }
            public string f_mobile1 { get; set; }
            public string f_hphone { get; set; }
            public string f_wphone { get; set; }
            public string f_acc { get; set; }
            public string f_mail { get; set; }

            // mother properties
            public string m_parent_id { get; set; }
            public DateTime? m_enddate_id { get; set; }
            public string m_aname { get; set; }
            public string m_ename { get; set; }
            public string mf_aname { get; set; }
            public string mf_ename { get; set; }
            public string m_religion { get; set; }
            public string m_country { get; set; }
            public string m_haddress { get; set; }
            public string m_waddress { get; set; }
            public string m_mobile1 { get; set; }
            public string m_hphone { get; set; }
            public string m_wphone { get; set; }
            public string m_acc { get; set; }
            public string m_mail { get; set; }

            // other properties
            public string branch_id { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            public string notes { get; set; }
            public string selecttype { get; set; }
            #endregion


            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[36];
                DataSet ds = new DataSet();
                // father parameters
                param[0] = new NpgsqlParameter("@in_f_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[0].Value = f_parent_id;
                param[1] = new NpgsqlParameter("@in_f_enddate_id", NpgsqlTypes.NpgsqlDbType.Timestamp);
                param[1].Value = f_enddate_id;
                param[2] = new NpgsqlParameter("@in_f_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = f_aname;
                param[3] = new NpgsqlParameter("@in_f_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[3].Value = f_ename;
                param[4] = new NpgsqlParameter("@in_ff_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[4].Value = ff_aname;
                param[5] = new NpgsqlParameter("@in_ff_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[5].Value = ff_ename;
                param[6] = new NpgsqlParameter("@in_f_religion", NpgsqlTypes.NpgsqlDbType.Smallint);
                param[6].Value = Convert.ToInt32(f_religion);
                param[7] = new NpgsqlParameter("@in_f_country", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[7].Value = f_country;
                param[8] = new NpgsqlParameter("@in_f_haddress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[8].Value = f_haddress;
                param[9] = new NpgsqlParameter("@in_f_waddress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[9].Value = f_waddress;
                param[10] = new NpgsqlParameter("@in_f_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[10].Value = f_mobile1;
                param[11] = new NpgsqlParameter("@in_f_hphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[11].Value = m_hphone;
                param[12] = new NpgsqlParameter("@in_f_wphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[12].Value = f_wphone;
                param[13] = new NpgsqlParameter("@in_f_acc", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[13].Value = f_acc;
                param[14] = new NpgsqlParameter("@in_f_mail", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[14].Value = f_mail;

                // mother parameters
                param[15] = new NpgsqlParameter("@in_m_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[15].Value = m_parent_id;
                param[16] = new NpgsqlParameter("@in_m_enddate_id", NpgsqlTypes.NpgsqlDbType.Timestamp);
                param[16].Value = m_enddate_id;
                param[17] = new NpgsqlParameter("@in_m_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[17].Value = m_aname;
                param[18] = new NpgsqlParameter("@in_m_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[18].Value = m_ename;
                param[19] = new NpgsqlParameter("@in_mf_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[19].Value = mf_aname;
                param[20] = new NpgsqlParameter("@in_mf_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[20].Value = mf_ename;
                param[21] = new NpgsqlParameter("@in_m_religion", NpgsqlTypes.NpgsqlDbType.Smallint);
                param[21].Value = Convert.ToInt32(f_religion);
                param[22] = new NpgsqlParameter("@in_m_country", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[22].Value = m_country;
                param[23] = new NpgsqlParameter("@in_m_hadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[23].Value = m_haddress;
                param[24] = new NpgsqlParameter("@in_m_wadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[24].Value = m_waddress;
                param[25] = new NpgsqlParameter("@in_m_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[25].Value = m_mobile1;
                param[26] = new NpgsqlParameter("@in_m_hphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[26].Value = m_hphone;
                param[27] = new NpgsqlParameter("@in_m_wphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[27].Value = m_wphone;
                param[28] = new NpgsqlParameter("@in_m_acc", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[28].Value = m_acc;
                param[29] = new NpgsqlParameter("@in_m_mail", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[29].Value = m_mail;


                // other parameters
                param[30] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[30].Value = id;
                param[31] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[31].Value = user_id;
                param[32] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[32].Value = company_id;
                param[33] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[33].Value = stop;
                param[34] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                param[34].Value = notes;
                param[35] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                param[35].Value = branch_id;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_parents_insert", param); ;
                ds.Tables[0].TableName = "tbl_parents"; 


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[36];
                DataSet ds = new DataSet();
                // father parameters
                param[0] = new NpgsqlParameter("@in_f_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[0].Value = f_parent_id;
                param[1] = new NpgsqlParameter("@in_f_enddate_id", NpgsqlTypes.NpgsqlDbType.Timestamp);
                param[1].Value = f_enddate_id;
                param[2] = new NpgsqlParameter("@in_f_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = f_aname;
                param[3] = new NpgsqlParameter("@in_f_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[3].Value = f_ename;
                param[4] = new NpgsqlParameter("@in_ff_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[4].Value = ff_aname;
                param[5] = new NpgsqlParameter("@in_ff_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[5].Value = ff_ename;
                param[6] = new NpgsqlParameter("@in_f_religion", NpgsqlTypes.NpgsqlDbType.Integer);
                param[6].Value = f_religion;
                param[7] = new NpgsqlParameter("@in_f_country", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[7].Value = f_country;
                param[8] = new NpgsqlParameter("@in_f_hadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[8].Value = f_haddress;
                param[9] = new NpgsqlParameter("@in_f_wadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[9].Value = f_waddress;
                param[10] = new NpgsqlParameter("@in_f_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[10].Value = f_mobile1;
                param[11] = new NpgsqlParameter("@in_f_hphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[11].Value = m_hphone;
                param[12] = new NpgsqlParameter("@in_f_wphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[12].Value = f_wphone;
                param[13] = new NpgsqlParameter("@in_f_acc", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[13].Value = m_acc;
                param[14] = new NpgsqlParameter("@in_f_mail", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[14].Value = m_mail;

                // mother parameters
                param[15] = new NpgsqlParameter("@in_m_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[15].Value = f_parent_id;
                param[16] = new NpgsqlParameter("@in_m_enddate_id", NpgsqlTypes.NpgsqlDbType.Timestamp);
                param[16].Value = f_enddate_id;
                param[17] = new NpgsqlParameter("@in_m_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[17].Value = f_aname;
                param[18] = new NpgsqlParameter("@in_m_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[18].Value = f_ename;
                param[19] = new NpgsqlParameter("@in_mf_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[19].Value = ff_aname;
                param[20] = new NpgsqlParameter("@in_mf_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[20].Value = ff_ename;
                param[21] = new NpgsqlParameter("@in_m_religion", NpgsqlTypes.NpgsqlDbType.Integer);
                param[21].Value = f_religion;
                param[22] = new NpgsqlParameter("@in_m_country", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[22].Value = f_country;
                param[23] = new NpgsqlParameter("@in_m_hadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[23].Value = f_haddress;
                param[24] = new NpgsqlParameter("@in_m_wadress", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[24].Value = f_waddress;
                param[25] = new NpgsqlParameter("@in_m_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[25].Value = f_mobile1;
                param[26] = new NpgsqlParameter("@in_m_hphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[26].Value = m_hphone;
                param[27] = new NpgsqlParameter("@in_m_wphone", NpgsqlTypes.NpgsqlDbType.Varchar, (20));
                param[27].Value = f_wphone;
                param[28] = new NpgsqlParameter("@in_m_acc", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[28].Value = m_acc;
                param[29] = new NpgsqlParameter("@in_m_mail", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[29].Value = m_mail;


                // other parameters
                param[30] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[30].Value = id;
                param[31] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[31].Value = user_id;
                param[32] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[32].Value = company_id;
                param[33] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[33].Value = stop;
                param[34] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                param[34].Value = notes;
                param[35] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                param[35].Value = branch_id;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_parents_update", param); ;
                ds.Tables[0].TableName = "tbl_parents";

                return ds;
            }
            public DataSet Delete()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[3];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 4);
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[1].Value = user_id;
                param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[2].Value = company_id;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_parents_delete", param);
                ds.Tables[0].TableName = "tbl_parents";

                return ds;
            }
            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();
                string select = "";

                switch (selecttype)
                {
                    case "Login":
                        select = "SELECT * FROM scl.tbl_parents WHERE id = '0';";
                        break;

                    case "Select_All":
                        select = "SELECT * FROM scl.tbl_parents WHERE company_id = '" + company_id + "';";
                        break;

                    case "Select":
                        select = "SELECT * FROM scl.tbl_parents WHERE id = '" + id + "' AND company_id = '" + company_id + "';";
                        break;
                    case "Search":
                        select = "select * from scl.tbl_parents where(f_parent_id = '" + f_parent_id + "'or id like '%" + id + "' or f_mobile1 = '" + f_mobile1 + "' or f_aname like '%" + f_aname + "%' or ff_aname like '%" + ff_aname + " %'or m_parent_id = '" + m_parent_id + "'  or m_mobile1 = '" + m_mobile1 + "' or m_aname like '%" + m_aname + "%' or mf_aname like '%" + mf_aname + "%'or f_ename like '" + f_ename + "%' or ff_ename like '%"  + ff_ename + "%' or m_ename like '%" + m_ename + "%' or mf_ename like '%" + mf_ename + "%')and company_id = '" + company_id + "';";
                        break;
                    case "First":
                        select = "SELECT * FROM scl.tbl_parents WHERE  company_id = '" + company_id + "' ORDER BY ctid ASC LIMIT 1;";
                             
                        break;
                    case "Prev":
                        select = "SELECT * FROM scl.tbl_parents WHERE id = (SELECT id FROM scl.tbl_parents WHERE sequ < (SELECT sequ FROM scl.tbl_parents WHERE id = '" + id + "' AND company_id = '" + company_id + "' LIMIT 1)  AND company_id = '" + company_id + "' ORDER BY ctid Desc LIMIT 1) AND company_id = '" + company_id + "';";
                        break;
                    case "Next":
                        select = "SELECT * FROM scl.tbl_parents WHERE id = (SELECT id FROM scl.tbl_parents WHERE sequ > (SELECT sequ FROM scl.tbl_parents WHERE id = '" + id + "' AND company_id = '" + company_id + "' LIMIT 1)  AND company_id = '" + company_id + "' ORDER BY ctid ASC LIMIT 1) AND company_id = '" + company_id + "';";
                        break;
                    case "Last":
                        select = "SELECT * FROM scl.tbl_parents WHERE  company_id = '" + company_id + "' ORDER BY ctid Desc LIMIT 1;";
                        break;
                }

                ds = dal.ExecuteAndRetriveDataSet(select
                                                + "Select * From grl.tbl_nationality order by ctid;"
                                                + "Select * From grl.tbl_religion order by ctid;"
                                                    );

                ds.Tables[0].TableName = "tbl_Parents";
                ds.Tables[1].TableName = "tbl_nationality";
                ds.Tables[2].TableName = "tbl_religion";
                return ds;
            }
        }
    }
}
