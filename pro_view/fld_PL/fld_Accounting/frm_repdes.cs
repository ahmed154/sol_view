using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting
{
    public partial class frm_repdes : Form
    {
        #region Declaration
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_Accounting.Rep bl = new fld_BL.cls_bl.stc_Accounting.Rep();

        string SCHEMA_NAME;
        string VIEW_NAME;

        DataTable Temp_dgv;
        DataRow dr_g;

        DataSet ds = new DataSet();
        DataTable dt_Rep = new DataTable();
        DataTable dt_Rep_Info = new DataTable();

        ListBox lst_Translated = new ListBox();

        #region Generate SQL
        string fields;
        string union;
        string where;
        string operand;
        string from;

        string condition;
        string condition_and_or;
        string condition_operand;
        string condition_not;
        #endregion

        #region ExportToExcel
        Microsoft.Office.Interop.Excel.Range myRange;
        Microsoft.Office.Interop.Excel.Range lastcol;
        Microsoft.Office.Interop.Excel.Range firstrow;
        private int you;
        private object me;
        #endregion

        #endregion

        public frm_repdes(fld_Login.frm_main frm_MAIN, string schema_name, string view_name)
        {
            InitializeComponent();

            frm_main = frm_MAIN;
            SCHEMA_NAME = schema_name;
            VIEW_NAME = view_name;

            //tab_dis.TabPages.RemoveAt(2);

            //dtp = new DateTimePicker();
            //dtp.Format = DateTimePickerFormat.Short;
            //dtp.Visible = false;
            //dtp.Width = 120;
            //dgv_Conditions.Controls.Add(dtp);
            //dtp.ValueChanged += this.dtp_Value_Changed;



            ds = bl.Select("SELECT * FROM grl.tbl_rep WHERE  view = '" + SCHEMA_NAME + "." + VIEW_NAME + "' AND user_id = '" + frm_main.com_users.SelectedValue.ToString() + "' AND company_id = '" + frm_main.com_companies.SelectedValue.ToString()+"';"
                         + "SELECT * FROM grl.tbl_repd WHERE view = '" + SCHEMA_NAME + "." + VIEW_NAME + "' AND user_id = '" + frm_main.com_users.SelectedValue.ToString() + "' AND company_id = '" + frm_main.com_companies.SelectedValue.ToString() + "';");


            com_SelectedRep.ValueMember = "id";
            com_SelectedRep.DisplayMember = "name";
            com_SelectedRep.DataSource = ds.Tables[0];
            com_SelectedRep.SelectedValue = -1;

            //dt_RepD = rep.Select_Rep("select * from RepD");
            //dt_g.DefaultView.RowFilter = string.Format("Rep_View = '" + Rep_TABLE_NAME + "' and User_ID = " + UserID.ToString());


            //if (com_SelectedRep.SelectedValue == null)
            //{
            //    dt_RepD.DefaultView.RowFilter = string.Format("Rep_ID = -1 ");
            //}
            //else
            //{
            //    dt_RepD.DefaultView.RowFilter = string.Format("Rep_ID = " + com_SelectedRep.SelectedValue.ToString());
            //}
            //dgv_Conditions.AutoGenerateColumns = false;

            //Temp_dgv = table(1);
            //dgv_Conditions.DataSource = null;
            //foreach (DataRow row in Temp_dgv.Rows)
            //{
            //    dgv_Conditions.Rows.Add();
            //    dgv_Conditions.CurrentCell = dgv_Conditions.Rows[0].Cells[0];

            //    dgv_Conditions.CurrentRow.Cells[0].Value = row[0].ToString();
            //    dgv_Conditions.CurrentRow.Cells[1].Value = row[1].ToString();
            //    dgv_Conditions.CurrentRow.Cells[2].Value = row[2].ToString();
            //    dgv_Conditions.CurrentRow.Cells[3].Value = row[3].ToString();
            //    dgv_Conditions.CurrentRow.Cells[4].Value = row[4].ToString();
            //    dgv_Conditions.CurrentRow.Cells[5].Value = row[5].ToString();
            //    dgv_Conditions.CurrentRow.Cells[6].Value = row[6].ToString();

            //}
            //dgv_Conditions.AllowUserToAddRows = true;
        }

        #region Pro
        string TranEnToAr(string s)
        {
            switch (s)
            {
                case "Document ID":
                    s = "كود السند";
                    break;
                case "Document Date":
                    s = "تاريخ السند";
                    break;
                case "Item ID":
                    s = "كود الصنف";
                    break;
                case "Item Name":
                    s = "أسم الصنف";
                    break;
                case "Quantity":
                    s = "الكمية";
                    break;
                case "Category":
                    s = "الفئة";
                    break;
                case "Farm":
                    s = "الحظيرة";
                    break;
                case "Type":
                    s = "النوع";
                    break;
                case "Note":
                    s = "البيان";
                    break;
                case "User":
                    s = "المستخدم";
                    break;
                case "Purchasing Price":
                    s = "سعر الشراء";
                    break;
                case "Selling Price":
                    s = "سعر البيع";
                    break;
                case "Average Cost":
                    s = "متوسط التكلفة";
                    break;
                case "Unit":
                    s = "الوحدة";
                    break;
                case "Customer ID":
                    s = "كود العميل";
                    break;
                case "Customer Name":
                    s = "أسم العميل";
                    break;
                case "Responsible Name":
                    s = "أسم المسؤل";
                    break;
                case "Mobile1":
                    s = "جوال1";
                    break;
                case "Mobile2":
                    s = "جوال2";
                    break;
                case "Phone1":
                    s = "هاتف1";
                    break;
                case "Phone2":
                    s = "هاتف2";
                    break;
                case "Email":
                    s = "البريد الالكتروني";
                    break;
                case "Registered Under":
                    s = "مقيد تحت";
                    break;
                case "Balance":
                    s = "الرصيد";
                    break;

                case "Document Type":
                    s = "نوع السند";
                    break;

                case "In":
                    s = "الوارد";
                    break;

                case "Out":
                    s = "المنصرف";
                    break;

                case "Cost Price":
                    s = "سعر التكلفة";
                    break;

                case "Total Purchasing Price":
                    s = "الإجمالي بسعر الشراء";
                    break;

                case "Total Selling Price":
                    s = "الإجمالي بسعر البيع";
                    break;

                case "Total Cost Price":
                    s = "الإجمالي بسعر التكلفة";
                    break;

                case "Total Average Cost":
                    s = "الإجمالي بمتوسط التكلفة";
                    break;

                case "Account ID":
                    s = "كود الحساب";
                    break;

                case "Account Name":
                    s = "أسم الحساب";
                    break;

                case "Payment Type":
                    s = "طريقة الدفع";
                    break;

                case "Product ID":
                    s = "كود المنتج";
                    break;

                case "Product Name":
                    s = "أسم المنتج";
                    break;

                case "Product Nomber":
                    s = "رقم المنتج";
                    break;

                case "Gender":
                    s = "الجنس";
                    break;

                case "Case":
                    s = "الحالة";
                    break;

                case "Mother Nomber":
                    s = "رقم الأم";
                    break;

                case "Birth Date":
                    s = "تاريخ الميلاد";
                    break;

                case "Weight":
                    s = "الوزن";
                    break;

                case "Initial Cost":
                    s = "التكلفة المبدئية";
                    break;

                case "Current Cost":
                    s = "التكلفة الحالية";
                    break;

                case "Health Status":
                    s = "الحالة الصحية";
                    break;

                case "Sale Date":
                    s = "تاريخ البيع";
                    break;

                case "Death Date":
                    s = "تاريخ النفوق";
                    break;

                case "Entry ID":
                    s = "رقم القيد";
                    break;

                case "Vendor ID":
                    s = "كود المورد";
                    break;

                case "Vendor Name":
                    s = "أسم المورد";
                    break;

                case "Vendor Document ID":
                    s = "كود سند المورد";
                    break;

                case "Total":
                    s = "الإجمالي";
                    break;

                case "Discount":
                    s = "الخصم";
                    break;

                case "Net":
                    s = "الصافي";
                    break;

                case "Date":
                    s = "التاريخ";
                    break;

                case "Profit":
                    s = "الربح";
                    break;

                case "Manual Document Number":
                    s = "رقم السند اليدوي";
                    break;

                case "Check Date":
                    s = "تاريخ الشيك";
                    break;

                case "Check Number":
                    s = "رقم الشيك";
                    break;

                case "Amount":
                    s = "المبلغ";
                    break;

                case "Debit":
                    s = "مدين";
                    break;

                case "Credit":
                    s = "دائن";
                    break;

                case "Document Type Name":
                    s = "نوع المرجع";
                    break;

                case "Currency ID":
                    s = "كود العملة";
                    break;

                case "Currency Name":
                    s = "العملة";
                    break;

                case "Currency Price":
                    s = "سعر العملة";
                    break;

                case "Year":
                    s = "السنة";
                    break;

                case "Month":
                    s = "الشهر";
                    break;

                case "Notes":
                    s = "بيان";
                    break;

                case "Entry Type":
                    s = "نوع القيد";
                    break;

                case "ref":
                    s = "كود نوع المرجع";
                    break;

                case "Company ID":
                    s = "كود الشركة";
                    break;

                case "Company Name":
                    s = "أسم الشركة";
                    break;

                case "Fyear ID":
                    s = "كود السنة المالية";
                    break;

                case "Fyear Name":
                    s = "أسم السنة المالية";
                    break;

                case "Branch ID":
                    s = "كود الفرع";
                    break;

                case "Branch Name":
                    s = "أسم الفرع";
                    break;

                case "Cost Center 1 ID":
                    s = "كود مركز1";
                    break;

                case "Cost Center 1 Name":
                    s = "أسم مركز1";
                    break;

                case "Cost Center 2 ID":
                    s = "كود مركز2";
                    break;

                case "Cost Center 2 Name":
                    s = "أسم مركز2";
                    break;

                case "Server Time":
                    s = "وقت السيرفر";
                    break;

                case "User ID":
                    s = "كود المستخدم";
                    break;

                case "User Name":
                    s = "أسم المستخدم";
                    break;

                case "Edited":
                    s = "معدل";
                    break;
            }
            return s;
        }
        string TranArToEn(string s)
        {
             switch (s)
            {
                case "كود السند":
                    s = "Document ID";
                    break;
                case "تاريخ السند":
                    s = "Document Date";
                    break;
                case "كود الصنف":
                    s = "Item ID";
                    break;
                case "أسم الصنف":
                    s = "Item Name";
                    break;
                case "الكمية":
                    s = "Quantity";
                    break;
                case "الفئة":
                    s = "Category";
                    break;
                case "الحظيرة":
                    s = "Farm";
                    break;
                case "النوع":
                    s = "Type";
                    break;
                case "البيان":
                    s = "Note";
                    break;
                case "المستخدم":
                    s = "User";
                    break;
                case "سعر الشراء":
                    s = "Purchasing Price";
                    break;
                case "سعر البيع":
                    s = "Selling Price";
                    break;
                case "متوسط التكلفة":
                    s = "Average Cost";
                    break;
                case "الوحدة":
                    s = "Unit";
                    break;
                case "كود العميل":
                    s = "Customer ID";
                    break;
                case "أسم العميل":
                    s = "Customer Name";
                    break;
                case "أسم المسؤل":
                    s = "Responsible Name";
                    break;
                case "جوال1":
                    s = "Mobile1";
                    break;
                case "جوال2":
                    s = "Mobile2";
                    break;
                case "هاتف1":
                    s = "Phone1";
                    break;
                case "هاتف2":
                    s = "Phone2";
                    break;
                case "البريد الالكتروني":
                    s = "Email";
                    break;
                case "مقيد تحت":
                    s = "Registered Under";
                    break;
                case "الرصيد":
                    s = "Balance";
                    break;

                case "نوع السند":
                    s = "Document Type";
                    break;

                case "الوارد":
                    s = "In";
                    break;

                case "المنصرف":
                    s = "Out";
                    break;

                case "سعر التكلفة":
                    s = "Cost Price";
                    break;

                case "الإجمالي بسعر الشراء":
                    s = "Total Purchasing Price";
                    break;

                case "الإجمالي بسعر البيع":
                    s = "Total Selling Price";
                    break;

                case "الإجمالي بسعر التكلفة":
                    s = "Total Cost Price";
                    break;

                case "الإجمالي بمتوسط التكلفة":
                    s = "Total Average Cost";
                    break;

                case "كود الحساب":
                    s = "Account ID";
                    break;

                case "أسم الحساب":
                    s = "Account Name";
                    break;

                case "طريقة الدفع":
                    s = "Payment Type";
                    break;

                case "كود المنتج":
                    s = "Product ID";
                    break;

                case "أسم المنتج":
                    s = "Product Name";
                    break;

                case "رقم المنتج":
                    s = "Product Nomber";
                    break;

                case "الجنس":
                    s = "Gender";
                    break;

                case "الحالة":
                    s = "Case";
                    break;

                case "رقم الأم":
                    s = "Mother Nomber";
                    break;

                case "تاريخ الميلاد":
                    s = "Birth Date";
                    break;

                case "الوزن":
                    s = "Weight";
                    break;

                case "التكلفة المبدئية":
                    s = "Initial Cost";
                    break;

                case "التكلفة الحالية":
                    s = "Current Cost";
                    break;

                case "الحالة الصحية":
                    s = "Health Status";
                    break;

                case "تاريخ البيع":
                    s = "Sale Date";
                    break;

                case "تاريخ النفوق":
                    s = "Death Date";
                    break;

                case "رقم القيد":
                    s = "Entry ID";
                    break;

                case "كود المورد":
                    s = "Vendor ID";
                    break;

                case "أسم المورد":
                    s = "Vendor Name";
                    break;

                case "كود سند المورد":
                    s = "Vendor Document ID";
                    break;

                case "الإجمالي":
                    s = "Total";
                    break;

                case "الخصم":
                    s = "Discount";
                    break;

                case "الصافي":
                    s = "Net";
                    break;

                case "التاريخ":
                    s = "Date";
                    break;

                case "الربح":
                    s = "Profit";
                    break;

                case "رقم السند اليدوي":
                    s = "Manual Document Number";
                    break;

                case "تاريخ الشيك":
                    s = "Check Date";
                    break;

                case "رقم الشيك":
                    s = "Check Number";
                    break;

                case "المبلغ":
                    s = "Amount";
                    break;

                case "مدين":
                    s = "Debit";
                    break;

                case "دائن":
                    s = "Credit";
                    break;

                case "نوع المرجع":
                    s = "Document Type Name";
                    break;

                case "كود العملة":
                    s = "Currency ID";
                    break;

                case "العملة":
                    s = "Currency Name";
                    break;

                case "سعر العملة":
                    s = "Currency Price";
                    break;

                case "السنة":
                    s = "Year";
                    break;

                case "الشهر":
                    s = "Month";
                    break;

                case "بيان":
                    s = "Notes";
                    break;

                case "نوع القيد":
                    s = "Entry Type";
                    break;

                case "كود نوع المرجع":
                    s = "ref";
                    break;

                case "كود الشركة":
                    s = "Company ID";
                    break;

                case "أسم الشركة":
                    s = "Company Name";
                    break;

                case "كود السنة المالية":
                    s = "Fyear ID";
                    break;

                case "أسم السنة المالية":
                    s = "Fyear Name";
                    break;

                case "كود الفرع":
                    s = "Branch ID";
                    break;

                case "أسم الفرع":
                    s = "Branch Name";
                    break;

                case "كود مركز1":
                    s = "Cost Center 1 ID";
                    break;

                case "أسم مركز1":
                    s = "Cost Center 1 Name";
                    break;

                case "كود مركز2":
                    s = "Cost Center 2 ID";
                    break;

                case "أسم مركز2":
                    s = "Cost Center 2 Name";
                    break;

                case "وقت السيرفر":
                    s = "Server Time";
                    break;

                case "كود المستخدم":
                    s = "User ID";
                    break;

                case "أسم المستخدم":
                    s = "User Name";
                    break;

                case "معدل":
                    s = "Edited";
                    break;
            }
            return s;
        }
        string LIMIT()
        {
            if (rad_Only.Checked)
            {
                return " LIMIT " + num_RecordsNumber.Value.ToString() + " ";
            }
            else
            {
                return "";
            }
        }
        string FIELDS(int i)
        {
            fields = "";

            union = "";
            bool u = false;
            if (i > -1)
            {
                foreach (string item in lst_Translated.Items)
                {
                    com_Fields.Text = item.Substring(1, item.Length - 2);
                    if (com_Fields.SelectedValue.ToString() != "numeric" && item.Substring(1, item.Length - 2) == TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString()))
                    {
                        fields += "," + item + " ";
                        union += ",null";
                    }
                    else
                    {
                        if (com_Fields.SelectedValue.ToString() == "numeric")
                        {
                            fields += ",SUM(\"" + item.Substring(1, item.Length - 2) + "\")" + "AS \"" + item.Substring(1, item.Length - 2) + "\"";

                            if (item.Substring(1, item.Length - 2) == "Balance")
                            {
                                union += ",null";
                            }
                            else
                            {
                                union += ",SUM(\"" + item.Substring(1, item.Length - 2) + "\")";
                                u = true;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (string item in lst_Translated.Items)
                {
                    com_Fields.Text = item.Substring(1, item.Length - 2);
                    fields += "," + item + " ";

                    if (com_Fields.SelectedValue.ToString() != "numeric")
                    {
                        union += ",null";
                    }
                    else
                    {
                        if (item == "الرصيد")
                        {
                            union += ",null";
                        }
                        else
                        {
                            union += ",SUM(" + item + ") ";
                            u = true;
                        }
                    }
                }
            }
            if (u == false) { union = ""; } else { union += ",2 sort"; }


            fields = fields.Substring(1) + ",1 sort";
            return fields;
        }
        string FROM()
        {
            return from = "\r\nFROM " + SCHEMA_NAME + "." + VIEW_NAME + " ";
        }
        string WHERE()
        {
            where = "\r\nWHERE ";
            condition = "";
            for (int i = 0; i < dgv_Conditions.Rows.Count; i++)
            {
                if (dgv_Conditions.Rows[i].Cells[0].Value == null || dgv_Conditions.Rows[i].Cells[2].Value == null || dgv_Conditions.Rows[i].Cells[3].Value == null) { continue; }

                com_Fields.Text = TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString());

                if (dgv_Conditions.Rows[i].Cells[0].Value.ToString() != "" && dgv_Conditions.Rows[i].Cells[2].Value.ToString() != "" && dgv_Conditions.Rows[i].Cells[3].Value.ToString() != "")
                {
                    if (dgv_Conditions.Rows[i].Cells[2].Value.ToString() == "يبدأ بـ")
                    {
                        where += AND_OR(i - 1) + " \"" + TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString()) + "\" " + NOT(i) + " LIKE '" + dgv_Conditions.Rows[i].Cells[3].Value + "%' ";
                        condition_operand = "يبدأ بـ ";
                    }
                    else if (dgv_Conditions.Rows[i].Cells[2].Value.ToString() == "يتضمن")
                    {
                        where += AND_OR(i - 1) + " \"" + TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString()) + "\" " + NOT(i) + " LIKE '%" + dgv_Conditions.Rows[i].Cells[3].Value + "%' ";
                        condition_operand = "يتضمن ";
                    }
                    else if (com_Fields.SelectedValue.ToString() != "numeric")
                    {
                        where += AND_OR(i - 1) + " \"" + TranArToEn(TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString())) + "\" " + NOT(i) + OPERAND(i) + "'" + dgv_Conditions.Rows[i].Cells[3].Value.ToString() + "' ";
                    }
                    else
                    {
                        where += AND_OR(i - 1) + " \"" + TranArToEn(dgv_Conditions.Rows[i].Cells[0].Value.ToString()) + "\" " + NOT(i) + OPERAND(i) + dgv_Conditions.Rows[i].Cells[3].Value + " ";
                    }

                    condition += condition_and_or + dgv_Conditions.Rows[i].Cells[0].Value.ToString() + " " + condition_not + condition_operand + dgv_Conditions.Rows[i].Cells[3].Value.ToString() + " ";
                }
            }

            if (where == "\r\nWHERE ") { where = ""; condition = ""; }
            return where;
        }
        string NOT(int i)
        {
            condition_not = "";
            string n = "";
            if (i < 0) { return n; }

            if (Convert.ToBoolean(dgv_Conditions.Rows[i].Cells[1].Value) == true)
            {
                n = "!";
                condition_not = "ليس ";
            }
            return n;
        }
        string AND_OR(int row_index)
        {
            string and_or = "AND ";
            condition_and_or = "  و  ";
            if (row_index < 0) { and_or = ""; return and_or; }

            if (dgv_Conditions.Rows[row_index].Cells[0].Value == null | dgv_Conditions.Rows[row_index].Cells[2].Value == null | dgv_Conditions.Rows[row_index].Cells[3].Value == null)
            {
                and_or = ""; return and_or;
            }

            if (dgv_Conditions.Rows[row_index].Cells[4].Value != null)
            {
                if (dgv_Conditions.Rows[row_index].Cells[4].Value.ToString() == "أو")
                {
                    and_or = "OR ";
                    condition_and_or = "  أو  ";
                }
            }
            return and_or;
        }
        string OPERAND(int i)
        {
            operand = "";
            switch (dgv_Conditions.Rows[i].Cells[2].Value.ToString())
            {
                case "أختيار":
                    operand = "= ";
                    condition_operand = "مساو لـ ";
                    break;

                case "يبدأ بـ":
                    operand = "= ";
                    break;

                case "مساو لـ":
                    operand = "= ";
                    break;

                case "أكبر من":
                    operand = "> ";
                    break;

                case "أقل من":
                    operand = "< ";
                    break;

                case "أكبر من أو يساوي":
                    operand = ">= ";
                    break;

                case "أقل من أو يساوي":
                    operand = "<= ";
                    break;

                case "يتضمن":
                    operand = "like ";
                    break;
            }
            condition_operand = dgv_Conditions.Rows[i].Cells[2].Value.ToString() == "أختيار" ? "مساو لـ " : dgv_Conditions.Rows[i].Cells[2].Value.ToString();
            return operand;
        }
        string ORDER_BY()
        {
            string order_by = "";
            foreach (DataGridViewRow r in dgv_Conditions.Rows)
            {
                if (r.Cells["col_order"].Value != null && r.Cells["col_order"].Value != null)
                {
                    if (r.Cells["col_order"].Value.ToString() == "تصاعدياً")
                    {
                        order_by = "ORDER BY sort, \"" + TranArToEn(r.Cells["col_field"].Value.ToString()) + "\" ASC ";
                    }
                    else if (r.Cells[6].Value.ToString() == "تنازلياً")
                    {
                        order_by = "ORDER BY sort, \"" + TranArToEn(r.Cells["col_field"].Value.ToString()) + "\" DESC ";
                    }
                }
            }
            return order_by;
        }
        string UNION_ALL()
        {
            if (union == "")
            {
                from = "";
                where = "";
                return "";
            }
            else
            {
                return "\r\nUNION ALL \r\nSELECT " + union.Substring(1);
            }
        }
        void DGV_Finish()
        {
            // حجم الخط
            dgv_Rep.DefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value));
            dgv_Rep.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value) + 2);
            dgv_Rep.RowTemplate.MinimumHeight = Convert.ToInt16(25 + (Convert.ToInt16(num_FontSize.Value) - 8));

            lbl_RepTitle.Text = txt_RepName.Text;
            if (condition == "")
            {
                lbl_RepCondition.Visible = false;

            }
            else
            {
                lbl_RepCondition.Visible = true;
                lbl_RepCondition.Text = "     " + condition.Substring(5);
            }
            // الترقيم
            foreach (DataGridViewRow indexrow in dgv_Rep.Rows)
            {
                indexrow.Cells[0].Value = indexrow.Index + 1;
            }
            dgv_Rep.Rows[dgv_Rep.RowCount - 1].Cells[0].Value = "";
            dgv_Rep.Columns[0].Visible = chk_Index.Checked;

            if (dgv_Rep.SelectedRows.Count > 0) { dgv_Rep.SelectedRows[0].Selected = false; }

            if (union == "")
            {
                dt_Rep.Rows.Add();
            }

            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value) + 2);
            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Navy;
            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Silver;

            //EmptyZero();
        }
        void Bind()
        {
            bl.Name = txt_RepName.Text;
            bl.Content = Content();
            bl.Rep_View = VIEW_NAME;
            bl.Row_Count = (rad_Only.Checked) ? Convert.ToInt16(num_RecordsNumber.Value) : 0;
            bl.Row_Index = chk_Index.Checked;
            bl.Font_Size = Convert.ToInt32(num_FontSize.Value);
            bl.RepD = table();
            bl.User_ID = frm_main.com_users.SelectedValue.ToString();
            bl.company_id = frm_main.com_companies.SelectedValue.ToString();
        }
        string Content()
        {
            string c = "";
            foreach (string item in lst_SelectedFields.Items)
            {
                c += item + ",";
            }
            return c;
        }
        DataTable table()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv_Conditions.Columns)
            {
                if (col.Index == dgv_Conditions.Columns.Count - 1) { break; }
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgv_Conditions.Rows)
            {
                if (row.Cells[0].Value == null) { break; }
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == dgv_Conditions.Columns.Count - 1) { break; }
                    if (cell.Value == null)
                    {
                        if(cell.OwningColumn.Name == "col_not" || cell.OwningColumn.Name == "col_group")
                        {
                            dRow[cell.ColumnIndex] = "false";
                        }
                    }

                    else if (cell.Value.ToString() == "") { dRow[cell.ColumnIndex] = null; }
                    else { dRow[cell.ColumnIndex] = cell.Value; }
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }
        DataTable table(int t)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv_Conditions.Columns)
            {
                dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgv_Conditions.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) { dRow[cell.ColumnIndex] = null; }
                    else if (cell.Value.ToString() == "") { dRow[cell.ColumnIndex] = null; }
                    else { dRow[cell.ColumnIndex] = cell.Value; }
                }
                dt.Rows.Add(dRow);
            }
            if (dt.Rows.Count > 0) { dt.Rows.RemoveAt(dt.Rows.Count - 1); }
            return dt;
        }

        void HideZero()
        {
            foreach (DataGridViewRow r in dgv_Rep.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.Value.ToString() == "0") { c.Style.ForeColor = Color.Transparent; }
                }
            }
        }
        #endregion

        #region Form
        private void frm_repdes_Shown(object sender, EventArgs e)
        {
            #region Design
            btn_Forward.Image = frm_main.imageList16.Images["Forward1_16.png"];
            btn_Backward.Image = frm_main.imageList16.Images["Backward1_16.png"];
            btn_ForwardAll.Image = frm_main.imageList16.Images["Forward_16.png"];
            btn_BackwardAll.Image = frm_main.imageList16.Images["Backward_16.png"];

            btn_MoveFirst.Image = frm_main.imageList16.Images["UpFirst_16.png"];
            btn_Up.Image = frm_main.imageList16.Images["Up_16.png"];
            btn_Down.Image = frm_main.imageList16.Images["Down_16.png"];
            btn_MoveLast.Image = frm_main.imageList16.Images["DownLast_16.png"];

            btn_SaveRep.Image = frm_main.imageList16.Images["Save2_16.png"];
            btn_DeleteRep.Image = frm_main.imageList16.Images["close2_16.png"];

            btn_Display.Image = frm_main.imageList_48.Images["Display_48.png"];
            btn_ExportToExcel.Image = frm_main.imageList_48.Images["excel_48.png"];
            #endregion

            dt_Rep_Info = bl.Select_RepInfo(VIEW_NAME, SCHEMA_NAME).Tables[0];
            foreach (DataRow r in dt_Rep_Info.Rows)
            {
                lst_AvailableFields.Items.Add(TranEnToAr(r[0].ToString()));
            }

            foreach (DataRow dr in dt_Rep_Info.Rows)
            {
                (dgv_Conditions.Columns[0] as DataGridViewComboBoxColumn).Items.Add(TranEnToAr(dr[0].ToString()));
            }
            com_Fields.DataSource = dt_Rep_Info;

            if ((dgv_Conditions.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Count == 0)
            {
                foreach (DataRow r in dt_Rep_Info.Rows)
                {
                    lst_AvailableFields.Items.Add(r[0].ToString());
                    (dgv_Conditions.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(TranEnToAr(r[0].ToString()));
                }
            }
            ((DataGridViewImageCell)dgv_Conditions.Rows[0].Cells["col_delete"]).Value = frm_main.imageList16.Images["close2_16.png"];
        }
        #endregion

        #region Controls
        private void btn_Display_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.Items.Count == 0)
            {
                dgv_Rep.Columns.Clear();
                return;
            }

            lst_Translated.Items.Clear();
            foreach (var i in lst_SelectedFields.Items)
            {
                lst_Translated.Items.Add("\"" + TranArToEn(i.ToString()) + "\"");
            }

            #region Group By
            foreach (DataGridViewRow r in dgv_Conditions.Rows)
            {
                if (r.Cells["col_group"].Value != null && r.Cells["col_field"].Value != null)
                {
                    if (Convert.ToBoolean(r.Cells["col_group"].Value) == true)
                    {
                        txt_SQL.Text = "SELECT " + FIELDS(r.Cells["col_group"].RowIndex) + FROM() + WHERE() + "Group By \"" + TranArToEn(r.Cells[0].Value.ToString()) + "\" " + UNION_ALL() + from + where + ORDER_BY();

                        dt_Rep = bl.Select(txt_SQL.Text).Tables[0];
                        dt_Rep.Columns.Remove("sort");

                        #region Translate dgv.Columns
                        foreach (DataColumn c in dt_Rep.Columns)
                        {
                            c.ColumnName = lst_SelectedFields.Items[c.Ordinal].ToString();
                        }
                        #endregion
                        dgv_Rep.DataSource = null;

                        DataRow total_rowG = dt_Rep.NewRow();
                        total_rowG.ItemArray = dt_Rep.Rows[dt_Rep.Rows.Count - 1].ItemArray;
                        dt_Rep.Rows.RemoveAt(dt_Rep.Rows.Count - 1);
                        ORDER_BY();
                        dt_Rep.Rows.Add(total_rowG.ItemArray);
                        dgv_Rep.DataSource = dt_Rep;

                        if (dgv_Rep.SelectedRows.Count > 0) { dgv_Rep.SelectedRows[0].Selected = false; }

                        if (union == "")
                        {
                            dt_Rep.Rows.Add();
                        }

                        dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value) + 2);
                        dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Navy;
                        dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Silver;

                        txt_RepName.Text = txt_RepName.Text;
                        if (condition == "")
                        {
                            lbl_RepCondition.Visible = false;
                            // DGV.Dock = DockStyle.Fill;
                        }
                        else
                        {
                            lbl_RepCondition.Visible = true;
                            lbl_RepCondition.Text = "     " + condition.Substring(5);
                        }
                        DGV_Finish();
                        return;
                    }
                }
            }
            #endregion

            #region Normal
            txt_SQL.Text = "SELECT " + FIELDS(-1) + FROM() + WHERE() + LIMIT() + UNION_ALL() + from + where + ORDER_BY();

            dt_Rep = bl.Select(txt_SQL.Text).Tables[0];
            dt_Rep.Columns.Remove("sort");

            #region Translate dgv.Columns

            foreach (DataColumn c in dt_Rep.Columns)
            {
                c.ColumnName = lst_SelectedFields.Items[c.Ordinal].ToString();                
            }
            #endregion

            dgv_Rep.DataSource = null;
            dgv_Rep.DataSource = dt_Rep;
            #endregion

            DGV_Finish();

            HideZero();
        }
        private void lst_AvailableFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bnt_Forward_Click(null, null);
        }
        private void bnt_Forward_Click(object sender, EventArgs e)
        {
            if (lst_AvailableFields.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lst_AvailableFields.SelectedItems.Count; i++)
                {
                    lst_SelectedFields.Items.Add(lst_AvailableFields.SelectedItems[i]);
                    lst_AvailableFields.Items.Remove(lst_AvailableFields.SelectedItems[i]);
                    i--;
                }
            }
        }
        private void btn_Backward_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.SelectedItems.Count > 0)
            {
                for (int i = 0; i < lst_SelectedFields.SelectedItems.Count; i++)
                {
                    lst_AvailableFields.Items.Add(lst_SelectedFields.SelectedItems[i]);
                    lst_SelectedFields.Items.Remove(lst_SelectedFields.SelectedItems[i]);
                    i--;
                }
            }
        }
        private void lst_SelectedFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_Backward_Click(null,null);
        }
        private void btn_ForwardAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst_AvailableFields.Items.Count; i++)
            {
                lst_SelectedFields.Items.Add(lst_AvailableFields.Items[i]);
                lst_AvailableFields.Items.Remove(lst_AvailableFields.Items[i]);
                i--;
            }
        }
        private void btn_BackwardAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst_SelectedFields.Items.Count; i++)
            {
                lst_AvailableFields.Items.Add(lst_SelectedFields.Items[i]);
                lst_SelectedFields.Items.Remove(lst_SelectedFields.Items[i]);
                i--;
            }
        }
        private void btn_MoveFirst_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.SelectedItems.Count > 0)
            {
                ListBox lstTemp = new ListBox();
                for (int i = lst_SelectedFields.SelectedItems.Count; i > 0; i--)
                {
                    lstTemp.Items.Add(lst_SelectedFields.SelectedItems[i-1]);
                    lst_SelectedFields.Items.Remove(lstTemp.Items[0]);
                    lst_SelectedFields.Items.Insert(0, lstTemp.Items[0]);
                    lstTemp.Items.Clear();
                }
            }
        }
        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.SelectedItems.Count > 0)
            {
                ListBox lstTemp = new ListBox();
                int index = lst_SelectedFields.Items.IndexOf(lst_SelectedFields.SelectedItems[0]);

                if(index > 0)
                {
                    foreach (var item in lst_SelectedFields.SelectedItems)
                    {
                        lstTemp.Items.Add(item);
                    }
                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Remove(item);
                    }

                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Insert(index - 1, item);
                        index++;
                    }

                    lst_SelectedFields.SelectedIndex = index -2;
                }             
            }
        }
        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.SelectedItems.Count > 0)
            {
                ListBox lstTemp = new ListBox();
                int index = lst_SelectedFields.Items.IndexOf(lst_SelectedFields.SelectedItems[lst_SelectedFields.SelectedItems.Count-1]);

                if (index < lst_SelectedFields.Items.Count-1)
                {
                    foreach (var item in lst_SelectedFields.SelectedItems)
                    {
                        lstTemp.Items.Add(item);
                    }
                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Remove(item);
                        index--;
                    }

                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Insert(index + 2, item);
                    }

                    lst_SelectedFields.SelectedIndex = index + 2;
                }
            }
        }
        private void btn_MoveLast_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.SelectedItems.Count > 0)
            {
                ListBox lstTemp = new ListBox();
                int index = lst_SelectedFields.Items.IndexOf(lst_SelectedFields.SelectedItems[lst_SelectedFields.SelectedItems.Count - 1]);

                if (index < lst_SelectedFields.Items.Count - 1)
                {
                    foreach (var item in lst_SelectedFields.SelectedItems)
                    {
                        lstTemp.Items.Add(item);
                    }
                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Remove(item);
                        index--;
                    }
                    foreach (var item in lstTemp.Items)
                    {
                        lst_SelectedFields.Items.Insert(lst_SelectedFields.Items.Count, item);
                    }
                }
            }
        }
        #endregion

        private void chk_Index_CheckedChanged(object sender, EventArgs e)
        {
            dgv_Rep.Columns[0].Visible = chk_Index.Checked;
        }
        private void num_FontSize_ValueChanged(object sender, EventArgs e)
        {
            // حجم الخط
            dgv_Rep.DefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value));
            dgv_Rep.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value) + 2);

            dgv_Rep.RowTemplate.Height = 27 + Convert.ToInt32(Convert.ToInt16(num_FontSize.Value) - 8);

            dgv_Rep.DataSource = null;
            dgv_Rep.DataSource = dt_Rep;
            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.Font = new Font("Tahoma", Convert.ToInt16(num_FontSize.Value) + 2);

            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Navy;
            dgv_Rep.Rows[dgv_Rep.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Silver;

            // الترقيم
            foreach (DataGridViewRow indexrow in dgv_Rep.Rows)
            {
                indexrow.Cells[0].Value = indexrow.Index + 1;
            }
            dgv_Rep.Rows[dgv_Rep.RowCount - 1].Cells[0].Value = "";
        }
        private void dgv_Conditions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Conditions.CurrentCell == null || dgv_Conditions.Focused == false) { return; }

            if (e.ColumnIndex == 2 & dgv_Conditions.CurrentRow.Cells[0].Value != null || e.ColumnIndex == 0 & dgv_Conditions.CurrentRow.Cells[2].Value != null)
            {
                if (dgv_Conditions.CurrentRow.Cells[2].Value.ToString() == "أختيار")
                {
                    dgv_Conditions.CurrentRow.Cells[3] = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell box = new DataGridViewComboBoxCell();
                    box = (DataGridViewComboBoxCell)dgv_Conditions.CurrentRow.Cells[3];
                    box.DataSource = bl.Select("SELECT DISTINCT \"" + TranArToEn(dgv_Conditions.CurrentRow.Cells[0].Value.ToString()) + "\" FROM " + SCHEMA_NAME + "." + VIEW_NAME).Tables[0];
                    box.DisplayMember = TranArToEn(dgv_Conditions.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    dgv_Conditions.CurrentRow.Cells[3] = new DataGridViewTextBoxCell();
                }
            }
        }
        private void dgv_Conditions_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewImageCell)dgv_Conditions.Rows[e.RowIndex].Cells["col_delete"]).Value = frm_main.imageList16.Images["close2_16.png"];
        }
        private void dgv_Conditions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (dgv_Conditions.CurrentRow.Index != dgv_Conditions.Rows.Count - 1)
                {
                    dgv_Conditions.Rows.Remove(dgv_Conditions.CurrentRow);
                    //dtp.Visible = false;
                }
            }
        }
        private void btn_ExportToExcel_Click(object sender, EventArgs e)
        {
            if (!frm_main.Perm("0208003"))
            {
                MessageBox.Show("ليس لديك تصريح لتصدير التقرير للاكسيل", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgv_Rep.Rows.Count == 0) { return; }
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                excel.DefaultSheetDirection = (int)dgv_Rep.RightToLeft;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 4;
                int j = 0, i = 0;
                int indexcol = 0;
                if (dgv_Rep.Columns[0].Visible == true) { indexcol = 0; } else { indexcol = 1; }

                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range["A1", "Z10000"];
                myRange.RowHeight = 20;
                myRange.HorizontalAlignment = 3;
                myRange.VerticalAlignment = 2;
                myRange.Font.Name = "Tahoma";
                myRange.Font.Size = 8;

                // Report Title
                if (lbl_RepTitle.Text != "")
                {
                    lastcol = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, dgv_Rep.ColumnCount - indexcol];
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range["A1", lastcol];
                    myRange.MergeCells = true;
                    myRange.Value2 = lbl_RepTitle.Text;
                    myRange.RowHeight = 30;
                    myRange.HorizontalAlignment = 3;
                    myRange.VerticalAlignment = 2;
                    myRange.Interior.Color = lbl_RepTitle.BackColor;
                    myRange.Font.Name = "Tahoma";
                    myRange.Font.Color = lbl_RepTitle.ForeColor;
                    myRange.Font.Size = 12;
                }
                else
                {
                    StartRow--;
                }

                // Report Conditions
                lastcol = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow - 2, dgv_Rep.ColumnCount - indexcol];
                firstrow = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow - 2, 1];

                if (lbl_RepCondition.Visible == true)
                {
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[firstrow, lastcol];
                    myRange.MergeCells = true;
                    myRange.Value2 = lbl_RepCondition.Text;
                    myRange.RowHeight = 30;
                    myRange.HorizontalAlignment = 1;
                    myRange.Interior.Color = lbl_RepCondition.BackColor;
                    myRange.Font.Color = lbl_RepCondition.ForeColor;
                }
                else
                {
                    StartRow--;
                }

                //Write Headers                
                for (j = 1; j <= dgv_Rep.Columns.Count - indexcol; j++)
                {
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow - 1, j];
                    myRange.Value2 = dgv_Rep.Columns[j + indexcol - 1].HeaderText;
                    myRange.RowHeight = 30;
                    myRange.ColumnWidth = dgv_Rep.Columns[j + indexcol - 1].Width / 6;
                    myRange.Font.Size = 10;
                    myRange.Font.FontStyle = FontStyle.Bold;
                    myRange.Borders.Color = Color.Gray;
                    myRange.Interior.Color = Color.Silver;
                }

                //Write datagridview content
                for (i = 0; i < dgv_Rep.Rows.Count; i++)
                {
                    for (j = 0; j < dgv_Rep.Columns.Count - indexcol; j++)
                    {
                        myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dgv_Rep[j + indexcol, i].Value == null ? "" : dgv_Rep[j + indexcol, i].Value.ToString();

                    }

                    firstrow = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, 1];
                    myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range[firstrow, myRange];
                    myRange.Borders.Color = Color.Gray;

                    if ((i % 2) > 0)
                    {
                        myRange.Interior.Color = Color.OldLace;
                    }
                    if (i == dgv_Rep.Rows.Count - 1)
                    {
                        myRange.Font.Color = Color.Navy;
                        myRange.Interior.Color = Color.Silver;
                        myRange.Font.Size = 10;
                    }
                }

                lastcol = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[dgv_Rep.RowCount + StartRow - 1, dgv_Rep.ColumnCount - indexcol];
                myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Range["A1", lastcol];
                myRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_SaveRep_Click(object sender, EventArgs e)
        {
            if (lst_SelectedFields.Items.Count == 0) { MessageBox.Show("لا يوجد حقول بالتقرير", "لم يتم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            if (txt_RepName.TextLength == 0) { MessageBox.Show("من فضلك أدخل أسم للتقرير", "لم يتم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            if (com_SelectedRep.Text == txt_RepName.Text)
            {
                if (MessageBox.Show("سيتم تعديل التقرير الحالي", "حفظ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    return;
                }
            }

            Bind();

            DataSet ds = bl.Insert();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["h_notes"] != null)
                {
                    if (ds.Tables[0].Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                    {
                        if (ds.Tables[0].Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                        {
                            string[] arrey = ds.Tables[0].Rows[0]["h_notes"].ToString().Split(',');
                            MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                            return;
                        }
                    }
                }
            }

            // fill combo
            DataTable dt_g = new DataTable();
            DataTable dt_RepD = new DataTable();
            DataSet ds_rep = new DataSet();

            ds_rep = bl.Select_Rep("select * from grl.tbl_rep; select * from grl.tbl_repd");
            ds_rep.Tables[0].DefaultView.RowFilter = string.Format("view = '" + SCHEMA_NAME + "." + VIEW_NAME + "' and user_id = " + frm_main.com_users.SelectedValue.ToString());

            com_SelectedRep.DataSource = ds_rep.Tables[0];
            com_SelectedRep.Text = txt_RepName.Text;

            MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void com_SelectedRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_SelectedRep.Focused == false) return;

            txt_RepName.Text = com_SelectedRep.Text;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["id"].ToString() == com_SelectedRep.SelectedValue.ToString())
                {
                    dr_g = r;
                    break;
                }
            }
            if (dr_g == null) { return; }

            #region Contents
            lst_SelectedFields.Items.Clear();
            lst_AvailableFields.Items.Clear();
            foreach (DataRow r in dt_Rep_Info.Rows)
            {
                lst_AvailableFields.Items.Add(TranEnToAr(r[0].ToString()));
            }

            string c = dr_g["Content"].ToString();
            string n = "";
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == ',')
                {
                    for (int p = 0; p < lst_AvailableFields.Items.Count; p++)
                    {
                        if (lst_AvailableFields.Items[p].ToString() == n)
                        {
                            lst_AvailableFields.SelectedIndex = p;
                            bnt_Forward_Click(null, null);
                            break;
                        }
                    }
                    n = "";
                    continue;
                }
                n += c[i];
            }
            #endregion

            #region Row_Count
            if (Convert.ToInt16(dr_g["rowcount"]) != 0)
            {
                rad_Only.Checked = true;
                num_RecordsNumber.Value = Convert.ToInt16(dr_g["rowcount"]);
            }
            else
            {
                rad_AllRecords.Checked = true;
            }
            #endregion

            #region Row_Index
            chk_Index.Checked = Convert.ToBoolean(dr_g["rowindex"]);
            #endregion

            #region Font_Size
            num_FontSize.Value = Convert.ToInt16(dr_g["fontsize"]);
            #endregion


            dgv_Conditions.Rows.Clear();
            foreach (DataRow r in ds.Tables[1].Rows)
            {
                if(r["rep_id"].ToString() == com_SelectedRep.SelectedValue.ToString())
                {
                    dgv_Conditions.Rows.Add(r["field"], r["no"], r["operator"], r["condition"], r["logic"], r["ggroup"], r["oorder"], frm_main.imageList16.Images["close2_16.png"]);
                }
            }

            foreach (DataGridViewRow rr in dgv_Conditions.Rows)
            {
                if (rr.Cells[0].Value != null && rr.Cells[2].Value.ToString() == "أختيار")
                {
                    //string s = rr.Cells[3].Value.ToString();
                    //rr.Cells[3] = new DataGridViewComboBoxCell();
                    //DataGridViewComboBoxCell box = new DataGridViewComboBoxCell();
                    //box = (DataGridViewComboBoxCell)rr.Cells[3];
                    //box.DataSource = bl.Select("select DISTINCT \"" + TranArToEn(rr.Cells[0].Value.ToString()) + "\" from " + SCHEMA_NAME + "." + VIEW_NAME);
                    //box.DisplayMember = TranArToEn(rr.Cells[0].Value.ToString());
                    //rr.Cells[3].Value = s;


                    string s = rr.Cells[3].Value.ToString();
                    rr.Cells[3] = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell box = (DataGridViewComboBoxCell)rr.Cells[3];

                    box.Items.Clear();
                    foreach (DataRow dr in bl.Select("select DISTINCT \"" + TranArToEn(rr.Cells[0].Value.ToString()) + "\" from " + SCHEMA_NAME + "." + VIEW_NAME).Tables[0].Rows)
                    {
                        box.Items.Add(dr[0].ToString());
                    }
                    
                    rr.Cells[3].Value = s;
                }
            }
            
        }
    }
}
