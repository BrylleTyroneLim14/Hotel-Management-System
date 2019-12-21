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
    public partial class adminRoom : UserControl
    {
        public adminRoom()
        {
            InitializeComponent();
        }

        // Database connection
        classconnection con = new classconnection();

        int RoomID;
        int roomCount = 0;
        string origRoomName;

        /*****************************
         *          ROUTINES
         *****************************/
        private void ClearForm() 
        {
            txtSearch.text = "";
            txtRoomNo.Text = "";
            cboRoomType.Text = "";
            cboRoomName.Text = "";
            txtRate1.Text = "";
            txtRate2.Text = "";
            txtRate3.Text = "";
            txtExtensionRate.Text = "";
            cboFloor.Text = "";
            txtPhoneNum.Text = "";
            picDP.ImageLocation = null;
        }
        private void LockForm() 
        {
            txtRoomNo.Enabled = false;
            cboRoomType.Enabled = false;
            cboRoomName.Enabled = false;
            txtRate1.Enabled = false;
            txtRate2.Enabled = false;
            txtRate3.Enabled = false;
            picDP.Enabled = false;
            txtExtensionRate.Enabled = false;
            cboFloor.Enabled = false;
            txtPhoneNum.Enabled = false;
        }
        private void UnlockForm() 
        {
            cboRoomType.Enabled = true;
            cboRoomName.Enabled = true;
            picDP.Enabled = true;
            cboFloor.Enabled = true;
            txtPhoneNum.Enabled = true;
        }
        private void SetDefault()
        {
            GetRecords("SELECT * FROM Room");
            ClearForm();
            LockForm();
            picDP.ImageLocation = null;

            dgvRoom.Enabled = true;
            btnBrowse.Enabled = false;
            btnCreate.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Text = "Add New";
            btnUpdate.Text = "Update";
            getRoomtype();
            txtSearch.Enabled = true;

        }

        //Get Room type
        private void getRoomtype()
        {
            DataTable dt = new DataTable();
            string strname = "SELECT Name from Roomtype";
            con.SelectRec(strname, dt);
            cboRoomType.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboRoomType.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }

        //Get Automatic Room No.
        void getRoomNo()
        {
            DataTable dt = new DataTable();
            string strregno = "Select RoomNo from Room order by RoomNo desc";
            con.SelectRec(strregno, dt);

            if (dt.Rows.Count == 0)
            {
                txtRoomNo.Text = "1";
            }
            else
            {
                double x = Convert.ToDouble(dt.Rows[0].ItemArray[0]) + 1;
                txtRoomNo.Text = x.ToString();
            }
            dt.Dispose();
        }

        private void GetRecords(string strSQL)
        {
            DataTable dt = new DataTable();
            con.SelectRec(strSQL, dt);
            dgvRoom.Rows.Clear();

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvRoom.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString(), dt.Rows[i].ItemArray[4].ToString(), dt.Rows[i].ItemArray[5].ToString(), dt.Rows[i].ItemArray[6].ToString());
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
            getRoomNo();
            DataTable dt = new DataTable();
            con.SelectRec("Select RoomName from Room where RoomName = '" + cboRoomName.Text + "'", dt);

            if (btnCreate.Text == "Add New")
            {
                btnCreate.Text = "Save";
                dgvRoom.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnBrowse.Enabled = true;

                txtRoomNo.Enabled = false;
                ClearForm();
                UnlockForm();
                cboRoomType.Focus();

                txtSearch.Enabled = false;
            }
            else
            {
                if (cboRoomName.Text=="" || cboRoomType.Text=="" || txtRate1.Text=="" || txtRate2.Text=="" || txtRate3.Text=="" || txtExtensionRate.Text=="" || cboFloor.Text=="" || txtPhoneNum.Text=="" )
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dt.Rows.Count == 0)
                {
                    // Add Room Name 
                    string strAdd = "INSERT INTO room(RoomNo,RoomTypeID,RoomName,Floor,PhoneNo,Status,Picture)" + Environment.NewLine + "values('" + txtRoomNo.Text + "','" + lblRoomtypeid.Text + "','" + cboRoomName.Text + "','" + cboFloor.Text + "','" + txtPhoneNum.Text + "','AVAILABLE','" + picDP.ImageLocation + "')";
                    con.ModRec(strAdd);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Added new Room Name" + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
                else
                {
                    MessageBox.Show("Room Name is already in a Room Maintenance Please Enter Another Room Name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboRoomType.Focus();

                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select Count(RoomName) from room where RoomName = '" + cboRoomName.Text + "'", dt);
            roomCount = Int32.Parse(dt.Rows[0].ItemArray[0].ToString());
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                dgvRoom.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = true;
                btnBrowse.Enabled = true;
                txtSearch.Enabled = false;
                UnlockForm();
                cboRoomType.Focus();
                origRoomName = cboRoomName.Text;
            }
            else
            {
                if (cboRoomName.Text == "" || cboRoomType.Text == "" || txtRate1.Text == "" || txtRate2.Text == "" || txtRate3.Text == "" || txtExtensionRate.Text == "" || cboFloor.Text == "" || txtPhoneNum.Text == "")
                {
                    //Restriction if empty
                    MessageBox.Show("Required field(s) missing \n Please check your input!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (roomCount >= 1 && origRoomName != cboRoomName.Text)
                {
                    MessageBox.Show("Room name already exists!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
                else
                {
                    //Update Room Name on Room maintenance
                    string strEdit = "UPDATE room SET RoomtypeID='" + lblRoomtypeid.Text + "',RoomName='" + cboRoomName.Text + "',Floor='" + cboFloor.Text + "',PhoneNo='" + txtPhoneNum.Text + "',Picture='" + picDP.ImageLocation + "'  WHERE RoomNo='" + RoomID + "'";
                    con.ModRec(strEdit);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Updated Room Name - Room No: " + RoomID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                    SetDefault();
                }
             
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.SelectRec("Select status from room where roomno='" + RoomID + "'", dt);
            string roomStatus = dt.Rows[0].ItemArray[0].ToString();

            if(roomStatus != "AVAILABLE")
            {
                MessageBox.Show("Room is still used. Please try again.","Alert",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDelete = "DELETE FROM room WHERE roomno=" + RoomID + "";
                    con.ModRec(strDelete);

                    // Log to audit trail
                    string strAddlogs = "INSERT INTO audit_trail(Userid,activity,datetime)" + Environment.NewLine + "values('" + con.getCurrentUser() + "','" + "Delete room name - Room ID: " + RoomID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    con.ModRec(strAddlogs);

                }
                SetDefault();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            GetRecords("SELECT * FROM room WHERE Roomname LIKE '%" + txtSearch.text + "%'");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picDP.ImageLocation = openFileDialog1.FileName.Replace('\\', '/');

            }
        }

        private void adminRoom_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void dgvRoom_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // from room
                txtRoomNo.Text = dgvRoom.SelectedRows[0].Cells[0].Value.ToString();
                RoomID = Convert.ToInt32(dgvRoom.SelectedRows[0].Cells[0].Value.ToString());
                cboRoomName.Text = dgvRoom.SelectedRows[0].Cells[2].Value.ToString();
                cboFloor.Text = dgvRoom.SelectedRows[0].Cells[3].Value.ToString();
                txtPhoneNum.Text = dgvRoom.SelectedRows[0].Cells[4].Value.ToString();
                picDP.ImageLocation = dgvRoom.SelectedRows[0].Cells[6].Value.ToString();
                // from room type
                string roomtypeid = dgvRoom.SelectedRows[0].Cells[1].Value.ToString();
                DataTable dt = new DataTable();
                string strName = "Select Name,Rate_1,Rate_2,Rate_3,ExtensionRate from roomtype where roomtypeid='" + roomtypeid + "'";
                con.SelectRec(strName, dt);
                cboRoomType.Text = dt.Rows[0].ItemArray[0].ToString();
                txtRate1.Text = Convert.ToDouble(dt.Rows[0].ItemArray[1]).ToString("0.00");
                txtRate2.Text = Convert.ToDouble(dt.Rows[0].ItemArray[2]).ToString("0.00");
                txtRate3.Text = Convert.ToDouble(dt.Rows[0].ItemArray[3]).ToString("0.00");
                txtExtensionRate.Text = Convert.ToDouble(dt.Rows[0].ItemArray[4]).ToString("0.00"); ;

                txtRoomNo.Enabled = false;
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

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //GET ROOM TYPE ID AND PUT IT IN A HIDE LABEL
                DataTable dt = new DataTable();
                string strUsertypeID = "Select roomtypeid,Rate_1,Rate_2,Rate_3,ExtensionRate from roomtype where name='" + cboRoomType.Text + "'";
                con.SelectRec(strUsertypeID, dt);
                lblRoomtypeid.Text = dt.Rows[0].ItemArray[0].ToString();
                txtRate1.Text = Convert.ToDouble(dt.Rows[0].ItemArray[1]).ToString("0.00");
                txtRate2.Text = Convert.ToDouble(dt.Rows[0].ItemArray[2]).ToString("0.00");
                txtRate3.Text = Convert.ToDouble(dt.Rows[0].ItemArray[3]).ToString("0.00");
                txtExtensionRate.Text = Convert.ToDouble(dt.Rows[0].ItemArray[4]).ToString("0.00");
            }
            catch
            {
            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Accept numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if((e.KeyChar=='.' && ((sender as TextBox).Text.IndexOf('.')> -1)))
            {
                e.Handled=true;
            }
        }

        private void txtRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if((e.KeyChar=='.' && ((sender as TextBox).Text.IndexOf('.')> -1)))
            {
                e.Handled=true;
            }
        }

        private void txtRate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //only allow one decimal point
            if((e.KeyChar=='.' && ((sender as TextBox).Text.IndexOf('.')> -1)))
            {
                e.Handled=true;
            }
        }

        private void txtExtensionRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPhoneNum_TextChanged(object sender, EventArgs e)
        {

        }


        // ID - auto increment lang
        // pero generated sa program.
        // para tama ung numbering

        // Floors - static values: 1st- 4th floor

        // Restrictions
        // All fields required
        // Room No. - not editable
        // Room Type - editable
        // Room name - no duplicate
        // Rates - double with 2 decimals
        // Floor - editable
        // phone number - numbers only

    }
}
