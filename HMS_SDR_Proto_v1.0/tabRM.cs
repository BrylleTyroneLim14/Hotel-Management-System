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
    public partial class tabRM : UserControl
    {
        // Global Variables
        classconnection con = new classconnection();
        string transNo;
        string selectedRoomNo;
        string selectedRoomName;
        string selectedRoomType;
        int maxCap;
        int duration;
        double normalRate = 0.00;
        string guestID;
        int IsDiscounted = 0;

        string CSKS_ID;
        string selectedProduct;
        int selectedQty;
        double totalAmount;
        string status;

        public tabRM()
        {
            InitializeComponent();
        }

        /*****************************
         *          ROUTINES
         *****************************/
        //
        // Start Up
        //
        public void SetDefault()
        {
            panelVacant.Hide();
            panelOccupied.Hide();
            panelRegForm.Hide();
            txtDiscountPercentage.Text = "0";
            GetRoomTypes();
            GetRooms("SELECT a.RoomNo,a.RoomName,a.Status,b.Name FROM room a, roomtype b WHERE a.roomtypeid=b.roomtypeid");

            dgvRooms.Enabled = true;
            cboRoomType.Enabled = true;

            btnRemoveConsumables.Enabled = false;
        }
        //
        // Get Room Types
        //
        private void GetRoomTypes()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Name FROM roomtype";
            con.SelectRec(sql, dt);
            cboRoomType.Items.Clear();
            cboRoomType.Items.Add("-SELECT ROOM TYPE-");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboRoomType.Items.Add(dt.Rows[i].ItemArray[0].ToString());

            }
            dt.Dispose();
            cboRoomType.Text = "-SELECT ROOM TYPE-";
        }
        //
        // Get Rooms
        //
        private void GetRooms(string sql)
        {
            DataTable dt = new DataTable();
            con.SelectRec(sql, dt);
            dgvRooms.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvRooms.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString());
                if (dt.Rows[i].ItemArray[2].ToString() == "AVAILABLE") 
                {
                    dgvRooms.Rows[i].Cells[0].Style.ForeColor = Color.Green;
                    dgvRooms.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                    dgvRooms.Rows[i].Cells[3].Style.ForeColor = Color.Green;
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "OCCUPIED")
                {
                    dgvRooms.Rows[i].Cells[0].Style.ForeColor = Color.RoyalBlue;
                    dgvRooms.Rows[i].Cells[1].Style.ForeColor = Color.RoyalBlue;
                    dgvRooms.Rows[i].Cells[3].Style.ForeColor = Color.RoyalBlue;
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "FOR CLEANING")
                {
                    dgvRooms.Rows[i].Cells[0].Style.ForeColor = Color.Tomato;
                    dgvRooms.Rows[i].Cells[1].Style.ForeColor = Color.Tomato;
                    dgvRooms.Rows[i].Cells[3].Style.ForeColor = Color.Tomato;
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "UNDER MAINTENANCE")
                {
                    dgvRooms.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    dgvRooms.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    dgvRooms.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                }
                ctrRec++;
            }
            dt.Dispose();
            GetRoomStat();
        }
        //
        // Get Room Statistics
        //
        private void GetRoomStat() 
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            // Get Vacant
            string sqlVacant = "SELECT count(*) FROM room WHERE status='AVAILABLE'";
            con.SelectRec(sqlVacant, dt1);
            lblVacantStat.Text = "Vacant Room(s) Ready For Occupancy: " + dt1.Rows[0].ItemArray[0].ToString();
            // Get Occupied
            string sqlOccu = "SELECT count(*) FROM room WHERE status='OCCUPIED'";
            con.SelectRec(sqlOccu, dt2);
            lblOccuStat.Text = "Occupied Room(s): " + dt2.Rows[0].ItemArray[0].ToString();
            // Get For Cleaning
            string sqlCleaning = "SELECT count(*) FROM room WHERE status='FOR CLEANING'";
            con.SelectRec(sqlCleaning, dt3);
            lblForCleaningStat.Text = "Room(s) for Cleaning: " + dt3.Rows[0].ItemArray[0].ToString();
            // Get Under Maintenance
            string sqlMainte = "SELECT count(*) FROM room WHERE status='UNDER MAINTENANCE'";
            con.SelectRec(sqlMainte, dt4);
            lblUnderMainteStat.Text = "Room(s) Under Maintenance: " + dt4.Rows[0].ItemArray[0].ToString();
        }
        //
        // Get Transaction No.
        //
        private void GetTransactionNo()
        {
            DataTable dt = new DataTable();
            string strCount = "SELECT count(*) FROM roomsales";
            con.SelectRec(strCount, dt);
            int result = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            int newTransNo = result + 1;
            transNo = newTransNo.ToString("0000000000");

            lblTransNo.Text = transNo;
        }
        //
        // Clear Registration Form
        //
        private void ClearRegistrationForm()
        {
            txtFirstName.Clear();
            txtLastname.Clear();
            txtAddress.Clear();
            txtCompany.Clear();
            txtContactNo.Clear();
            txtNoOfPax.Clear();

            txtDeposit.Clear();
            txtRemarks.Clear();
            txtRate.Clear();
        }
        //
        // Get Guess ID
        //
        private void GetGuestID()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT COUNT(*) FROM guest";
            con.SelectRec(sql, dt);

            int result = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
            int newGuestID = result + 1;
            guestID = newGuestID.ToString("0000000000");
        }
        //
        // Get Room Information
        //
        private void GetRoomInfo(string RoomNo) 
        {
            DataTable dtRoomInfo = new DataTable();
            string sqlRoomInfo = "SELECT a.RoomName,a.RoomNo,b.Name,b.MaxCap,a.Floor,a.PhoneNo,a.RoomTypeID FROM room a, roomtype b WHERE a.RoomTypeID=b.RoomTypeID AND a.RoomNo='" + RoomNo + "';";
            con.SelectRec(sqlRoomInfo, dtRoomInfo);
            lblOccuRoomName.Text = dtRoomInfo.Rows[0].ItemArray[0].ToString();
            lblOccuRoomNo.Text = "Room No. " + dtRoomInfo.Rows[0].ItemArray[1].ToString();
            lblOccuRoomType.Text = "Room Type: " + dtRoomInfo.Rows[0].ItemArray[2].ToString();
            lblOccuMaxCap.Text = "Maximum Capacity: " + dtRoomInfo.Rows[0].ItemArray[3].ToString();
            lblOccuFloor.Text = "Floor: " + dtRoomInfo.Rows[0].ItemArray[4].ToString();
            lblOccuPhone.Text = "Phone: " + dtRoomInfo.Rows[0].ItemArray[5].ToString();
            selectedRoomType = dtRoomInfo.Rows[0].ItemArray[6].ToString();
        }
        //
        // Get Transaction Details
        //
        public void GetTransactionDetails(string RoomNo)
        {
            DataTable dtTransDetails = new DataTable();
            try
            {
                string sqlTransDetails = "SELECT TransactionNo,CheckInDateTime,ExpectedCheckOut,Duration,DiscountedRate,Deposit,RoomCharges,OtherCharges,TotalCharge,Remarks,Pax,GuestID FROM roomsales WHERE RoomNo='" + RoomNo + "' AND IsCurrentlyCheckedIn='1'";
                con.SelectRec(sqlTransDetails, dtTransDetails);
                lblOccuTransNo.Text = dtTransDetails.Rows[0].ItemArray[0].ToString();
                transNo = dtTransDetails.Rows[0].ItemArray[0].ToString();
                lblCheckin.Text = "Check-in: " + Convert.ToDateTime(dtTransDetails.Rows[0].ItemArray[1]).ToString("MMM. dd, yyyy | hh:mm:ss tt");
                lblCheckOut.Text = "Check-out: " + Convert.ToDateTime(dtTransDetails.Rows[0].ItemArray[2]).ToString("MMM. dd, yyyy | hh:mm:ss tt");
                lblDuration.Text = "Hours Stayed: " + dtTransDetails.Rows[0].ItemArray[3].ToString() + " Hour(s)";
                lblDiscount.Text = "Discount: " + Convert.ToInt32(dtTransDetails.Rows[0].ItemArray[4]) + " %";
                lblDeposit.Text = "Deposit: Php " + Convert.ToDouble(dtTransDetails.Rows[0].ItemArray[5]).ToString("N2");
                lblRoomCharge.Text = "Room Charge: Php " + Convert.ToDouble(dtTransDetails.Rows[0].ItemArray[6]).ToString("N2");
                lblOtherCharges.Text = "Other Charges: Php " + Convert.ToDouble(dtTransDetails.Rows[0].ItemArray[7]).ToString("N2");
                lblTotalAmount.Text = "TOTAL AMOUNT: Php " + Convert.ToDouble(dtTransDetails.Rows[0].ItemArray[8]).ToString("N2");
                txtRemarks.Text = dtTransDetails.Rows[0].ItemArray[9].ToString();
                lblPaxNo.Text = dtTransDetails.Rows[0].ItemArray[10].ToString() + " pax";
                guestID = dtTransDetails.Rows[0].ItemArray[11].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //
        // Get Guest Details
        //
        private void GetGuestDetails()
        {
            DataTable dtGuestDetails = new DataTable();
            try
            {
                string sqlGuestDetails = "SELECT * FROM guest WHERE GuestID='" + guestID + "'";
                con.SelectRec(sqlGuestDetails, dtGuestDetails);
                lblGuestName.Text = dtGuestDetails.Rows[0].ItemArray[1].ToString() + " " + dtGuestDetails.Rows[0].ItemArray[2].ToString();
                lblAddress.Text = dtGuestDetails.Rows[0].ItemArray[3].ToString();
                lblCompany.Text = dtGuestDetails.Rows[0].ItemArray[4].ToString();
                lblContactNo.Text = dtGuestDetails.Rows[0].ItemArray[5].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //
        // Get Consumables
        //
        private void GetConsumables(string TransNo) 
        {
            DataTable dtConsumables = new DataTable();
            try 
            {
                string sqlConsumables = "SELECT a.CSKS_Code,a.TransactionNo,a.ProductCode,b.Name, b.SellingPrice, a.Quantity,a.TotalAmount,a.Remarks FROM constorekitchensales a, product b WHERE  a.ProductCode=b.ProductCode AND a.TransactionNo='" + TransNo + "'";
                con.SelectRec(sqlConsumables, dtConsumables);

                dgvConsumables.Rows.Clear();

                int ctrRec = 0;
                for (int i = 0; i < dtConsumables.Rows.Count; i++)
                {
                    this.dgvConsumables.Rows.Add(dtConsumables.Rows[i].ItemArray[0].ToString(), dtConsumables.Rows[i].ItemArray[1].ToString(), dtConsumables.Rows[i].ItemArray[2].ToString(), dtConsumables.Rows[i].ItemArray[3].ToString(), Convert.ToDouble(dtConsumables.Rows[i].ItemArray[4]).ToString("0.00"), dtConsumables.Rows[i].ItemArray[5].ToString(), Convert.ToDouble(dtConsumables.Rows[i].ItemArray[6]).ToString("0.00"), dtConsumables.Rows[i].ItemArray[7].ToString());
                    ctrRec++;
                }
                dtConsumables.Dispose();   
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /*****************************
         *           EVENTS
         *****************************/
        private void tabRM_Load(object sender, EventArgs e)
        {
            SetDefault();
        }
        //
        // Room Selection
        //
        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRooms.SelectedRows[0].Cells[2].Value.ToString() == "OCCUPIED")
                {
                    panelRegForm.Hide();
                    panelVacant.Hide();
                    panelOccupied.Show();
                    selectedRoomNo = dgvRooms.SelectedRows[0].Cells[0].Value.ToString();
                    btnRemarks.Text = "Edit Remarks";
                    GetRoomInfo(selectedRoomNo);
                    GetTransactionDetails(selectedRoomNo);
                    GetGuestDetails();
                    GetConsumables(transNo);
                }
                else 
                {
                    panelRegForm.Hide();
                    panelOccupied.Hide();
                    panelVacant.Show();
                    // Get Room Information
                    string RoomNo = dgvRooms.SelectedRows[0].Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    string sql = "SELECT a.RoomNo,a.RoomName,a.Floor,a.PhoneNo,a.Status,a.Picture,b.Name,b.MaxCap,b.Rate_1,b.Rate_2,b.Rate_3,b.ExtensionRate,b.RoomTypeID FROM room a, roomtype b WHERE a.RoomTypeID=b.RoomTypeId AND a.RoomNo='" + RoomNo + "'";
                    con.SelectRec(sql, dt);
                    // Set Room Information
                    lblVacRoomNo.Text = "Room No. " + dt.Rows[0].ItemArray[0].ToString();
                    lblVacRoomName.Text = dt.Rows[0].ItemArray[1].ToString();
                    lblVacFloor.Text = "Floor: " + dt.Rows[0].ItemArray[2].ToString();
                    lblVacPhone.Text = "Phone: " + dt.Rows[0].ItemArray[3].ToString();
                        // Change Forecolor depending on the status
                        if (dt.Rows[0].ItemArray[4].ToString() == "AVAILABLE") { lblVacRoomStatus.ForeColor = Color.Green; rdoAvailable.Checked = true; }
                        else if (dt.Rows[0].ItemArray[4].ToString() == "OCCUPIED") { lblVacRoomStatus.ForeColor = Color.RoyalBlue; }
                        else if (dt.Rows[0].ItemArray[4].ToString() == "FOR CLEANING") { lblVacRoomStatus.ForeColor = Color.Tomato; rdoCleaning.Checked = true; }
                        else if (dt.Rows[0].ItemArray[4].ToString() == "UNDER MAINTENANCE") { lblVacRoomStatus.ForeColor = Color.Red; rdoMaintenance.Checked = true; }
                    lblVacRoomStatus.Text = "Room Status: " + dt.Rows[0].ItemArray[4].ToString();
                    picRoom.ImageLocation = dt.Rows[0].ItemArray[5].ToString();
                    lblVacRoomType.Text = "Room Type: "+ dt.Rows[0].ItemArray[6].ToString();
                    lblVacMaxCap.Text = "Maximum Capacity: " + dt.Rows[0].ItemArray[7].ToString() + " pax";
                    lblRate1.Text = "5 hours - Php " + Convert.ToDouble(dt.Rows[0].ItemArray[8]).ToString("N2");
                    lblRate2.Text = "10 hours - Php " + Convert.ToDouble(dt.Rows[0].ItemArray[9]).ToString("N2");
                    lblRate3.Text = "22 hours - Php " + Convert.ToDouble(dt.Rows[0].ItemArray[10]).ToString("N2");
                    lblExtRate.Text = "Extension Rate(per hour) - Php " + Convert.ToDouble(dt.Rows[0].ItemArray[11]).ToString("N2");

                    selectedRoomNo = dt.Rows[0].ItemArray[0].ToString();
                    selectedRoomName = dt.Rows[0].ItemArray[1].ToString();
                    selectedRoomType = dt.Rows[0].ItemArray[12].ToString();
                    maxCap = Convert.ToInt32(dt.Rows[0].ItemArray[7].ToString());
                }
            }
            catch/*(Exception ex)*/
            { /*MessageBox.Show(ex.Message)*/ /*FOR DEBUGGING ONLY*/}
        }
        //
        // Room Type Selection
        //
        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoomType.Text == "-SELECT ROOM TYPE-")
            {
                GetRooms("SELECT a.RoomNo,a.RoomName,a.Status,b.Name FROM room a, roomtype b WHERE a.roomtypeid=b.roomtypeid");
            }
            else 
            {
                GetRooms("SELECT a.RoomNo,a.RoomName,a.Status,b.Name FROM room a, roomtype b WHERE a.roomtypeid=b.roomtypeid AND b.name='" + cboRoomType.Text + "'");
            }
        }
        //
        // Show Registration Form
        //
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // Show Registration Form
            panelVacant.Hide();
            panelOccupied.Hide();
            panelRegForm.Show();

            dgvRooms.Enabled = false;
            cboRoomType.Enabled = false;

            // Generate Transaction No.
            GetTransactionNo();
            txtRoomNo.Text = selectedRoomNo;
            txtRoomName.Text = selectedRoomName;

            // Set cboDuration values
            cboDuration.Items.Clear();
            cboDuration.Items.Add("5 hours");
            cboDuration.Items.Add("10 hours");
            cboDuration.Items.Add("22 hours");
            ClearRegistrationForm();
            txtFirstName.Focus();
        }
        //
        // Cancel Registration
        //
        private void btnRFCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }
        //
        // Computes Rate Automatically
        //
        private void cboDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            
            if (cboDuration.Text == "5 hours")
            {
                string sql = "SELECT Rate_1 FROM roomtype WHERE RoomTypeID='" + selectedRoomType + "'";
                con.SelectRec(sql, dt);
                txtRate.Text = Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("0.00");
                normalRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                duration = 5;
            }
            else if(cboDuration.Text == "10 hours")
            {
                string sql = "SELECT Rate_2 FROM roomtype WHERE RoomTypeID='" + selectedRoomType + "'";
                con.SelectRec(sql, dt);
                txtRate.Text = Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("0.00");
                normalRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                duration = 10;
            }
            else if (cboDuration.Text == "22 hours")
            {
                string sql = "SELECT Rate_3 FROM roomtype WHERE RoomTypeID='" + selectedRoomType + "'";
                con.SelectRec(sql, dt);
                txtRate.Text = Convert.ToDouble(dt.Rows[0].ItemArray[0]).ToString("0.00");
                normalRate = Convert.ToDouble(dt.Rows[0].ItemArray[0]);
                duration = 22;
            }
        }
        //
        // Enabling Discount
        //
        private void rdoDiscounted_CheckedChanged(object sender, EventArgs e)
        {
            txtDiscountPercentage.Clear();
            txtDiscountPercentage.Enabled = true;
            txtDiscountPercentage.Focus();
            IsDiscounted = 1;
        }
        private void rdoNoDiscount_CheckedChanged(object sender, EventArgs e)
        {
            txtDiscountPercentage.Enabled = false;
            //txtDiscountPercentage.Clear();
            txtDiscountPercentage.Text = "0";
            IsDiscounted = 0;
        }
        /// 
        /// Registration Form Restrictions
        /// 
        //
        // Letters Only
        //
        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        //
        // Numbers Only
        //
        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNoOfPax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtDiscountPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //
        // Double Only
        //
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
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
        /// 
        /// End of Restrictions
        ///
        //
        // Compute Discount Automatically
        //
        private void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
        {
            int discountRate = txtDiscountPercentage.Text == "" ? 0 : Convert.ToInt32(txtDiscountPercentage.Text);
            double discount = normalRate * discountRate / 100;
            double discountedRate = normalRate - discount;
            txtRate.Text = discountedRate.ToString("0.00");
        }
        //
        // Check-in
        //
        private void btnRFCheckIn_Click(object sender, EventArgs e)
        {
            if(txtFirstName.Text == "" || txtLastname.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "" || txtNoOfPax.Text == "" || cboDuration.Text == "" || txtRate.Text == "")
            {
                MessageBox.Show("Required Field(s) Missing!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Convert.ToInt32(txtNoOfPax.Text) > maxCap) 
            {
                MessageBox.Show("Number of pax exceeds maximum capacity of the room!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else if (Convert.ToInt32(txtNoOfPax.Text) < 1) 
            {
                MessageBox.Show("Invalid Number of pax!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Convert.ToDouble(txtRate.Text) <= 0)
            {
                MessageBox.Show("Invalid Room Rate!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rdoDiscounted.Checked == true && (txtDiscountPercentage.Text == "" || Convert.ToInt32(txtDiscountPercentage.Text) < 1))
            {
                MessageBox.Show("Invalid Discount Rate!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Save Guest Details
                GetGuestID();
                string sqlGuest = "INSERT INTO guest(GuestID,FirstName,LastName,Address,Company,MobileNo)" + Environment.NewLine + "values('" + guestID + "','" + txtFirstName.Text + "','" + txtLastname.Text + "','" + txtAddress.Text + "','" + txtCompany.Text + "','" + txtContactNo.Text + "')";
                con.ModRec(sqlGuest);
                // Save Transaction
                string checkin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string checkout = DateTime.Now.AddHours(duration).ToString("yyyy-MM-dd HH:mm:ss");
                string sqlRoomSale = "INSERT INTO roomsales(TransactionNo, RoomNo, GuestID, Pax, CheckInDateTime, Duration, ExpectedCheckOut, Deposit, IsDiscounted, DiscountedRate, RoomCharges, OtherCharges, TotalCharge, TotalPaid, Remarks,IsCurrentlyCheckedIn) VALUES ('" + lblTransNo.Text + "', '" + txtRoomNo.Text + "', '" + guestID + "', '" + txtNoOfPax.Text + "', '" + checkin + "', '" + duration + "', '" + checkout + "', '" + txtDeposit.Text + "', '" + IsDiscounted + "', '" + txtDiscountPercentage.Text + "','" + txtRate.Text + "', '0', '" + txtRate.Text + "','" + txtDeposit.Text + "', '" + txtRFRemarks.Text + "','1')";
                con.ModRec(sqlRoomSale);
                // Change Room Status
                string sqlRoomUpdate = "UPDATE room SET Status='OCCUPIED' WHERE RoomNo='" + selectedRoomNo + "'";
                con.ModRec(sqlRoomUpdate);

                SetDefault();
            }
        }
        //
        // Change Room Status
        //
        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            if (rdoAvailable.Checked == true)
            {
                // Update Room Status
                string sqlRoomUpdate = "UPDATE room SET Status='AVAILABLE' WHERE RoomNo='" + selectedRoomNo + "'";
                con.ModRec(sqlRoomUpdate);
                SetDefault();
            }
            else if(rdoCleaning.Checked == true)
            {
                // Update Room Status
                string sqlRoomUpdate = "UPDATE room SET Status='FOR CLEANING' WHERE RoomNo='" + selectedRoomNo + "'";
                con.ModRec(sqlRoomUpdate);
                SetDefault();
            }
            else if (rdoMaintenance.Checked == true)
            {
                // Update Room Status
                string sqlRoomUpdate = "UPDATE room SET Status='UNDER MAINTENANCE' WHERE RoomNo='" + selectedRoomNo + "'";
                con.ModRec(sqlRoomUpdate);
                SetDefault();
            }
        }
        //
        // Show POS for Consumables
        //
        private void btnAddConsumables_Click(object sender, EventArgs e)
        {
            frmAddConsumables addCon = new frmAddConsumables(transNo);
            addCon.ShowDialog();
            GetTransactionDetails(selectedRoomNo);
            GetConsumables(transNo);
        }
        //
        // Get Consumables Information
        //
        private void dgvConsumables_SelectionChanged(object sender, EventArgs e)
        {
            
            try
            {
                CSKS_ID = dgvConsumables.SelectedRows[0].Cells[0].Value.ToString();
                transNo = dgvConsumables.SelectedRows[0].Cells[1].Value.ToString();
                selectedProduct = dgvConsumables.SelectedRows[0].Cells[2].Value.ToString();
                selectedQty = Convert.ToInt32(dgvConsumables.SelectedRows[0].Cells[5].Value);
                string tmp = Convert.ToDouble(dgvConsumables.SelectedRows[0].Cells[6].Value).ToString();
                totalAmount = Convert.ToDouble(tmp);
                status = dgvConsumables.SelectedRows[0].Cells[7].Value.ToString();

                btnRemoveConsumables.Enabled = true;
            }
            catch /*(Exception ex)*/ {
                //MessageBox.Show(ex.Message);
                // DO NOTHING
                // CATCH IF EMPTY / FOR DEBUGGING ONLY
            }
            
        }
        //
        // Remove Consumables
        //
        private void btnRemoveConsumables_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bill will be affected upon removing this consumables.\nAre you sure to remove this consumables?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Remove from ConstoreKitchenSales
                string sqlDelConsumables = "DELETE FROM constorekitchensales WHERE CSKS_Code='" + CSKS_ID +"'";
                con.ModRec(sqlDelConsumables);
                // Deduct from RoomSales
                DataTable dtCurrentCharge = new DataTable();
                string sqlGetCurrentCharge = "SELECT OtherCharges, TotalCharge, TotalPaid FROM roomsales WHERE TransactionNo='" + transNo + "'";
                con.SelectRec(sqlGetCurrentCharge, dtCurrentCharge);
                double currentOtherCharges = Convert.ToDouble(dtCurrentCharge.Rows[0].ItemArray[0]);
                double currentTotalCharge = Convert.ToDouble(dtCurrentCharge.Rows[0].ItemArray[1]);
                double currentTotalPaid = Convert.ToDouble(dtCurrentCharge.Rows[0].ItemArray[2]);
                if (status == "PAID")
                {
                    double newOtherCharge = currentOtherCharges - totalAmount;
                    double newTotalCharge = currentTotalCharge - totalAmount;
                    double newTotalPaid = currentTotalPaid - totalAmount;
                    string sqlUpdateRoomSales = "UPDATE roomsales SET OtherCharges='" + newOtherCharge + "',TotalCharge='"+ newTotalCharge +"',TotalPaid='"+newTotalPaid +"' WHERE TransactionNo='"+transNo+"'";
                    con.ModRec(sqlUpdateRoomSales);
                }
                else 
                {
                    double newOtherCharge = currentOtherCharges - totalAmount;
                    double newTotalCharge = currentTotalCharge - totalAmount;
                    string sqlUpdateRoomSales = "UPDATE roomsales SET OtherCharges='" + newOtherCharge + "',TotalCharge='" + newTotalCharge + "' WHERE TransactionNo='" + transNo + "'";
                    con.ModRec(sqlUpdateRoomSales);
                }
                // Update Inventory
                DataTable dtCurrentStock = new DataTable();
                string sqlGetCurrentStock = "SELECT QtyOnHand FROM inventory WHERE ProductCode='"+selectedProduct+"'";
                con.SelectRec(sqlGetCurrentStock, dtCurrentStock);
                int currentStock = Convert.ToInt32(dtCurrentStock.Rows[0].ItemArray[0]);
                int newStock = currentStock + selectedQty;
                string sqlUpdateInventory = "UPDATE inventory SET QtyOnHand='" + newStock + "'";
                con.ModRec(sqlUpdateInventory);

                //Refresh
                MessageBox.Show("Product Successfully Removed.\nBill and Inventory Updated.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                GetConsumables(transNo);
                GetTransactionDetails(selectedRoomNo);
                btnRemoveConsumables.Enabled = false;
            }
        }
        //
        // Edit Remarks
        // 
        private void btnRemarks_Click(object sender, EventArgs e)
        {
            if (btnRemarks.Text == "Edit Remarks")
            {
                btnRemarks.Text = "Save";
                txtRemarks.ReadOnly = false;
                txtRemarks.Focus();
            }
            else 
            {
                string sqlUpdateRemarks = "UPDATE roomsales SET Remarks='"+ txtRemarks.Text +"' WHERE TransactionNo='"+ transNo +"'";
                con.ModRec(sqlUpdateRemarks);
                btnRemarks.Text = "Edit Remarks";
                txtRemarks.ReadOnly = true;
                GetTransactionDetails(selectedRoomNo);
            }
        }
        //
        // Show Extend Stay Module
        //
        private void btnExtend_Click(object sender, EventArgs e)
        {
            frmExtendRoom extend = new frmExtendRoom(selectedRoomType, transNo);
            extend.ShowDialog();
            GetTransactionDetails(selectedRoomNo);
        }
        //
        // Show Room Transfer Module 
        //
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            frmTransferRoom transfer = new frmTransferRoom(transNo, selectedRoomType, selectedRoomNo);
            transfer.ShowDialog();
            SetDefault();
        }
        //
        // Show Check Out Module
        //
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut checkout = new frmCheckOut(transNo);
            checkout.ShowDialog();
            SetDefault();
        }
    }
}