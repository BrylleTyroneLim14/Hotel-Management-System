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
    public partial class frmMainMenu : Form
    {
        public string User_ID; // container of ID that will be sent from log in module
        
        classconnection con = new classconnection();

        public frmMainMenu()
        {
            InitializeComponent();
  
            User_ID = con.getCurrentUser();
            FetchUserInformation(User_ID);
        }

        /*****************************
         *          ROUTINES
         *****************************/
        
        private void FetchUserInformation(string User_ID)
        {
            DataTable dtUser = new DataTable();
            string strUser = "SELECT a.Firstname,a.Lastname,b.Description  FROM user a, usertype b WHERE UserID='" + User_ID + "' AND a.UserTypeID=b.UserTypeID LIMIT 1";
            con.SelectRec(strUser, dtUser);

            string firstname = dtUser.Rows[0].ItemArray[0].ToString();
            string lastname = dtUser.Rows[0].ItemArray[1].ToString();
            string userType = dtUser.Rows[0].ItemArray[2].ToString();

            lblUserNameDisplay.Text = "Hi, " + firstname + " " + lastname;
            lblUserTypeDisplay.Text = "Logged in as " + userType;

            dtUser.Dispose();
        }
        
        private void SetDefaultNavColor()
        {
            navRM.ForeColor = Color.FromArgb(141, 146, 150);
            navReservations.ForeColor = Color.FromArgb(141, 146, 150);
            navInventory.ForeColor = Color.FromArgb(141, 146, 150);
            navReports.ForeColor = Color.FromArgb(141, 146, 150);
            navUtilities.ForeColor = Color.FromArgb(141, 146, 150);
        }

        private void HideAllTab()
        {
            tabRM.Hide();
            tabReservation.Hide();
            tabInventory.Hide();
            tabReports.Hide();
            tabUtilities.Hide();
        }

        /*****************************
         *           EVENTS
         *****************************/
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            // Display current date
            lblDateDisplay.Text = "Today is " + DateTime.Now.ToString("dddd, MMMM dd, yyyy") + ".";

            HideAllTab();
            tabRM.Show();
        }
        // Time Display
        private void tmTime_Tick(object sender, EventArgs e)
        {
            lblTimeDisplay.Text = "Time : " + DateTime.Now.ToString("hh:mm:ss tt");
        }

        // 
        // NAV TRANSITIONS
        //

        // ROOM MANAGEMENT NAV
        private void navRM_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRM.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabRM.Show();
        }
        private void icoRM_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navRM.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabRM.Show();
        }

        // RESERVATION NAV
        private void navReservations_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navReservations.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabReservation.Show();
        }
        private void icoReservations_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navReservations.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabReservation.Show();
        }

        // INVENTORY NAV
        private void navInventory_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navInventory.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabInventory.Show();
        }
        private void icoInventory_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navInventory.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabInventory.Show();
        }

        // REPORTS NAV
        private void navReports_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navReports.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabReports.Show();
        }
        private void icoReports_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navReports.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabReports.Show();
        }

        // UTILITIES NAV
        private void navUtilities_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUtilities.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabUtilities.Show();
        }
        private void icoUtilities_Click(object sender, EventArgs e)
        {
            SetDefaultNavColor();
            navUtilities.ForeColor = System.Drawing.Color.White;

            HideAllTab();
            tabUtilities.Show();
        }
        //
        // END OF NAV TRANSITIONS
        //

        private void lblLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Audit Trail
                string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strAddLog = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + User_ID + "','" + "Logged Out" + "','" + currentDateTime + "')";
                con.ModRec(strAddLog);
                this.Close();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }
    }
}
