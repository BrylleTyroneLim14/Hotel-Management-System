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
    public partial class adminSupplier : UserControl
    {
        public adminSupplier()
        {
            InitializeComponent();
        }

        // Database connection
        classconnection con = new classconnection();

        string SupplierNames = "";
        int supplierCount;
        string origSupplierName;


        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM supplier");
            txtSupID.Text = "";
            txtAddress.Text = "";
            txtSupplierName.Text = "";
            txtContact.Text = "";
            txtSearch.text = "";
            txtSearch.Enabled = true;
            txtSupID.Enabled = false;
            txtContact.Enabled = false;
            txtAddress.Enabled = false;
            txtSupplierName.Enabled = false;
            dgvSupplier.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";

            

        }
        //Get Automatic Supplier ID Base 2 Digits
        void getSupplierID()
        {
            DataTable dt = new DataTable();
            string strregno = "Select SupplierID from Supplier order by SupplierID desc";
            con.SelectRec(strregno, dt);

            if (dt.Rows.Count == 0)
            {
                txtSupID.Text = "01";
            }
            else
            {
                double x = Convert.ToDouble(dt.Rows[0].ItemArray[0]) + 1;
                txtSupID.Text =""+ x.ToString("00");
            }
            dt.Dispose();
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvSupplier.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvSupplier.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString());
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
            getSupplierID();
            DataTable dt = new DataTable();
            con.SelectRec("Select SupplierName from supplier where SupplierName = '" + txtSupplierName.Text + "'", dt);
            
            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvSupplier.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtSupplierName.Enabled = true;
                txtContact.Enabled = true;
                txtAddress.Enabled = true;
                txtSearch.Enabled = false;
                txtSupplierName.Focus();


            }
            else
            {
                try
                {
                    SupplierNames = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
                if (SupplierNames == txtSupplierName.Text)
                {
                    MessageBox.Show("Unit Name is already in a Unit Maintenance Please Enter Another Unit Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSupplierName.Focus();
                }
                else if (txtSupplierName.Text=="" || txtAddress.Text=="" || txtContact.Text=="")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Add Supplier Name 
                    string strAdd = "INSERT INTO supplier(SupplierID,SupplierName,SupplierAddress,SupplierContactNo)" + Environment.NewLine + "values('" + txtSupID.Text + "','"+txtSupplierName.Text+"','"+txtAddress.Text+"','"+txtContact.Text+"')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Supplier Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(SupplierName) from supplier where SupplierName = '" + txtSupplierName.Text + "'", dt);
            supplierCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvSupplier.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtSupplierName.Enabled = true;
                txtContact.Enabled = true;
                txtAddress.Enabled = true;
                txtSupplierName.Focus();
                txtSearch.Enabled = false;
                origSupplierName = txtSupplierName.Text;
            }
            else
            {
                if (txtSupplierName.Text == "" || txtAddress.Text == "" || txtContact.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (supplierCount >= 1 && origSupplierName != txtSupplierName.Text)
                {
                    MessageBox.Show("Supplier already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSupplierName.Focus();
                }
                else
                {
                    //Update Supplier Name on Supplier maintenance
                    string strEdit = "UPDATE Supplier SET SupplierName='" + txtSupplierName.Text+ "',SupplierAddress='"+txtAddress.Text+"',SupplierContactNo='"+txtContact.Text+"'  WHERE SupplierID='" + txtSupID.Text + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Supplier Name - Supplier ID: " + txtSupID.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(supplierid) from product where supplierid = '" + txtSupID.Text + "'", dt);
            supplierCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (supplierCount > 0)
            {
                MessageBox.Show("Supplier still used by a product! Please try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete Supplier Name from Supplier
                    string strDelete = "DELETE FROM Supplier WHERE SupplierID=" + txtSupID.Text + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Supplier Name - Supplier ID: " + txtSupID.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                }
                SetDefault();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        { 
            // Accept numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
             try
            {
               txtSupID.Text = dgvSupplier.SelectedRows[0].Cells[0].Value.ToString();
               txtSupplierName.Text = dgvSupplier.SelectedRows[0].Cells[1].Value.ToString();
               txtAddress.Text = dgvSupplier.SelectedRows[0].Cells[2].Value.ToString();
               txtContact.Text = dgvSupplier.SelectedRows[0].Cells[3].Value.ToString();
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
            GetRecords("SELECT * FROM Supplier WHERE SupplierName LIKE '%" + txtSearch.text + "%'");

        }

        private void adminSupplier_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        // ID - base 2 incremental digits
        
        // Restrictions
        // All fields required
        // No Duplicate name
        // numbers only for phone
    }
}
