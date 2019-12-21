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
    public partial class adminStaff : UserControl
    {
        public adminStaff()
        {
            InitializeComponent();
        }

        // Database connection
        classconnection con = new classconnection();

        int StaffID;
        int staffCount;
        string origStaffName;

        /*****************************
         *          ROUTINES
         *****************************/
        private void SetDefault()
        {
            GetRecords("SELECT * FROM staff");
            cboStaffName.Text = "";
            txtStaffID.Text = "";
            txtSearch.text = "";
            txtSearch.Enabled = true;
            txtStaffID.Enabled = false; 
            cboStaffName.Enabled = false;
            dgvStaff.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
        
        }
        //Get Automatic ID Base 5 Digits
        void getStaffID()
        {
            DataTable dt = new DataTable();
            string strregno = "Select StaffID from Staff order by StaffID desc";
            con.SelectRec(strregno, dt);

            if (dt.Rows.Count == 0)
            {
                txtStaffID.Text = "10001";
            }
            else
            {
                double x = Convert.ToDouble(dt.Rows[0].ItemArray[0]) + 1;
                txtStaffID.Text = x.ToString();
            }
            dt.Dispose();
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvStaff.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvStaff.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString());
                ctrRec++;
            }
            if (ctrRec != 0)
                lblRecCount.Text = "Total of " + ctrRec.ToString() + " record(s) in the list";
            else
                lblRecCount.Text = "No Records!";
            dt.Dispose();

        }

        /*****************************
         *           EVENTS
         *****************************/

        private void btnCreate_Click(object sender, EventArgs e)
        {
            getStaffID();
            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvStaff.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtSearch.Enabled = false;
                cboStaffName.Text = "";
                cboStaffName.Enabled = true;
                cboStaffName.Focus();
            
            }
            else
            {
                
                 if (cboStaffName.Text=="")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Add StaffName 
                    string strAdd = "INSERT INTO staff(StaffID,Name)" + Environment.NewLine + "values('" + txtStaffID.Text + "','"+cboStaffName.Text+"')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Staff Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select Count(name) from staff where name = '" + cboStaffName.Text + "'", dt);
            staffCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvStaff.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtSearch.Enabled = false;
                cboStaffName.Enabled = true;
                cboStaffName.Focus();

                origStaffName = cboStaffName.Text;
            }
            else
            {
               
                 if (cboStaffName.Text=="")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(staffCount >= 1 && origStaffName != cboStaffName.Text)
                {
                    MessageBox.Show("Staff already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Update Staff Name on Staff maintenance
                    string strEdit = "UPDATE Staff SET Name='" + cboStaffName.Text + "' WHERE StaffID='" + StaffID + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Staff Name - Staff ID: " + StaffID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //delete data from Staff
                string strDelete = "DELETE FROM Staff WHERE StaffID=" + StaffID + "";
                con.ModRec(strDelete);

                // Log to audit trail
                string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Staff Name - Staff ID: " + StaffID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                con.ModRec(strAddlogs);

            }
            SetDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void adminStaff_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM STAFF WHERE Name LIKE '%" + txtSearch.text + "%'");
        }

        private void dgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtStaffID.Text = dgvStaff.SelectedRows[0].Cells[0].Value.ToString();
                StaffID = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells[0].Value.ToString());
                cboStaffName.Text = dgvStaff.SelectedRows[0].Cells[1].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = true;
                btnCancel.Enabled = false;

            }
            catch
            {
             //do nothing
            }
              
        }

        private void cboStaffName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        // ID - base 5 digits auto increment sa program

        // walang restriction
    }
}
