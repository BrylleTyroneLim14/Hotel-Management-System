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
    public partial class adminUnit : UserControl
    {
        public adminUnit()
        {
            InitializeComponent();
        }

        // Database connection
        classconnection con = new classconnection();

        string UnitID;
        string UnitName = "";
        int unitCount;
        string origUnitName;
        /*****************************
         *          ROUTINES
         *****************************/

        private void SetDefault()
        {
            GetRecords("SELECT * FROM unit");
            cboUnit.Text = "";
            cboUnit.Enabled = false;
            txtSearch.text = "";
            dgvMeasurement.Enabled = true;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvMeasurement.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvMeasurement.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString());
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

     

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(UnitName) from Unit where UnitName = '" + cboUnit.Text + "'", dt);
            unitCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvMeasurement.Enabled = false;
                txtSearch.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                cboUnit.Enabled = true;
                cboUnit.Focus();

                origUnitName = cboUnit.Text;
            }
            else
            {
                
                    if (cboUnit.Text == "")
                    {
                        //Restriction if empty
                        MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }else if(unitCount > 0 && origUnitName != cboUnit.Text)
                    {
                        MessageBox.Show("Unit of measurement already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //Update Data on unit maintenance
                        string strEdit = "UPDATE unit SET UnitName='" + cboUnit.Text + "' WHERE unitid='" + UnitID + "'";
                        con.ModRec(strEdit);

                        // Log to audit trail
                        string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Unit Name - Unit ID: " + UnitID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        con.ModRec(strAddlogs);

                        SetDefault();
                    }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select UnitName from Unit where UnitName = '" +cboUnit.Text+"'", dt);
          
                if (btnCreate.Text == "Add New")
                {
                    btnCreate.Text = "Save";
                    dgvMeasurement.Enabled = false;
                    txtSearch.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnCancel.Enabled = true;
                    cboUnit.Enabled = true;
                    cboUnit.Text = "";
                    cboUnit.Focus();
                }
                else
                {
                    try
                    {
                        UnitName = dt.Rows[0].ItemArray[0].ToString();
                    }
                    catch
                    {
                    }
                    if (UnitName == cboUnit.Text)
                    {
                        MessageBox.Show("Unit Name is already in a Unit Maintenance Please Enter Another Unit Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboUnit.Focus();
                    }
                    else if (cboUnit.Text == "")
                    {
                        //Restriction if empty
                        MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        // Add Unit 
                        string strAdd = "INSERT INTO unit(UnitName)" + Environment.NewLine + "values('" + cboUnit.Text + "')";
                        con.ModRec(strAdd);

                        // Log to audit trail
                        string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new UnitName" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        con.ModRec(strAddlogs);

                        SetDefault();
                    }
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select count(unitID) from product where unitID = '" + UnitID + "'", dt);
            unitCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (unitCount > 0)
            {
                MessageBox.Show("Unit of measurement is still used! Please try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //delete data from unit
                    string strDelete = "DELETE FROM unit WHERE UnitID=" + UnitID + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete Unit Name - Unit ID: " + UnitID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                }
                SetDefault();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
             SetDefault();
        }
    
        private void adminUnit_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            cboUnit.Text = "";
            GetRecords("SELECT * FROM Unit WHERE UnitName LIKE '%" + txtSearch.text + "%'");
        }

        private void dgvMeasurement_SelectionChanged(object sender, EventArgs e)
        {
            cboUnit.Text = "";
            try
            {
                UnitID = dgvMeasurement.SelectedRows[0].Cells[0].Value.ToString();
                cboUnit.Text = dgvMeasurement.SelectedRows[0].Cells[1].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCreate.Enabled = true;
                btnCancel.Enabled = false;

            }
            catch
            {
                // do nothing
            }

        }

        
        }

        // ID auto increment
        // no duplicate

    }

