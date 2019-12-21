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
    public partial class adminProduct : UserControl
    {
        public adminProduct()
        {
            InitializeComponent();
        }

        // Database connection
        classconnection con = new classconnection();


        string catID;
        string UnitID;
        string autoID;
        int productCount;
        string origProduct;


        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM product");
            txtProductCode.Enabled = false;
            cboSupplier.Enabled=false;
            cboCategory.Enabled = false;
            cboMeasurement.Enabled = false;
            txtName.Enabled = false;
            txtSupPrice.Enabled = false;
            txtSelPrice.Enabled = false;
            txtCriticalLevel.Enabled = false;

            txtProductCode.Text = "";
            cboSupplier.Text = "";
            cboCategory.Text = "";
            cboMeasurement.Text = "";
            txtName.Text = "";
            txtSupPrice.Text = "";
            txtSelPrice.Text = "";
            txtCriticalLevel.Text = "";

            dgvProduct.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
            getSupplier();
            getCategory();
            getUnitofMeasurement();

            txtSearch.Enabled = true;
        }
        //get supplier
        private void getSupplier()
        {
            DataTable dt = new DataTable();
            string strname = "SELECT SupplierName FROM Supplier";
            con.SelectRec(strname, dt);
            cboSupplier.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboSupplier.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }

        //get category
        private void getCategory()
        {
            DataTable dt = new DataTable();
            string strname = "SELECT Name FROM Category";
            con.SelectRec(strname, dt);
            cboCategory.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCategory.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }

        //get Unit Of Measurement

        private void getUnitofMeasurement()
        {
            DataTable dt = new DataTable();
            string strname = "SELECT UnitName FROM Unit";
            con.SelectRec(strname, dt);
            cboMeasurement.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboMeasurement.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvProduct.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvProduct.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[6].ToString(), dt.Rows[i].ItemArray[7].ToString());
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
            DataTable dt = new DataTable();
            con.SelectRec("Select Name from product where name = '" + txtName.Text + "'", dt);

            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvProduct.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                cboSupplier.Enabled = true;
                cboCategory.Enabled = true;
                cboMeasurement.Enabled = true;
                txtName.Enabled = true;
                txtSupPrice.Enabled = true;
                txtSelPrice.Enabled = true;
                txtCriticalLevel.Enabled = true;
                cboSupplier.Focus();
                txtSearch.Enabled = false;
            }
            else
            {

                if (cboSupplier.Text=="" || cboCategory.Text == "" || cboMeasurement.Text == "" || txtName.Text == "" || txtSupPrice.Text == "" || txtSelPrice.Text == "" || txtCriticalLevel.Text == "" )
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dt.Rows.Count == 0)
                {
                    // Add Product Name 
                    string strAdd = "INSERT INTO product(ProductCode,SupplierID,CategoryID,UnitID,Name,SupplierPrice,SellingPrice,CriticalLevel)" + Environment.NewLine + "values('" + autoID + "','" + lblsupplierid.Text + "','" + catID + "'," + UnitID + ",'" + txtName.Text + "'," + txtSupPrice.Text + "," + txtSelPrice.Text + "," + txtCriticalLevel.Text + ")";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Room Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
                else
                {
                    MessageBox.Show("Product Name is already in a Product Maintenance Please Enter Another Product Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();

                }
            }
        }

        private void adminProduct_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSupplierID = "Select supplierid from supplier where SupplierName='" + cboSupplier.Text + "'";
                con.SelectRec(strSupplierID, dt);
                lblsupplierid.Text = dt.Rows[0].ItemArray[0].ToString();

                DataTable dtCount = new DataTable();
                string strCount = "Select count(*) from product where supplierid='" + lblsupplierid.Text + "'";
                con.SelectRec(strCount, dtCount);
                int result = Convert.ToInt32(dtCount.Rows[0].ItemArray[0].ToString());
                int newID = result + 1;
                autoID = lblsupplierid.Text + "" + newID.ToString("00000000");

            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(Name) from product where name = '" + txtName.Text + "'", dt);
            productCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvProduct.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                cboSupplier.Enabled = false;
                cboCategory.Enabled = true;
                cboMeasurement.Enabled = true;
                txtName.Enabled = true;
                txtSupPrice.Enabled = true;
                txtSelPrice.Enabled = true;
                txtCriticalLevel.Enabled = true;
                cboSupplier.Focus();
                txtSearch.Enabled = false;

                origProduct = txtName.Text;

            }
            else
            {

                if (cboSupplier.Text == "" || cboCategory.Text == "" || cboMeasurement.Text == "" || txtName.Text == "" || txtSupPrice.Text == "" || txtSelPrice.Text == "" || txtCriticalLevel.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(productCount > 0 && origProduct != txtName.Text)
                {
                    MessageBox.Show("Product already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Update Supplier Name on Supplier maintenance
                    string strEdit = "UPDATE product SET  categoryid='" + catID+ "',UnitID='" + UnitID + "',Name='" + txtName.Text + "',SupplierPrice='" + txtSupPrice.Text + "',SellingPrice='" + txtSelPrice.Text + "',CriticalLevel='"+txtCriticalLevel.Text+"'  WHERE productcode='" + txtProductCode.Text + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Product Name - Product ID: " + txtProductCode.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();

                }
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string strCatID = "Select categoryid from category where name='" + cboCategory.Text + "'";
                con.SelectRec(strCatID, dt);
                catID = dt.Rows[0].ItemArray[0].ToString();
               
            }
            catch
            {
            }
        }

        private void cboMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSupplierID = "Select Unitid from Unit where  Unitname='" + cboMeasurement.Text+ "'";
                con.SelectRec(strSupplierID, dt);
                UnitID = dt.Rows[0].ItemArray[0].ToString();
               
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //delete Supplier Name from Supplier
                string strDelete = "DELETE FROM product WHERE productcode=" + txtProductCode.Text + "";
                con.ModRec(strDelete);

                // Log to audit trail
                string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Product Name - Product ID: " + txtProductCode.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                con.ModRec(strAddlogs);
                
            }
            SetDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductCode.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
                
                try
                {
                    string supid = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
                    string catid = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
                    string unitid = dgvProduct.SelectedRows[0].Cells[3].Value.ToString();
                    //supplier
                    DataTable dtSupplier = new DataTable();
                    string strSupName= "Select SupplierName from Supplier where Supplierid='" + supid + "'";
                    con.SelectRec(strSupName, dtSupplier);
                    cboSupplier.Text = dtSupplier.Rows[0].ItemArray[0].ToString();
                    cboSupplier.Enabled = false;

                    //category
                    DataTable dtCategory = new DataTable();
                    string strCategory = "Select Name from category where categoryid='" + catid+ "'";
                    con.SelectRec(strCategory, dtCategory);
                    cboCategory.Text = dtCategory.Rows[0].ItemArray[0].ToString();

                    //Unit Name
                    DataTable dtUnit = new DataTable();
                    string strUnit = "Select UnitName from Unit where UnitID='" + unitid + "'";
                    con.SelectRec(strUnit, dtUnit);
                    cboMeasurement.Text = dtUnit.Rows[0].ItemArray[0].ToString();
                }
                catch
                {

                }
                txtName.Text = dgvProduct.SelectedRows[0].Cells[4].Value.ToString();
                txtSupPrice.Text = dgvProduct.SelectedRows[0].Cells[5].Value.ToString();
                txtSelPrice.Text = dgvProduct.SelectedRows[0].Cells[6].Value.ToString();
                txtCriticalLevel.Text = dgvProduct.SelectedRows[0].Cells[7].Value.ToString();

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
            GetRecords("SELECT * FROM product WHERE Name LIKE '%" + txtSearch.text + "%'");
        }

        private void txtCriticalLevel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSelPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSupPrice_KeyPress(object sender, KeyPressEventArgs e)
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

      

        // Auto Generated ID Logic:
        // base 10 digit
        // first 2 digits depende sa supplier ID
        // next 8 digits incremental
        // ex. 0100000001, 0100000002

        // Restrictions
        // All fields required
        // Supplier - not editable
        // Category - editable
        // Measurement - editable
        // No duplicate product name
        // Prices - double with 2 decimal values only
        // Critical Level - numbers only
    }
}
