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
    public partial class frmExtendRoom : Form
    {
        // Global Variables
        classconnection con = new classconnection();
        string RoomType;
        string transNo;
        int duration;
        double extensionRate;

        public frmExtendRoom(string selectedRoomType, string selectedTransNo)
        {
            InitializeComponent();
            RoomType = selectedRoomType;
            transNo = selectedTransNo;
        }

        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Get Rate
        // 
        private void GetRate() 
        {   
            DataTable dt = new DataTable();
            if (rdoRate_1.Checked == true)
            {
                string sqlGetRate = "SELECT Rate_1 FROM roomtype WHERE RoomTypeID='" + RoomType + "'";
                duration = 5;
                con.SelectRec(sqlGetRate, dt);
                extensionRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                lblRatePreview.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("N2");
            }
            else if (rdoRate_2.Checked == true)
            {
                string sqlGetRate = "SELECT Rate_2 FROM roomtype WHERE RoomTypeID='" + RoomType + "'";
                duration = 10;
                con.SelectRec(sqlGetRate, dt);
                extensionRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                lblRatePreview.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("N2");
            }
            else if (rdoRate_3.Checked == true)
            {
                string sqlGetRate = "SELECT Rate_3 FROM roomtype WHERE RoomTypeID='" + RoomType + "'";
                duration = 22;
                con.SelectRec(sqlGetRate, dt);
                extensionRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                lblRatePreview.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("N2");
            }
            
        }
        //
        // Get Rate Per Hour
        private void GetPerHourRate() 
        {
            DataTable dt = new DataTable();
            string sqlGetExtRate = "SELECT ExtensionRate FROM roomtype WHERE RoomTypeID='" + RoomType + "'";
            con.SelectRec(sqlGetExtRate, dt);
            duration = txtHour.Text == "" ? 0 : Convert.ToInt32(txtHour.Text);
            extensionRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]) * duration;
            lblRatePreview.Text = "Php " + extensionRate.ToString("N2");
        }

        /*****************************
         *           EVENTS
         *****************************/

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExtendRoom_Load(object sender, EventArgs e)
        {
            txtHour.Enabled = false;
            GetRate();
        }

        private void rdoRate_1_CheckedChanged(object sender, EventArgs e)
        {
            GetRate();
        }

        private void rdoRate_2_CheckedChanged(object sender, EventArgs e)
        {
            GetRate();
        }

        private void rdoRate_3_CheckedChanged(object sender, EventArgs e)
        {
            GetRate();
        }

        private void rdoPerHour_CheckedChanged(object sender, EventArgs e)
        {
            txtHour.Enabled = true;
            txtHour.Text = "1";
            txtHour.Focus();
        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            GetPerHourRate();
        }

        private void txtHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (extensionRate <= 0)
            {
                MessageBox.Show("Invalid Extension Rate", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                if (MessageBox.Show("Confirm extension of stay?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get current data to be updated
                    DataTable dt = new DataTable();
                    string sqlGetCurrentData = "SELECT Duration, RoomCharges, TotalCharge, RoomNo, ExpectedCheckOut, Remarks FROM roomsales WHERE TransactionNo='" + transNo + "'";
                    con.SelectRec(sqlGetCurrentData, dt);
                    int newDuration = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + duration;
                    double newRoomCharges = Convert.ToDouble(dt.Rows[0].ItemArray[1]) + extensionRate;
                    double newTotalCharge = Convert.ToDouble(dt.Rows[0].ItemArray[2]) + extensionRate;
                    string RoomNo = dt.Rows[0].ItemArray[3].ToString();
                    DateTime checkout = Convert.ToDateTime(dt.Rows[0].ItemArray[4]);
                    string newCheckOut = checkout.AddHours(duration).ToString("yyyy-MM-dd HH:mm:ss");
                    string remarks = dt.Rows[0].ItemArray[5].ToString();
                    string newRemarks = remarks.Length < 1 ? "Extended " + duration + " hour(s)" : remarks + System.Environment.NewLine + "Extended " + duration + " hour(s)";
                    // Update Duration and Charges
                    string sqlExtendStay = "UPDATE roomsales SET Duration='" + newDuration + "',ExpectedCheckOut='" + newCheckOut + "',RoomCharges='" + newRoomCharges + "', TotalCharge='" + newTotalCharge + "', Remarks='" + newRemarks + "' WHERE TransactionNo='" + transNo + "'";
                    con.ModRec(sqlExtendStay);
                    this.Close();    
                }
            }
        }
    }
}
