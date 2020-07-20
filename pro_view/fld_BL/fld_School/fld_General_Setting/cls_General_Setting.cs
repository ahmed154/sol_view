using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_view.fld_BL.fld_School.fld_General_Setting
{
    class cls_General_Setting
    {
        
        public struct stc_nationality
        {
            
            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From grl.tbl_nationality order by sequ;");
                ds.Tables[0].TableName = "tbl_nationality";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[5];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_nationality_insert", param); ;
                ds.Tables[0].TableName = "tbl_nationality";
                

                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[5];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;


                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_nationality_update", param);
                ds.Tables[0].TableName = "tbl_nationality";
                
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

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_nationality_delete", param);
                ds.Tables[0].TableName = "tbl_nationality";

                return ds;
            }
        }

        public struct stc_cities
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public string country_id { get; set; }
            #endregion


            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From grl.tbl_cities order by sequ;"
                                                    + "Select * From grl.tbl_nationality order by sequ;");
                ds.Tables[0].TableName = "tbl_cities";
                ds.Tables[1].TableName = "tbl_nationality";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_country_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[5].Value = country_id;

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_cities_insert", param); ;
                ds.Tables[0].TableName = "tbl_cities";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_country_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[4].Value = country_id;
                param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[5].Value = company_id;

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_cities_update", param);
                ds.Tables[0].TableName = "tbl_cities";

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

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_cities_delete", param);
                ds.Tables[0].TableName = "tbl_cities";

                return ds;
            }
        }

        public struct stc_areas
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public string city_id { get; set; }
            #endregion


            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From grl.tbl_areas order by sequ;"
                                                    + "Select id,aname,ename From grl.tbl_cities order by sequ;");
                ds.Tables[0].TableName = "tbl_areas";
                ds.Tables[1].TableName = "tbl_cities";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_city_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[5].Value = city_id;


                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_areas_insert", param); ;
                ds.Tables[0].TableName = "tbl_areas";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_city_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[4].Value = city_id;
                param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[5].Value = company_id;

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_areas_update", param);
                ds.Tables[0].TableName = "tbl_areas";

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

                ds = dal.ExecuteAndRetriveDataSet("grl.fnc_areas_delete", param);
                ds.Tables[0].TableName = "tbl_areas";

                return ds;
            }
        }

        public struct stc_stages
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From scl.tbl_stages order by sequ;");
                ds.Tables[0].TableName = "tbl_stages";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_stages_insert", param); ;
                ds.Tables[0].TableName = "tbl_stages";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;


                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_stages_update", param);
                ds.Tables[0].TableName = "tbl_stages";

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

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_stages_delete", param);
                ds.Tables[0].TableName = "tbl_stages";

                return ds;
            }
        }


        public struct stc_rows
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From scl.tbl_rows order by sequ;");
                ds.Tables[0].TableName = "tbl_rows";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_rows_insert", param); ;
                ds.Tables[0].TableName = "tbl_rows";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;


                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_rows_update", param);
                ds.Tables[0].TableName = "tbl_rows";

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

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_rows_delete", param);
                ds.Tables[0].TableName = "tbl_rows";

                return ds;
            }
        }

        public struct stc_class
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From scl.tbl_class order by sequ;");
                ds.Tables[0].TableName = "tbl_class";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_class_insert", param); ;
                ds.Tables[0].TableName = "tbl_class";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;


                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_class_update", param);
                ds.Tables[0].TableName = "tbl_class";

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

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_class_delete", param);
                ds.Tables[0].TableName = "tbl_class";

                return ds;
            }
        }

        public struct stc_study
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From scl.tbl_study order by sequ;");
                ds.Tables[0].TableName = "tbl_study";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_study_insert", param); ;
                ds.Tables[0].TableName = "tbl_study";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;


                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_study_update", param);
                ds.Tables[0].TableName = "tbl_study";

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

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_study_delete", param);
                ds.Tables[0].TableName = "tbl_study";

                return ds;
            }
        }

        public struct stc_section
        {

            #region properties
            public string id { get; set; }
            public string aname { get; set; }
            public string ename { get; set; }
            public string user_id { get; set; }
            public string company_id { get; set; }
            public bool stop { get; set; }
            #endregion

            public DataSet Select()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                DataSet ds = new DataSet();

                ds = dal.ExecuteAndRetriveDataSet("Select * From scl.tbl_section order by sequ;");
                ds.Tables[0].TableName = "tbl_section";
                return ds;
            }
            public DataSet Insert()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_section_insert", param); ;
                ds.Tables[0].TableName = "tbl_section";


                return ds;
            }
            public DataSet Update()
            {
                pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                NpgsqlParameter[] param = new NpgsqlParameter[6];
                DataSet ds = new DataSet();

                param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[0].Value = id;
                param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[1].Value = aname;
                param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                param[2].Value = ename;
                param[3] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                param[3].Value = user_id;
                param[4] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                param[4].Value = company_id;
                param[5] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                param[5].Value = stop;


                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_section_update", param);
                ds.Tables[0].TableName = "tbl_section";

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

                ds = dal.ExecuteAndRetriveDataSet("scl.fnc_section_delete", param);
                ds.Tables[0].TableName = "tbl_section";

                return ds;
            }
        }
    }
}
