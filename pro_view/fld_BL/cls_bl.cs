using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;

namespace pro_view.fld_BL
{
    class cls_bl
    {
        public struct stc_Login
        {
            public DataTable UpdateDatabase()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataTable dt = new DataTable();

                dal.UpdateDatabase();

                return dt;
            }
            public DataSet SelectAllowedCompaniesAndFyears(string user_id)
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();
                ds = dal.ExecuteAndRetriveDataSet(
                      "SELECT id,aname,ename FROM grl.tbl_companies WHERE stop = 'false' AND id NOT IN (SELECT company_id FROM grl.tbl_userblocked WHERE user_id = '" + user_id + "' AND company_id IS NOT NULL);"
                    + "SELECT id,aname,ename FROM grl.tbl_fyears WHERE stop = 'false' AND id NOT IN (SELECT fyear_id FROM grl.tbl_userblocked WHERE user_id = '" + user_id + "' AND fyear_id IS NOT NULL) ORDER BY sequ DESC;");

                ds.Tables[0].TableName = "tbl_companies";
                ds.Tables[1].TableName = "tbl_fyears";

                return ds;
            }
            public DataSet SelectAllowedBranchesAndStores(string user_id, string company_id)
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();
                ds = dal.ExecuteAndRetriveDataSet(    
                      "SELECT id,aname,ename FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '"+company_id+"' "
                    + "AND id NOT IN (SELECT branch_id FROM grl.tbl_userblocked WHERE user_id = '" + user_id + "' AND branch_id IS NOT NULL) ORDER BY sequ;"
                    + "SELECT id,aname,ename FROM grl.tbl_stores WHERE stop = 'false' AND company_id = '" + company_id + "' " 
                    + "AND id NOT IN (SELECT store_id from grl.tbl_userblocked WHERE user_id = '" + user_id + "' AND store_id IS NOT NULL) ORDER BY sequ;"
                    );

                ds.Tables[0].TableName = "tbl_branches";
                ds.Tables[1].TableName = "tbl_stores";

