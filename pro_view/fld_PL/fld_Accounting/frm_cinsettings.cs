using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Accounting
{
    public partial class frm_cinsettings : Form
    {
        public frm_cinsettings()
        {
            InitializeComponent();
        }

        private void btn_PrintSettings_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_PrintingDesigner f = new fld_General_Settings.frm_PrintingDesigner();

            f.Show();
        }
    }
}
