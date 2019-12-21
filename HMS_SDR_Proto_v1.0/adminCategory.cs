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
    public partial class adminCategory : UserControl
    {
        public adminCategory()
        {
            InitializeComponent();
        }
        // Database connection
        classconnection con = new classconnection();
        
        int type;
        int catid;
        string CategoryNames = "";
        int categoryCount;
        string origCatName;


        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM category");

            txtCatName.Text = "";
            txtCategoryID.Text = "";
            cboCatType.Text = "";
            txtCategoryID.Enabled = false;
            txtCatName.Enabled = false;
            cboCatType.Enabled = false;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            dgvCategory.Enabled = true;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
            txtSearch.Enabled = true;
        }
        
        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvCategory.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvCategory.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString());
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
            con.SelectRec("Select name from category where name = '" + txtCatName.Text + "'", dt);

            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvCategory.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtCatName.Enabled = true;
                cboCatType.Enabled = true;
                txtSearch.Enabled = false;
                cboCatType.Text = "";
                txtCatName.Clear();
                cboCatType.Focus();
            }
            else
            {
                try
                {
                    CategoryNames = dt.Rows[0].ItemArray[0].ToString();
                }
                catch
                {
                }
                if (CategoryNames == txtCatName.Text)
                {
                    MessageBox.Show("Category Name is already in a Category Maintenance Please Enter Another Category Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboCatType.Focus();
                }
                else if (txtCatName.Text == "" || txtCategoryID.Text == "" || cboCatType.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Add Category Name 
                    string strAdd = "INSERT INTO category(CategoryID,type,Name)" + Environment.NewLine + "values('" + txtCategoryID.Text + "','" + type + "','" + txtCatName.Text + "')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Category Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void adminCategory_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void cboCatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCatType.Text == "Kitchen Products")
            {
                type = 1;
                DataTable dtCount = new DataTable();
                string strCount = "Select count(*) from category where type='" + type + "'";
                con.SelectRec(strCount, dtCount);
                int result = Convert.ToInt32(dtCount.Rows[0].ItemArray[0].ToString());
                int newID = result + 1;
                txtCategoryID.Text =type +"" + newID.ToString("00");
            }
            else
            {
                type = 2;

                DataTable dtCount = new DataTable();
                string strCount = "Select count(*) from category where type='" + type + "'";
                con.SelectRec(strCount, dtCount);
                int result = Convert.ToInt32(dtCount.Rows[0].ItemArray[0].ToString());
                int newID = result + 1;
                txtCategoryID.Text = type + "" + newID.ToString("00");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(name) from category where name = '" + txtCatName.Text + "'", dt);
            categoryCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvCategory.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                txtCatName.Enabled = true;
                txtCatName.Focus();
                txtSearch.Enabled = false;

                origCatName = txtCatName.Text;
            }
            else
            {
               
                if (txtCatName.Text == "" || txtCategoryID.Text == "" || cboCatType.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(categoryCount > 0 && origCatName != txtCatName.Text)
                {
                    MessageBox.Show("Category Already Exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Update Supplier Name on Supplier maintenance
                    string strEdit = "UPDATE Category SET Name='" + txtCatName.Text + "' WHERE categoryid='" + catid+ "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Category Name - Category ID: " + catid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(categoryid) from product where categoryid = '" + txtCategoryID.Text + "'", dt);
            categoryCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (categoryCount > 0)
            {
                MessageBox.Show("Category is still used by a product! Please try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete Supplier Name from Supplier
                    string strDelete = "DELETE FROM category WHERE CategoryID=" + catid + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Category Name - Supplier ID: " + catid + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                }
                SetDefault();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtCategoryID.Text = dgvCategory.SelectedRows[0].Cells[0].Value.ToString();
                catid = Convert.ToInt32(dgvCategory.SelectedRows[0].Cells[0].Value.ToString());
                if (dgvCategory.SelectedRows[0].Cells[1].Value.ToString() == "1")
                {
                    cboCatType.Text = "Kitchen Products";
                }
                else {
                    cboCatType.Text = "ConStore Products";
                }
                
                txtCatName.Text = dgvCategory.SelectedRows[0].Cells[2].Value.ToString();
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
            GetRecords("SELECT * FROM category WHERE Name LIKE '%" + txtSearch.text + "%'");
        }
        // Category type values
        // 1(value sa db) - Kitchen Products(Display sa ComboBox)
        // 2(value sa db) - Convenient Store Product(Display sa ComboBox)
        // di ko na nilagyan ng maintenance kasi static values nmn yan

        // Auto Generated ID logic: 
        // 1st digit base sa piniling type... 1 - Kitchen, 2 - ConStore
        // next 2 digits increment nlng, 01,02,03
        // Sample ID: 101, 102, 201, 202

        // Restriction
        // No duplicate category name
        // ID and Type not editable
    }
}
