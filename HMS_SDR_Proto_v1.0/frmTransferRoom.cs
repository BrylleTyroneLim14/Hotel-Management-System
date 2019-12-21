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
    public partial class frmTransferRoom : Form
    {
        classconnection con = new classconnection();
        string transNo;
        string roomTypeID;
        string roomNo;

        string selectedRoomNo;

        public frmTransferRoom(string selectedtransNo, string selectedRoomType, string selectedRoomNo)
        {
            InitializeComponent();
            transNo = selectedtransNo;
            roomTypeID = selectedRoomType;
            roomNo = selectedRoomNo;
        }

        private void GetRoomAvailable() 
        {
            DataTable dt = new DataTable();
            string sqlGetRooms = "SELECT a.RoomNo,a.RoomName,a.Status,b.Name FROM room a, roomtype b WHERE a.roomtypeid=b.roomtypeid AND a.status='AVAILABLE' AND a.roomtypeid='" + roomTypeID + "'";
            con.SelectRec(sqlGetRooms, dt);

            int ctrRec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvRooms.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString());
                ctrRec++;
            }
            dt.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTransferRoom_Load(object sender, EventArgs e)
        {
            GetRoomAvailable();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm room transfer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Generate Remarks
                DataTable dt = new DataTable();
                string sqlGetRemarks = "SELECT Remarks FROM roomsales WHERE TransactionNo='" + transNo + "'";
                con.SelectRec(sqlGetRemarks, dt);
                string remarks = dt.Rows[0].ItemArray[0].ToString();
                string newRemarks = remarks.Length < 1 ? "Transfered from Room No. : " + roomNo : remarks + System.Environment.NewLine + "Transfered from Room No.: " + roomNo;
                // Update Room Sales
                string sqlTransferRoom = "UPDATE roomsales SET RoomNo='" + selectedRoomNo + "',Remarks='" + newRemarks + "' WHERE TransactionNo='"+ transNo +"'";
                con.ModRec(sqlTransferRoom);
                // Update Old Room Status
                string sqlUpdateOldRoom = "UPDATE room SET status='AVAILABLE' WHERE RoomNo='" + roomNo + "'";
                con.ModRec(sqlUpdateOldRoom);
                // Update New Room Status
                string sqlUpdateNewRoom = "UPDATE room SET status='OCCUPIED' WHERE RoomNo='" + selectedRoomNo + "'";
                con.ModRec(sqlUpdateNewRoom);
                this.Close();             
            }
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            // Get Room Information
            string RoomNo = dgvRooms.SelectedRows[0].Cells[0].Value.ToString();
            DataTable dt = new DataTable();
            string sql = "SELECT a.RoomNo,a.RoomName,a.Floor,a.PhoneNo,b.Name,b.MaxCap FROM room a, roomtype b WHERE a.RoomTypeID=b.RoomTypeId AND a.RoomNo='" + RoomNo + "'";
            con.SelectRec(sql, dt);

            lblRoomNo.Text = "Room No. " + dt.Rows[0].ItemArray[0].ToString();
            lblRoomName.Text = dt.Rows[0].ItemArray[1].ToString();
            lblFloor.Text = "Floor: " + dt.Rows[0].ItemArray[2].ToString();
            lblPhone.Text = "Phone: " + dt.Rows[0].ItemArray[3].ToString();
            lblRoomType.Text = "Room Type: " + dt.Rows[0].ItemArray[4].ToString();
            lblMaxCap.Text = "Maximum Capacity: " + dt.Rows[0].ItemArray[5].ToString() + " pax";
            selectedRoomNo = dt.Rows[0].ItemArray[0].ToString();
            
        }
    }
}
