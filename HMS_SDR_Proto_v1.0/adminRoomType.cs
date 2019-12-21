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
    public partial class adminRoomType : UserControl
    {
        // Database connection
        classconnection con = new classconnection();

        string roomTypeID;
        string origRoomName;
        int rtCount;

        public adminRoomType()
        {
            InitializeComponent();
        }

        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM roomtype");
            ClearForm();
            LockForm();

            dgvRoomType.Enabled = true;

            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";

            txtSearch.Enabled = true;
        }
        private void ClearForm() 
        {
            cboDescription.Text = "";
            txtMaxCap.Clear();
            txtRate1.Clear();
            txtRate2.Clear();
            txtRate3.Clear();
            txtExtensionRate.Clear();
        }
        private void LockForm() 
        {
            cboDescription.Enabled = false;
            txtMaxCap.Enabled = false;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            txtExtensionRate.Enabled = false;
        }
        private void UnlockForm() 
        {
            cboDescription.Enabled = true;
            txtMaxCap.Enabled = true;
            txtRate1.Enabled = true;
            txtRate2.Enabled = true;
            txtRate3.Enabled = true;
            txtExtensionRate.Enabled = true;
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvRoomType.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvRoomType.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[6].ToString());
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

        private void adminRoomType_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM roomtype WHERE name LIKE '%" + txtSearch.text + "%'");
        }

        private void dgvRoomType_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                roomTypeID = dgvRoomType.SelectedRows[0].Cells[0].Value.ToString();
                cboDescription.Text = dgvRoomType.SelectedRows[0].Cells[1].Value.ToString();
                txtMaxCap.Text = dgvRoomType.SelectedRows[0].Cells[2].Value.ToString();
                txtRate1.Text = Convert.ToDouble(dgvRoomType.SelectedRows[0].Cells[3].Value).ToString("0.00");
                txtRate2.Text = Convert.ToDouble(dgvRoomType.SelectedRows[0].Cells[4].Value).ToString("0.00");
                txtRate3.Text = Convert.ToDouble(dgvRoomType.SelectedRows[0].Cells[5].Value).ToString("0.00");
                txtExtensionRate.Text = Convert.ToDouble(dgvRoomType.SelectedRows[0].Cells[6].Value).ToString("0.00");
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch/*(Exception ex)*/
            {
                // MessageBox.Show(ex.Message);
                // do nothing
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvRoomType.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                ClearForm();
                UnlockForm();
                cboDescription.Focus();
                txtSearch.Enabled = false;
            }
            else
            {
                if (cboDescription.Text == "" || txtMaxCap.Text == "" || txtRate1.Text == "" || txtRate2.Text == "" || txtRate3.Text == "" || txtExtensionRate.Text == "")
                {
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Int32.Parse(txtMaxCap.Text) < 1)
                {
                    MessageBox.Show("Invalid maximum capacity!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(txtRate1.Text) <= 0 || Convert.ToDouble(txtRate2.Text) <= 0 || Convert.ToDouble(txtRate3.Text) <= 0 || Convert.ToDouble(txtExtensionRate.Text) <= 0) 
                {
                    MessageBox.Show("Invalid rate!\nRate(s) contains zero value!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Add user 
                    string strAdd = "INSERT INTO roomtype(name,maxcap,rate_1,rate_2,rate_3,extensionrate)" + Environment.NewLine + "values('" + cboDescription.Text + "','" + txtMaxCap.Text + "','" + txtRate1.Text + "','" + txtRate2.Text + "','" + txtRate3.Text + "','" + txtExtensionRate.Text + "')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new room type" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select Count(name) from roomtype where name = '" + cboDescription.Text + "'", dt);
            rtCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvRoomType.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;

                UnlockForm();

                cboDescription.Focus();
                txtSearch.Enabled = false;
                origRoomName = cboDescription.Text;
            }
            else
            {

                if (cboDescription.Text == "" || txtMaxCap.Text == "" || txtRate1.Text == "" || txtRate2.Text == "" || txtRate3.Text == "" || txtExtensionRate.Text == "")
                {
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(Int32.Parse(txtMaxCap.Text) < 1)
                {
                    MessageBox.Show("Invalid maximum capacity!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToDouble(txtRate1.Text) <= 0 || Convert.ToDouble(txtRate2.Text) <= 0 || Convert.ToDouble(txtRate3.Text) <= 0 || Convert.ToDouble(txtExtensionRate.Text) <= 0)
                {
                    MessageBox.Show("Invalid rate!\nRate(s) contains zero value!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(rtCount >= 1 && origRoomName != cboDescription.Text)
                {
                    MessageBox.Show("Room type already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string strEdit = "UPDATE roomtype SET name='" + cboDescription.Text + "',Maxcap='" + txtMaxCap.Text + "',Rate_1='" + txtRate1.Text + "',Rate_2='" + txtRate2.Text + "',Rate_3='" + txtRate3.Text + "',ExtensionRate='" + txtExtensionRate.Text + "' WHERE roomtypeid='" + roomTypeID + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated room type - Room Type ID: " + roomTypeID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(*) as useCount from room where roomTypeID='" + roomTypeID + "'", dt);
            int useCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());

            if (useCount > 0)
            {
                MessageBox.Show("Room Type is still used. Please try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDelete = "DELETE FROM roomtype WHERE roomtypeid=" + roomTypeID + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated room type - Room Type ID: " + roomTypeID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);
                }
                SetDefault();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtMaxCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accept numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if ((e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
            }
        }

        private void txtRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if ((e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
            }
        }

        private void txtRate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if ((e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
            }
        }

        private void txtExtensionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if ((e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
            }
        }

        

        
    }
}