                return ds;
            }

            public struct main
            {
                public DataSet Select(string user_id)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(
                          "SELECT * FROM grl.tbl_system LIMIT 1;" +
                          "SELECT * FROM grl.tbl_permuser WHERE user_id = '" + user_id + "';"
                          );

                    ds.Tables[0].TableName = "tbl_system";
                    ds.Tables[1].TableName = "tbl_permuser";

                    return ds;
                }
                public DataSet ExecuteCommand(string s)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    return dal.ExecuteAndRetriveDataSet(s);
                }
            }
        }

        #region Accounting
        public struct stc_Accounting
        {
            public struct stc_cin
            {
                #region properties
                public string id { get; set; }
                public string jor_id { get; set; }
                public string notes { get; set; }
                public string company_id { get; set; }
                public string fyear_id { get; set; }
                public string branch_id { get; set; }
                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public DateTime ddate { get; set; }
                public string user_id { get; set; }
                public DataTable cinD { get; set; }

                public string selecttype { get; set; }
                public int sequ { get; set; }

                #endregion

                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart  WHERE stop = 'false' AND parent = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_paytype order by id;";
                    s += "SELECT * FROM grl.tbl_bank order by id;";
                    s += "SELECT * FROM grl.tbl_currencies where stop = 'false' order by sequ;";
                    s += "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";
                    ds.Tables[4].TableName = "tbl_paytype";
                    ds.Tables[5].TableName = "tbl_bank";
                    ds.Tables[6].TableName = "tbl_currencies";
                    ds.Tables[7].TableName = "tbl_fyears";

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
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = '" + id + "';"; 
                            break;

                        case "Select":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "';";
                            break;
                        case "Search":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_sequ = " + sequ + " AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "';";
                            break;
                        case "First":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = (SELECT h_id FROM acc.viw_cin_Select WHERE h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "';";
                            break;
                        case "Prev":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = (SELECT h_id FROM acc.viw_cin_Select WHERE h_sequ < (SELECT h_sequ FROM acc.viw_cin_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "' LIMIT 1) AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ Desc LIMIT 1) AND h_company_id = '" + company_id + "';";
                            break;
                        case "Next":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = (SELECT h_id FROM acc.viw_cin_Select WHERE h_sequ > (SELECT h_sequ FROM acc.viw_cin_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "' LIMIT 1) AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1) AND h_company_id = '" + company_id + "';";
                            break;
                        case "Last":
                            select = "SELECT * FROM acc.viw_cin_Select WHERE h_id = (SELECT h_id FROM acc.viw_cin_Select WHERE h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ Desc LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "';";
                            break;
                    }

                    ds = dal.ExecuteAndRetriveDataSet(select
                                                     + "SELECT * FROM acc.tbl_chart  WHERE stop = 'false' AND parent = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM grl.tbl_paytype order by id;"
                                                     + "SELECT * FROM grl.tbl_bank order by id;"
                                                     + "SELECT * FROM grl.tbl_currencies where stop = 'false' order by sequ;"
                                                     + "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;"
                                                        );

                    ds.Tables[0].TableName = "tbl_cin";
                    ds.Tables[1].TableName = "tbl_chart";
                    ds.Tables[2].TableName = "tbl_branches";
                    ds.Tables[3].TableName = "tbl_cc1";
                    ds.Tables[4].TableName = "tbl_cc2";
                    ds.Tables[5].TableName = "tbl_paytype";
                    ds.Tables[6].TableName = "tbl_bank";
                    ds.Tables[7].TableName = "tbl_currencies";
                    ds.Tables[8].TableName = "tbl_fyears";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(cinD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = notes;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;
                    param[3] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = fyear_id;
                    param[4] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[4].Value = branch_id;
                    param[5] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = cc1_id;
                    param[6] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = cc2_id;
                    param[7] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[7].Value = ddate;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;
                    param[9] = new NpgsqlParameter("@in_cind", NpgsqlTypes.NpgsqlDbType.Json);
                    param[9].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cin_insert", param); ;
                    ds.Tables[0].TableName = "tbl_cin";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(cinD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = notes;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;
                    param[3] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = fyear_id;
                    param[4] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[4].Value = branch_id;
                    param[5] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = cc1_id;
                    param[6] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = cc2_id;
                    param[7] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[7].Value = ddate;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;
                    param[9] = new NpgsqlParameter("@in_cind", NpgsqlTypes.NpgsqlDbType.Json);
                    param[9].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cin_update", param); ;
                    ds.Tables[0].TableName = "tbl_cin";

                    return ds;
                }
                public DataSet Delete()

                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(cinD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = company_id;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cin_delete", param); ;
                    ds.Tables[0].TableName = "tbl_cin";

                    return ds;
                }
                public DataSet Post()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_cin_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_posttime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[1].Value = ddate;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;
                    param[3] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cin_post", param); ;
                    ds.Tables[0].TableName = "tbl_cin";

                    return ds;
                }
                public DataSet PostCancel()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_cin_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_time", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[1].Value = ddate;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;
                    param[3] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cin_postcancel", param); ;
                    ds.Tables[0].TableName = "tbl_cin";

                    return ds;
                }
            }
            public struct stc_cout
            {
                #region properties
                public string id { get; set; }
                public string notes { get; set; }
                public string company_id { get; set; }
                public string fyear_id { get; set; }
                public string branch_id { get; set; }
                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public DateTime ddate { get; set; }
                public string user_id { get; set; }
                public DataTable coutD { get; set; }

                public string selecttype { get; set; }
                public int sequ { get; set; }

                #endregion

                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart  WHERE stop = 'false' AND parent = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_paytype order by id;";
                    s += "SELECT * FROM grl.tbl_bank order by id;";
                    s += "SELECT * FROM grl.tbl_currencies where stop = 'false' order by sequ;";
                    s += "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";
                    ds.Tables[4].TableName = "tbl_paytype";
                    ds.Tables[5].TableName = "tbl_bank";
                    ds.Tables[6].TableName = "tbl_currencies";
                    ds.Tables[7].TableName = "tbl_fyears";

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
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = '"+ id +"';";
                            break;

                        case "Select":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "';";
                            break;
                        case "Search":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_sequ = " + sequ + " AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "';";
                            break;
                        case "First":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = (SELECT h_id FROM acc.viw_cout_Select WHERE h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "';";
                            break;
                        case "Prev":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = (SELECT h_id FROM acc.viw_cout_Select WHERE h_sequ < (SELECT h_sequ FROM acc.viw_cout_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "' LIMIT 1) AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ Desc LIMIT 1) AND h_company_id = '" + company_id + "';";
                            break;
                        case "Next":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = (SELECT h_id FROM acc.viw_cout_Select WHERE h_sequ > (SELECT h_sequ FROM acc.viw_cout_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "' LIMIT 1) AND h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1) AND h_company_id = '" + company_id + "';";
                            break;
                        case "Last":
                            select = "SELECT * FROM acc.viw_cout_Select WHERE h_id = (SELECT h_id FROM acc.viw_cout_Select WHERE h_branch_id = '" + branch_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ Desc LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "';";
                            break;
                    }

                    ds = dal.ExecuteAndRetriveDataSet(select
                                                     + "SELECT * FROM acc.tbl_chart  WHERE stop = 'false' AND parent = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';"
                                                     + "SELECT * FROM grl.tbl_paytype order by id;"
                                                     + "SELECT * FROM grl.tbl_bank order by id;"
                                                     + "SELECT * FROM grl.tbl_currencies where stop = 'false' order by sequ;"
                                                     + "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;"
                                                        );

                    ds.Tables[0].TableName = "tbl_cout";
                    ds.Tables[1].TableName = "tbl_chart";
                    ds.Tables[2].TableName = "tbl_branches";
                    ds.Tables[3].TableName = "tbl_cc1";
                    ds.Tables[4].TableName = "tbl_cc2";
                    ds.Tables[5].TableName = "tbl_paytype";
                    ds.Tables[6].TableName = "tbl_bank";
                    ds.Tables[7].TableName = "tbl_currencies";
                    ds.Tables[8].TableName = "tbl_fyears";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(coutD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = notes;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;
                    param[3] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = fyear_id;
                    param[4] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[4].Value = branch_id;
                    param[5] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = cc1_id;
                    param[6] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = cc2_id;
                    param[7] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[7].Value = ddate;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;
                    param[9] = new NpgsqlParameter("@in_coutd", NpgsqlTypes.NpgsqlDbType.Json);
                    param[9].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cout_insert", param); ;
                    ds.Tables[0].TableName = "tbl_cout";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(coutD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = notes;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;
                    param[3] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = fyear_id;
                    param[4] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[4].Value = branch_id;
                    param[5] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = cc1_id;
                    param[6] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = cc2_id;
                    param[7] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[7].Value = ddate;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;
                    param[9] = new NpgsqlParameter("@in_coutd", NpgsqlTypes.NpgsqlDbType.Json);
                    param[9].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cout_update", param); ;
                    ds.Tables[0].TableName = "tbl_cout";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(coutD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = company_id;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cout_delete", param); ;
                    ds.Tables[0].TableName = "tbl_cout";

                    return ds;
                }
                public DataSet Post()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_cout_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_posttime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[1].Value = ddate;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;
                    param[3] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cout_post", param); ;
                    ds.Tables[0].TableName = "tbl_cout";

                    return ds;
                }
                public DataSet PostCancel()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_cout_id", NpgsqlTypes.NpgsqlDbType.Varchar, (10));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_time", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[1].Value = ddate;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;
                    param[3] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[3].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_cout_postcancel", param); ;
                    ds.Tables[0].TableName = "tbl_cout";

                    return ds;
                }
            }
            public struct stc_jor
            {
                #region properties
                public string id { get; set; }
                public string currency_id { get; set; }
                public decimal currencyPrice { get; set; }
                public string jortype_id { get; set; }

                public string notes { get; set; } 
                public string company_id { get; set; }
                public string fyear_id { get; set; }
                public string branch_id { get; set; }
                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public DateTime ddate { get; set; }
                public string user_id { get; set; }
                public DataTable jorD { get; set; }

                public string selecttype { get; set; }
                public int sequ { get; set; }

                #endregion

                public DataSet SelectLogin()
                {
                    string s = 
                         "SELECT * FROM acc.tbl_chart  WHERE stop = 'false' AND parent = 'false'; "; 
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND parent = 'false' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_Doctype order by id;";
                    s += "SELECT * FROM acc.tbl_jortype order by id;";
                    s += "SELECT * FROM grl.tbl_currencies where stop = 'false' order by sequ;";
                    s += "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;";
                    s += "SELECT DISTINCT (h_id) , h_notes FROM acc.viw_jorcyc_select ORDER BY h_id;";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";
                    ds.Tables[4].TableName = "tbl_Doctype";
                    ds.Tables[5].TableName = "tbl_jortype";
                    ds.Tables[6].TableName = "tbl_currencies";
                    ds.Tables[7].TableName = "tbl_fyears";
                    ds.Tables[8].TableName = "tbl_jorcyc";

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
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = '0';";
                            break;
                        
                        case "Select":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = '"+id+"' AND h_company_id = '"+company_id+ "' AND company_id = '" + company_id + "';";
                            break;
                        case "Search":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_sequ = "+sequ+" AND h_branch_id = '"+branch_id+ "' AN h_company_id = '" + company_id + "';";
                            break;
                        case "First":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = (SELECT h_id FROM acc.viw_jor_Select WHERE h_branch_id = '" + branch_id + "' AND h_fyear_id = '" + fyear_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "' AND company_id = '"+ company_id + "';";
                            break;
                        case "Prev":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = (SELECT h_id FROM acc.viw_jor_Select WHERE h_sequ < (SELECT h_sequ FROM acc.viw_jor_Select WHERE h_id = '"+id+"' AND h_company_id = '"+company_id+"' LIMIT 1) AND h_branch_id = '"+branch_id+ "' AND h_fyear_id = '" + fyear_id + "' AND h_company_id = '" + company_id+ "' ORDER BY h_sequ Desc LIMIT 1) AND h_company_id = '" + company_id+ "'AND company_id = '" + company_id + "';";
                            break;
                        case "Next":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = (SELECT h_id FROM acc.viw_jor_Select WHERE h_sequ > (SELECT h_sequ FROM acc.viw_jor_Select WHERE h_id = '" + id + "' AND h_company_id = '" + company_id + "' LIMIT 1) AND h_branch_id = '" + branch_id + "' AND h_fyear_id = '" + fyear_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ ASC LIMIT 1) AND h_company_id = '" + company_id + "'AND company_id = '" + company_id + "';";
                            break;
                        case "Last":
                            select = "SELECT * FROM acc.viw_jor_Select WHERE h_id = (SELECT h_id FROM acc.viw_jor_Select WHERE h_branch_id = '" + branch_id + "' AND h_fyear_id = '" + fyear_id + "' AND h_company_id = '" + company_id + "' ORDER BY h_sequ Desc LIMIT 1)"
                                   + " AND h_company_id = '" + company_id + "' AND company_id = '" + company_id + "';";
                            break;
                    }

                    ds = dal.ExecuteAndRetriveDataSet(select
                                                    + "Select * From acc.tbl_jortype order by id;"
                                                    + "Select * From grl.tbl_currencies where stop = 'false' order by sequ;"
                                                    + "Select * From acc.tbl_cc where stop = 'false' AND cc1 = 'true' AND parent = 'false' AND company_id = '" + company_id + "' order by sequ;"
                                                    + "Select * From acc.tbl_cc where stop = 'false' AND cc2 = 'true' AND parent = 'false' AND company_id = '" + company_id + "' order by sequ;"
                                                    + "Select * From acc.tbl_chart where stop = 'false' AND parent = 'false' AND company_id = '" + company_id + "' ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_fyears where stop = 'false' AND company_id = '" + company_id + "' order by sequ;"
                                                        );

                    ds.Tables[0].TableName = "tbl_jor";
                    ds.Tables[1].TableName = "tbl_jortype";
                    ds.Tables[2].TableName = "tbl_currencies";
                    ds.Tables[3].TableName = "tbl_cc1";
                    ds.Tables[4].TableName = "tbl_cc2";
                    ds.Tables[5].TableName = "tbl_chart";
                    ds.Tables[6].TableName = "tbl_fyears";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(jorD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (15));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_currency_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = currency_id;
                    param[2] = new NpgsqlParameter("@in_currencyprice", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[2].Value = currencyPrice;
                    param[3] = new NpgsqlParameter("@in_jortype_id", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = jortype_id;
                    param[4] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[4].Value = notes;
                    param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[5].Value = company_id;
                    param[6] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[6].Value = fyear_id;
                    param[7] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[7].Value = branch_id;
                    param[8] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = cc1_id;
                    param[9] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = cc2_id;
                    param[10] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[10].Value = ddate;
                    param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[11].Value = user_id;
                    param[12] = new NpgsqlParameter("@in_jord", NpgsqlTypes.NpgsqlDbType.Json);
                    param[12].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_jor_insert", param); ;
                    ds.Tables[0].TableName = "tbl_jor";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(jorD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (15));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_currency_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = currency_id;
                    param[2] = new NpgsqlParameter("@in_currencyprice", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[2].Value = currencyPrice;
                    param[3] = new NpgsqlParameter("@in_jortype_id", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = jortype_id;
                    param[4] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[4].Value = notes;
                    param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[5].Value = company_id;
                    param[6] = new NpgsqlParameter("@in_fyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[6].Value = fyear_id;
                    param[7] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[7].Value = branch_id;
                    param[8] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = cc1_id;
                    param[9] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = cc2_id;
                    param[10] = new NpgsqlParameter("@in_creationtime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[10].Value = ddate;
                    param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[11].Value = user_id;
                    param[12] = new NpgsqlParameter("@in_jord", NpgsqlTypes.NpgsqlDbType.Json);
                    param[12].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_jor_update", param); ;
                    ds.Tables[0].TableName = "tbl_jor";
                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(jorD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (15));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = company_id;
                    param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[2].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_jor_delete", param); ;
                    ds.Tables[0].TableName = "tbl_jor";

                    return ds;
                }

                public DataSet Insert_JorCyc()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[8];
                    DataSet ds = new DataSet();
                    string json = JsonConvert.SerializeObject(jorD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Integer);
                    param[0].Value = null;
                    param[1] = new NpgsqlParameter("@in_currency_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[1].Value = currency_id;
                    param[2] = new NpgsqlParameter("@in_currencyprice", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[2].Value = currencyPrice;
                    param[3] = new NpgsqlParameter("@in_jortype_id", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = jortype_id;
                    param[4] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[4].Value = notes;                
                    param[5] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = cc1_id;
                    param[6] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = cc2_id;               
                    param[7] = new NpgsqlParameter("@in_jord", NpgsqlTypes.NpgsqlDbType.Json);
                    param[7].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("acc.fnc_jorcyc_insert", param); ;
                    ds.Tables[0].TableName = "tbl_jorcyc";

                    return ds;
                }
                public DataSet Select_JorCyc(string id)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();           

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM acc.viw_jorcyc_select WHERE h_id = "+id+";");

                    ds.Tables[0].TableName = "tbl_jorcyc";

                    return ds;
                }
                public DataSet Delete_JorCyc(string id)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(

                            "DELETE FROM acc.tbl_jorcyc WHERE id = " + id + ";"
                          + "DELETE FROM acc.tbl_jordcyc WHERE jorcyc_id = " + id + ";"
                          + "SELECT * FROM acc.viw_jorcyc_select ORDER BY h_id;"

                        );

                    ds.Tables[0].TableName = "tbl_jorcyc";

                    return ds;
                }
            }
            public struct ST
            {
                public string ID;
                public string date_From;
                public string date_To;

                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }


                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart "
                             //+ "WHERE company_id = '" + company_id + "' "
                             + "WHERE stop = 'false' "
                             + "AND parent = 'false';";

                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";

                    return ds;
                }
                public DataSet Select(string fyear_id, bool PrevFyears)
                {
                    string where = "\r\nWHERE ";                   
                    where += "chart_id = '" + ID + "'";              
                    where += (date_From != "01/01/1753") ? " and Date >= '" + date_From + "'" : "";
                    where += (date_To != "12/31/9998") ? " and Date <=  '" + date_To + "'" : "";
                    
                    where += (cc1_id != null) ? " AND cc1_id = '" + cc1_id + "'" : "";
                    where += (cc2_id != null) ? " AND cc2_id = '" + cc2_id + "'" : "";
                    where += (branch_id != null) ? " AND branch_id = '" + branch_id + "'" : "";
                    where += " AND company_id = '" + company_id + "'";
                    where += (PrevFyears == false) ?" AND fyear_id = '" + fyear_id + "'" : "";
                    where += (PrevFyears == true) ? " AND jortype_id != '2'" : "";

                    string where_open = "\r\nWHERE ";
                    where_open += "chart_id = '" + ID + "'";
                    where_open += (date_From != "01/01/1753") ? " and Date < '" + date_From + "'" : " and Date < '01/01/1753'";
                    where_open += (cc1_id != null) ? " AND cc1_id = '" + cc1_id + "'" : "";
                    where_open += (cc2_id != null) ? " AND cc2_id = '" + cc2_id + "'" : "";
                    where_open += (branch_id != null) ? " AND branch_id = '" + branch_id + "'" : "";
                    where_open += " AND company_id = '" + company_id + "'";
                    where_open += (PrevFyears == false) ? " AND fyear_id = '" + fyear_id + "'" : "";
                    where_open += (PrevFyears == true) ? " AND jortype_id != '2'" : "";


                    if (where == "\r\nWHERE ") { where = ""; }

                    string open = "SELECT "
                    + "sum(debit) as Debit, "
                    + "sum(credit) as Credit,"
                    + "'رصيد إفتتاحي' as notes,"
                    + "null as jor_id,"
                    + "null as date,"
                    + "null as doctype_aname,"
                    + "null as doc_id"
                    + " FROM acc.viw_ST"
                    + where_open + " union all ";

                    string s = open
                    + "SELECT " 
                    + "debit"
                    + ",credit"
                    + ",notes"
                    + ",jor_id"
                    + ",date"                   
                    + ",doctype_aname"
                    + ",doc_id"
                    + " FROM acc.viw_ST"
                    + where;

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(s);

                    return ds;
                }
            }
            public struct TB
            {
                public string ID;
                public string date_From;
                public string date_To;

                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }
                public int level { get; set; }


                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart WHERE stop = 'false' AND parent = 'true' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";

                    return ds;
                }
                public DataSet Select()
                {
                    string where_tb = "WHERE";
                    where_tb += (ID != "")? " tb.id LIKE '" + ID + "%'" : "";
                    where_tb += " AND level <= " + level;

                    string where_v = "";
                    where_v += (cc1_id != null) ? " AND cc1_id = '" + cc1_id + "'" : "";
                    where_v += (cc2_id != null) ? " AND cc2_id = '" + cc2_id + "'" : "";
                    where_v += (branch_id != null) ? " AND branch_id = '" + branch_id + "'" : "";
                    where_v += " AND company_id = '" + company_id + "'";

                    if(where_tb.Substring(0, 9) == "WHERE AND")
                    {
                        where_tb = "WHERE " + where_tb.Substring(10);
                    }

                    string s = "SELECT tb.id, tb.aname," + "\r\n"
                        + "SUM(CASE WHEN(tb.date < '"+date_From+ "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date < '" + date_From + "' AND v.id like tb.id || '%' "+ where_v + "),0) ELSE 0  END) as open_debit," + "\r\n"
                        + " SUM(CASE WHEN(tb.date < '" + date_From + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date < '" + date_From + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as open_credit," + "\r\n"

                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '"+date_To+ "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as debit, " + "\r\n"
                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                + " WHEN(tb.parent = 'true')" + "\r\n"
                                + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date >= '" + date_From+"' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as credit," + "\r\n"

                        + " SUM(CASE WHEN(tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as balance_debit," + "\r\n"
                        + " SUM(CASE WHEN(tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as balance_credit," + "\r\n"
                        + " ((SUM(CASE WHEN(tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END)) - "
                                 + " (SUM(CASE WHEN(tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END))) AS net_balance," + "\r\n"
                        + "tb.level, tb.parent"
                        + "\r\nFROM acc.viw_tb tb"
                        + "\r\n" + where_tb
                        + "\r\n GROUP BY tb.id, tb.aname, level, tb.parent";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(s);

                    return ds;
                }
            }
            public struct IS
            {
                public string ID;
                public string date_From;
                public string date_To;

                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }
                public int level { get; set; }
                public string menue_id { get; set; }
                public string side_id { get; set; }

                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart WHERE stop = 'false' AND parent = 'true' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";

                    return ds;
                }
                public DataSet Select(bool LastLevel)
                {
                    #region Generate Select
                    string where_tb = "WHERE";
                    where_tb += (ID != "") ? " tb.id LIKE '" + ID + "%'" : "";
                    where_tb += " AND level <= " + level;
                    where_tb += "AND tb.menue_id = '2'";

                    string where_v = "";
                    where_v += (cc1_id != null) ? " AND cc1_id = '" + cc1_id + "'" : "";
                    where_v += (cc2_id != null) ? " AND cc2_id = '" + cc2_id + "'" : "";
                    where_v += (branch_id != null) ? " AND branch_id = '" + branch_id + "'" : "";
                    where_v += " AND company_id = '" + company_id + "'";

                    if (where_tb.Substring(0, 9) == "WHERE AND")
                    {
                        where_tb = "WHERE " + where_tb.Substring(10);
                    }

                    string s = "SELECT \r\n"

                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To 
                                 + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as debit," + "\r\n"

                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                + " WHEN(tb.parent = 'true')" + "\r\n"
                                + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To 
                                + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as credit," + "\r\n"

                        + "\r\ntb.id chart_debit_id,"
                        + "\r\ntb.aname chart_debit_name,"
                        + "tb.level level_debit, tb.parent parent_debit, tb.menue_id, tb.side_id"
                        + "\r\nFROM acc.viw_tb tb"
                        + "\r\n" + "WHERE level <= " + level + " AND tb.menue_id = '2' AND tb.side_id = '1'"
                        + "\r\n GROUP BY tb.id, tb.aname, level, tb.parent, tb.menue_id, tb.side_id;" + "\r\n \r\n "

                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        + " SELECT SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                        + " WHEN(tb.parent = 'true')" + "\r\n"
                        + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To
                        + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as debit," + "\r\n"

                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                + " WHEN(tb.parent = 'true')" + "\r\n"
                                + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as credit," + "\r\n"
                        + "\r\ntb.id chart_credit_id,"
                        + "\r\ntb.aname chart_credit_name,"
                        + "tb.level level_credit, tb.parent parent_credit, tb.menue_id, tb.side_id"
                        + "\r\nFROM acc.viw_tb tb"
                        + "\r\n" + "WHERE level <= "+level+" AND tb.menue_id = '2' AND tb.side_id = '2'"
                        + "\r\n GROUP BY tb.id, tb.aname, level, tb.parent, tb.menue_id, tb.side_id;";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();
                    #endregion

                    ds = dal.ExecuteAndRetriveDataSet(s);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("debit");
                    dt.Columns.Add("chart_debit_name");
                    dt.Columns.Add("chart_debit_id");
                    dt.Columns.Add("level_debit");
                    dt.Columns.Add("parent_debit");

                    dt.Columns.Add("credit");
                    dt.Columns.Add("chart_credit_name");
                    dt.Columns.Add("chart_credit_id");
                    dt.Columns.Add("level_credit");
                    dt.Columns.Add("parent_credit");


                    //Remove record which not has balance
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (Convert.ToDecimal(ds.Tables[0].Rows[i]["debit"]) == 0)
                        {
                            ds.Tables[0].Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (Convert.ToDecimal(ds.Tables[1].Rows[i]["credit"]) == 0)
                        {
                            ds.Tables[1].Rows.RemoveAt(i);
                            i--;
                        }
                    }

                    if (LastLevel)
                    {
                        ds.Tables[0].DefaultView.RowFilter = "parent_debit = false";
                        ds.Tables[1].DefaultView.RowFilter = "parent_credit = false";
                    }

                    for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                    {
                        dt.Rows.Add(
                                    (Convert.ToDecimal(ds.Tables[0].DefaultView[i]["debit"]) - Convert.ToDecimal(ds.Tables[0].DefaultView[i]["credit"])).ToString(),
                                    ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString(),
                                    ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString(),
                                    ds.Tables[0].DefaultView[i]["level_debit"].ToString(),
                                    ds.Tables[0].DefaultView[i]["parent_debit"].ToString()
                            );
                    }
                    for (int i = 0; i < ds.Tables[1].DefaultView.Count; i++)
                    {
                        if (dt.Rows.Count < i + 1) dt.Rows.Add();

                        dt.Rows[i]["credit"] = (Convert.ToDecimal(ds.Tables[1].DefaultView[i]["credit"]) - Convert.ToDecimal(ds.Tables[1].DefaultView[i]["debit"])).ToString();
                        dt.Rows[i]["chart_credit_name"] = ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString();
                        dt.Rows[i]["chart_credit_id"] = ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString();
                        dt.Rows[i]["level_credit"] = ds.Tables[1].DefaultView[i]["level_credit"].ToString();
                        dt.Rows[i]["parent_credit"] = ds.Tables[1].DefaultView[i]["parent_credit"].ToString();
                    }

                        #region Distrbute
                        //if (ds.Tables[0].DefaultView.Count >= ds.Tables[1].DefaultView.Count)
                        //{
                        //    for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                        //    {
                        //        dt.Rows.Add(ds.Tables[0].DefaultView[i]["debit"].ToString(),
                        //                    ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString(),
                        //                    ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString(),
                        //                    ds.Tables[0].DefaultView[i]["level_debit"].ToString(),
                        //                    ds.Tables[0].DefaultView[i]["parent_debit"].ToString()
                        //            );
                        //        if(ds.Tables[1].DefaultView.Count >= i +1)
                        //        {
                        //            dt.Rows[i]["credit"] = ds.Tables[1].DefaultView[i]["credit"].ToString();
                        //            dt.Rows[i]["chart_credit_name"] = ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString();
                        //            dt.Rows[i]["chart_credit_id"] = ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString();
                        //            dt.Rows[i]["level_credit"] = ds.Tables[1].DefaultView[i]["level_credit"].ToString();
                        //            dt.Rows[i]["parent_credit"] = ds.Tables[1].DefaultView[i]["parent_credit"].ToString();
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    for (int i = 0; i < ds.Tables[1].DefaultView.Count; i++)
                        //    {
                        //        dt.Rows.Add(ds.Tables[1].DefaultView[i]["credit"].ToString(),
                        //                    ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString(),
                        //                    ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString(),
                        //                    ds.Tables[1].DefaultView[i]["level_credit"].ToString(),
                        //                    ds.Tables[1].DefaultView[i]["parent_credit"].ToString()
                        //        );

                        //        if (ds.Tables[0].DefaultView.Count >= i + 1)
                        //        {
                        //            dt.Rows[i]["debit"] = ds.Tables[0].DefaultView[i]["debit"].ToString();
                        //            dt.Rows[i]["chart_debit_name"] = ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString();
                        //            dt.Rows[i]["chart_debit_id"] = ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString();
                        //            dt.Rows[i]["level_debit"] = ds.Tables[0].DefaultView[i]["level_debit"].ToString();
                        //            dt.Rows[i]["parent_debit"] = ds.Tables[0].DefaultView[i]["parent_debit"].ToString();
                        //        }
                        //    }
                        //}
                        #endregion

                        ds.Tables.Add(dt);
                    return ds;
                }
            }
            public struct BS
            {
                #region pro
                public string ID;
                public string date_From;
                public string date_To;

                public string cc1_id { get; set; }
                public string cc2_id { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }
                public int level { get; set; }
                public string menue_id { get; set; }
                public string side_id { get; set; }
                #endregion

                public DataSet SelectLogin()
                {
                    string s = "SELECT * FROM acc.tbl_chart WHERE stop = 'false' AND parent = 'true' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc1 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";
                    s += "SELECT * FROM acc.tbl_cc WHERE cc2 = 'true' AND stop = 'false' AND company_id = '" + company_id + "';";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    ds.Tables[0].TableName = "tbl_chart";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_cc1";
                    ds.Tables[3].TableName = "tbl_cc2";

                    return ds;
                }
                public DataSet Select(bool LastLevel)
                {
                    string tb = " (SELECT c.id, c.aname,c.ename,( SELECT CASE WHEN c.parent = true THEN ( SELECT sum(d.debit * d.currencyprice) AS sum FROM acc.tbl_jord d WHERE jortype_id != '2' AND d.chart_id ~~ (c.id::text || '%'::text)  AND company_id = '" + company_id+ "') ELSE (select case when j.company_id = '"+ company_id + "' then j.debit * j.currencyprice else 0 end) END) AS debit,"
                                + " (SELECT CASE WHEN c.parent = true THEN(SELECT sum(d.credit * d.currencyprice) AS sum FROM acc.tbl_jord d WHERE jortype_id != '2' AND d.chart_id ~~(c.id::text || '%'::text) AND company_id = '" + company_id+ "') ELSE (select case when j.company_id = '"+ company_id + "' then j.credit * j.currencyprice else 0 end) END) AS credit,"
                                + " j.creationtime AS date,c.level, c.parent_id,c.parent, c.menue_id, c.side_id, j.cc1_id, j.cc2_id, j.branch_id, j.company_id"
                                + " FROM acc.tbl_chart c LEFT JOIN acc.tbl_jord j ON c.id::text = j.chart_id"
                                + " WHERE j.jortype_id != '2' OR j.jortype_id IS null"
                                + " ORDER BY c.id) ";

                    string where_tb = "WHERE";
                    where_tb += (ID != "") ? " tb.id LIKE '" + ID + "%'" : "";
                    where_tb += " AND level <= " + level;
                    where_tb += "AND tb.menue_id = '2'";

                    string where_v = "";
                    where_v += (cc1_id != null) ? " AND cc1_id = '" + cc1_id + "'" : "";
                    where_v += (cc2_id != null) ? " AND cc2_id = '" + cc2_id + "'" : "";
                    where_v += (branch_id != null) ? " AND branch_id = '" + branch_id + "'" : "";
                    where_v += " AND company_id = '" + company_id + "'";

                    if (where_tb.Substring(0, 9) == "WHERE AND")
                    {
                        where_tb = "WHERE " + where_tb.Substring(10);
                    }

                    string s = "SELECT \r\n"

                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as debit,"
                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as credit,"
                        + "\r\nSUM(debit-credit) AS net_debit,"
                        + "\r\ntb.id chart_debit_id,"
                        + "\r\ntb.aname chart_debit_name,"
                        + "tb.level level_debit, tb.parent parent_debit, tb.menue_id, tb.side_id"

                        + "\r\nFROM "+tb+" tb"

                        + "\r\n" + "WHERE level <= " + level + " AND tb.menue_id = '1' AND tb.side_id = '1'"
                        + "\r\n GROUP BY tb.id, tb.aname, level, tb.parent, tb.menue_id, tb.side_id;"

                        + "\r\nSELECT "
                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.debit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.debit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as debit,"
                        + " SUM(CASE WHEN(tb.date >= '" + date_From + "' AND tb.date <= '" + date_To + "' " + where_v + ") THEN tb.credit" + "\r\n"
                                 + " WHEN(tb.parent = 'true')" + "\r\n"
                                 + " THEN coalesce((select sum(v.credit) from acc.viw_tb v where v.date >= '" + date_From + "' AND v.date <= '" + date_To + "' AND v.id like tb.id || '%' " + where_v + "),0) ELSE 0  END) as credit,"
                        + "\r\nSUM(credit-debit) AS net_credit,"
                        + "\r\ntb.id chart_credit_id,"
                        + "\r\ntb.aname chart_credit_name,"
                        + "tb.level level_credit, tb.parent parent_credit, tb.menue_id, tb.side_id"
                        + "\r\nFROM "+tb+" tb"
                        + "\r\n" + "WHERE level <= " + level + " AND tb.menue_id = '1' AND tb.side_id = '2'"
                        + "\r\n GROUP BY tb.id, tb.aname, level, tb.parent, tb.menue_id, tb.side_id;";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(s);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("net_debit");
                    dt.Columns.Add("chart_debit_name");
                    dt.Columns.Add("chart_debit_id");
                    dt.Columns.Add("level_debit");
                    dt.Columns.Add("parent_debit");

                    dt.Columns.Add("net_credit");
                    dt.Columns.Add("chart_credit_name");
                    dt.Columns.Add("chart_credit_id");
                    dt.Columns.Add("level_credit");
                    dt.Columns.Add("parent_credit");

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dr["net_debit"] = Convert.ToDecimal(dr["debit"]) - Convert.ToDecimal(dr["credit"]);
                    }
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        dr["net_credit"] = Convert.ToDecimal(dr["credit"]) - Convert.ToDecimal(dr["debit"]);
                    }

                    //Remove record which not has balance
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["net_debit"] is DBNull)
                        {
                            ds.Tables[0].Rows.RemoveAt(i);
                            i--;
                        }
                        else if (Convert.ToDecimal(ds.Tables[0].Rows[i]["net_debit"]) == 0)
                        {
                            ds.Tables[0].Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        if (ds.Tables[1].Rows[i]["net_credit"] is DBNull)
                        {
                            ds.Tables[1].Rows.RemoveAt(i);
                            i--;
                        }
                        else if (Convert.ToDecimal(ds.Tables[1].Rows[i]["net_credit"]) == 0)
                        {
                            ds.Tables[1].Rows.RemoveAt(i);
                            i--;
                        }
                    }

                    if (LastLevel)
                    {
                        ds.Tables[0].DefaultView.RowFilter = "parent_debit = false";
                        ds.Tables[1].DefaultView.RowFilter = "parent_credit = false";
                    }

                    if (ds.Tables[0].DefaultView.Count >= ds.Tables[1].DefaultView.Count)
                    {
                        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                        {
                            dt.Rows.Add();
                            dt.Rows[i]["net_debit"] = ds.Tables[0].DefaultView[i]["net_debit"].ToString();
                            dt.Rows[i]["chart_debit_name"] = ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString();
                            dt.Rows[i]["chart_debit_id"] = ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString();
                            dt.Rows[i]["level_debit"] = ds.Tables[0].DefaultView[i]["level_debit"].ToString();
                            dt.Rows[i]["parent_debit"] = ds.Tables[0].DefaultView[i]["parent_debit"].ToString();

                            //dt.Rows.Add(ds.Tables[0].DefaultView[i]["net_debit"].ToString(),
                            //            ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString(),
                            //            ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString(),
                            //            ds.Tables[0].DefaultView[i]["level_debit"].ToString(),
                            //            ds.Tables[0].DefaultView[i]["parent_debit"].ToString()
                            //    );
                            if (ds.Tables[1].DefaultView.Count >= i + 1)
                            {
                                dt.Rows[i]["net_credit"] = ds.Tables[1].DefaultView[i]["net_credit"].ToString();
                                dt.Rows[i]["chart_credit_name"] = ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString();
                                dt.Rows[i]["chart_credit_id"] = ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString();
                                dt.Rows[i]["level_credit"] = ds.Tables[1].DefaultView[i]["level_credit"].ToString();
                                dt.Rows[i]["parent_credit"] = ds.Tables[1].DefaultView[i]["parent_credit"].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables[1].DefaultView.Count; i++)
                        {
                            dt.Rows.Add();
                            dt.Rows[i]["net_credit"] = ds.Tables[1].DefaultView[i]["net_credit"].ToString();
                            dt.Rows[i]["chart_credit_name"] = ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString();
                            dt.Rows[i]["chart_credit_id"] = ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString();
                            dt.Rows[i]["level_credit"] = ds.Tables[1].DefaultView[i]["level_credit"].ToString();
                            dt.Rows[i]["parent_credit"] = ds.Tables[1].DefaultView[i]["parent_credit"].ToString();

                            //dt.Rows.Add(ds.Tables[1].DefaultView[i]["net_credit"].ToString(),
                            //            ds.Tables[1].DefaultView[i]["chart_credit_name"].ToString(),
                            //            ds.Tables[1].DefaultView[i]["chart_credit_id"].ToString(),
                            //            ds.Tables[1].DefaultView[i]["level_credit"].ToString(),
                            //            ds.Tables[1].DefaultView[i]["parent_credit"].ToString()
                            //);

                            if (ds.Tables[0].DefaultView.Count >= i + 1)
                            {
                                dt.Rows[i]["net_debit"] = ds.Tables[0].DefaultView[i]["net_debit"].ToString();
                                dt.Rows[i]["chart_debit_name"] = ds.Tables[0].DefaultView[i]["chart_debit_name"].ToString();
                                dt.Rows[i]["chart_debit_id"] = ds.Tables[0].DefaultView[i]["chart_debit_id"].ToString();
                                dt.Rows[i]["level_debit"] = ds.Tables[0].DefaultView[i]["level_debit"].ToString();
                                dt.Rows[i]["parent_debit"] = ds.Tables[0].DefaultView[i]["parent_debit"].ToString();
                            }
                        }
                    }

                    ds.Tables.Add(dt);
                    return ds;
                }
            }
            public struct Rep
            {
                #region properties
                public int id { get; set; }
                public string Name { get; set; }
                public string Content { get; set; }
                public int Row_Count { get; set; }
                public bool Row_Index { get; set; }
                public int Font_Size { get; set; }
                public string Rep_View { get; set; }
                public string User_ID { get; set; }
                public string company_id { get; set; }
                public DataTable RepD { get; set; }
                #endregion

                public DataSet Select(string txt)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();

                    DataSet ds = new DataSet();
                    ds = dal.ExecuteAndRetriveDataSet(txt);

                    return ds;
                }
                public DataSet Select_RepInfo(string viw_Name, string schema_name)
                {
                    string s = "SELECT column_name, data_type FROM information_schema.columns WHERE table_schema = '"+ schema_name + "' AND table_name = '"+ viw_Name + "'";

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet(s);

                    return ds;
                }

                public DataSet Insert()
                {
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    string json = JsonConvert.SerializeObject(RepD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Integer);
                    param[0].Value = id;

                    param[1] = new NpgsqlParameter("@in_name", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = Name;

                    param[2] = new NpgsqlParameter("@in_content", NpgsqlTypes.NpgsqlDbType.Text);
                    param[2].Value = Content;

                    param[3] = new NpgsqlParameter("@in_rowcount", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[3].Value = Row_Count;

                    param[4] = new NpgsqlParameter("@in_rowindex", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[4].Value = Row_Index;

                    param[5] = new NpgsqlParameter("@in_fontsize", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[5].Value = Font_Size;

                    param[6] = new NpgsqlParameter("@in_view", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = "acc.viw_repjor";

                    param[7] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, 4);
                    param[7].Value = User_ID;

                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[8].Value = company_id;

                    param[9] = new NpgsqlParameter("@in_repd", NpgsqlTypes.NpgsqlDbType.Json);
                    param[9].Value = json;

                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = dal.ExecuteAndRetriveDataSet("grl.fnc_rep_insert", param);

                    return ds;
                }
                public DataSet Select_Rep(string Rep_Name)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();

                    DataSet ds = dal.ExecuteAndRetriveDataSet(Rep_Name);

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[1];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Integer);
                    param[0].Value = id;


                    DataSet ds = dal.ExecuteAndRetriveDataSet("Rep_Delete", param);

                    return ds;
                }
            }

            #region Accounting_Settings
            public struct stc_Settings
            {
                public struct stc_chart
                {
                    #region properties
                    public string id { get; set; }
                    public string aname { get; set; }
                    public string ename { get; set; }
                    public string menue_id { get; set; }
                    public string side_id { get; set; }
                    public string ccrelation_id { get; set; }
                    public string cc1_id { get; set; }
                    public string cc2_id { get; set; }
                    public string property_id { get; set; }
                    public string company_id { get; set; }
                    public string branch_id { get; set; }
                    public string notes { get; set; }
                    public bool stop { get; set; }
                    public DateTime? activetime { get; set; }
                    public string parent_id { get; set; }
                    public string user_id { get; set; }
                    #endregion

                    public DataSet Select()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        DataSet ds = new DataSet();
                        ds = dal.ExecuteAndRetriveDataSet("SELECT *, (select count(chart_id) from acc.tbl_jord where chart_id = c.id) as used From acc.tbl_chart c ORDER BY sequ;"
                                                        + "SELECT * From acc.tbl_chartlists ORDER BY id;"
                                                        + "SELECT * From acc.tbl_chartside ORDER BY id;"
                                                        + "SELECT * From acc.tbl_chartccrelation ORDER BY id;"
                                                        + "SELECT * From acc.tbl_chartprop ORDER BY id;"
                                                        + "SELECT * From grl.tbl_branches ORDER BY sequ;");

                        ds.Tables[0].TableName = "tbl_chart";
                        ds.Tables[1].TableName = "tbl_chartlists";
                        ds.Tables[2].TableName = "tbl_chartside";
                        ds.Tables[3].TableName = "tbl_chartccrelation";
                        ds.Tables[4].TableName = "tbl_chartprop";
                        ds.Tables[5].TableName = "tbl_branches";

                        return ds;
                    }
                    public DataSet Insert()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[16];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_menue_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[3].Value = menue_id;
                        param[4] = new NpgsqlParameter("@in_side_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[4].Value = side_id;
                        param[5] = new NpgsqlParameter("@in_ccrelation_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[5].Value = ccrelation_id;
                        param[6] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[6].Value = cc1_id;
                        param[7] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[7].Value = cc2_id;
                        param[8] = new NpgsqlParameter("@in_property_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[8].Value = property_id;
                        param[9] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[9].Value = company_id;
                        param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[10].Value = branch_id;
                        param[11] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[11].Value = notes;
                        param[12] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[12].Value = stop;
                        param[13] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                        param[13].Value = activetime;
                        param[14] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[14].Value = parent_id;
                        param[15] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[15].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_chart_insert", param); ;
                    }
                    public DataSet Update()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[16];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_menue_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[3].Value = menue_id;
                        param[4] = new NpgsqlParameter("@in_side_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[4].Value = side_id;
                        param[5] = new NpgsqlParameter("@in_ccrelation_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[5].Value = ccrelation_id;
                        param[6] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[6].Value = cc1_id;
                        param[7] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[7].Value = cc2_id;
                        param[8] = new NpgsqlParameter("@in_property_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[8].Value = property_id;
                        param[9] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[9].Value = company_id;
                        param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[10].Value = branch_id;
                        param[11] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[11].Value = notes;
                        param[12] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[12].Value = stop;
                        param[13] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                        param[13].Value = activetime;
                        param[14] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[14].Value = parent_id;
                        param[15] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[15].Value = user_id;


                        return dal.ExecuteAndRetriveDataSet("acc.fnc_chart_update", param);
                    }
                    public DataSet Delete()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[3];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar,50);
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[1].Value = company_id;
                        param[2] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[2].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_chart_delete", param);
                    }
                }

                public struct stc_cc
                {
                    #region properties
                    public string id { get; set; }
                    public string aname { get; set; }
                    public string ename { get; set; }
                    public bool cc1 { get; set; }
                    public bool cc2 { get; set; }
                    public string company_id { get; set; }
                    public string branch_id { get; set; }
                    public string notes { get; set; }
                    public bool stop { get; set; }
                    public DateTime? activetime { get; set; }
                    public string parent_id { get; set; }
                    public string user_id { get; set; }
                    #endregion

                    public DataSet Select()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        DataSet ds = new DataSet();
                        ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM acc.tbl_cc WHERE company_id = '"+company_id+"' ORDER BY sequ;"
                                                        + "SELECT * FROM grl.tbl_branches WHERE stop = 'false' AND company_id = '" + company_id + "' ORDER BY sequ;");

                        ds.Tables[0].TableName = "tbl_chart";
                        ds.Tables[1].TableName = "tbl_branches";

                        return ds;
                    }
                    public DataSet Insert()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[12];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_cc1", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[3].Value = cc1;
                        param[4] = new NpgsqlParameter("@in_cc2", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[4].Value = cc2;
                        param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[5].Value = company_id;
                        param[6] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[6].Value = branch_id;
                        param[7] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[7].Value = notes;
                        param[8] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[8].Value = stop;
                        param[9] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                        param[9].Value = activetime;
                        param[10] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[10].Value = parent_id;
                        param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[11].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_cc_insert", param); ;
                    }
                    public DataSet Update()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[12];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_cc1", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[3].Value = cc1;
                        param[4] = new NpgsqlParameter("@in_cc2", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[4].Value = cc2;
                        param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[5].Value = company_id;
                        param[6] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[6].Value = branch_id;
                        param[7] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[7].Value = notes;
                        param[8] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[8].Value = stop;
                        param[9] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                        param[9].Value = activetime;
                        param[10] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[10].Value = parent_id;
                        param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[11].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_cc_update", param);
                    }
                    public DataSet Delete()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[3];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 50);
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[1].Value = user_id;
                        param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[2].Value = company_id;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_cc_delete", param);
                    }
                }

                public struct stc_close
                {
                    #region properties
                    public string company_id { get; set; }
                    public DataTable branches { get; set; }
                    public string oldfyear { get; set; }
                    public string newfyear { get; set; }
                    public Boolean cc { get; set; }
                    public string user_id { get; set; }
                    public DateTime? date { get; set; }
                    public string notes { get; set; }
                    #endregion

                    public DataSet Select()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        DataSet ds = new DataSet();
                        ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_fyears WHERE stop = 'false' AND company_id = '" + company_id + "' ORDER BY sequ DESC;"
                                                        + "SELECT * FROM grl.tbl_fyears WHERE stop = 'false' AND company_id = '" + company_id + "' ORDER BY sequ DESC;");

                        ds.Tables[0].TableName = "tbl_newfyear";
                        ds.Tables[1].TableName = "tbl_oldfyear";

                        return ds;
                    }
                    public DataSet Select_Chart()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        return dal.ExecuteAndRetriveDataSet("SELECT * FROM acc.tbl_chart WHERE stop = 'false' AND company_id = '" + company_id + "' AND parent = 'false' AND property_id = '4';"
                                                          + "SELECT * FROM acc.tbl_chart WHERE stop = 'false' AND company_id = '" + company_id + "' AND parent = 'false' AND property_id = '5';");
                    }
                    public DataSet Close()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        string json = JsonConvert.SerializeObject(branches, Formatting.Indented);

                        NpgsqlParameter[] param = new NpgsqlParameter[8];

                        param[0] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Text);
                        param[0].Value = company_id;
                        param[1] = new NpgsqlParameter("@in_branches_ids", NpgsqlTypes.NpgsqlDbType.Json);
                        param[1].Value = json;
                        param[2] = new NpgsqlParameter("@in_oldfyear_id", NpgsqlTypes.NpgsqlDbType.Text);
                        param[2].Value = oldfyear;
                        param[3] = new NpgsqlParameter("@in_newfyear_id", NpgsqlTypes.NpgsqlDbType.Text);
                        param[3].Value = newfyear;
                        param[4] = new NpgsqlParameter("@in_cc", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[4].Value = cc;
                        param[5] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Text);
                        param[5].Value = user_id;
                        param[6] = new NpgsqlParameter("@in_date", NpgsqlTypes.NpgsqlDbType.Timestamp);
                        param[6].Value = date;
                        param[7] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[7].Value = notes;

                        return dal.ExecuteAndRetriveDataSet("acc.fnc_jor_close", param); ;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region General_Settings
        public struct stc_General_Settings
        {
            public struct stc_companies
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public DateTime? activetime { get; set; }
                public string user_id { get; set; }
                public string company_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    return dal.ExecuteAndRetriveDataSet("Select * From grl.tbl_companies Where stop = 'false' order by sequ");
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[8];


                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = notes;
                    param[4] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[4].Value = stop;
                    param[5] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[5].Value = activetime;
                    param[6] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[6].Value = user_id;
                    param[7] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[7].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_companies_insert", param); ;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[8];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = notes;
                    param[4] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[4].Value = stop;
                    param[5] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[5].Value = activetime;
                    param[6] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[6].Value = user_id;
                    param[7] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[7].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_companies_update", param);
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_companies_delete", param);
                }
            }
            public struct stc_branches
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string mobile1 { get; set; }
                public string mobile2 { get; set; }
                public string phone1 { get; set; }
                public string phone2 { get; set; }
                public string email { get; set; }
                public string company_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public DateTime? activetime { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_branches WHERE company_id = '"+ company_id +"' order by sequ;"
                                                    + "SELECT * FROM grl.tbl_companies WHERE  stop = 'false' order by sequ;");
                    ds.Tables[0].TableName = "tbl_branches";
                    ds.Tables[1].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = mobile1;
                    param[4] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile2;
                    param[5] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = phone1;
                    param[6] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone2;
                    param[7] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = email;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[9].Value = notes;
                    param[10] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[10].Value = stop;
                    param[11] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[11].Value = activetime;
                    param[12] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[12].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_branches_insert", param); ;
                    ds.Tables[0].TableName = "tbl_branches";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = mobile1;
                    param[4] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile2;
                    param[5] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = phone1;
                    param[6] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone2;
                    param[7] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = email;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[9].Value = notes;
                    param[10] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[10].Value = stop;
                    param[11] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[11].Value = activetime;
                    param[12] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[12].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_branches_update", param);
                    ds.Tables[0].TableName = "tbl_branches";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_branches_delete", param);
                    ds.Tables[0].TableName = "tbl_branches";

                    return ds;
                }
            }
            public struct stc_stores
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string responame { get; set; }
                public string mobile1 { get; set; }
                public string mobile2 { get; set; }
                public string phone1 { get; set; }
                public string phone2 { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public DateTime? activetime { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_stores s WHERE  s.branch_id = '" + branch_id + "' AND  s.company_id = '" + company_id + "' AND s.stop = 'false' ORDER BY s.sequ;"
                                                    + "SELECT * FROM grl.tbl_branches b WHERE b.company_id = '" + company_id + "' AND b.stop = 'false' ORDER BY b.sequ;"
                                                    + "SELECT * FROM grl.tbl_companies c WHERE  c.stop = 'false' order by c.sequ;");

                    ds.Tables[0].TableName = "tbl_stores";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[14];
                    DataSet ds = new DataSet();


                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_responame", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = responame;
                    param[4] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile1;
                    param[5] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = mobile2;
                    param[6] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone1;
                    param[7] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = phone2;
                    param[8] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[8].Value = notes;
                    param[9] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[9].Value = stop;
                    param[10] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[10].Value = activetime;
                    param[11] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[11].Value = branch_id;
                    param[12] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[12].Value = company_id;
                    param[13] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[13].Value = user_id;


                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_stores_insert", param); ;
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[14];
                    DataSet ds = new DataSet();


                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_responame", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = responame;
                    param[4] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile1;
                    param[5] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = mobile2;
                    param[6] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone1;
                    param[7] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = phone2;
                    param[8] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[8].Value = notes;
                    param[9] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[9].Value = stop;
                    param[10] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[10].Value = activetime;
                    param[11] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[11].Value = branch_id;
                    param[12] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[12].Value = company_id;
                    param[13] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[13].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_stores_update", param);
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[4];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[1].Value = branch_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;
                    param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[3].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_stores_delete", param);
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
            }
            public struct stc_fyears
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public DateTime beigndate { get; set; }
                public DateTime enddate { get; set; }
                public string company_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public DateTime? activetime { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_fyears WHERE company_id = '"+company_id+"' ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_companies WHERE  stop = 'false' ORDER BY sequ;");
                    ds.Tables[0].TableName = "tbl_fyears";
                    ds.Tables[1].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_beigndate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[3].Value = beigndate;
                    param[4] = new NpgsqlParameter("@in_enddate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[4].Value = enddate;
                    param[5] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[5].Value = notes;
                    param[6] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[6].Value = company_id;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[8].Value = activetime;
                    param[9] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[9].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_fyears_insert", param); ;
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[10];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_beigndate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[3].Value = beigndate;
                    param[4] = new NpgsqlParameter("@in_enddate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[4].Value = enddate;
                    param[5] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[5].Value = notes;
                    param[6] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[6].Value = company_id;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[8].Value = activetime;
                    param[9] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[9].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_fyears_update", param);
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_fyears_delete", param);
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
            }
            public struct stc_currencies
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string asymbol { get; set; }
                public string esymbol { get; set; }
                public decimal price { get; set; }           
                public string notes { get; set; }
                public bool stop { get; set; }
                public DateTime? activetime { get; set; }
                public string user_id { get; set; }
                public string branch_id { get; set; }
                public string company_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("Select * From grl.tbl_currencies order by sequ;");

                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[12];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_asymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = asymbol;
                    param[4] = new NpgsqlParameter("@in_esymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = esymbol;
                    param[5] = new NpgsqlParameter("@in_price", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[5].Value = price;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[8].Value = activetime;
                    param[9] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[9].Value = user_id;
                    param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[10].Value = branch_id;
                    param[11] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[11].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_currencies_insert", param); ;
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[12];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_asymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = asymbol;
                    param[4] = new NpgsqlParameter("@in_esymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = esymbol;
                    param[5] = new NpgsqlParameter("@in_price", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[5].Value = price;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[8].Value = activetime;
                    param[9] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[9].Value = user_id;
                    param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[10].Value = branch_id;
                    param[11] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[11].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_currencies_update", param);
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_currencies_delete", param);
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
            }
            public struct stc_users
            {
                #region properties
                public string id { get; set; }//----------------------------------1
                public string aname { get; set; }//-------------------------------2
                public string ename { get; set; }//-------------------------------3
                public string password { get; set; }//----------------------------4
                public int gender_id { get; set; }//------------------------------5
                public string jobtitle { get; set; }//----------------------------6
                public string mobile1 { get; set; }//-----------------------------7
                public string mobile2 { get; set; }//-----------------------------8
                public string phone1 { get; set; }//------------------------------9
                public string phone2 { get; set; }//------------------------------10
                public string email { get; set; }//-------------------------------11
                public string permission_id { get; set; }//-----------------------12
                public string blockedcompanies_ids { get; set; }//----------------13
                public string blockedbranches_ids { get; set; }//-----------------14
                public string blockedstores_ids { get; set; }//-------------------15
                public string blockedfyears_ids { get; set; }//-------------------16
                public string defaultcompany_id { get; set; }//-------------------17
                public string defaultbranch_id { get; set; }//--------------------18
                public string defaultstore_id { get; set; }//---------------------19
                public string defaultfyear_id { get; set; }//---------------------20
                public string notes { get; set; }//-------------------------------21
                public bool stop { get; set; }//----------------------------------22
                public DateTime? activetime { get; set; }//-----------------------23
                public string user_id { get; set; }//-----------------------------24
                public string branch_id { get; set; }//---------------------------25
                public string company_id { get; set; }//--------------------------26
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();
                    
                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_users ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_gender ORDER BY id;"
                                                    + "SELECT * FROM grl.tbl_companies ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_branches ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_stores ORDER BY sequ;"
                                                    + "SELECT * FROM grl.tbl_fyears ORDER BY sequ;");
                    ds.Tables[0].TableName = "users";
                    ds.Tables[1].TableName = "gender";
                    ds.Tables[2].TableName = "companies";
                    ds.Tables[3].TableName = "branches";
                    ds.Tables[4].TableName = "stores";
                    ds.Tables[5].TableName = "fyears";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[26];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_password", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = password;
                    param[4] = new NpgsqlParameter("@in_gender_id", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[4].Value = gender_id;
                    param[5] = new NpgsqlParameter("@in_jobtitle", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = jobtitle;
                    param[6] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = mobile1;
                    param[7] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = mobile2;
                    param[8] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = phone1;
                    param[9] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = phone2;
                    param[10] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[10].Value = email;
                    param[11] = new NpgsqlParameter("@in_permission_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[11].Value = permission_id;
                    param[12] = new NpgsqlParameter("@in_blockedcompanies_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[12].Value = blockedcompanies_ids;
                    param[13] = new NpgsqlParameter("@in_blockedbranches_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[13].Value = blockedbranches_ids;
                    param[14] = new NpgsqlParameter("@in_blockedstores_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[14].Value = blockedstores_ids;
                    param[15] = new NpgsqlParameter("@in_blockedfyears_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[15].Value = blockedfyears_ids;
                    param[16] = new NpgsqlParameter("@in_defaultcompany_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[16].Value = defaultcompany_id;
                    param[17] = new NpgsqlParameter("@in_defaultbranch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[17].Value = defaultbranch_id;
                    param[18] = new NpgsqlParameter("@in_defaultstore_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[18].Value = defaultstore_id;
                    param[19] = new NpgsqlParameter("@in_defaultfyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[19].Value = defaultfyear_id;
                    param[20] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[20].Value = notes;
                    param[21] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[21].Value = stop;
                    param[22] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[22].Value = activetime;
                    param[23] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[23].Value = user_id;
                    param[24] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[24].Value = branch_id;
                    param[25] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[25].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_users_insert", param); ;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[26];
                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_password", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = password;
                    param[4] = new NpgsqlParameter("@in_gender_id", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[4].Value = gender_id;
                    param[5] = new NpgsqlParameter("@in_jobtitle", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = jobtitle;
                    param[6] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = mobile1;
                    param[7] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = mobile2;
                    param[8] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = phone1;
                    param[9] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = phone2;
                    param[10] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[10].Value = email;
                    param[11] = new NpgsqlParameter("@in_permission_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[11].Value = permission_id;
                    param[12] = new NpgsqlParameter("@in_blockedcompanies_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[12].Value = blockedcompanies_ids;
                    param[13] = new NpgsqlParameter("@in_blockedbranches_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[13].Value = blockedbranches_ids;
                    param[14] = new NpgsqlParameter("@in_blockedstores_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[14].Value = blockedstores_ids;
                    param[15] = new NpgsqlParameter("@in_blockedfyears_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[15].Value = blockedfyears_ids;
                    param[16] = new NpgsqlParameter("@in_defaultcompany_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[16].Value = defaultcompany_id;
                    param[17] = new NpgsqlParameter("@in_defaultbranch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[17].Value = defaultbranch_id;
                    param[18] = new NpgsqlParameter("@in_defaultstore_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[18].Value = defaultstore_id;
                    param[19] = new NpgsqlParameter("@in_defaultfyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[19].Value = defaultfyear_id;
                    param[20] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[20].Value = notes;
                    param[21] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[21].Value = stop;
                    param[22] = new NpgsqlParameter("@in_activetime", NpgsqlTypes.NpgsqlDbType.Timestamp);
                    param[22].Value = activetime;
                    param[23] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[23].Value = user_id;
                    param[24] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[24].Value = branch_id;
                    param[25] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[25].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_users_update", param);
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[3];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 4);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;
                    param[2] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[2].Value = company_id;

                    return dal.ExecuteAndRetriveDataSet("grl.fnc_users_delete", param);
                }
            }


            public struct stc_perm
            {
                public DataSet Select(string user_id)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_permgroup order by module_id,id;"
                                                    + "SELECT * FROM grl.tbl_perm WHERE id NOT IN (SELECT perm_id FROM grl.tbl_permuser WHERE user_id = '" + user_id + "')  order by id;"
                                                    + "SELECT * FROM grl.tbl_perm WHERE id IN (SELECT perm_id FROM grl.tbl_permuser WHERE user_id = '" + user_id + "')  order by id;"
                                                    + "SELECT * FROM grl.tbl_permuser WHERE user_id = '" + user_id + "';"
                                                    );
                    ds.Tables[0].TableName = "tbl_permgroup";
                    ds.Tables[1].TableName = "tbl_perm";
                    ds.Tables[2].TableName = "tbl_AllowedPerm";
                    ds.Tables[3].TableName = "tbl_permuser";
                    return ds;
                }
                public DataSet Insert(string user_id, string s)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    s = "INSERT INTO grl.tbl_permuser(user_id, perm_id)VALUES" + s;

                    dal.ExecuteAndRetriveDataSet(s);

                    return Select(user_id);
                }
                public DataSet Delete(string user_id, string s)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    s = "DELETE FROM grl.tbl_permuser WHERE user_id = '" + user_id + "' AND perm_id IN" + s;

                    dal.ExecuteAndRetriveDataSet(s);

                    return Select(user_id);
                }

            }

            public struct stc_SystemSettings
            {
                public DataSet ResetData()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();


                    return dal.ExecuteAndRetriveDataSet(Properties.Resources.ResetData);
                }
            }

            public struct stc_print
            {
                #region Prop
                public int id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string frm { get; set; }
                public string pagetype { get; set; }
                public decimal pagew { get; set; }
                public decimal pageh { get; set; }
                public decimal repheaderh { get; set; }
                public decimal pageheaderh { get; set; }
                public decimal detailsh { get; set; }
                public decimal pagefooterh { get; set; }
                public decimal repfooterh { get; set; }
                public string notes { get; set; }
                public string user_id { get; set; }
                public string company_id { get; set; }
                public DataTable printD { get; set; }
                #endregion

                public DataSet Select(string txt)
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet(txt);

                    return ds;
                }
                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("SELECT * FROM grl.tbl_print order by id;"
                                                    + "SELECT * FROM grl.tbl_printd;"
                                                    + "SELECT * FROM grl.tbl_printav;"
                                                    );
                    ds.Tables[0].TableName = "tbl_print";
                    ds.Tables[1].TableName = "tbl_printd";
                    ds.Tables[2].TableName = "tbl_printav";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[16];
                    DataSet ds = new DataSet();

                    string json = JsonConvert.SerializeObject(printD, Formatting.Indented);

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Integer);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Text);
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Text);
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_frm", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = frm;
                    param[4] = new NpgsqlParameter("@in_pagetype", NpgsqlTypes.NpgsqlDbType.Text);
                    param[4].Value = pagetype;
                    param[5] = new NpgsqlParameter("@in_pagew", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[5].Value = pagew;
                    param[6] = new NpgsqlParameter("@in_pageh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[6].Value = pageh;
                    param[7] = new NpgsqlParameter("@in_repheaderh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[7].Value = repheaderh;
                    param[8] = new NpgsqlParameter("@in_pageheaderh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[8].Value = pageheaderh;
                    param[9] = new NpgsqlParameter("@in_detailsh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[9].Value = detailsh;
                    param[10] = new NpgsqlParameter("@in_pagefooterh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[10].Value = pagefooterh;
                    param[11] = new NpgsqlParameter("@in_repfooterh", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[11].Value = repfooterh;
                    param[12] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[12].Value = notes;
                    param[13] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[13].Value = user_id;
                    param[14] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[14].Value = company_id;
                    param[15] = new NpgsqlParameter("@in_printd", NpgsqlTypes.NpgsqlDbType.Json);
                    param[15].Value = json;

                    ds = dal.ExecuteAndRetriveDataSet("grl.fnc_print_insert", param); ;
                    ds.Tables[0].TableName = "tbl_print";

                    return ds;
                }
            }
        }
        #endregion
    }
}
