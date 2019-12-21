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
    public partial class frmAddInvItem : Form
    {
        // Global Variables
        classconnection con = new classconnection();
        string type;
        string CategoryID;
        string SupplierID;

        string selectedProduct;
        int selectedCritLevel;

        string InventoryID;

        public frmAddInvItem()
        {
            InitializeComponent();
        }
        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Default Start Up
        //
        private void SetDefault() 
        {
            GetSupplier();

            cboType.Items.Clear();
            cboType.Items.Add("All");
            cboType.Items.Add("Kitchen Product");
            cboType.Items.Add("ConStore Product");

            cboType.Text = "All";
            cboCategory.Text = "All";
            cboSupplier.Text = "All";
            txtSearch.text = "";
            txtQty.Clear();

            GetProductList();
        }
        //
        // Load Supplier to combobox
        //
        private void GetSupplier() 
        {
            DataTable dt = new DataTable();
            string sql = "SELECT SupplierName FROM Supplier";
            con.SelectRec(sql, dt);
            cboSupplier.Items.Clear();
            cboSupplier.Items.Add("All");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboSupplier.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }
        //
        // Load Category to combobox
        //
        private void GetCategory(string SQL) 
        {
            DataTable dt = new DataTable();
            con.SelectRec(SQL, dt);
            cboCategory.Items.Clear();
            cboCategory.Items.Add("All");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCategory.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }
        //
        // Get Products
        //
        private void GetProductList() 
        {
            DataTable dt = new DataTable();
            string sql = "SELECT a.ProductCode,a.Name,b.SupplierName,c.Type,c.Name,d.UnitName,a.SellingPrice,a.CriticalLevel FROM product a,supplier b, category c, unit d WHERE a.SupplierID=b.SupplierID AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND a.SupplierID LIKE '%" + SupplierID + "%' AND a.CategoryID LIKE '%" + CategoryID + "%' AND c.Type LIKE '%" + type + "%' AND a.Name LIKE '%" + txtSearch.text + "%'";
            con.SelectRec(sql, dt);
            dgvProduct.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvProduct.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[6].ToString(), dt.Rows[i].ItemArray[7].ToString());
                ctrRec++;
            }
            dt.Dispose();
        }
        //
        // Generate InventoryID
        //
        private void GenerateInvID() 
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM inventory";
            con.SelectRec(sql, dt);

            int result = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int newID = result + 1;
            InventoryID = "I" + newID.ToString("000000000");
        }
        /*****************************
         *           EVENTS
         *****************************/
        //
        // Form Load
        //
        private void frmAddInvItem_Load(object sender, EventArgs e)
        {
            SetDefault();
        }
        //
        // Close
        //
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        // Assign type value and load category combobox content
        //
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboType.Text == "All")
            {
                string sql = "SELECT Name FROM category";
                GetCategory(sql);
                type = "";
                cboCategory.Text = "All";
            }
            else if (cboType.Text == "Kitchen Product")
            {
                string sql = "SELECT Name FROM category WHERE Type='1'";
                GetCategory(sql);
                type = "1";
                cboCategory.Text = "All";
            }
            else if (cboType.Text == "ConStore Product")
            {
                string sql = "SELECT Name FROM category WHERE Type='2'";
                GetCategory(sql);
                type = "2";
                cboCategory.Text = "All";
            }
            GetProductList();
        }
        //
        // Get the CategoryID for filtering
        //
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT CategoryID FROM category WHERE Name='" + cboCategory.Text + "' AND type LIKE '%" + type + "%'";
                con.SelectRec(sql, dt);
                CategoryID = dt.Rows.Count == 0 ? "" : dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            GetProductList();
        }
        //
        // Get the SupplierID for filtering
        //
        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SupplierID FROM supplier WHERE SupplierName='" + cboSupplier.Text + "'";
                con.SelectRec(sql, dt);
                SupplierID = dt.Rows.Count == 0 ? "" : dt.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            GetProductList();
        }
        //
        // Search Product
        //
        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetProductList();
        }
        
        //
        // Display Product Details
        //
        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                lblProdCode.Text = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
                lblProdName.Text = dgvProduct.SelectedRows[0].Cells[1].Value.ToString();
                lblSupplier.Text = dgvProduct.SelectedRows[0].Cells[2].Value.ToString();
                lblType.Text = dgvProduct.SelectedRows[0].Cells[3].Value.ToString() == "1" ? "Kitchen Products" : "ConStore Products";
                lblCategory.Text = dgvProduct.SelectedRows[0].Cells[4].Value.ToString();
                lblUnit.Text = dgvProduct.SelectedRows[0].Cells[5].Value.ToString();
                lblPrice.Text = "Php " + Convert.ToDouble(dgvProduct.SelectedRows[0].Cells[6].Value).ToString("N2");
                lblCritLevel.Text = dgvProduct.SelectedRows[0].Cells[7].Value.ToString();

                selectedProduct = dgvProduct.SelectedRows[0].Cells[0].Value.ToString();
                selectedCritLevel = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[7].Value);
            }
            catch { }
            
        }
        //
        // Accept Numbers Only
        //
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //
        // Add Item to Inventory
        //
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int qty = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
            // Validate quantity
            if (qty < 1)
            {
                MessageBox.Show("Invalid quantity!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQty.Focus();
            }
            else 
            {   
                // Check if there the product is already existing in inventory list
                DataTable dt = new DataTable();
                string sql = "SELECT COUNT(*) FROM inventory WHERE ProductCode='" + selectedProduct + "'";
                con.SelectRec(sql, dt);
                int result = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                // If product exists update the quantity
                if (result > 0)
                {
                    // Get the current qtyonhand
                    DataTable dtGetQtyOnHand = new DataTable();
                    string sqlGetQtyOnHand = "SELECT QtyOnHand FROM inventory WHERE ProductCode='" + selectedProduct + "'";
                    con.SelectRec(sqlGetQtyOnHand, dtGetQtyOnHand);
                    // Add existing qty to new quantity
                    int currentQty = Convert.ToInt32(dtGetQtyOnHand.Rows[0].ItemArray[0]);
                    int newQty = currentQty + qty;
                    // Check if the product reaches critical level
                    string status = newQty <= selectedCritLevel ? "CRITICAL" : "AVAILABLE";
                    // Update
                    string sqlUpdInv = "UPDATE inventory SET QtyOnHand='" + newQty+ "', Status='" + status+ "' WHERE ProductCode='"+ selectedProduct+"'";
                    con.ModRec(sqlUpdInv);
                    MessageBox.Show("Product Successfully Added to Inventory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Clear();
                }
                // If product didn't exists create new record
                else 
                {
                    GenerateInvID();
                    // Check if the product reaches critical level
                    string status = qty <= selectedCritLevel ? "CRITICAL" : "AVAILABLE";
                    // Create
                    string sqlAddInv = "INSERT INTO inventory(InventoryID,ProductCode,QtyOnHand,Status) VALUES('" + InventoryID + "','" + selectedProduct + "','" + +qty + "','" + status + "')";
                    con.ModRec(sqlAddInv);
                    MessageBox.Show("Product Successfully Added to Inventory!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Clear();
                }
            }
        } 
    }
}
