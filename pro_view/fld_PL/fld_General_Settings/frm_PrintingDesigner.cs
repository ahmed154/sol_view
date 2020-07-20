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
    public partial class frm_PrintingDesigner : Form
    {
        Point p;
        DataSet ds_print = new DataSet();
        DataTable dt_print = new DataTable();
        DataTable dt_AvailbleFields = new DataTable();
        DataView dv = new DataView();
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_print bl = new fld_BL.cls_bl.stc_General_Settings.stc_print();

        Button btn_RepHeader = new Button { Name = "btn_RepHeader", Text = "Report Header"};
        Button btn_PageHeader = new Button { Name = "btn_PageHeader", Text = "Page Header" };
        Button btn_Details = new Button { Name = "btn_Details", Text = "Details" };
        Button btn_PageFooter = new Button { Name = "btn_PageFooter", Text = "Page Footer" };
        Button btn_RepFooter = new Button { Name = "btn_RepFooter", Text = "Report Footer" };

        public frm_PrintingDesigner()
        {
            InitializeComponent();

            btn_RepHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            btn_RepHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(btn_MouseMove);

            btn_PageHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            btn_PageHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(btn_MouseMove);

            btn_Details.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            btn_Details.MouseMove += new System.Windows.Forms.MouseEventHandler(btn_MouseMove);

            btn_PageFooter.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            btn_PageFooter.MouseMove += new System.Windows.Forms.MouseEventHandler(btn_MouseMove);

            btn_RepFooter.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            btn_RepFooter.MouseMove += new System.Windows.Forms.MouseEventHandler(btn_MouseMove);


            dt_AvailbleFields = bl.Select("select * from acc.viw_cin_select1").Tables[0];

            ds_print = bl.Select();

            com_Desigen.DataSource = ds_print.Tables[0];
            com_Desigen.ValueMember = "id";
            com_Desigen.DisplayMember = "aname";

            foreach (DataColumn d in dt_AvailbleFields.Columns)
            {
                lst_AvailableFields.Items.Add(d.ColumnName);
            }
        }

        #region Pro
        DataTable DGVToDatatable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgv_SelectedFields.Columns)
            {
                dt.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dgv_SelectedFields.Rows)
            {
                DataRow Row = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        Row[cell.ColumnIndex] = null;                     
                    }
                    else if (cell.Value.ToString() == "")
                    {
                        Row[cell.ColumnIndex] = null;
                    }
                    else
                    {
                        Row[cell.ColumnIndex] = cell.Value;
                    }
                }
                dt.Rows.Add(Row);
            }
            return dt;
        }
        void Bind()
        {
            bl.aname = txt_DesigenName.Text.Trim();
            bl.ename = txt_DesigenName.Text.Trim();
            bl.frm = "pin";
            bl.pagetype = "A4";
            bl.pagew = pnl.Size.Width;
            bl.pageh = pnl.Size.Height;
            bl.repheaderh = btn_RepHeader.Top;
            bl.pageheaderh = btn_PageHeader.Top;
            bl.detailsh = btn_Details.Top;
            bl.pagefooterh = btn_PageFooter.Top;
            bl.repfooterh = btn_RepFooter.Top;
            bl.notes = "";
            bl.user_id = "0001";
            bl.company_id = "01";
            bl.printD = DGVToDatatable();
        }

        #endregion

        #region Events
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (((Control)sender).Name == "btn_RepHeader")
                {
                    if(btn_RepHeader.Bottom < btn_PageHeader.Top)
                    {
                        ((Control)sender).Top += e.Y - p.Y;
                    }
                    else if(e.Y < btn_RepHeader.Bottom)
                    {
                        ((Control)sender).Top += e.Y - p.Y;
                    }
                }


                if (((Control)sender).Name == "btn_RepFooter")
                {
                    pnl.Size = new Size(pnl.Width, ((Control)sender).Bottom);
                }
            }
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            p = e.Location;
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Control)sender).Top += e.Y - p.Y;
                ((Control)sender).Left += e.X - p.X;
            }
        }
        private void Enter(object sender, EventArgs e)
        {         
            lst_SelectedFields.SelectedIndex = Convert.ToInt32(((Control)sender).Tag);
        }
        private void Leave(object sender, EventArgs e)
        {
            dgv_SelectedFields.SelectedRows[0].Cells["x"].Value = ((Control)sender).Location.X;
            dgv_SelectedFields.SelectedRows[0].Cells["y"].Value = ((Control)sender).Location.Y;
            lst_SelectedFields.SelectedItems.Clear();
        }
        private void TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(((TextBox)sender).Text, ((TextBox)sender).Font);
            ((TextBox)sender).Width = size.Width;
            ((TextBox)sender).Height = size.Height;

            lst_SelectedFields.Items[lst_SelectedFields.SelectedIndex] = ((TextBox)sender).Text;
        }
        #endregion

        #region Form
        private void frm_PrintingDesigner_Shown(object sender, EventArgs e)
        {
            //foreach (DataRow r in ds_print.Tables["tbl_printd"].Rows)
            //{
            //    if(r["fieldtype"].ToString() == "lable")
            //    {
            //        Label lbl = new Label
            //        {
            //            Text = r["text"].ToString(),
            //            Font = new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"]), FontStyle.Bold),
            //            Location = new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"]))
            //        };

            //        //Label lbl = new Label();
            //        //lbl.Text = r["text"].ToString();
            //        //lbl.Location = new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"]));
            //        //lbl.Font = new Font(r["fontName"].ToString(), Convert.ToInt32(r["fontSize"]), FontStyle.Bold);


            //        lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            //        lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

            //        pnl.Controls.Add(lbl);
            //    }
            //}




            //int Top = Convert.ToInt32(ds_print.Tables["tbl_print"].Rows[0]["repHeaderh"]) + Convert.ToInt32(ds_print.Tables["tbl_print"].Rows[0]["pageHeaderh"]);
            //int Row_H = Convert.ToInt32(ds_print.Tables["tbl_print"].Rows[0]["detailsh"]);
            //Top += Row_H * 2;


            //foreach (DataRow r in ds_print.Tables["tbl_printd"].Rows)
            //{
            //    if (r["fieldzone"].ToString() == "Details")
            //    {
            //        if (r["fieldtype"].ToString() == "lbl")
            //        {
            //        }
            //        else if (r["fieldtype"].ToString() == "value")
            //        {
            //        }
            //    }
            //}
            //Top += Row_H;
   



            //foreach (DataRow r in ds_print.Tables["tbl_printd"].Rows)
            //{
            //    if (r["fieldzone"].ToString() == "Page_Footer")
            //    {
            //        if (r["fieldtype"].ToString() == "lbl")
            //        {
            //        }
            //        else if (r["fieldtype"].ToString() == "value")
            //        {
            //        }
            //    }
            //}
        }
        #endregion

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst_AvailableFields.SelectedItems.Count; i++)
            {
                //foreach (DataColumn col in dt_AvailbleFields.Columns)
                //{
                TextBox txt = new TextBox
                {
                    Text = lst_AvailableFields.SelectedItems[i].ToString(),
                    ReadOnly = true,
                    //Location = new Point(Convert.ToInt32(Convert.ToDecimal(r["x"]) * pnl.Width), Convert.ToInt32(Convert.ToDecimal(r["y"]) * pnl.Height)),
                    AutoSize = true
                };
                txt.Cursor = Cursors.Arrow;
                txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
                txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

                pnl.Controls.Add(txt);

                //if (col.ColumnName.Substring(0, 1) == "h")
                //{

                //}
                //}

                lst_SelectedFields.Items.Add(lst_AvailableFields.SelectedItems[i]);
                lst_AvailableFields.Items.Remove(lst_AvailableFields.SelectedItems[i]);

                i--;

                dgv_SelectedFields.Rows.Add(txt.Text, txt.Text, "val", "pageheader", txt.Location.X, txt.Location.Y, "Calibri", 16, 0, true, null);
            }
        }

        private void btn_Backward_Click(object sender, EventArgs e)
        {

        }

        private void btn_ForwardAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst_AvailableFields.SelectedItems.Count; i++)
            {

                TextBox txt = new TextBox
                {
                    Text = lst_AvailableFields.SelectedItems[i].ToString(),
                    ReadOnly = true,
                };
                txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
                txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

                pnl.Controls.Add(txt);

                lst_SelectedFields.Items.Add(lst_AvailableFields.SelectedItems[i]);
                lst_AvailableFields.Items.Remove(lst_AvailableFields.SelectedItems[i]);

                i--;
            }
        }

        private void btn_BackwardAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lst_AvailableFields.SelectedItems.Count; i++)
            {

                TextBox txt = new TextBox
                {
                    Text = lst_AvailableFields.SelectedItems[i].ToString(),
                    ReadOnly = true,
                };
                txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
                txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

                pnl.Controls.Add(txt);

                lst_SelectedFields.Items.Add(lst_AvailableFields.SelectedItems[i]);
                lst_AvailableFields.Items.Remove(lst_AvailableFields.SelectedItems[i]);

                i--;
            }
        }


        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    Graphics g = e.Graphics;
        //    using (Pen selPen = new Pen(Color.Blue))
        //    {
        //        g.DrawRectangle(selPen, 10, 10, 50, 50);
        //    }
        //}
        private void btn_Down_Click(object sender, EventArgs e)
        {
            pnl.CreateGraphics();
        }

        private void tsm_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddLbl_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox
            {
                BackColor = pnl.BackColor,
                AutoSize = false,
                Text = "Lable",
                Tag = lst_SelectedFields.Items.Count
            };
            txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);
            txt.Enter += new System.EventHandler(Enter);
            txt.Leave += new System.EventHandler(Leave);
            txt.TextChanged += new System.EventHandler(TextChanged);

            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Cursor = Cursors.Arrow;


            lst_SelectedFields.Items.Add(txt.Text);
            pnl.Controls.Add(txt);

            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.Width = size.Width;
            txt.Height = size.Height;

            dgv_SelectedFields.Rows.Add(txt.Text, txt.Text, "lbl", "pageheader", txt.Location.X, txt.Location.Y, "Calibri", 16, 0, true, null);
        }

        private void btn_AddRec_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox
            {
                BackColor = pnl.BackColor,
                ReadOnly = true,
                AutoSize = false,
                Size = new Size(200, 150),
                Tag = Tag = lst_SelectedFields.Items.Count
            };
            txt.SendToBack();
            txt.Cursor = Cursors.Arrow;
            txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
            txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);


            pnl.Controls.Add(txt);
            lst_SelectedFields.Items.Add("rec");
        }

        private void lst_SelectedFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in pnl.Controls)
            {
                if(c.Tag != null)
                {
                    if(Convert.ToInt32(c.Tag) == lst_SelectedFields.SelectedIndex)
                    {
                        c.Focus();
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region New
            if (txt_DesigenName.Text.Trim() != "")
            {
                Bind();

                dt_print = bl.Insert().Tables["tbl_print"];
                if (dt_print.Rows.Count > 0)
                {
                    if (dt_print.Rows[0]["h_notes"] != null)
                    {
                        if (dt_print.Rows[0]["h_notes"].ToString().Trim().Length >= 10)
                        {
                            if (dt_print.Rows[0]["h_notes"].ToString().Substring(0, 10) == "PostgreSQL")
                            {
                                string[] arrey = dt_print.Rows[0]["h_notes"].ToString().Split(',');
                                MessageBox.Show(arrey[1] + "\r\n" + arrey[2] + "\r\n" + arrey[3] + "\r\n" + arrey[4], arrey[0]);
                                return;
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void com_Desigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnl.Controls.Clear();
            lst_SelectedFields.Items.Clear();
            dgv_SelectedFields.Rows.Clear();

            pnl.Controls.Add(btn_RepHeader);
            pnl.Controls.Add(btn_PageHeader);
            pnl.Controls.Add(btn_Details);
            pnl.Controls.Add(btn_PageFooter);
            pnl.Controls.Add(btn_RepFooter);

            foreach (DataRow r in ds_print.Tables[0].Rows)
            {
                if (r["id"].ToString() == com_Desigen.SelectedValue.ToString())
                {
                    pnl.Size = new Size(Convert.ToInt32(r["pagew"]), Convert.ToInt32(r["pageh"]));
                    btn_RepHeader.Width = pnl.Width;
                    btn_PageHeader.Width = pnl.Width;
                    btn_Details.Width = pnl.Width;
                    btn_PageFooter.Width = pnl.Width;
                    btn_RepFooter.Width = pnl.Width;

                    btn_RepHeader.Top = Convert.ToInt32(r["repheaderh"]);
                    btn_PageHeader.Top = Convert.ToInt32(r["pageheaderh"]);
                    btn_Details.Top = Convert.ToInt32(r["detailsh"]);
                    btn_PageFooter.Top = Convert.ToInt32(r["pagefooterh"]);
                    btn_RepFooter.Top = Convert.ToInt32(r["repfooterh"]);
                    break;
                }
            }

            foreach (DataRow r in ds_print.Tables[1].Rows)
            {
                if (r["print_id"].ToString() != com_Desigen.SelectedValue.ToString()) continue;

                if (r["fieldtype"].ToString() == "lbl")
                {
                    TextBox txt = new TextBox
                    {
                        BackColor = pnl.BackColor,
                        AutoSize = false,
                        Text = r["fieldtext"].ToString(),
                        Location = new Point(Convert.ToInt32(r["x"]), Convert.ToInt32(r["y"])),
                        Tag = lst_SelectedFields.Items.Count
                    };
                    txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
                    txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);
                    txt.Enter += new System.EventHandler(Enter);
                    txt.Leave += new System.EventHandler(Leave);
                    txt.TextChanged += new System.EventHandler(TextChanged);

                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Cursor = Cursors.Arrow;


                    lst_SelectedFields.Items.Add(txt.Text);
                    pnl.Controls.Add(txt);

                    Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
                    txt.Width = size.Width;
                    txt.Height = size.Height;

                    dgv_SelectedFields.Rows.Add(txt.Text, txt.Text, "lbl", "pageheader", txt.Location.X, txt.Location.Y, "Calibri", 16, 0, true, null);
                }
                else if (r["fieldtype"].ToString() == "val")
                {
                    TextBox txt = new TextBox
                    {
                        Text = r["fieldtext"].ToString(),
                        ReadOnly = true,
                        AutoSize = true
                    };
                    txt.Cursor = Cursors.Arrow;
                    txt.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDown);
                    txt.MouseMove += new System.Windows.Forms.MouseEventHandler(MouseMove);

                    pnl.Controls.Add(txt);


                    dgv_SelectedFields.Rows.Add(txt.Text, txt.Text, "val", "pageheader", txt.Location.X, txt.Location.Y, "Calibri", 16, 0, true, null);
                }
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            pnl.Controls.Clear();
            lst_SelectedFields.Items.Clear();
            dgv_SelectedFields.Rows.Clear();
            com_Desigen.SelectedValue = -1;
            pnl.Size = new Size(500, 600);

            pnl.Controls.Add(btn_RepHeader);
            pnl.Controls.Add(btn_PageHeader);
            pnl.Controls.Add(btn_Details);
            pnl.Controls.Add(btn_PageFooter);
            pnl.Controls.Add(btn_RepFooter);

            btn_RepHeader.Top = Convert.ToInt32(pnl.Height * .2);
            btn_PageHeader.Top = Convert.ToInt32(pnl.Height * .5);
            btn_Details.Top = Convert.ToInt32(pnl.Height * .6);
            btn_PageFooter.Top = Convert.ToInt32(pnl.Height * .9);
            btn_RepFooter.Top = Convert.ToInt32(pnl.Height * 1) - btn_RepFooter .Height;

            btn_RepHeader.Width = pnl.Width;
            btn_PageHeader.Width = pnl.Width;
            btn_Details.Width = pnl.Width;
            btn_PageFooter.Width = pnl.Width;
            btn_RepFooter.Width = pnl.Width;
        }
    }
}
