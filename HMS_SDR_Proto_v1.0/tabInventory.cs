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
    public partial class tabInventory : UserControl
    {
        // Global Variables
        classconnection con = new classconnection();
        string status;
        string type;

        public tabInventory()
        {
            InitializeComponent();
        }

        
        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Default Start up
        //
        public void SetDefault() 
        {
            // View
            cboView.Items.Clear();
            cboView.Items.Add("All");
            cboView.Items.Add("Stocks");
            cboView.Items.Add("Critical Level");
            cboView.Items.Add("Out of Stock");
            cboView.Text = "All";
            // Type
            cboType.Items.Clear();
            cboType.Items.Add("All");
            cboType.Items.Add("ConStore Products");
            cboType.Items.Add("Kitchen Products");
            cboType.Text = "All";
            // Filter
            cboFilter.Items.Clear();
            cboFilter.Items.Add("-SELECT FILTER-");
            cboFilter.Items.Add("Product Code");
            cboFilter.Items.Add("Product Name");
            cboFilter.Items.Add("Category");
            cboFilter.Items.Add("Unit of Measurement");
            cboFilter.Text = "-SELECT FILTER-";
            
            txtSearch.Clear();

            GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
        }
        //
        // Get Inventory Items
        // 
        public void GetInventory(string SQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(SQL, dt);
            dgvInventory.Rows.Clear();
            int ctrCritLvl=0;
            int ctrOutOfStock=0;
            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvInventory.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), Convert.ToDouble(dt.Rows[i].ItemArray[5]).ToString("N2"), dt.Rows[i].ItemArray[6].ToString(), dt.Rows[i].ItemArray[7].ToString(), dt.Rows[i].ItemArray[8].ToString());
                // Change Cell Style depending on the status
                if (dt.Rows[i].ItemArray[8].ToString() == "CRITICAL")
                {
                    dgvInventory.Rows[i].Cells[1].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[2].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[3].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[4].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[5].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[6].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[7].Style.ForeColor = Color.White;

                    dgvInventory.Rows[i].Cells[1].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[2].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[3].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[4].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[5].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[6].Style.BackColor = Color.Tomato;
                    dgvInventory.Rows[i].Cells[7].Style.BackColor = Color.Tomato;
                    ctrCritLvl += 1;
                }
                else if (dt.Rows[i].ItemArray[8].ToString() == "OUT OF STOCK")
                {
                    dgvInventory.Rows[i].Cells[1].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[2].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[3].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[4].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[5].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[6].Style.ForeColor = Color.White;
                    dgvInventory.Rows[i].Cells[7].Style.ForeColor = Color.White;

                    dgvInventory.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[2].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    dgvInventory.Rows[i].Cells[7].Style.BackColor = Color.Red;
                    ctrOutOfStock += 1;
                }
                ctrRec++;
            }
            // Display Statistics
            if (ctrRec != 0)
                lblRecCount.Text = "Total of " + ctrRec.ToString() + " record(s) in the list";
            else
                lblRecCount.Text = "No Record!";

            lblCritLvl.Text = ctrCritLvl + " Item(s) on Critical Level";
            lblOutOfStock.Text = ctrOutOfStock + " Item(s) on Out of Stock";
            dt.Dispose();
        }
        /*****************************
         *           EVENTs
         *****************************/
        //
        // Default Start Up
        //
        private void tabInventory_Load(object sender, EventArgs e)
        {
            SetDefault();
        }
        //
        // Show Add Inventory Module
        //
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmAddInvItem addInv = new frmAddInvItem();
            addInv.ShowDialog();
            SetDefault();
        }
        //
        // Filter by View
        //
        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboView.Text == "All") 
            {
                status = "";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
            else if(cboView.Text == "Stocks")
            {
                status = "AVAILABLE";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
            else if (cboView.Text == "Critical Level")
            {
                status = "CRITICAL";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
            else if (cboView.Text == "Out of Stock")
            {
                status = "OUT OF STOCK";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
        }
        //
        // Filter by Type
        // 
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text == "All") 
            {
                type = "";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
            else if (cboType.Text == "ConStore Products") 
            {
                type = "2";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
            else if (cboType.Text == "Kitchen Products")
            {
                type = "1";
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%'");
            }
        }
        //
        // Search Product
        //
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboFilter.Text == "Product Code")
            {
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%' AND a.ProductCode LIKE '%" + txtSearch.Text + "%'");
            }
            else if (cboFilter.Text == "Product Name")
            {
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%' AND b.Name LIKE '%" + txtSearch.Text + "%'");
            }
            else if (cboFilter.Text == "Category")
            {
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%' AND c.Name LIKE '%" + txtSearch.Text + "%'");
            }
            else if (cboFilter.Text == "Unit of Measurement")
            {
                GetInventory("SELECT a.InventoryID,a.ProductCode,b.Name,c.Name,d.UnitName,b.SellingPrice,a.QtyOnHand,b.CriticalLevel,a.Status FROM inventory a, product b, category c, unit d WHERE a.ProductCode=b.ProductCode AND b.CategoryID=c.CategoryID AND b.UnitID=d.UnitID AND a.status LIKE '%" + status + "%' AND c.type LIKE '%" + type + "%' AND d.UnitName LIKE '%" + txtSearch.Text + "%'");
            }
        }
        //
        // Refresh Inventory
        //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetDefault();
        }
    }
}
