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
    public partial class frmCheckOut : Form
    {
        // Global Variables
        classconnection con = new classconnection();
        string transNo;
        double balance;
        double totalPaid;
        string RoomNo;

        public frmCheckOut(string selectedTransNo)
        {
            InitializeComponent();
            transNo = selectedTransNo;
        }
        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Get Bill
        //
        private void GetBillPreview(string transNo)
        {
            DataTable dt = new DataTable();
            string sqlGetBill = "SELECT CheckInDateTime, ExpectedCheckOut, Duration, RoomCharges,OtherCharges,DiscountedRate, TotalCharge, Deposit, TotalPaid,RoomNo FROM roomsales WHERE TransactionNo='" + transNo + "'";
            con.SelectRec(sqlGetBill, dt);

            lblCheckin.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[0]).ToString("MMM. dd, yyyy | hh:mm:ss tt");
            lblCheckOut.Text = Convert.ToDateTime(dt.Rows[0].ItemArray[1]).ToString("MMM. dd, yyyy | hh:mm:ss tt");
            lblDuration.Text = dt.Rows[0].ItemArray[2].ToString() + " hours";
            lblRoomCharges.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[3]).ToString("N2");
            lblOtherCharges.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[4]).ToString("N2");
            lblDiscount.Text = dt.Rows[0].ItemArray[5].ToString() + " %";
            lblTotalCharge.Text = "Php " + Convert.ToDouble(dt.Rows[0].ItemArray[6]).ToString("N2");
            lblDeposit.Text = "(Php " + Convert.ToDouble(dt.Rows[0].ItemArray[7]).ToString("N2") + ")";
            lblTotalPaid.Text = "(Php " + Convert.ToDouble(dt.Rows[0].ItemArray[8]).ToString("N2") + ")";
            totalPaid = Convert.ToDouble(dt.Rows[0].ItemArray[8]);
            balance = Convert.ToDouble(dt.Rows[0].ItemArray[6]) - Convert.ToDouble(dt.Rows[0].ItemArray[8]);
            lblBalance.Text = "Php " + balance.ToString("N2");
            RoomNo = dt.Rows[0].ItemArray[9].ToString();
        }
        /*****************************
         *           EVENTS
         *****************************/
        //
        // Default
        //
        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            GetBillPreview(transNo);
        }
        //
        // Check out
        // 
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            double amountReceived = txtAmountReceived.Text == "" ? 0 : Convert.ToDouble(txtAmountReceived.Text);
            if (amountReceived < balance) // Validate payment received
            {
                MessageBox.Show("Insufficient payment! \nPlease check amount received. ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                double newTotalPaid = totalPaid + amountReceived;
                // Update room sales
                string sqlCheckOut = "UPDATE roomsales SET TotalPaid='" + newTotalPaid + "', IsCurrentlyCheckedIn='0' WHERE TransactionNo='" + transNo + "'";
                con.ModRec(sqlCheckOut);
                // Update room status
                string sqlUpdateRoomStatus = "UPDATE room SET status='FOR CLEANING' WHERE RoomNo='" + RoomNo + "'";
                con.ModRec(sqlUpdateRoomStatus);
                // Update ConstoreKitchen Sales
                string sqlUpdateCSKS = "UPDATE constorekitchensales SET remarks='PAID' WHERE TransactionNo='" + transNo +"'";
                con.ModRec(sqlUpdateCSKS);
                this.Close();
            }
        }
        //
        // Cancel
        // 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        // Double values ONLY Restriction
        //
        private void txtAmountReceived_KeyPress(object sender, KeyPressEventArgs e)
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
