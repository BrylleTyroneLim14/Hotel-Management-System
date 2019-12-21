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
    public partial class adminUserType : UserControl
    {
        classconnection con = new classconnection();
        string uTypeID;
        int utCount;
        string origUserType;

        public adminUserType()
        {
            InitializeComponent();
        }
        
        private void SetDefault()
        {
            GetRecords("SELECT * FROM usertype");
            txtSearch.Enabled = true;
            UncheckAccess();
            LockAccess();
            cboUserType.Enabled = false;
            cboUserType.Text = "";

            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;

            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";

            dgvUserType.Enabled = true;
        }

        private void UncheckAccess() 
        {
            chkSales.Checked = false;
            chkReservation.Checked = false;
            chkReport.Checked = false;
            chkInventory.Checked = false;
            chkUserMainte.Checked = false;
            chkRoomMainte.Checked = false;
            chkProdMainte.Checked = false;
            chkGuestMainte.Checked = false;

        }
        private void LockAccess() 
        {
            chkSales.Enabled = false;
            chkReservation.Enabled = false;
            chkReport.Enabled = false;
            chkInventory.Enabled = false;
            chkUserMainte.Enabled = false;
            chkRoomMainte.Enabled = false;
            chkProdMainte.Enabled = false;
            chkGuestMainte.Enabled = false;
        }

        private void UnlockAccess() 
        {
            chkSales.Enabled = true;
            chkReservation.Enabled = true;
            chkReport.Enabled = true;
            chkInventory.Enabled = true;
            chkUserMainte.Enabled = true;
            chkRoomMainte.Enabled = true;
            chkProdMainte.Enabled = true;
            chkGuestMainte.Enabled = true;
        }
        private void GetRecords(string strSQL) 
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvUserType.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvUserType.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[6].ToString(), dt.Rows[i].ItemArray[7].ToString(), dt.Rows[i].ItemArray[8].ToString(), dt.Rows[i].ItemArray[9].ToString());
                ctrRec++;
            }
            if (ctrRec != 0)
                lblRecCount.Text = "Total of " + ctrRec.ToString() + " record(s) in the list";
            else
                lblRecCount.Text = "No Records!";
            dt.Dispose();
        }
        private void adminUserType_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void dgvUserType_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                
                uTypeID = dgvUserType.SelectedRows[0].Cells[0].Value.ToString();
                cboUserType.Text = dgvUserType.SelectedRows[0].Cells[1].Value.ToString();

                chkSales.Checked = dgvUserType.SelectedRows[0].Cells[2].Value.ToString() == "1" ? true : false;
                chkReservation.Checked = dgvUserType.SelectedRows[0].Cells[3].Value.ToString() == "1" ? true : false;
                chkInventory.Checked = dgvUserType.SelectedRows[0].Cells[4].Value.ToString() == "1" ? true : false;
                chkReport.Checked = dgvUserType.SelectedRows[0].Cells[5].Value.ToString() == "1" ? true : false;
                chkRoomMainte.Checked = dgvUserType.SelectedRows[0].Cells[6].Value.ToString() == "1" ? true : false;
                chkProdMainte.Checked = dgvUserType.SelectedRows[0].Cells[7].Value.ToString() == "1" ? true : false;
                chkUserMainte.Checked = dgvUserType.SelectedRows[0].Cells[8].Value.ToString() == "1" ? true : false;
                chkGuestMainte.Checked = dgvUserType.SelectedRows[0].Cells[9].Value.ToString() == "1" ? true : false;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch
            {
                // do nothing
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(description) as utCount from usertype where description='" + cboUserType.Text + "'", dt);
            utCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                cboUserType.Enabled = true;
                UnlockAccess();
                UncheckAccess();
                txtSearch.Enabled = false;
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                dgvUserType.Enabled = false;
                cboUserType.Text = "";
                cboUserType.Focus();
            }
            else 
            {
                if (cboUserType.Text == "")
                {
                    MessageBox.Show("Enter user type description!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (utCount > 0) 
                {
                    MessageBox.Show("User Type already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Generate ID
                    DataTable dtCount = new DataTable();
                    string strCount = "Select count(*) from usertype";
                    con.SelectRec(strCount, dtCount);
                    int result = Convert.ToInt32(dtCount.Rows[0].ItemArray[0].ToString());
                    int newID = result + 1;
                    uTypeID = newID.ToString("00");

                    // Get the values of User Access
                    int sales = (chkSales.Checked == true) ? 1 : 0;
                    int reservation = (chkReservation.Checked == true) ? 1 : 0;
                    int inventory = (chkInventory.Checked == true) ? 1 : 0;
                    int reports = (chkReport.Checked == true) ? 1 : 0;
                    int roomMainte = (chkRoomMainte.Checked == true) ? 1 : 0;
                    int userMainte = (chkUserMainte.Checked == true) ? 1 : 0;
                    int prodMainte = (chkProdMainte.Checked == true) ? 1 : 0;
                    int guestMainte = (chkGuestMainte.Checked == true) ? 1 : 0;

                    string strAdd = "INSERT INTO usertype(usertypeid,description,sales,reservation,inventory,reports,roommaintenance,usermaintenance,productmaintenance,guestmaintenance)" + Environment.NewLine + "values('" + uTypeID + "','" + cboUserType.Text + "','" + sales + "','" + reservation + "','" + inventory + "','" + reports + "','" + roomMainte + "','" + userMainte + "','" + prodMainte + "','" + guestMainte + "')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new user type" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM usertype WHERE description LIKE '%" + txtSearch.text + "%'");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(description) as utCount from usertype where description='" + cboUserType.Text + "'", dt);
            utCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                cboUserType.Enabled = true;
                UnlockAccess();
                txtSearch.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                cboUserType.Focus();
                dgvUserType.Enabled = false;
                origUserType = cboUserType.Text;
            }
            else
            {
                if (cboUserType.Text == "")
                {
                    MessageBox.Show("Enter user type description!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (utCount > 0 && origUserType != cboUserType.Text)
                {
                    MessageBox.Show("User Type already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    // Get the values of User Access
                    int sales = (chkSales.Checked == true) ? 1 : 0;
                    int reservation = (chkReservation.Checked == true) ? 1 : 0;
                    int inventory = (chkInventory.Checked == true) ? 1 : 0;
                    int reports = (chkReport.Checked == true) ? 1 : 0;
                    int roomMainte = (chkRoomMainte.Checked == true) ? 1 : 0;
                    int userMainte = (chkUserMainte.Checked == true) ? 1 : 0;
                    int prodMainte = (chkProdMainte.Checked == true) ? 1 : 0;
                    int guestMainte = (chkGuestMainte.Checked == true) ? 1 : 0;

                    string strUpdate = "UPDATE usertype set description='" + cboUserType.Text + "',sales='" + sales + "',reservation='" + reservation + "',inventory='" + inventory + "',reports='" + reports + "',roommaintenance='" + roomMainte + "',usermaintenance='" + userMainte + "',productmaintenance='" + prodMainte + "',guestmaintenance='" + guestMainte + "' WHERE usertypeid='"+ uTypeID +"'";
                    con.ModRec(strUpdate);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated user type - User Type ID : " + uTypeID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(*) from user where usertypeid = '" + uTypeID + "'", dt);
            utCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (utCount > 0)
            {
                MessageBox.Show("User type is still used by a user. \n Delete all user under this user type first!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete Supplier Name from Supplier
                    string strDelete = "DELETE FROM usertype WHERE usertypeid=" + uTypeID + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete User Type - User Type ID: " + uTypeID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                }
                SetDefault();
            }
        }

        

        // ID - base 2 incremental digits
        // No duplicate 
    }
}
