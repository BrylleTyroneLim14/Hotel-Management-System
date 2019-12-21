using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMS_SDR_Proto_v1._0
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }
        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefaultNavColor()
        {
            navUAL.ForeColor = Color.FromArgb(141, 146, 150);
            navUser.ForeColor = Color.FromArgb(141, 146, 150);
            navActLog.ForeColor = Color.FromArgb(141, 146, 150);
            navRoomType.ForeColor = Color.FromArgb(141, 146, 150);
            navRoom.ForeColor = Color.FromArgb(141, 146, 150);
            navStaff.ForeColor = Color.FromArgb(141, 146, 150);
            navGuest.ForeColor = Color.FromArgb(141, 146, 150);
            navSupplier.ForeColor = Color.FromArgb(141, 146, 150);
            navCategory.ForeColor = Color.FromArgb(141, 146, 150);
            navMeasurement.ForeColor = Color.FromArgb(141, 146, 150);
            navProduct.ForeColor = Color.FromArgb(141, 146, 150);
        }
        private void SetDefaultFontStyle()
        {
            navUAL.Font = new Font(navUAL.Font, FontStyle.Regular);
            navUser.Font = new Font(navUser.Font, FontStyle.Regular);
            navActLog.Font = new Font(navActLog.Font, FontStyle.Regular);
            navRoomType.Font = new Font(navRoomType.Font, FontStyle.Regular);
            navRoom.Font = new Font(navRoom.Font, FontStyle.Regular);
            navStaff.Font = new Font(navStaff.Font, FontStyle.Regular);
            navGuest.Font = new Font(navGuest.Font, FontStyle.Regular);
            navSupplier.Font = new Font(navSupplier.Font, FontStyle.Regular);
            navCategory.Font = new Font(navCategory.Font, FontStyle.Regular);
            navMeasurement.Font = new Font(navMeasurement.Font, FontStyle.Regular);
            navProduct.Font = new Font(navProduct.Font, FontStyle.Regular);
        }
        private void HideAllTabs()
        {
            adminUserType.Hide();
            adminUser.Hide();
            adminActLog.Hide();
            adminRoomType.Hide();
            adminRoom.Hide();
            adminStaff.Hide();
            adminGuest.Hide();
            adminSupplier.Hide();
            adminCategory.Hide();
            adminUnit.Hide();
            adminProduct.Hide();
        }

        /*****************************
         *           EVENTS
         *****************************/
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            HideAllTabs();
        }

        //
        // NAV TRANSITIONS
        //

        // User Access Level
        private void navUAL_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUAL.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navUAL.Font = new Font(navUAL.Font, FontStyle.Bold);
            HideAllTabs();
            adminUserType.Show();
        }
        private void icoAccessLevel_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUAL.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navUAL.Font = new Font(navUAL.Font, FontStyle.Bold);
            HideAllTabs();
            adminUserType.Show();
        }

        // User
        private void navUser_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUser.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navUser.Font = new Font(navUser.Font, FontStyle.Bold);
            HideAllTabs();
            adminUser.Show();
        }
        private void icoUsers_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUser.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navUser.Font = new Font(navUser.Font, FontStyle.Bold);
            HideAllTabs();
            adminUser.Show();
        }

        // Activity Log
        private void navActLog_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navActLog.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navActLog.Font = new Font(navActLog.Font, FontStyle.Bold);
            HideAllTabs();
            adminActLog.Show();
        }
        private void icoActLog_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navActLog.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navActLog.Font = new Font(navActLog.Font, FontStyle.Bold);
            HideAllTabs();
            adminActLog.Show();
        }

        // Room Type
        private void icoRoomType_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRoomType.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navRoomType.Font = new Font(navRoomType.Font, FontStyle.Bold);
            HideAllTabs();
            adminRoomType.Show();
        }
        private void navRoomType_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRoomType.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navRoomType.Font = new Font(navRoomType.Font, FontStyle.Bold);
            HideAllTabs();
            adminRoomType.Show();
        }

        // Room
        private void icoRoom_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRoom.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navRoom.Font = new Font(navRoom.Font, FontStyle.Bold);
            HideAllTabs();
            adminRoom.Show();
        }
        private void navRoom_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRoom.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navRoom.Font = new Font(navRoom.Font, FontStyle.Bold);
            HideAllTabs();
            adminRoom.Show();
        }

        // Staff
        private void icoStaff_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navStaff.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navStaff.Font = new Font(navStaff.Font, FontStyle.Bold);
            HideAllTabs();
            adminStaff.Show();
        }
        private void navStaff_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navStaff.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navStaff.Font = new Font(navStaff.Font, FontStyle.Bold);
            HideAllTabs();
            adminStaff.Show();
        }

        //Guest
        private void icoGuest_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navGuest.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navGuest.Font = new Font(navGuest.Font, FontStyle.Bold);
            HideAllTabs();
            adminGuest.Show();
        }
        private void navGuest_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navGuest.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navGuest.Font = new Font(navGuest.Font, FontStyle.Bold);
            HideAllTabs();
            adminGuest.Show();
        }

        // Supplier
        private void icoSupplier_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navSupplier.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navSupplier.Font = new Font(navSupplier.Font, FontStyle.Bold);
            HideAllTabs();
            adminSupplier.Show();
        }
        private void navSupplier_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navSupplier.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navSupplier.Font = new Font(navSupplier.Font, FontStyle.Bold);
            HideAllTabs();
            adminSupplier.Show();
        }
        
        // Category
        private void icoCategory_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navCategory.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navCategory.Font = new Font(navCategory.Font, FontStyle.Bold);
            HideAllTabs();
            adminCategory.Show();
        }
        private void navCategory_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navCategory.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navCategory.Font = new Font(navCategory.Font, FontStyle.Bold);
            HideAllTabs();
            adminCategory.Show();
        }

        // Unit of Measurement
        private void icoMeasurement_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navMeasurement.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navMeasurement.Font = new Font(navMeasurement.Font, FontStyle.Bold);
            HideAllTabs();
            adminUnit.Show();
        }
        private void navMeasurement_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navMeasurement.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navMeasurement.Font = new Font(navMeasurement.Font, FontStyle.Bold);
            HideAllTabs();
            adminUnit.Show();
        }

        // Product
        private void icoProduct_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navProduct.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navProduct.Font = new Font(navProduct.Font, FontStyle.Bold);
            HideAllTabs();
            adminProduct.Show();
        }
        private void navProduct_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navProduct.ForeColor = System.Drawing.Color.White;
            SetDefaultFontStyle();
            navProduct.Font = new Font(navProduct.Font, FontStyle.Bold);
            HideAllTabs();
            adminProduct.Show();
        }

        //
        // END OF NAV TRANSITION
        //
    }
}
