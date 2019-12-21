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
    public partial class adminUser : UserControl
    {
        public adminUser()
        {
            InitializeComponent();
        }
        // Database connection
        classconnection con = new classconnection();

        string autoID = "";
        string origUsername;
        int userCount = 0;

        /*****************************
         *          ROUTINES
         *****************************/

        private void getUlvl()
        {
            DataTable dt = new DataTable();
            string strname = "SELECT description FROM usertype";
            con.SelectRec(strname, dt);
            cboUserType.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboUserType.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }
        private void SetDefault()
        {
            GetRecords("SELECT * FROM user");
            ClearForm();
            LockForm();
            txtSearch.Enabled = true;
            dgvUser.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
            getUlvl();
        }
        
        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvUser.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvUser.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString());
                ctrRec++;
            }
            if (ctrRec != 0)
                lblRecCount.Text = "Total of " + ctrRec.ToString() + " record(s) in the list";
            else
                lblRecCount.Text = "No Records!";
            dt.Dispose();

        }

        private void ClearForm() 
        {
            cboUserType.Text = "";
            txtFirstname.Clear();
            txtLastname.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPass.Clear();
            txtSearch.text = "";
            txtUserID.Clear();
            
        }
        private void LockForm() 
        {
            txtFirstname.Enabled = false;
            txtLastname.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPass.Enabled = false;
            txtUsername.Enabled = false;
            cboUserType.Enabled = false;
        }
        private void UnlockForm() 
        {
            txtFirstname.Enabled = true;
            txtLastname.Enabled = true;
            txtPassword.Enabled = true;
            txtConfirmPass.Enabled = true;
            txtUsername.Enabled = true;
            cboUserType.Enabled = true;
        }
        /*****************************
         *           EVENTS
         *****************************/


        private void adminUser_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string strUsertypeID = "Select usertypeid from usertype where description='" + cboUserType.Text + "'";
                con.SelectRec(strUsertypeID, dt);
                lblusertypeid.Text = dt.Rows[0].ItemArray[0].ToString();

                DataTable dtCount = new DataTable();
                string strCount = "Select count(*) from user where usertypeid='" + lblusertypeid.Text + "'";
                con.SelectRec(strCount, dtCount);
                int result = Convert.ToInt32(dtCount.Rows[0].ItemArray[0].ToString());
                int newID = result + 1;
                autoID = lblusertypeid.Text + "" + newID.ToString("00");
             
            }
            catch
            {
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            con.SelectRec("Select username from user where username='" + txtUsername.Text + "'", dt);

            if (btnCreate.Text.Equals("Add New"))
            {
                dgvUser.Enabled = false;
                btnCreate.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;

                ClearForm();
                UnlockForm();
                txtSearch.Enabled = false;
                
                cboUserType.Focus();  
            }
            else
            {
                if (txtFirstname.Text == "" || txtLastname.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPass.Text == "" || cboUserType.Text == "")
                {
                    MessageBox.Show("Required field(s) missing \n Please check your input!");
                }
                else if (dt.Rows.Count == 0)
                {
                    if (txtPassword.Text.Equals(txtConfirmPass.Text))
                    { txtUserID.Text=autoID;
                        //insert data
                        string strAdd = "Insert Into user(userid,usertypeid,username,password,firstname,lastname)" + Environment.NewLine + "values('" + autoID + "','" + lblusertypeid.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFirstname.Text + "','" + txtLastname.Text + "')";
                        con.ModRec(strAdd);

                        // Log to audit trail
                        string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new User " + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        con.ModRec(strAddlogs);
                        SetDefault();
                    }
                    else
                    {
                        MessageBox.Show("Password mismatched");
                        txtPassword.Clear();
                        txtConfirmPass.Clear();
                        txtPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Username Already Exist!");
                }
                dt.Dispose();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(username) as userCount from user where username='" + txtUsername.Text + "'", dt);
            userCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;

                UnlockForm();
                txtSearch.Enabled = false;
                cboUserType.Enabled = false;
                cboUserType.Focus();

                origUsername = txtUsername.Text;
            }
            else
            {
                if (txtFirstname.Text == "" || txtLastname.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPass.Text == "" || cboUserType.Text == "")
                {
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (userCount >= 1 && origUsername != txtUsername.Text)
                {
                    MessageBox.Show("Username already used", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //update user
                   string strEdit = "Update user set username= '" + txtUsername.Text + "'," + Environment.NewLine + " password='" + txtPassword.Text + "'," + Environment.NewLine + " firstname='" + txtFirstname.Text + "'," + Environment.NewLine + " lastname='" + txtLastname.Text + "'Where userid=" + txtUserID.Text +"";
                   con.ModRec(strEdit);

                   // Log to audit trail
                   string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated User Name - User ID: " +txtUserID.Text+ "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                   con.ModRec(strAddlogs);
                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete the Selected Record?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string strDel = "Delete From user Where userid=" + txtUserID.Text + "";
                con.ModRec(strDel);

                // Log to audit trail
                string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete User Name - User ID: " + txtUserID.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                con.ModRec(strAddlogs);
            }
            SetDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

       

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM user WHERE UserName LIKE '%" + txtSearch.text + "%'");
        }

        private void dgvUser_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {

                txtUserID.Text = dgvUser.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    string usertypeid = dgvUser.SelectedRows[0].Cells[1].Value.ToString();
                    DataTable dt = new DataTable();
                    string strDesc = "Select Description from usertype where usertypeid='" + usertypeid + "'";
                    con.SelectRec(strDesc, dt);
                    cboUserType.Text = dt.Rows[0].ItemArray[0].ToString();
                    cboUserType.Enabled = false;
                }
                catch
                {

                }
                txtUsername.Text = dgvUser.SelectedRows[0].Cells[2].Value.ToString();
                txtPassword.Text = dgvUser.SelectedRows[0].Cells[3].Value.ToString();
                txtConfirmPass.Text = dgvUser.SelectedRows[0].Cells[3].Value.ToString();
                txtFirstname.Text = dgvUser.SelectedRows[0].Cells[4].Value.ToString();
                txtLastname.Text = dgvUser.SelectedRows[0].Cells[5].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = true;
                btnCancel.Enabled = false;
            }
            catch
            {

            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
