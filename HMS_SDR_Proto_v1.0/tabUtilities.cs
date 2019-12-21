using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMS_SDR_Proto_v1._0
{
    public partial class tabUtilities : UserControl
    {
        public tabUtilities()
        {
            InitializeComponent();
        }

        private void btnAdminTools_Click(object sender, EventArgs e)
        {
            frmMaintenance maintenance = new frmMaintenance();
            maintenance.ShowDialog();
        }
    }
}
