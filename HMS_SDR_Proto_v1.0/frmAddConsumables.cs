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
    public partial class frmAddConsumables : Form
    {
        // Global Variables
        classconnection con = new classconnection();
        string transNo;
        string type;
        string selectedProductCode;
        int selectedQtyOnHand;
        string CSKS_ID;
        double selectedAmount;

        public frmAddConsumables(string selectedTransNo)
        {
            InitializeComponent();
            transNo = selectedTransNo;
        }
        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Get Products from Inventory
        //
        private void GetProducts(string SQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(SQL, dt);
            dgvProductList.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvProductList.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), Convert.ToDouble(dt.Rows[i].ItemArray[4]).ToString("N2"), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[4].ToString());
                ctrRec++;
            }
            dt.Dispose();
        }
        //
        // Auto Generate CSKS_Code
        //
        private void Generate_CSKSID()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM constorekitchensales";
            con.SelectRec(sql, dt);
            int results = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
            int newID = results + 1;
            CSKS_ID = "CK" + results.ToString("00000000");
        }
        /*****************************
         *           EVENTS
         *****************************/
        //
        // Default Startup
        // 
        private void frmAddConsumables_Load(object sender, EventArgs e)
        {
            cboType.Items.Clear();
            cboType.Items.Add("All Products");
            cboType.Items.Add("Kitchen Products");
            cboType.Items.Add("ConStore Products");
            cboType.Text = "All Products";

            cboFilter.Items.Clear();
            cboFilter.Items.Add("Product Code");
            cboFilter.Items.Add("Product Name");
            cboFilter.Text = "Product Code";

            GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%'");

        }
        //
        // Cancel 
        //
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        // Filter by Type
        //
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboType.Text == "All Products")
            {
                type = "";
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%'");
            }
            else if (cboType.Text == "Kitchen Products")
            {
                type = "1";
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%'");
            }
            else if (cboType.Text == "ConStore Products")
            {
                type = "2";
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%'");
            }
        }
        //
        // Search Product
        //
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text == "Product Code") 
            {
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%' AND a.ProductCode LIKE '%" + txtSearch.Text + "%'");
            }
            else if (cboFilter.Text == "Product Name")
            {
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%' AND a.Name LIKE '%" + txtSearch.Text + "%'");
            }
        }
        //
        // Numbers ONLY Restriction
        //
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //
        // Add Consumables
        //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int qty = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
            if (qty < 1) // Validate Quantity
            {
                MessageBox.Show("Invalid Quantity!","Alert",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else if (selectedQtyOnHand < qty) // Check Inventory Stock
            {
                MessageBox.Show("Insufficient Stock(s)!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                // Add Consumables
                Generate_CSKSID();
                double totalAmount = selectedAmount * qty;
                string remarks = rdoPaid.Checked == true? "PAID" : "UNPAID";
                string sqlAddConsumables = "INSERT INTO constorekitchensales(CSKS_Code,TransactionNo,DateOfSale,ProductCode,Quantity,TotalAmount,Remarks) VALUES('" + CSKS_ID + "','" + transNo + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + selectedProductCode + "','" + qty + "','" + totalAmount + "','" + remarks +"')";
                con.ModRec(sqlAddConsumables);
                // Update Inventory
                int remainingStock = selectedQtyOnHand - qty;
                DataTable dt = new DataTable();
                string sqlCheckCritLevel = "SELECT CriticalLevel FROM product WHERE ProductCode='" + selectedProductCode +"'";
                con.SelectRec(sqlCheckCritLevel, dt);
                string status="";
                if(remainingStock == 0)
                {
                    status = "OUT OF STOCK";
                }
                else if (remainingStock <= Convert.ToInt32(dt.Rows[0].ItemArray[0]))
                {
                    status = "CRITICAL";
                }
                else 
                {
                    status = "AVAILABLE";
                }
                string sqlUpdateInventory = "UPDATE inventory SET QtyOnHand='" + remainingStock + "', Status='" + status + "' WHERE ProductCode='"+selectedProductCode+"'";
                con.ModRec(sqlUpdateInventory);
                // Update RoomSales
                DataTable dtRoomSale = new DataTable();
                string sqlTransDetail = "SELECT OtherCharges, TotalCharge, TotalPaid FROM roomsales WHERE TransactionNo='" + transNo + "'";
                con.SelectRec(sqlTransDetail, dtRoomSale);
                double otherCharges = Convert.ToDouble(dtRoomSale.Rows[0].ItemArray[0]) + totalAmount;
                double totalCharge = Convert.ToDouble(dtRoomSale.Rows[0].ItemArray[1]) + totalAmount;
                double totalPaid = Convert.ToDouble(dtRoomSale.Rows[0].ItemArray[2]) + totalAmount;
                string sqlUpdateRoomSales = remarks == "PAID" ? "UPDATE roomsales SET OtherCharges='" + otherCharges + "',TotalCharge='" + totalCharge + "',TotalPaid='" + totalPaid + "' WHERE TransactionNo='" + transNo + "'" : "UPDATE roomsales SET OtherCharges='" + otherCharges + "',TotalCharge='" + totalCharge + "' WHERE TransactionNo='" + transNo + "'";
                con.ModRec(sqlUpdateRoomSales);
                // Refresh
                MessageBox.Show("Successfully Added Consumables!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                GetProducts("SELECT a.ProductCode,a.Name,c.Name,d.UnitName,a.SellingPrice,b.QtyOnHand FROM product a, inventory b, category c, unit d WHERE a.ProductCode=b.ProductCode AND a.CategoryID=c.CategoryID AND a.UnitID=d.UnitID AND c.Type LIKE '%" + type + "%'");
                txtQty.Clear();
            }
        }
        //
        // Select Product
        //
        private void dgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            try 
            {
                selectedProductCode = dgvProductList.SelectedRows[0].Cells[0].Value.ToString();
                selectedQtyOnHand = Convert.ToInt32(dgvProductList.SelectedRows[0].Cells[5].Value);
                selectedAmount = Convert.ToDouble(dgvProductList.SelectedRows[0].Cells[6].Value);
            }
            catch /*(Exception ex)*/ { /*MessageBox.Show(ex.Message);*/ }
        }
    }
}
