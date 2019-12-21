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
    [System.Runtime.InteropServices.Guid("B96694B7-A64C-4475-A5F2-6A52C9DD228F")]
    public partial class frmLogin : Form
    {
        // Database connection
        classconnection con = new classconnection();

        public frmLogin()
        {
            InitializeComponent();
        }
        /*****************************
         *          ROUTINES
         *****************************/
        public void SetDefault()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }
        /*****************************
         *            EVENTS
         *****************************/
        private void frmLogin_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Choose sql query depending on the checked radio button / User Type
            string strUser;
            if (rdoAdmin.Checked == true)
            {
                strUser = "SELECT UserID,Username,Password FROM user WHERE Username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "' AND UserTypeID = '01'";
            }
            else 
            {
                strUser = "SELECT UserID,Username,Password FROM user WHERE Username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "' AND UserTypeID != '01'";
            }
            
            // Verify User
            try
            {
                DataTable dtUser = new DataTable();
                con.SelectRec(strUser, dtUser);

                string userID = dtUser.Rows[0].ItemArray[0].ToString();
                string user = dtUser.Rows[0].ItemArray[1].ToString();
                string pass = dtUser.Rows[0].ItemArray[2].ToString();

                
                if (user == txtUsername.Text && pass == txtPassword.Text)
                {
                    
                    // Audit Trail
                    string strAddLog = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + userID + "','" + "Logged In" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddLog);
                    
                    // Set Global Variable for CurrentUser
                    con.setCurrentUser(userID);

                    // Redirect to Main Menu
                    frmMainMenu main = new frmMainMenu();
                    main.Show();
                    this.Hide(); 
                }
                else
                {
                    lblError.Show();
                    SetDefault();
                }
                
            }
            catch(Exception ex)
            {
                string errorTester = ex.Message;
                // MessageBox.Show(errorTester);
             
                lblError.Show();
                SetDefault();
            }
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
