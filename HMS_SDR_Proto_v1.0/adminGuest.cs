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
    public partial class adminGuest : UserControl
    {
        public adminGuest()
        {
            InitializeComponent();
        }
        // Database connection
        classconnection con = new classconnection();

        int GuestID;
        //string GuestNames = "";

        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM guest");
            txtGuestID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtAddress.Text = "";
            txtCompany.Text = "";
            txtContactNum.Text = "";
            txtSearch.text = "";
            txtGuestID.Enabled = false;
            txtFirstname.Enabled = false;
            txtLastname.Enabled = false;
            txtAddress.Enabled = false;
            txtCompany.Enabled=false;
            txtContactNum.Enabled = false;

            dgvGuest.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";

        }
        //Get Automatic Guest ID Base 10 Digits
        void getGuestID()
        {
            DataTable dt = new DataTable();
            string strregno = "Select guestid from guest order by guestid desc";
            con.SelectRec(strregno, dt);

            if (dt.Rows.Count == 0)
            {
                txtGuestID.Text = "0000000001";
            }
            else
            {
                double x = Convert.ToDouble(dt.Rows[0].ItemArray[0]) + 1;
                txtGuestID.Text =x.ToString("0000000000");
            }
            dt.Dispose();
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvGuest.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvGuest.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[1].ToString()+" "+dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString());
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
            getGuestID();
            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvGuest.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtFirstname.Enabled = true;
                txtLastname.Enabled = true;
                txtAddress.Enabled = true;
                txtCompany.Enabled = true;
                txtContactNum.Enabled = true;
                txtFirstname.Focus();
            }
            else
            {
                if (txtFirstname.Text == "" ||txtLastname.Text == "" || txtAddress.Text == ""|| txtContactNum.Text=="")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Add Guest Name 
                    string strAdd = "INSERT INTO guest(GuestID,FirstName,LastName,Address,Company,MobileNo)" + Environment.NewLine + "values('" + txtGuestID.Text + "','" + txtFirstname.Text + "','" + txtLastname.Text +"','" + txtAddress.Text + "','"+txtCompany.Text+"','"+txtContactNum.Text+"')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Guest Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }

            }
        }

        private void adminGuest_Load(object sender, EventArgs e)
        {
            SetDefault();
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvGuest.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtFirstname.Enabled = true;
                txtLastname.Enabled = true;
                txtAddress.Enabled = true;
                txtCompany.Enabled = true;
                txtContactNum.Enabled = true;
                txtFirstname.Focus();

            }
            else
            {

                if (txtFirstname.Text == "" || txtLastname.Text == "" || txtAddress.Text == "" || txtContactNum.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Update Supplier Name on Supplier maintenance
                    string strEdit = "UPDATE Guest SET  firstname='" + txtFirstname.Text + "',LastName='" + txtLastname.Text + "',Address='" + txtAddress.Text + "',Company='" + txtCompany.Text + "',MobileNo='" + txtContactNum.Text + "'  WHERE guestid='" + txtGuestID.Text + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Guest Name - Supplier ID: " + GuestID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //delete Supplier Name from Supplier
                string strDelete = "DELETE FROM Guest WHERE GuestID=" + GuestID + "";
                con.ModRec(strDelete);

                // Log to audit trail
                string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Guest Name - Guest ID: " + GuestID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                con.ModRec(strAddlogs);
                dgvGuest.Enabled = true;
            }
            SetDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtContactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accept numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void dgvGuest_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtGuestID.Text = dgvGuest.SelectedRows[0].Cells[0].Value.ToString();
                GuestID = Convert.ToInt32(dgvGuest.SelectedRows[0].Cells[0].Value.ToString());
                txtFirstname.Text = dgvGuest.SelectedRows[0].Cells[1].Value.ToString();
                txtLastname.Text = dgvGuest.SelectedRows[0].Cells[2].Value.ToString();
                txtAddress.Text= dgvGuest.SelectedRows[0].Cells[4].Value.ToString();
                txtCompany.Text = dgvGuest.SelectedRows[0].Cells[5].Value.ToString();
                txtContactNum.Text= dgvGuest.SelectedRows[0].Cells[6].Value.ToString();

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

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM guest WHERE concat(firstname,' ',lastname) LIKE '%" + txtSearch.text + "%'");
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        // Check mo yung column
        // merong hiwalay na first name at last name
        // meron din full name
        // ung hiwalay para pag nag select sa grid view un ung iffetch na value sa textbox
        // ung fullname para compact ung display nya sa gridview
        // kaya pag nag query ka nlng pareho mong kunin ung concat(firstname,'',lastname) at, firstname,lastname

        // Auto Generated ID logic:
        // incremental ID lang, pero base sa 10 digits.
        // Ex. 0000000001, 0000000002, 0000000003

        // Restrictions
        // ID - not editable
        // Names - Letters only
        // Contact Number - Numbers Only
        
    }
}
