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
    public partial class adminActLog : UserControl
    {
        // Database connection
        classconnection con = new classconnection();

        public adminActLog()
        {
            InitializeComponent();
        }

        /*****************************
         *          ROUTINES
         *****************************/
        private void SetDefault()
        {
            cboUserType.Text = "";
            cboUserType.Enabled = true;
            dgvActLog.Rows.Clear();
            lblRecCount.Visible = false;
            GetUserType("SELECT description FROM usertype");
            
            dtpFrom.Enabled = true;
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "MM-dd-yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "MM-dd-yyyy";

            cboUserType.Text = "All";
            
            string dteFrom = dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string dteTo = dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            SetLogs("SELECT a.userid,CONCAT(b.firstname,' ',b.lastname),a.activity,a.datetime FROM audit_trail AS a,user as b  WHERE datetime>='"+dteFrom+"' AND datetime<='"+dteTo+"' AND a.userid=b.userid ORDER BY datetime ASC");
        }
        
        private void GetUserType(string strSQL)
        {
            DataTable dt = new DataTable();
            string strname = strSQL;
            con.SelectRec(strname, dt);
            cboUserType.Items.Clear();

            cboUserType.Items.Add("All");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboUserType.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            dt.Dispose();
        }

        private void SetLogs(string strSQL)
        {
            DataTable dt = new DataTable();
            string strborrowrec = strSQL;
            con.SelectRec(strborrowrec, dt);
            dgvActLog.Rows.Clear();

            int ctrRec = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.dgvActLog.Rows.Add(dt.Rows[i].ItemArray[0].ToString(), dt.Rows[i].ItemArray[1].ToString(), dt.Rows[i].ItemArray[2].ToString(), dt.Rows[i].ItemArray[3].ToString());
                ctrRec++;
            }

            lblRecCount.Visible = true;
            if (ctrRec != 0)
                lblRecCount.Text = "Total of " + ctrRec.ToString() + " record(s) in the list";
            else
                lblRecCount.Text = "No Records!";
            dt.Dispose();
        }

        public void FilterLogs()
        {
            // Get dates
            string dteFrom = dtpFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string dteTo = dtpTo.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            // Get Search Keyword
            string keyword = txtSearch.text;


            // Get User Type
            if (cboUserType.Text == "All")
            {
                SetLogs("SELECT a.userid,CONCAT(b.firstname,' ',b.lastname),a.activity,a.datetime FROM audit_trail AS a,user as b  WHERE (datetime>='" + dteFrom + "' AND datetime<='" + dteTo + "' AND a.userid=b.userid) AND (a.userid LIKE '%"+ keyword +"%' OR concat_ws(' ',b.firstname,b.lastname) LIKE '%" + keyword + "%') ORDER BY datetime ASC");        
            }
            else
            {
                DataTable dt = new DataTable();
                string strUsertypeID = "SELECT usertypeid FROM usertype WHERE description='" + cboUserType.Text + "'";
                con.SelectRec(strUsertypeID, dt);
                string userTypeID = dt.Rows[0].ItemArray[0].ToString();

                SetLogs("SELECT a.userid,CONCAT(b.firstname,' ',b.lastname),a.activity,a.datetime FROM audit_trail AS a,user as b  WHERE (datetime>='" + dteFrom + "' AND datetime<='" + dteTo + "' AND b.usertypeid='" + userTypeID + "' AND a.userid=b.userid) AND (a.userid LIKE '%" + keyword + "%' OR concat_ws(' ',b.firstname,b.lastname) LIKE '%" + keyword + "%') ORDER BY datetime ASC");
            }
        }
        
        /*****************************
         *           EVENTS
         *****************************/

        private void adminActLog_Load(object sender, EventArgs e)
        {
            SetDefault();
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLogs();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            FilterLogs();
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            FilterLogs();
        }
    }
}
